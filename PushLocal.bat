@echo off
echo PRESS ANY KEY TO INSTALL TO LOCAL NUGET FEED
echo Remember to generate the up-to-date package.
pause
c:\exe\nuget add .\Cadmus.General.Parts\bin\Debug\Cadmus.General.Parts.3.0.0.nupkg -source C:\Projects\_NuGet
c:\exe\nuget add .\Cadmus.Seed.General.Parts\bin\Debug\Cadmus.Seed.General.Parts.3.0.0.nupkg -source C:\Projects\_NuGet
pause