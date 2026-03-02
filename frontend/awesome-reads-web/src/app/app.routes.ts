import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { SignupComponent } from './pages/signup/signup.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { AuthGuardService } from './features/auth/services/auth-guard.service';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
    {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: '*usuario*',
    component: UsuarioComponent,
    canActivate: [AuthGuardService]
  },

  {
    path: 'browse',
    loadComponent: () => import('./features/livros/pages/browse/browse.component').then(m => m.BrowseComponent)
  }
];
