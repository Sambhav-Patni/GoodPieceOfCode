for /R "C:\SAM\temp" %%I in ("*.zip") do (
  "%ProgramFiles%\7-Zip\7z.exe" x -y -o"%%~dpI" "%%~fI" 
)