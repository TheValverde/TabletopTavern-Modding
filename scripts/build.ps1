#Requires -Version 5.1
param(
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$repoRoot = Split-Path $PSScriptRoot -Parent

dotnet build (Join-Path $repoRoot "src\TTMod.Core\TTMod.Core.csproj") -c $Configuration
dotnet build (Join-Path $repoRoot "examples\TTMod.Template\TTMod.Template.csproj") -c $Configuration
