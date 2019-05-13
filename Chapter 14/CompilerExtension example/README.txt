This example demonstrates building a custom CompilerExtension. 

To run this example:

1. Compile the solution in Visual Studio
2. Add the extension assembly as a reference in a WiX project
3. Use the SuperElement in the WiX markup:

    <Wix ... 
         xmlns:awesome="http://www.mydomain.com/AwesomeSchema">

       ...
       <awesome:SuperElement Id="mySuperElement" Type="Super" />

4. Compile the WiX project and run the installer to see the messagebox displaying
   the SuperElement values