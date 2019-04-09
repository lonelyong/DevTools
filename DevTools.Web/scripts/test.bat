
::start mstsc /ADMIN /v:wetest.fun
@echo off
echo cd=%cd%
echo %%~dp0=%~dp0;%~p0
echo %0; %1; %2; %*
echo %~1; %~2
if "%~1" equ "-a" echo %~1
cd /d c:\users\jiu-z\desktop
attrib ..txt