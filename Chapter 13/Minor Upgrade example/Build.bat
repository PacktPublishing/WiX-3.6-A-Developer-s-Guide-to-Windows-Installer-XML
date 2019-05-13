
@ECHO OFF

ECHO --------Building OldInstaller--------
"%WIX%bin\candle.exe" -arch x86 OldInstaller\Product.wxs -out OldInstaller\Product.wixobj

ECHO.
ECHO --------Linking OldInstaller--------
"%WIX%bin\light.exe" OldInstaller\Product.wixobj -out Output\OldInstaller\Product.msi

ECHO.
ECHO --------Building MinorUpgradeInstaller--------
"%WIX%bin\candle.exe" -arch x86 MinorUpgradeInstaller\Product.wxs -out MinorUpgradeInstaller\Product.wixobj

ECHO.
ECHO --------Linking MinorUpgradeInstaller--------
"%WIX%bin\light.exe" MinorUpgradeInstaller\Product.wixobj -out Output\MinorUpgradeInstaller\Product.msi

ECHO.
ECHO --------Building Patch--------
"%WIX%bin\candle.exe" Patch\Patch.wxs -out Patch\Patch.wixobj

ECHO.
ECHO --------Linking Patch--------
"%WIX%bin\light.exe" Patch\Patch.wixobj -out Output\Patch\Patch.wixmsp

ECHO.
ECHO --------Creating transform from OldInstaller and MinorUpgradeInstaller--------
"%WIX%bin\torch.exe" -p -xi Output\OldInstaller\Product.wixpdb Output\MinorUpgradeInstaller\Product.wixpdb -out Output\Patch\Patch.wixmst

ECHO.
ECHO --------Creating Patch file--------
"%WIX%\bin\pyro.exe" Output\Patch\Patch.wixmsp -t MyPatch Output\Patch\Patch.wixmst -out Output\Patch.msp

ECHO.
ECHO --------Copying OldInstaller to main Output as OriginalProduct.msi--------
COPY Output\OldInstaller\Product.msi Output\OriginalProduct.msi

ECHO.
ECHO --------Finished!--------
ECHO.