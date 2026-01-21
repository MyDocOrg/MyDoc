import { TestBed } from '@angular/core/testing';
import { LanguageService } from './language.service';
import { TranslateModule, TranslateService } from '@ngx-translate/core';

describe('LanguageService', () => {
  let service: LanguageService;
  let translateService: TranslateService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [TranslateModule.forRoot()],
      providers: [LanguageService]
    });
    service = TestBed.inject(LanguageService);
    translateService = TestBed.inject(TranslateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should initialize with Spanish as default language', () => {
    expect(service.getCurrentLanguage()).toBe('es');
  });

  it('should change language', () => {
    service.changeLanguage('en');
    expect(service.getCurrentLanguage()).toBe('en');
  });

  it('should return available languages', () => {
    const languages = service.getAvailableLanguages();
    expect(languages.length).toBe(2);
    expect(languages[0].code).toBe('es');
    expect(languages[1].code).toBe('en');
  });
});
