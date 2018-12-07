@echo off

if %processor_architecture%==AMD64 (
	"%PROGRAMFILES(X86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" Scolatica.sln /m /t:Build /p:Configuration=Release
) else (
	"%ProgramFiles%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" Scolatica.sln /m /t:Build /p:Configuration=Release
)

PAUSE
