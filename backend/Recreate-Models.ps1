# ========================================
# Script para regenerar modelos y DbContext
# ========================================

param(
    [string]$Server = "mydocdbinstance.cjmky0i8i025.us-east-2.rds.amazonaws.com",
    [string]$Database = "MyDoc",
    [string]$User = "mydocadmin",
    [string]$Password = "mydocmastersql2026*",
    [string]$InfrastructurePath = ".\MyDoc.Infrastructure",
    [string]$ApplicationPath = ".\MyDoc.Application",
    [string]$DbContextName = "ApplicationDbContext",
    [string]$ModelsFolder = "Models"
)

# ----------------------------
# Paso 1: Eliminar modelos antiguos
# ----------------------------
Write-Host "Eliminando modelos antiguos..."
$modelsPath = Join-Path $InfrastructurePath $ModelsFolder
if (Test-Path $modelsPath) {
    Remove-Item "$modelsPath\*" -Recurse -Force
    Write-Host "Modelos eliminados."
} else {
    Write-Host "Carpeta de modelos no existe, se creará al generar."
}

# ----------------------------
# Paso 2: Limpiar y compilar Infrastructure
# ----------------------------
Write-Host "Limpiando y compilando Infrastructure..."
cd $InfrastructurePath
dotnet clean
$buildResult = dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Error "Error al compilar Infrastructure. Corrige errores antes de regenerar modelos."
    exit 1
}

# ----------------------------
# Paso 3: Scaffold EF Core
# ----------------------------
Write-Host "Generando modelos con EF Core Scaffold..."
$scaffoldCmd = "dotnet ef dbcontext scaffold `"Server=$Server;Database=$Database;User Id=$User;Password=$Password;Encrypt=True;TrustServerCertificate=True;`" Microsoft.EntityFrameworkCore.SqlServer --output-dir $ModelsFolder --context $DbContextName --use-database-names --data-annotations"
Write-Host "Ejecutando: $scaffoldCmd"
Invoke-Expression $scaffoldCmd

if ($LASTEXITCODE -ne 0) {
    Write-Error "Error durante el scaffold. Revisa la conexión a la base de datos o la configuración de EF Core."
    exit 1
}

# ----------------------------
# Paso 4: Compilar Infrastructure después de Scaffold
# ----------------------------
Write-Host "Compilando Infrastructure después del scaffold..."
dotnet build
if ($LASTEXITCODE -ne 0) {
    Write-Error "Compilación fallida después del scaffold."
    exit 1
}

# ----------------------------
# Paso 5 (opcional): Compilar Application
# ----------------------------
if (Test-Path $ApplicationPath) {
    Write-Host "Compilando Application..."
    cd $ApplicationPath
    dotnet build
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Error al compilar Application. Revisa los using y la referencia a Infrastructure."
        exit 1
    }
}

Write-Host "¡Regeneración de modelos completada correctamente!"