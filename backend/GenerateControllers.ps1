$modelsPath = ".\MyDoc.Infrastructure\Models"
$controllersPath = ".\MyDoc\Controllers"

# Crear carpeta si no existe
if (!(Test-Path $controllersPath)) { New-Item -ItemType Directory -Path $controllersPath | Out-Null }

# Obtener todos los modelos excepto ApplicationDbContext
Get-ChildItem $modelsPath -Filter *.cs | Where-Object { $_.BaseName -ne "ApplicationDbContext" } | ForEach-Object {

    $modelName = $_.BaseName

    Write-Host "Generando Controller para $modelName"

    # ===============================
    # CONTROLLER
    # ===============================
    $controllerFile = Join-Path $controllersPath "$modelName`Controller.cs"

    if (Test-Path $controllerFile) {
        Remove-Item $controllerFile -Force
    }

    $controllerContent = @"
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyDoc.Application.Services;
using MyDoc.Application.BO.Contants;
using MyDoc.Infrastructure.Models;

namespace MyDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ${modelName}Controller(${modelName}Service ${modelName.ToLower()}Service) : ControllerBase
    {
        private readonly ${modelName}Service _${modelName.ToLower()}Service = ${modelName.ToLower()}Service;
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _${modelName.ToLower()}Service.GetAll();
            return StatusCode(result.Status, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _${modelName.ToLower()}Service.GetById(id);
            return StatusCode(result.Status, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ${modelName} entity)
        {
            var result = await _${modelName.ToLower()}Service.Create(entity);
            return StatusCode(result.Status, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ${modelName} entity)
        {
            var result = await _${modelName.ToLower()}Service.Update(entity);
            return StatusCode(result.Status, result);
        }
    }
}
"@

    Set-Content -Path $controllerFile -Value $controllerContent -Encoding UTF8
}

Write-Host "Generación de Controllers completada correctamente."
