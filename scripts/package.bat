@echo off

set version=1.0.0

set scriptDir=%~dp0
set rootDir=%scriptDir%..
set targetDll=%rootDir%\bin\Release\net48\LessBright.dll
set destDir=%rootDir%\package
set zipDest=%rootDir%\package\LessBright-%version%.zip

if exist %destDir%\LessBright.dll del %destDir%\LessBright.dll

echo Deploying: %targetDll%
echo Destination: %destDir%
copy %targetDll% %destDir%

if exist %zipDest% del %zipDest%

echo Zipping: %zipDest%
powershell Compress-Archive -Path %destDir%\* -DestinationPath %zipDest%

echo Packaging complete
