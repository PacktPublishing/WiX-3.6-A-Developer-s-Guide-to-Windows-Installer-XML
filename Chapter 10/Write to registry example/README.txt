This example demonstrates writing a value to the Registry.

To run this example:

1. Build the project in Visual Studio
2. Double click the resulting MSI file to install
3. Use regedit to check that a value called "myValue" was written to the key: 
	
	HKEY_LOCAL_MACHINE\Software\WixTest\Test
	
4. Uninstall to remove key