CLS
ECHO Packing Files [Started]
FOR /R ../../%~dp1 %%F IN (*.nuspec) DO (
	CD %%~dpF
	D:\programs\NuGet\NuGet.exe  pack %%F -NonInteractive -IncludeReferencedProjects -Symbols -OutputDirectory %~dp0NuPkg 
	ECHO ---------------------------------------------------------------------------------
)
ECHO Packing Files [Finished]
PAUSE

CLS
ECHO Pushing Files [Started]
FOR /R %~dp0NuPkg %%F IN (*.symbols.nupkg) DO (
	D:\programs\NuGet\NuGet.exe push %%F -NonInteractive -Source bsi-nuget-prod
	del %%F
	ECHO ---------------------------------------------------------------------------------
)
ECHO Pushing Files [Finished]
PAUSE