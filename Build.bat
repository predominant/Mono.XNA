@REM Builds Mono.Xna using NAnt

@ECHO OFF

@REM Create NAnt Project Files
tools\Prebuild\Prebuild.exe /target nant /file Prebuild.xml /FRAMEWORK NET_2_0

@REM Build using NAnt
NAnt -t:net-2.0 -buildfile:Mono.Xna.build clean
NAnt -t:net-2.0 -buildfile:Mono.Xna.build build-release

xcopy .\examples\SimpleExample\bin\Release\*.exe .\dist\*.* /Q /Y
xcopy .\examples\Pong\bin\Release\*.exe .\dist\*.* /Q /Y
xcopy .\src\Microsoft.Xna.Framework.Game\bin\Release\*.dll .\dist\*.* /Q /Y
xcopy .\lib\win32deps\*.dll .\dist\*.* /Q /Y

@REM Clean NAnt Project Files
tools\Prebuild\Prebuild.exe /file Prebuild.xml /clean nant /removedir obj /yes /FRAMEWORK NET_2_0
pause
