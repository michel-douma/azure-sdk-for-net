#Requires -Version 7.0
param (
  [string]$inputJsonFile,
  [string]$outputJsonFile
)

. (Join-Path $PSScriptRoot ".." ".." "common" "scripts" "Helpers" PSModule-Helpers.ps1)
. (Join-Path $PSScriptRoot GenerateAndBuildLib.ps1)

$inputJson = Get-Content $inputJsonFile | Out-String | ConvertFrom-Json
$swaggerDir = $inputJson.specFolder
if($swaggerDir) {
  $swaggerDir = Resolve-Path $swaggerDir
}
$swaggerDir = $swaggerDir -replace "\\", "/"
$readmeFile = $inputJson.relatedReadmeMdFile
$readmeFile = $readmeFile -replace "\\", "/"
$commitid = $inputJson.headSha
$repoHttpsUrl = $inputJson.repoHttpsUrl
$serviceType = $inputJson.serviceType
$downloadUrlPrefix = $inputJson.installInstructionInput.downloadUrlPrefix
$autorestConfig = $inputJson.autorestConfig

$autorestConfig = $inputJson.autorestConfig
$relatedCadlProjectFolder = $inputJson.relatedCadlProjectFolder

$autorestConfigYaml = ""
if ($autorestConfig) {
    $autorestConfig | Set-Content "config.md"
    $autorestConfigYaml = Get-Content -Path .\config.md
    $range = ($autorestConfigYaml | Select-String -Pattern '```').LineNumber
    if ( $range.count -gt 1) {
        $startNum = $range[0];
        $lines = $range[1] - $range[0] - 1
        $autorestConfigYaml = ($autorestConfigYaml | Select -Skip $startNum | Select -First $lines) |Out-String
    }
    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
    $yml = ConvertFrom-YAML $autorestConfigYaml
    $requires = $yml["require"]
    if ($requires.Count -gt 0) {
        $readmeFile = $requires[0]
    }
}

$generatedSDKPackages = New-Object 'Collections.Generic.List[System.Object]'

# $service, $serviceType = Get-ResourceProviderFromReadme $readmeFile
$sdkPath =  (Join-Path $PSScriptRoot .. .. ..)
$sdkPath = Resolve-Path $sdkPath
$sdkPath = $sdkPath -replace "\\", "/"

if ($readmeFile) {
  Write-Host "swaggerDir:$swaggerDir, readmeFile:$readmeFile"

  $readme = ""
  if ($commitid -ne "") {
    if ($repoHttpsUrl -ne "") {
      $readme = "$repoHttpsUrl/blob/$commitid/$readmeFile"
    } else {
      $readme = "https://github.com/$org/azure-rest-api-specs/blob/$commitid/$readmeFile"
    }
  } else {
    $readme = (Join-Path $swaggerDir $readmeFile)
  }
  Invoke-GenerateAndBuildSDK -readmeAbsolutePath $readme -sdkRootPath $sdkPath -autorestConfigYaml "$autorestConfigYaml" -downloadUrlPrefix "$downloadUrlPrefix" -generatedSDKPackages $generatedSDKPackages
}

if ($relatedCadlProjectFolder) {
  $cadlFolder = Resolve-Path (Join-Path $swaggerDir $relatedCadlProjectFolder)
  $newPackageOutput = "newPackageOutput.json"

  $cadlProjectYaml = Get-Content -Path (Join-Path "$cadlFolder" "cadl-project.yaml") -Raw

  Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module
  $yml = ConvertFrom-YAML $cadlProjectYaml
  $sdkFolder = $yml["emitters"]["@azure-tools/cadl-csharp"]["sdk-folder"]
  $projectFolder = (Join-Path $sdkPath $sdkFolder)
  # $projectFolder = $projectFolder -replace "\\", "/"
  if ($projectFolder) {
      $directories = $projectFolder -split "/|\\"
      $count = $directories.Count
      $projectFolder = $directories[0 .. ($count-2)] -join "/"
      $service = $directories[-3];
      $namespace = $directories[-2];
  }
  New-CADLPackageFolder `
      -service $service `
      -namespace $namespace `
      -sdkPath $sdkPath `
      -relatedCadlProjectFolder $relatedCadlProjectFolder `
      -specRoot $swaggerDir `
      -outputJsonFile $newpackageoutput
  $newPackageOutputJson = Get-Content $newPackageOutput -Raw | ConvertFrom-Json
  $relativeSdkPath = $newPackageOutputJson.path
  GeneratePackage `
      -projectFolder $projectFolder `
      -sdkRootPath $sdkPath `
      -path $relativeSdkPath `
      -downloadUrlPrefix $downloadUrlPrefix `
      -generatedSDKPackages $generatedSDKPackages
}
$outputJson = [PSCustomObject]@{
  packages = $generatedSDKPackages
}
$outputJson
$outputJson | ConvertTo-Json -depth 100 | Out-File $outputJsonFile