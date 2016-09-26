for /d %%a in (*) do (
cd %%a
zip -r -p "../../Zips/%%~na.zip" "*"
cd ..
)