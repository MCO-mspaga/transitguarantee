REM #!/bin/ksh
REM echo '... BTE Import XML Files to Tlogs   Started: \c';date +%T
REM $MAGIC_HOME/scripts/callbarsh ep  83 -[ep124Opt]Option=$1
REM exit 0

REM ####call s:\dotnetlive\rundotnet.bat ep 83 ep124Opt %1

call e:\scripts\rundotnet.bat ep 83 ep124Opt %1


if %ERRORLEVEL% NEQ 0 goto error
opsexit 0
goto end

:error
REM - THIS PROGRAM FAILS CONSTANTLY SO MANUALLY SETTING OPSEXIT 0 AS PER DONALD
REM opsexit 1
opsexit 0

:end
Exit
