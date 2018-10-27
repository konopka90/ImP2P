@echo off
setlocal enableextensions
if not exist "ImP2P/bin/Debug/certs" mkdir "ImP2P/bin/Debug/certs"
xcopy /s "certs" "ImP2P/bin/Debug/certs"
endlocal