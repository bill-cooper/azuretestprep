$name = appname
$group = ContosoAzureResourceGroup

$fqdn="somecustomedomain.com"


# Note: App Service plan must be at least Shared tier (minimum required by custom domains)


# Add a custom domain name to the web app. 
Set-AzureRmWebApp -Name $name -ResourceGroupName $group -HostNames @($fqdn,"$name.azurewebsites.net")