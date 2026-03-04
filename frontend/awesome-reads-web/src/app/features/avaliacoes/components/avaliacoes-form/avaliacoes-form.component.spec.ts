import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvaliacoesFormComponent } from './avaliacoes-form.component';

describe('AvaliacoesFormComponent', () => {
  let component: AvaliacoesFormComponent;
  let fixture: ComponentFixture<AvaliacoesFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AvaliacoesFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvaliacoesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
