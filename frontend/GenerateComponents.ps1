# Rutas
$modelsPath = "..\backend\MyDoc.Infrastructure\Models"
$frontendBasePath = ".\src\app\pages\features"

# Crear carpeta base si no existe
if (!(Test-Path $frontendBasePath)) { 
    New-Item -ItemType Directory -Path $frontendBasePath -Force | Out-Null 
}

# Función para convertir PascalCase a kebab-case
function ConvertTo-KebabCase {
    param([string]$text)
    return ($text -creplace '([A-Z])', '-$1').ToLower().TrimStart('-')
}

# Función para convertir PascalCase a camelCase
function ConvertTo-CamelCase {
    param([string]$text)
    return $text.Substring(0,1).ToLower() + $text.Substring(1)
}

# Obtener todos los modelos excepto ApplicationDbContext
Get-ChildItem $modelsPath -Filter *.cs | Where-Object { $_.BaseName -ne "ApplicationDbContext" } | ForEach-Object {

    $modelName = $_.BaseName
    $kebabName = ConvertTo-KebabCase $modelName
    $camelName = ConvertTo-CamelCase $modelName
    $lowerName = $modelName.ToLower()

    Write-Host "Generando componentes para $modelName" -ForegroundColor Green

    # Crear carpeta principal del feature
    $featurePath = Join-Path $frontendBasePath $kebabName
    if (!(Test-Path $featurePath)) {
        New-Item -ItemType Directory -Path $featurePath -Force | Out-Null
    }

    # ===============================
    # 1. Crear {modelo}-add
    # ===============================
    $addPath = Join-Path $featurePath "$kebabName-add"
    if (!(Test-Path $addPath)) {
        New-Item -ItemType Directory -Path $addPath -Force | Out-Null
    }

    # {modelo}-add.ts
    Set-Content -Path (Join-Path $addPath "$kebabName-add.ts") -Encoding UTF8 -Value @"
import { Component } from '@angular/core';

@Component({
  selector: 'app-$kebabName-add',
  imports: [],
  templateUrl: './$kebabName-add.html',
  styleUrl: './$kebabName-add.scss',
})
export class ${modelName}Add {

}
"@

    # {modelo}-add.html
    Set-Content -Path (Join-Path $addPath "$kebabName-add.html") -Encoding UTF8 -Value @"
<p>$kebabName-add works!</p>
"@

    # {modelo}-add.scss
    Set-Content -Path (Join-Path $addPath "$kebabName-add.scss") -Encoding UTF8 -Value ""

    # {modelo}-add.spec.ts
    Set-Content -Path (Join-Path $addPath "$kebabName-add.spec.ts") -Encoding UTF8 -Value @"
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ${modelName}Add } from './$kebabName-add';

describe('${modelName}Add', () => {
  let component: ${modelName}Add;
  let fixture: ComponentFixture<${modelName}Add>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [${modelName}Add]
    })
    .compileComponents();

    fixture = TestBed.createComponent(${modelName}Add);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
"@

    # ===============================
    # 2. Crear {modelo}-home
    # ===============================
    $homePath = Join-Path $featurePath "$kebabName-home"
    if (!(Test-Path $homePath)) {
        New-Item -ItemType Directory -Path $homePath -Force | Out-Null
    }

    # {modelo}-home.ts
    Set-Content -Path (Join-Path $homePath "$kebabName-home.ts") -Encoding UTF8 -Value @"
import { Component } from '@angular/core';

@Component({
  selector: 'app-$kebabName-home',
  imports: [],
  templateUrl: './$kebabName-home.html',
  styleUrl: './$kebabName-home.scss',
})
export class ${modelName}Home {

}
"@

    # {modelo}-home.html
    Set-Content -Path (Join-Path $homePath "$kebabName-home.html") -Encoding UTF8 -Value @"
<p>$kebabName-home works!</p>
"@

    # {modelo}-home.scss
    Set-Content -Path (Join-Path $homePath "$kebabName-home.scss") -Encoding UTF8 -Value ""

    # {modelo}-home.spec.ts
    Set-Content -Path (Join-Path $homePath "$kebabName-home.spec.ts") -Encoding UTF8 -Value @"
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ${modelName}Home } from './$kebabName-home';

describe('${modelName}Home', () => {
  let component: ${modelName}Home;
  let fixture: ComponentFixture<${modelName}Home>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [${modelName}Home]
    })
    .compileComponents();

    fixture = TestBed.createComponent(${modelName}Home);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
"@

    # ===============================
    # 3. Crear carpeta components
    # ===============================
    $componentsPath = Join-Path $featurePath "components"
    if (!(Test-Path $componentsPath)) {
        New-Item -ItemType Directory -Path $componentsPath -Force | Out-Null
    }

    # ===============================
    # 3.1. Crear {modelo}-form
    # ===============================
    $formPath = Join-Path $componentsPath "$kebabName-form"
    if (!(Test-Path $formPath)) {
        New-Item -ItemType Directory -Path $formPath -Force | Out-Null
    }

    # {modelo}-form.ts
    Set-Content -Path (Join-Path $formPath "$kebabName-form.ts") -Encoding UTF8 -Value @"
import { Component } from '@angular/core';

@Component({
  selector: 'app-$kebabName-form',
  imports: [],
  templateUrl: './$kebabName-form.html',
  styleUrl: './$kebabName-form.scss',
})
export class ${modelName}Form {

}
"@

    # {modelo}-form.html
    Set-Content -Path (Join-Path $formPath "$kebabName-form.html") -Encoding UTF8 -Value @"
<p>$kebabName-form works!</p>
"@

    # {modelo}-form.scss
    Set-Content -Path (Join-Path $formPath "$kebabName-form.scss") -Encoding UTF8 -Value ""

    # {modelo}-form.spec.ts
    Set-Content -Path (Join-Path $formPath "$kebabName-form.spec.ts") -Encoding UTF8 -Value @"
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ${modelName}Form } from './$kebabName-form';

describe('${modelName}Form', () => {
  let component: ${modelName}Form;
  let fixture: ComponentFixture<${modelName}Form>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [${modelName}Form]
    })
    .compileComponents();

    fixture = TestBed.createComponent(${modelName}Form);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
"@

    # ===============================
    # 3.2. Crear {modelo}-table
    # ===============================
    $tablePath = Join-Path $componentsPath "$kebabName-table"
    if (!(Test-Path $tablePath)) {
        New-Item -ItemType Directory -Path $tablePath -Force | Out-Null
    }

    # {modelo}-table.ts
    Set-Content -Path (Join-Path $tablePath "$kebabName-table.ts") -Encoding UTF8 -Value @"
import { Component } from '@angular/core';

@Component({
  selector: 'app-$kebabName-table',
  imports: [],
  templateUrl: './$kebabName-table.html',
  styleUrl: './$kebabName-table.scss',
})
export class ${modelName}Table {

}
"@

    # {modelo}-table.html
    Set-Content -Path (Join-Path $tablePath "$kebabName-table.html") -Encoding UTF8 -Value @"
<p>$kebabName-table works!</p>
"@

    # {modelo}-table.scss
    Set-Content -Path (Join-Path $tablePath "$kebabName-table.scss") -Encoding UTF8 -Value ""

    # {modelo}-table.spec.ts
    Set-Content -Path (Join-Path $tablePath "$kebabName-table.spec.ts") -Encoding UTF8 -Value @"
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ${modelName}Table } from './$kebabName-table';

describe('${modelName}Table', () => {
  let component: ${modelName}Table;
  let fixture: ComponentFixture<${modelName}Table>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [${modelName}Table]
    })
    .compileComponents();

    fixture = TestBed.createComponent(${modelName}Table);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
"@

    # ===============================
    # 4. Crear carpeta services
    # ===============================
    $servicesPath = Join-Path $featurePath "services"
    if (!(Test-Path $servicesPath)) {
        New-Item -ItemType Directory -Path $servicesPath -Force | Out-Null
    }

    # {modelo}-service.ts - Usando formato diferente para evitar problemas con backticks
    $backtick = [char]96
    $apiUrlTemplate = "$backtick`$`{environment.apiUrl`}/$lowerName$backtick"
    $apiUrlWithId = "$backtick`$`{environment.apiUrl`}/$lowerName/`$`{data.id`}$backtick"
    $apiUrlWithIdParam = "$backtick`$`{environment.apiUrl`}/$lowerName/`$`{id`}$backtick"
    
    $serviceContent = @"
import { inject, Injectable } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { IApiResponse } from '../../../../shared/Interfaces/IApiResponse';
import { Observable } from 'rxjs/internal/Observable';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ${modelName}Service {
   http = inject(HttpClient);

  GetAll() : Observable<IApiResponse<any[]>> { return this.http.get<IApiResponse<any[]>>($apiUrlTemplate); }
  Add(data : any) : Observable<IApiResponse<any[]>> { return this.http.post<IApiResponse<any[]>>($apiUrlTemplate, data); }
  Edit(data : any) : Observable<IApiResponse<any[]>> { return this.http.put<IApiResponse<any[]>>($apiUrlWithId, data); }
  Delete(id : number) : Observable<IApiResponse<any[]>> { return this.http.delete<IApiResponse<any[]>>($apiUrlWithIdParam); }
}
"@
    
    Set-Content -Path (Join-Path $servicesPath "$kebabName-service.ts") -Encoding UTF8 -Value $serviceContent

    # {modelo}-service.spec.ts
    Set-Content -Path (Join-Path $servicesPath "$kebabName-service.spec.ts") -Encoding UTF8 -Value @"
import { TestBed } from '@angular/core/testing';

import { ${modelName}Service } from './$kebabName-service';

describe('${modelName}Service', () => {
  let service: ${modelName}Service;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(${modelName}Service);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
"@

    Write-Host "Generado: $modelName" -ForegroundColor Cyan
}

Write-Host ""
Write-Host "========================================"
Write-Host "Generacion de componentes completada!"
Write-Host "========================================"
