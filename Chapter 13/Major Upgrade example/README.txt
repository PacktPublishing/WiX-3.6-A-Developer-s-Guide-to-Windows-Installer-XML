This example demonstrates a major upgrade of existing software.

To run this example:

1. Compile the solution in Visual Studio
2. Install the OriginalInstaller.msi and note that it creates a text file
   under Program Files (x86)\Awesome Software. The text in the text file 
   mentions that it comes from the original installer.
3. Install the UpgradeInstaller.msi and then check that the text file
   has been overwritten with new text.