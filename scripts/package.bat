@echo off

set version=2.0.0
set projectDir=%~dp0..
set packageDir=%projectDir%\package

del %packageDir%\LessBright.dll
del %packageDir%\LessBright-*.zip

copy %projectDir%\bin\net48\LessBright.dll %packageDir%

powershell Compress-Archive -Path %packageDir%\* -DestinationPath %packageDir%\LessBright-%version%.zip
