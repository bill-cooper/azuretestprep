$name = appName
$group = ContosoAzureResourceGroup

Get-AzureRmWebAppPublishingProfile -Name $name -ResourceGroupName $group -OutputFile .\publishingprofile.txt