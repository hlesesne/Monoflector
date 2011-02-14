using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cecil.Decompiler.Languages;
using Mono.Cecil;

namespace Monoflector
{
    partial class ExtensionMethods
    {
        /// <summary>
        /// Writes the specified definition to a language writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public static void WriteDefinition(this ILanguageWriter writer, object definition)
        {
            if (definition == null)
                throw new ArgumentNullException("definition");

            try
            {
                if (definition is MethodDefinition)
                    writer.Write((MethodDefinition)definition);
                else if (definition is AssemblyDefinition)
                    writer.Write((AssemblyDefinition)definition);
                else if (definition is EventDefinition)
                    writer.Write((EventDefinition)definition);
                else
                    throw new NotSupportedException();
            }
            catch (NotSupportedException ex)
            {
                // Just add some more info.
                throw new NotSupportedException(Properties.Resources.ILanguageWriter_Extensions_TypeNotSupported.FormatWith(definition.GetType()), ex);
            }
        }
    }
}
