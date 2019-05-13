
namespace AwesomeExtension
{
    using Microsoft.Tools.WindowsInstallerXml;
    using System.Reflection;

    public class AwesomeExtension : WixExtension
    {
        private CompilerExtension compilerExtension;

        public override CompilerExtension CompilerExtension
        {
            get
            {
                if (this.compilerExtension == null)
                {
                    this.compilerExtension =
                       new AwesomeCompiler();
                }

                return this.compilerExtension;
            }
        }

        private TableDefinitionCollection tableDefinitions;

        public override TableDefinitionCollection TableDefinitions
        {
            get
            {
                if (this.tableDefinitions == null)
                {
                    this.tableDefinitions =
                       LoadTableDefinitionHelper(
                          Assembly.GetExecutingAssembly(),
                          "AwesomeExtension.TableDefinitions.xml");
                }

                return this.tableDefinitions;
            }
        }

        private Library library;

        public override Library GetLibrary(TableDefinitionCollection tableDefinitions)
        {
            if (this.library == null)
            {
                this.library = 
                    LoadLibraryHelper(
                        Assembly.GetExecutingAssembly(), 
                        "AwesomeExtension.AwesomeLibrary.wixlib", 
                        tableDefinitions);
            }

            return this.library;
        }
    }
}
