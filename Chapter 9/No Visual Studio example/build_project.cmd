REM Example of building a WiX project without using Visual Studio
@ECHO OFF

ECHO.
ECHO Using Candle to compile WiX source file...
ECHO.

candle.exe -v -arch x86 -ext "WixUIExtension.dll" -out "PracticeWix.wixobj" PracticeWix.wxs

ECHO.
ECHO Using Light to link and bind WIXOBJ file...
ECHO.

light.exe -v -ext "WixUIExtension.dll" -out "PracticeWix.msi" PracticeWix.wixobj

ECHO.
ECHO Finished!
ECHO.