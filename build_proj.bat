@echo off
dotnet restore
set solution=%cd%\DndUtils.sln
set charGenProj=%cd%\CharacterGenerator\CharacterGenerator.csproj
set utilsProj=%cd%\DndUtils\DndUtils.csproj
set setupProj=%cd%\SetupProject\SetupProject.wixproj
set pathMSBuild="C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin"
cd /D %pathMSBuild%
msbuild.exe %solution% -t:build /p:configuration=release
msbuild.exe %setupProj% -t:build /p:configuration=release
pause