$name = appname
$group = ContosoAzureResourceGroup


#Set-AzureRmWebApp
#   [-ResourceGroupName] <String>
#   [-Name] <String>
#   [[-ConnectionStrings] <Hashtable>]
#   [[-HandlerMappings] <System.Collections.Generic.IList`1[Microsoft.Azure.Management.WebSites.Models.HandlerMapping]>]
#   [[-ManagedPipelineMode] <String>]
#   [[-WebSocketsEnabled] <Boolean>]
#   [[-Use32BitWorkerProcess] <Boolean>]
#   [[-HostNames] <String[]>]
#   [[-AppServicePlan] <String>]
#   [[-DefaultDocuments] <String[]>]
#   [[-NetFrameworkVersion] <String>]
#   [[-PhpVersion] <String>]
#   [[-RequestTracingEnabled] <Boolean>]
#   [[-HttpLoggingEnabled] <Boolean>]
#   [[-DetailedErrorLoggingEnabled] <Boolean>]
#   [[-AppSettings] <Hashtable>]
#   [-AutoSwapSlotName <String>]
#   [-NumberOfWorkers <Int32>]


$connectionstrings = @{ ContosoConn1 = @{ Type = "MySql"; Value = "MySqlConn"}; ContosoConn2 = @{ Type = "SQLAzure"; Value = "SQLAzureConn"} }
$appsettings = @{appsetting1 = "appsetting1value"; appsetting2 = "appsetting2value"}

Set-AzureRmWebApp -Name $name -ResourceGroupName $group -ConnectionStrings $connectionstrings -AppSettings $appsettings -Use32BitWorkerProcess $False