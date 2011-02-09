using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Mono.Cecil;
using System.Globalization;

namespace Monoflector.Languages
{
    /// <summary>
    /// Represents an HTML formatter hook.
    /// </summary>
    public class HtmlFormatterHook : IFormatterHook
    {
        public string Name
        {
            get { return "text/html"; }
        }

        private StringWriter _gutterStringWriter;
        private StringWriter _codeStringWriter;
        private XmlWriter _gutter;
        private XmlWriter _code;

        private int _indent;
        private bool _writeIndent;
        private bool _alt;
        private int _index;
        private bool _ensureStartLine;

        private string _finalString;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlFormatterHook"/> class.
        /// </summary>
        public HtmlFormatterHook()
        {
            var settings = new XmlWriterSettings();
            settings.CheckCharacters = false;
            settings.CloseOutput = false;
            settings.OmitXmlDeclaration = true;
            
            _gutterStringWriter = new StringWriter();
            _codeStringWriter = new StringWriter();
            _gutter = XmlWriter.Create(_gutterStringWriter, settings);
            _code = XmlWriter.Create(_codeStringWriter, settings);

            _gutter.WriteStartElement("td");
            _gutter.WriteAttributeString("class", "gutter");

            _code.WriteStartElement("td");
            _code.WriteAttributeString("class", "code");
            _code.WriteStartElement("div");
            _code.WriteAttributeString("class", "container");

            _ensureStartLine = true;
        }

        private void WriteStartLine()
        {
            if (!_ensureStartLine)
                return;
            _ensureStartLine = false;

            var index = _index++;
            var line = _index;
            var alt = _alt = !_alt;

            var attrValue = string.Format("line number{0} index{1} alt{2}",
                line.ToString(CultureInfo.InvariantCulture), index.ToString(CultureInfo.InvariantCulture), alt ? "2" : "1");

            _gutter.WriteStartElement("div");
            _gutter.WriteAttributeString("class", attrValue);
            _gutter.WriteString(line.ToString());

            _code.WriteStartElement("div");
            _code.WriteAttributeString("class", attrValue);
        }

        private void WriteEndLine()
        {
            if (_ensureStartLine)
                return;
            _gutter.WriteEndElement();
            _code.WriteEndElement();
            _ensureStartLine = true;
        }

        private void WriteEscaped(string str)
        {
            // This is terribad, but what can you do?
            foreach (char c in str)
            {
                if (c == ' ')
                    _code.WriteEntityRef("nbsp");
                else if (c == '\t')
                {
                    _code.WriteEntityRef("nbsp");
                    _code.WriteEntityRef("nbsp");
                }
                else
                    _code.WriteString(c.ToString());
            }
        }
        
        /// <summary>
        /// Writes the indent.
        /// </summary>
        void WriteIndent()
        {
            if (!_writeIndent)
                return;

            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", "csharp spaces");
            for (int i = 0; i < _indent; i++)
            {
                _code.WriteEntityRef("nbsp");
                _code.WriteEntityRef("nbsp");
            }
            _code.WriteEndElement();
        }

        public void CompleteDecompile(object item, DecompilationTarget target, FormatterChain containingChain)
        {
            _gutter.WriteEndDocument();
            _code.WriteEndDocument();
            _gutter.Close();
            _code.Close();

            _gutterStringWriter.Write(_codeStringWriter.ToString());
            _finalString = _gutterStringWriter.ToString();
            _codeStringWriter.Dispose();
        }

        public void Write(string str)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", "csharp plain");
            WriteIndent();
            WriteEscaped(str);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteComment(string comment)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", "csharp comment");
            WriteIndent();
            WriteEscaped(comment);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteDefinition(string value, object definition)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", string.Format("csharp {0}", GetToken(definition, "definition")));
            WriteIndent();
            WriteEscaped(value);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteIdentifier(string value, object identifier)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", "csharp identifier");
            WriteIndent();
            WriteEscaped(value);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteKeyword(string keyword)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", "csharp keyword");
            WriteIndent();
            WriteEscaped(keyword);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteLine()
        {
            if (_writeIndent)
                return;
            WriteEndLine();
            _ensureStartLine = true;
            _writeIndent = true;
        }

        public void WriteLiteral(string literal)
        {
            WriteStartLine();
            var cls = "literal";
            if (literal.StartsWith("\""))
            {
                cls = "string";
            }
            else if (literal.StartsWith("'"))
            {
                cls = "char";
            }

            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", string.Format("csharp {0}", cls));
            WriteIndent();
            WriteEscaped(literal);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteReference(string value, object reference)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", string.Format("csharp{0}", GetToken(reference, "ref")));
            WriteIndent();
            WriteEscaped(value);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void WriteSpace()
        {
            WriteStartLine();
            Write(" ");
        }

        public void WriteToken(string token)
        {
            WriteStartLine();
            _code.WriteStartElement("code");
            _code.WriteAttributeString("class", string.Format("csharp token"));
            WriteIndent();
            WriteEscaped(token);
            _writeIndent = false;
            _code.WriteEndElement();
        }

        public void Indent()
        {
            _indent++;
        }

        public void Outdent()
        {
            _indent--;
        }

        private static string GetToken(object value, string @default)
        {
            var mdtp = value as IMetadataTokenProvider;
            if (mdtp == null)
                return @default;
            else
                return string.Format(" {0} dataToken{1}", mdtp.MetadataToken.TokenType, mdtp.MetadataToken.RID.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _finalString;
        }
    }
}
