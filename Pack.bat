@echo off
echo BUILD Cadmus General Packages
del .\Cadmus.General.Parts\bin\Debug\*.nupkg
del .\Cadmus.General.Parts\bin\Debug\*.snupkg
del .\Cadmus.Seed.General.Parts\bin\Debug\*.nupkg
del .\Cadmus.Seed.General.Parts\bin\Debug\*.snupkg

cd .\Cadmus.General.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

cd .\Cadmus.Seed.General.Parts
dotnet pack -c Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
cd..

pause
