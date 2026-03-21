import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { LoginService } from '../../../features/usuarios/services/login.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  private _loginService = inject(LoginService);
  private _router = inject(Router);

  query = signal('');

  logout() {
    this._loginService.logout();
    this._router.navigate(['/login']);
  }

  onQueryInput(value: string) {}
  submitSearch() {}
}