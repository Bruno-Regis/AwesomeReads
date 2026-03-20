import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-default-login-layout',
  standalone: true,
  imports: [],
  templateUrl: './default-login-layout.component.html',
  styleUrl: './default-login-layout.component.scss'
})
export class DefaultLoginLayoutComponent {
  @Input() title: string = '';
  @Input() primaryBtnText: string = '';
  @Input() secondaryBtnText: string = '';
  @Input() disablePrimaryBtn: boolean = true;

  @Output("submit") onSubmitPrimaryButton = new EventEmitter();
  @Output("navigate") onNavigateSecondaryBtnClick = new EventEmitter();

  submit(){
    this.onSubmitPrimaryButton.emit();
  }
  navigate(){
    this.onNavigateSecondaryBtnClick.emit();
  }
}
