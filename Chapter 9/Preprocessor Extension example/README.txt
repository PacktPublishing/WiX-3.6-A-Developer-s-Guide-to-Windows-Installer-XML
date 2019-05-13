This example shows how to create a preprocessor extension.

To run this example:

1. Build the project in Visual Studio
2. Reference the built .dll file in one of your WiX projects
3. Use the preprocessor variable $(company.myvar)":

	<Property Id="myVar" Value="$(company.myvar)" />
	
	or the sayHelloWorld function:
	
	<Property Id="checkVar" Value="$(company.sayHelloWorld())" />