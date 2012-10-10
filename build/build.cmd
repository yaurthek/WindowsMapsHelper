del build.log
mkdir ..\out

devenv.exe ..\src\WinMapsHelper.sln /build Release /out build.log
..\tools\nuget\NuGet.exe pack WindowsMapsHelper.nuspec -o ..\out