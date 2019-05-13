
@ECHO OFF
ECHO ---------WiX Heat Example 1--------------
ECHO Running Heat on Testing_Heat folder. This uses all defaults for Heat flags.
SET CURRENTDIR=%~dp0
ECHO.

"%WIX%bin\heat.exe" dir "%CURRENTDIR%Testing_Heat" -out "HeatFile1.wxs"

ECHO.
ECHO Finished. Output has been saved as 'HeatFile1.wxs'.