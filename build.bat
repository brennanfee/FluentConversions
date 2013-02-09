@echo off
set TARGETS=%1
:param_loop
shift
if [%1]==[] goto after_loop
set TARGETS=%TARGETS%;%1
goto param_loop
:after_loop
IF "%TARGETS%"=="" SET TARGETS=Build

SET ERR=0

DEL build.log
%windir%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe FluentAssertions.msbuild "/t:%TARGETS%" /fileLogger /fileloggerparameters:LogFile=build.log;Verbosity=normal;Encoding=UTF-8
if NOT "%ERRORLEVEL%"=="0" set ERR=%ERRORLEVEL%
COPY build.log Builds
EXIT /B %ERR%
