
@ECHO OFF
ECHO ---------WiX Heat Example 2--------------
ECHO Running Heat on Testing_Heat folder. Uses more flags to get better output.
SET CURRENTDIR=%~dp0
ECHO.

"%WIX%bin\heat.exe" dir "%CURRENTDIR%Testing_Heat" -dr MyProgramDir -cg NewFilesGroup -gg -g1 -sf -srd -var "var.MyDir" -out "HeatFile2.wxs"

ECHO.
ECHO Finished. Output has been saved as 'HeatFile2.wxs'.