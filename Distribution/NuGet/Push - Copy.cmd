@ECHO OFF
CLS
ECHO Packing Files [Started]
FOR /R ../../%~dp1 %%F IN (*.nuspec) DO (
	CD %%~dpF
	D:\programs\NuGet\NuGet.exe  pack %%F -NonInteractive -IncludeReferencedProjects -Symbols -OutputDirectory %~dp0NuPkg 
	ECHO ---------------------------------------------------------------------------------
)
ECHO Packing Files [Finished]
PAUSE

