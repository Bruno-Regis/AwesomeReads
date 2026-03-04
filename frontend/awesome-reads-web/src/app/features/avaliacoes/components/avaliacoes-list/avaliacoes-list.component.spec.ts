import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AvaliacoesListComponent } from './avaliacoes-list.component';

describe('AvaliacoesListComponent', () => {
  let component: AvaliacoesListComponent;
  let fixture: ComponentFixture<AvaliacoesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AvaliacoesListComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AvaliacoesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
