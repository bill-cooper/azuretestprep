$name = appname
$group = ContosoAzureResourceGroup

$fqdn="somecustomedomain.com"
$pfxPath="<Replace with path to your .PFX file>"
$pfxPassword="<Replace with your .PFX password>"


# NOTE: Ensure that the App Service plan is at least Basic tier (minimum required by custom SSL certificates)

Write-Host "Ensure that you have configured a CNAME record that maps $fqdn to $name.azurewebsites.net"
Read-Host "Press [Enter] key when ready ..."

# Before continuing, go to your DNS configuration UI for your custom domain and follow the 
# instructions at https://aka.ms/appservicecustomdns to configure a CNAME record for the 
# hostname "www" and point it your web app's default domain name.


# Add a custom domain name to the web app. 
Set-AzureRmWebApp -Name $name -ResourceGroupName $group -HostNames @($fqdn,"$name.azurewebsites.net")

# Upload and bind the SSL certificate to the web app.
New-AzureRmWebAppSSLBinding -WebAppName $name -ResourceGroupName $group -Name $fqdn -CertificateFilePath $pfxPath -CertificatePassword $pfxPassword -SslState SniEnabled