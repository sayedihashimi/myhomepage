<#
 1. publish Server project to folder specified below
 2. cd into publish folder
 3. run web app with url below
#>

$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$serverProjectFile = (Get-Item (join-path $scriptDir .\src\Server\LocalHome.Server.csproj)).FullName
$outputPath = Join-Path -Path $scriptDir '_output' 
$url='https://localhost:45655'

# need to create the folder to easily get the full path
if(-not (test-path -LiteralPath $outputPath)){
    New-Item -Path $outputPath -ItemType Directory
}

$outputpathtouse = (Get-Item $outputPath).FullName + '\'
'outputpathtouse: "{0}"' -f $outputpathtouse | Write-Output
# &dotnet publish $serverProjectFile -p:BaseOutputPath=$outputpathtouse

&dotnet build $serverProjectFile -p:DeployOnBuild=true -p:PublishProfile=FolderProfile -p:PublishUrl="$outputpathtouse"

$pathToExe = Join-Path $outputPath 'LocalHome.Server.exe'
if(-not (test-path $pathToExe)){
    'File not found at "{0}"' -f $pathToExe | Write-Error
}

# change into directory containing the exe
Push-Location -Path (Split-Path $pathToExe -Parent)
# launch browser before it starts because the process never ends
'pathToExe: "{0}"' -f $pathToExe | Write-output
start $url
&$pathToExe --urls=$url
Pop-Location
