<#
 1. publish Server project to folder specified below
 2. cd into publish folder
 3. run web app with url below
#>

$scriptDir = split-path -parent $MyInvocation.MyCommand.Definition
$serverProjectFile = (Get-Item (join-path $scriptDir .\src\Server\LocalHome.Server.csproj)).FullName
$outputPath = Join-Path -Path $scriptDir '.output' 
$url='https://localhost:9005'

# need to create the folder to easily get the full path
if(-not (test-path -LiteralPath $outputPath)){
    New-Item -Path $outputPath -ItemType Directory
}

$outputpathtouse = (Get-Item $outputPath).FullName + '\'
'outputpathtouse: "{0}"' -f $outputpathtouse | Write-Output
&dotnet publish $serverProjectFile -p:BaseOutputPath=$outputpathtouse

$pathToExe = Join-Path $outputPath 'Debug\netcoreapp3.1\publish\LocalHome.Server.exe'
if(-not (test-path $pathToExe)){
    'File not found at "{0}"' -f $pathToExe | Write-Error
}

# change into directory containing the exe
Push-Location -Path (Split-Path $pathToExe -Parent)
# launch browser before it starts because the process never ends
start $url
&$pathToExe --urls=$url
Pop-Location
