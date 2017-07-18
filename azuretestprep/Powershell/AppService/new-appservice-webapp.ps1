$name = ContosoAppServicePlan
$group = ContosoAzureResourceGroup
$location = "South Central US"

#AppServicePlan: name for the service plan used to host the web app.
$planName = ''

New-AzureRmWebApp -Name $name -Location $location -ResourceGroupName $group -AppServicePlan $planName