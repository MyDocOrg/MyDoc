$modelsPath   = ".\MyDoc.Infrastructure\Models"
$dalPath      = ".\MyDoc.Application\DAL"
$servicesPath = ".\MyDoc.Application\Services"

# Crear carpetas si no existen
if (!(Test-Path $dalPath)) { New-Item -ItemType Directory -Path $dalPath | Out-Null }
if (!(Test-Path $servicesPath)) { New-Item -ItemType Directory -Path $servicesPath | Out-Null }

Get-ChildItem $modelsPath -Filter *.cs | ForEach-Object {

    $modelName = $_.BaseName

    Write-Host "Generando DAL y Service para $modelName"

    # ===============================
    # DAL
    # ===============================
    $dalFile = Join-Path $dalPath "$modelName`DAL.cs"

    if (Test-Path $dalFile) {
        Remove-Item $dalFile -Force
    }

    $dalContent = @"
using MyDoc.Application.DAL.Abstract;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDoc.Application.DAL
{
    public class ${modelName}DAL : AbstractDAL<${modelName}>
    {
        private readonly ApplicationDbContext _context;

        public ${modelName}DAL(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<${modelName}>> GetAll()
        {
            var result = await base.GetAllAsync();
            return result.ToList();
        }

        public async Task<${modelName}?> GetById(int id)
        {
            return await base.GetByIdAsync(id);
        }

        public async Task<${modelName}> Create(${modelName} entity)
        {
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<${modelName}> Update(${modelName} entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
"@

    Set-Content -Path $dalFile -Value $dalContent -Encoding UTF8

    # ===============================
    # SERVICE
    # ===============================
    $serviceFile = Join-Path $servicesPath "$modelName`Service.cs"

    if (Test-Path $serviceFile) {
        Remove-Item $serviceFile -Force
    }

    $serviceContent = @"
using MyDoc.Application.BO.Contants;
using MyDoc.Application.DAL;
using MyDoc.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDoc.Application.Services
{
    public class ${modelName}Service
    {
        private readonly ${modelName}DAL _dAL;

        public ${modelName}Service(${modelName}DAL dAL)
        {
            _dAL = dAL;
        }

        public async Task<ApiResponse<List<${modelName}>>> GetAll()
        {
            var result = await _dAL.GetAll();
            return ApiResponse<List<${modelName}>>.Ok(result);
        }

        public async Task<ApiResponse<${modelName}?>> GetById(int id)
        {
            var result = await _dAL.GetById(id);
            return ApiResponse<${modelName}?>.Ok(result);
        }

        public async Task<ApiResponse<${modelName}>> Create(${modelName} entity)
        {
            var result = await _dAL.Create(entity);
            return ApiResponse<${modelName}>.Ok(result);
        }

        public async Task<ApiResponse<${modelName}>> Update(${modelName} entity)
        {
            var result = await _dAL.Update(entity);
            return ApiResponse<${modelName}>.Ok(result);
        }
    }
}
"@

    Set-Content -Path $serviceFile -Value $serviceContent -Encoding UTF8
}

Write-Host "Completada correctamente."
