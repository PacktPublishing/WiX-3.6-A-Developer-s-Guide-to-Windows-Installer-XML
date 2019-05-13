
@ECHO OFF
ECHO -------------------------------------------------------------------------------
ECHO This script creates a single MSI package with transforms for Spanish and German
ECHO.
ECHO -------------------------------------------------------------------------------
ECHO.

ECHO.
ECHO Compiling files with Candle...
ECHO.

"%WIX%bin\candle.exe" -nologo Product.wxs -arch x86 -out Output\Product.wixobj -ext "%WIX%bin\WixUIExtension.dll" 

ECHO Done.
ECHO.
ECHO Linking files with Light...
ECHO.

"%WIX%bin\light.exe" Output\Product.wixobj -nologo -loc en-us.wxl -cultures:en-us -ext "%WIX%bin\WixUIExtension.dll" -out Output\en-us\TestInstaller.msi
"%WIX%bin\light.exe" Output\Product.wixobj -nologo -loc es-es.wxl -cultures:es-es -ext "%WIX%bin\WixUIExtension.dll" -out Output\es-es\TestInstaller.msi
"%WIX%bin\light.exe" Output\Product.wixobj -nologo -loc de-de.wxl -cultures:de-de -ext "%WIX%bin\WixUIExtension.dll" -out Output\de-de\TestInstaller.msi

ECHO Done.
ECHO.
ECHO Creating transform files with Torch...
ECHO.

IF NOT EXIST "Output\transforms" MKDIR Output\transforms

"%WIX%bin\torch.exe" -t language "Output\en-us\TestInstaller.msi" "Output\es-es\TestInstaller.msi" -out "Output\transforms\es-es.mst"
"%WIX%bin\torch.exe" -t language "Output\en-us\TestInstaller.msi" "Output\de-de\TestInstaller.msi" -out "Output\transforms\de-de.mst"

ECHO Done.
ECHO.
ECHO Merging transforms into single MSI...
ECHO.

WiSubStg.vbs "Output\en-us\TestInstaller.msi" "Output\transforms\es-es.mst" 1034
WiSubStg.vbs "Output\en-us\TestInstaller.msi" "Output\transforms\de-de.mst" 1031

ECHO Done.
ECHO.
ECHO Updating MSI Package Languages attribute...
ECHO.

WiLangId.vbs "Output\en-us\TestInstaller.msi" Package 1033,1034,1031

ECHO Done.
ECHO Copying output to new location...
ECHO.

COPY "Output\en-us\TestInstaller.msi" "Output\MultiLanguage.msi"

ECHO Done.
