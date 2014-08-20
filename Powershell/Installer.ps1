$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.Powershell'}
if ($snapin -eq $null)
{
	 Write-Host "Loading SharePoint Powershell Snapin"
	 Add-PSSnapin "Microsoft.SharePoint.Powershell"
}

# administrador del portal
$portalUrl = 'http://portal.kdev.local/sites/skandia'
$webapplicationUrl = 'http://portal.kdev.local'

Write-Host -f yellow "***** Instalando paquetes de Solucion *****"

$webApplication = Get-SPWebApplication $webapplicationUrl



Write-Host -f Green "Desinstalando paquete de definicion de objetos"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "Jondu.Skandia.Simulators.ObjectDef.wsp" -Confirm:$false -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "Jondu.Skandia.Simulators.ObjectDef.wsp" -ErrorAction SilentlyContinue
if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de definicion de objetos..." 
    Remove-SPSolution -Identity "Jondu.Skandia.Simulators.ObjectDef.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de definicion de objetos no se encuentra instalado"
}

Write-Host -f Green "Instalando paquete de definicion de objetos"
Add-SPSolution "C:\Dev\Jondu.Skandia\Powershell\Packages\Jondu.Skandia.Simulators.ObjectDef.wsp" -ErrorAction SilentlyContinue
Write-Host -f Green "Por favor espere" -NoNewline
Install-SPSolution –Identity "Jondu.Skandia.Simulators.ObjectDef.wsp" -GACDeployment
$solution = Get-SPSolution -Identity "Jondu.Skandia.Simulators.ObjectDef.wsp" -ErrorAction SilentlyContinue
if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "El paquete de definicion de objetos ha sido instalado y desplegado"    
}




Write-Host -f Green "Desinstalando paquete de formularios"
Write-Host -f Green "Por favor espere" -NoNewline
Uninstall-SPSolution -Identity "Jondu.Skandia.Simulators.UI.wsp" -Confirm:$false -WebApplication $webApplication -ErrorAction SilentlyContinue
$solution = Get-SPSolution -Identity "Jondu.Skandia.Simulators.UI.wsp" -ErrorAction SilentlyContinue
if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "Eliminando paquete de formularios..." 
    Remove-SPSolution -Identity "Jondu.Skandia.Simulators.UI.wsp" -Confirm:$false
    Write-Host -f Green "Paquete eliminado"
}else
{
    Write-Host ""
    Write-Host -f Green "El paquete de definicion de formularios no se encuentra instalado"
}

Write-Host -f Green "Instalando paquete de formularios"
Add-SPSolution "C:\Dev\Jondu.Skandia\Powershell\Packages\Jondu.Skandia.Simulators.UI.wsp" -ErrorAction SilentlyContinue
Write-Host -f Green "Por favor espere" -NoNewline
Install-SPSolution –Identity "Jondu.Skandia.Simulators.UI.wsp" -GACDeployment -WebApplication $webApplication
$solution = Get-SPSolution -Identity "Jondu.Skandia.Simulators.UI.wsp" -ErrorAction SilentlyContinue
if($solution -ne $null){
    while ($solution.JobExists -eq $true) {
        Write-Host '.' -NoNewline
        sleep -Seconds:1
    }
    Write-Host ""
    Write-Host -f Green "El paquete de formularios ha sido instalado y desplegado"    
}

Write-Host -f Green "Activando caracteristica de definicion de objetos..."
Enable-SPFeature -Identity "e1f017c0-dc90-405f-9773-78c75066b918" -Url $portalUrl -Confirm:$false

Write-Host -f Green "Activando caracteristica de formularios..."
Enable-SPFeature -Identity "1b8d7adc-d8f8-452b-a5f4-b7df05f2457d" -Url $portalUrl -Confirm:$false