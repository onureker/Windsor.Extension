@ECHO OFF

CLS
ECHO Setting Bsi Source [Started]
SET /p USER_NAME="UserName: "
SET /p PASSWORD="Password: "

D:\programs\NuGet\NuGet.exe sources Add -Name bsi-nuget-prod -Source https://repo.finansbank.com.tr/artifactory/api/nuget/bsi-nuget-prod -username %USER_NAME% -password %PASSWORD%
ECHO Setting Bsi Source [Finished]
PAUSE