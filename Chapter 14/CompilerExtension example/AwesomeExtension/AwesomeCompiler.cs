
namespace AwesomeExtension
{
    using Microsoft.Tools.WindowsInstallerXml;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Schema;
    
    public class AwesomeCompiler : CompilerExtension
    {
        private XmlSchema schema;

        public AwesomeCompiler()
        {
            this.schema = LoadXmlSchemaHelper(Assembly.GetExecutingAssembly(), "AwesomeExtension.AwesomeSchema.xsd");
        }

        public override XmlSchema Schema
        {
            get 
            {
                return this.schema; 
            }
        }

        public override void ParseElement(
           SourceLineNumberCollection sourceLineNumbers,
           XmlElement parentElement,
           XmlElement element,
           params string[] contextValues)
        {
            switch (parentElement.LocalName)
            {
                case "Product":
                case "Fragment":
                    switch (element.LocalName)
                    {
                        case "SuperElement":
                            this.ParseSuperElement(element);
                            break;
                        default:
                            this.Core.UnexpectedElement(
                               parentElement,
                               element);
                            break;
                    }
                    break;
                default:
                    this.Core.UnexpectedElement(
                       parentElement,
                       element);
                    break;
            }
        }

        private void ParseSuperElement(XmlNode node)
        {
            SourceLineNumberCollection sourceLineNumber =
               Preprocessor.GetSourceLineNumbers(node);

            string superElementId = null;
            string superElementType = null;

            foreach (XmlAttribute attribute in node.Attributes)
            {
                if (attribute.NamespaceURI.Length == 0 ||
                    attribute.NamespaceURI == this.schema.TargetNamespace)
                {
                    switch (attribute.LocalName)
                    {
                        case "Id":
                            superElementId =
                               this.Core.GetAttributeIdentifierValue(
                                  sourceLineNumber,
                                  attribute);
                            break;
                        case "Type":
                            superElementType =
                               this.Core.GetAttributeValue(
                                  sourceLineNumber,
                                  attribute);
                            break;
                        default:
                            this.Core.UnexpectedAttribute(
                               sourceLineNumber,
                               attribute);
                            break;
                    }
                }
                else
                {
                    this.Core.UnsupportedExtensionAttribute(
                       sourceLineNumber,
                       attribute);
                }
            }

            if (string.IsNullOrEmpty(superElementId))
            {
                this.Core.OnMessage(
                   WixErrors.ExpectedAttribute(
                      sourceLineNumber,
                      node.Name,
                      "Id"));
            }

            if (string.IsNullOrEmpty(superElementType))
            {
                this.Core.OnMessage(
                   WixErrors.ExpectedAttribute(
                      sourceLineNumber,
                      node.Name,
                      "Type"));
            }

            if (!this.Core.EncounteredError)
            {
                Row superElementRow =
                   this.Core.CreateRow(
                      sourceLineNumber,
                      "SuperElementTable");

                superElementRow[0] = superElementId;
                superElementRow[1] = superElementType;
            }

            this.Core.CreateWixSimpleReferenceRow(sourceLineNumber, "CustomAction", "ShowMessageImmediate");
        }


    }
}
