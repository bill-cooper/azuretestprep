$name = ContosoAppServicePlan
$group = ContosoAzureResourceGroup


Set-AzureRmAppServicePlan -Name $name -ResourceGroupName $group -Tier Standard -WorkerSize Medium -NumberofWorkers 9