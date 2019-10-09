@ECHO OFF

CLS
ECHO Setting Api Key [Started]
SET /p USER_NAME="UserName: "
SET /p PASSWORD="Password: "

D:\programs\NuGet\NuGet.exe setapikey %USER_NAME%:%PASSWORD% -Source bsi-nuget-prod
ECHO Setting Api Key [Finished]
PAUSE