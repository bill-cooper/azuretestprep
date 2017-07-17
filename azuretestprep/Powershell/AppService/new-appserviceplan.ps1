$name = ContosoAppServicePlan
$group = ContosoAzureResourceGroup
$location = "South Central US"

#Tier: the desired pricing tier (Default is Free, other options are Shared, Basic, Standard, and Premium.)
#WorkerSize: the size of workers (Default is small if the Tier parameter was specified as Basic, Standard, or Premium. Other options are Medium, and Large.)
#NumberofWorkers: the number of workers in the app service plan (Default value is 1).

New-AzureRmAppServicePlan -Name $name -Location $location -ResourceGroupName $group -Tier Standard -WorkerSize Medium -NumberofWorkers 9