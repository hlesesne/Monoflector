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
    public class HtmlFormatterHook : Cecil.Decompiler.Languages.FormatterBase, IFormatterHook
    {
        public string Name
        {
            get { return "text/html"; }
        }

        private StringWriter _gutterStringWriter;
        private StringWriter _codeStringWriter;
        private XmlWriter _gutter;
        private XmlWriter _code;

        private bool _alt;
        private int _index;
        private bool _firstLine;

        private string _finalString;
        private bool _lineHasData;

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
            _gutter.WriteAttributeString("valign", "top");
            _gutter.WriteAttributeString("class", "hll");

            _code.WriteStartElement("td");
            _code.WriteAttributeString("width", "100%");
            _code.WriteAttributeString("valign", "top");

            _firstLine = true;
            WriteLine();
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

        public void CompleteDecompile(object item, DecompilationTarget target, FormatterChain containingChain)
        {
            if (_lineHasData)
                WriteLine();

            _code.WriteEndDocument();
            _gutter.WriteEndDocument();
            _code.Flush();
            _gutter.Flush();

            _gutterStringWriter.Write(_codeStringWriter.ToString());
            _finalString = _gutterStringWriter.ToString();
        }

        private void WriteWrapped(string elementName, string htmlClass, string value, IMetadataTokenProvider provider)
        {
            _code.WriteStartElement(elementName);
            if (!string.IsNullOrEmpty(elementName))
                _code.WriteAttributeString("class", htmlClass);
            if (provider != null && provider.MetadataToken.RID != 0)
                _code.WriteAttributeString("token", string.Format("{0}:{1}", provider.MetadataToken.TokenType, provider.MetadataToken.RID));
            WriteRaw(value);
            _code.WriteEndElement();
        }

        private void Code(string htmlClass, string value, IMetadataTokenProvider provider)
        {
            WriteWrapped("code", htmlClass, value, provider);
        }

        private void Code(string htmlClass, string value)
        {
            WriteWrapped("code", htmlClass, value, null);
        }

        #region Override
        protected override void OnWriteIndent(int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                _code.WriteStartElement("code");
                _code.WriteAttributeString("class", "tab");
                _code.WriteEndElement();
            }
        }

        protected override void OnWriteLine()
        {
            if (!_firstLine)
            {
                _code.WriteEndElement();
            }
            _firstLine = false;

            if (!_lineHasData)
                _code.WriteEntityRef("nbsp");
            _lineHasData = false;

            var index = _index++;
            var line = _index;
            var alt = _alt = !_alt;

            // This might still be useful.
            var attrValue = string.Format("alt{2}",
                line.ToString(CultureInfo.InvariantCulture), index.ToString(CultureInfo.InvariantCulture), alt ? "2" : "1");
            var lineValue = string.Format("L{0}", line);

            _gutter.WriteStartElement("a");
            _gutter.WriteAttributeString("name", lineValue);
            _gutter.WriteAttributeString("class", attrValue);
            _gutter.WriteString(line.ToString());
            _gutter.WriteEndElement();

            _code.WriteStartElement("div");
            _code.WriteAttributeString("id", lineValue);
            _code.WriteAttributeString("class", attrValue);
        }

        protected override void OnWriteRaw(string value)
        {
            _lineHasData = true;
            // This is terribad, but what can you do?
            foreach (char c in value)
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

        protected override void OnWriteSpace()
        {
            _code.WriteEntityRef("nbsp");
        }

        protected override void OnWriteAliasTypeKeyword(string keyword, TypeReference type)
        {
            Code("kt", keyword, type);
        }

        protected override void OnWriteBlockEnd(string value)
        {
            Code("bc", value);
        }

        protected override void OnWriteBlockStart(string value)
        {
            Code("bo", value);
        }

        protected override void OnWriteComment(string comment)
        {
            Code("c1", comment);
        }

        protected override void OnWriteDocComment(string comment)
        {
            Code("cs", comment);
        }

        protected override void OnWriteGenericToken(string name)
        {
            Code("t", name);
        }

        protected override void OnWriteKeyword(string keyword)
        {
            Code("k", keyword);
        }

        protected override void OnWriteLabelReference(string name)
        {
            Code("nl", name);
        }

        protected override void OnWriteLiteralChar(string value)
        {
            Code("sc", value);
        }

        protected override void OnWriteLiteralNumber(string value)
        {
            Code("m", value);
        }

        protected override void OnWriteLiteralString(string value)
        {
            Code("s", value);
        }

        protected override void OnWriteMultilineComment(string comment)
        {
            Code("cm", comment);
        }

        protected override void OnWriteNameReference(string name, MemberReference member)
        {
            var className = "nb";
            if (member is TypeDefinition)
            {
                var td = (TypeDefinition)member;
                if (td.IsInterface)
                    className = "nd";
                else if (td.IsEnum)
                    className = "ni";
                else
                    className = "nc";
            }
            else if (member is PropertyDefinition)
            {
                className = "np";
            }
            else if (member is FieldDefinition)
            {
                var fd = (FieldDefinition)member;
                if (fd.IsStatic && fd.IsInitOnly)
                    className = "no";
                else
                    className = "np";
            }
            else if (member is EventDefinition)
                className = "nf";
            else if (member is MethodDefinition)
                className = "nf";

            Code(className, name, member);
        }

        protected override void OnWriteVariableReference(string name)
        {
            Code("nv", name);
        }

        protected override void OnWriteOperator(string name)
        {
            Code("o", name);
        }

        protected override void OnWriteOperatorWord(string name)
        {
            Code("ow", name);
        }

        protected override void OnWriteParameterName(string value)
        {
            Code("pn", value);
        }

        protected override void OnWriteParenthesisClose(string value)
        {
            Code("pc", value);
        }

        protected override void OnWriteParenthesisOpen(string value)
        {
            Code("po", value);
        }

        protected override void OnWritePrepocComment(string comment)
        {
            Code("cp", comment);
        }
        #endregion

    }
}
