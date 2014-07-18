@echo off

SET ERR=0

DEL clean.log
%windir%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe FluentAssertions.msbuild "/t:Clean" /fileLogger /fileloggerparameters:LogFile=clean.log;Verbosity=normal;Encoding=UTF-8
if NOT "%ERRORLEVEL%"=="0" set ERR=%ERRORLEVEL%
EXIT /B %ERR%
