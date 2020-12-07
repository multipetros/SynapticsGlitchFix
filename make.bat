::(c) Petros Kyladitis
@echo off
set prod=SynapticsGlitchFix
echo Make Distribution Script for %prod%
set /p v=version: 
if not exist dist\ md dist
cd dist
if not exist temp\ md temp
copy /y ..\bin\Release\*.* temp\
copy /y ..\readme.txt temp\
copy /y ..\license.txt temp\
cd temp
zip %prod%-%v%_bin.zip *.*
mv %prod%-%v%_bin.zip ..\
cd ..
rd /s /q temp
pause
