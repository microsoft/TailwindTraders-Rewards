param (
    [string]$webConfig = "c:\inetpub\wwwroot\Web.config"
)

## Apply web.config transform if exists

$transformFile = "c:\transform.config";

if (Test-Path $transformFile) {CD
    Write-Host "Running web.config transform..."
    \WebConfigTransformRunner.1.0.0.1\Tools\WebConfigTransformRunner.exe $webConfig $transformFile $webConfig
    Write-Host "Done!"
}
