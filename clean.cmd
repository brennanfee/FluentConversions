@echo off
set EXTRA_TARGETS=%1
:param_loop
shift
if [%1]==[] goto after_loop
set EXTRA_TARGETS=%EXTRA_TARGETS%;%1
goto param_loop
:after_loop
IF NOT "%EXTRA_TARGETS%"=="" set EXTRA_TARGETS="%EXTRA_TARGETS%;"

SET ERR=0

SET SLN_FILE=""
FOR %%f IN (*.msbuild) DO (
    SET SLN_FILE=%%f
    goto after_sln_search
)

:after_sln_search

IF %SLN_FILE%=="" (
    ECHO ERROR: No solution could be found!!!
    EXIT /B 1
)

%windir%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe %SLN_FILE% /m /nr:false "/t:%EXTRA_TARGETS%Clean" /fileLogger /fileloggerparameters:LogFile=.build\clean.log;Verbosity=normal;Encoding=UTF-8
if NOT "%ERRORLEVEL%"=="0" set ERR=%ERRORLEVEL%
EXIT /B %ERR%
