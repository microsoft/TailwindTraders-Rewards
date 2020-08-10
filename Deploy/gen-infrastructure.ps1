#! /usr/bin/pwsh

##################################################################################################
#
# Parameters.
#

Param(
    [parameter(Mandatory=$true)][string]$resourceGroup,
    [parameter(Mandatory=$true)][string]$location,
    [parameter(Mandatory=$false)][string]$subscription,
    [parameter(Mandatory=$false)][string]$sqlAdminName,
    [parameter(Mandatory=$false)][string]$sqlAdminPassword,
    [parameter(Mandatory=$false)][string]$armScriptPath="deployment.json"
)

###################################################################################################
#
# Handle all errors.
#

trap
{
    $message = $Error[0].Exception.Message
    if ($message)
    {
        Write-Host -Object "`nERROR: $message" -ForegroundColor Red
    }

    Log -msg "`nThe script failed.`n" -level 'error'

    exit -1
}

###################################################################################################
#
# Functions.
#

function Ensure-Success
{
    if ($LastExitCode -or $expError)
    {
        if ($expError[0])
        {
            throw $expError[0]
        }
        else
        {
            throw "Deployment failed ($LastExitCode)."
        }       
    }
}

function Log
{
    param(
        [string] $msg,
        [string] $level='info'
    )

    switch ( $level )
    {
        'success' { $fc = 'Green'    }
        'info' { $fc = 'Yellow'    }
        'error' { $fc = 'Red'   }
    }

    Write-Host "--------------------------------------------------------" -ForegroundColor $fc
    Write-Host $msg -ForegroundColor $fc
    Write-Host "-------------------------------------------------------- " -ForegroundColor $fc
}

function LoginAndSetAzureSubscription
{
    param(
        [string] $subs
    )

    Log -msg "Login in your account"
    az login

    Log -msg "Setting your subscription $subs"
    az account set --subscription $subs
}

###################################################################################################
#
# Main.
#

try
{
    Push-Location $($MyInvocation.InvocationName | Split-Path)

    LoginAndSetAzureSubscription -subs $subscription

    Log -msg "Deploying ARM script $armScriptPath"

    $rg = $(az group show -n $resourceGroup -o json | ConvertFrom-Json)

    if (-not $rg) {
        Log -msg "Creating resource group $resourceGroup in $location"
        az group create -n $resourceGroup -l $location
    }

    az deployment group create -g $resourceGroup --template-file $armScriptPath --parameters sqlServerAdministratorUser=$sqlAdminName --parameters sqlServerAdministratorPassword=$sqlAdminPassword
    
    Ensure-Success

    Log -msg "Script successfully completed!" -level 'success'
}
finally
{
    Pop-Location
}

