@echo off
cls
echo Updating UpStream from External
echo -------------------------------
echo.
copy "Cecil\decompiler\Cecil.Decompiler\bin\Debug\Cecil.Decompiler.dll" "..\UpStream\Cecil.Decompiler.dll" /y
copy "Cecil\decompiler\Cecil.Decompiler\bin\Debug\Cecil.Decompiler.pdb" "..\UpStream\Cecil.Decompiler.pdb" /y
echo.
echo Done.
echo.
pause