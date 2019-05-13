using Microsoft.Tools.WindowsInstallerXml;

namespace MyPreprocessorExtension
{
     public class MyWixExtension : WixExtension
     {
          private MyPreprocessorExtension preprocessorExtension;

          public override PreprocessorExtension
                   PreprocessorExtension
          {
               get
               {
                    if (this.preprocessorExtension == null)
                    {
                         this.preprocessorExtension = new
                                        MyPreprocessorExtension();
                    }

                    return this.preprocessorExtension;
               }
          }
     }

     public class MyPreprocessorExtension :
          PreprocessorExtension
     {
          private static string[] prefixes = { "company" };

          public override string[] Prefixes
          {
               get
               {
                    return
                         prefixes;
               }
          }

          public override string GetVariableValue(string
                    prefix, string name)
          {
               string result = null;
               switch (prefix)
               {
                    case "company":
                         switch (name)
                         {
                              // define all the variables under 
                              // this prefix here...
                              case "myvar":
                                   result = "myvalue";
                                   break;
                         }
                         break;
               }

               return result;
          }

          public override string EvaluateFunction(string
               prefix, string function, string[] args)
          {
               string result = null;
               switch (prefix)
               {
                    case "company":
                         switch (function)
                         {
                              // add any functions that you can 
                              // call with your prefix...
                              case "sayHelloWorld":
                                   result = "Hello, World!";
                                   break;
                         }
                         break;
               }
               return result;
          }
     }
}
