import { Routes } from '@angular/router';
import { LoginComponent } from './features/usuarios/pages/login/login.component';
import { SignupComponent } from './features/usuarios/pages/signup/signup.component';
import { UsuarioComponent } from './pages/usuario/usuario.component';
import { AuthGuardService } from './features/usuarios/services/auth/auth-guard.service';

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
  },

  {
    path: 'livros/:id',
    loadComponent: () => import('./features/livros/pages/livro-detail/livro-detail.component').then(m => m.LivroDetailComponent)
  }


];
