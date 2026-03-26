import { Routes } from '@angular/router';
import { LoginComponent } from './features/usuarios/pages/login/login.component';
import { SignupComponent } from './features/usuarios/pages/signup/signup.component';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    data: { fullBleed: true },
  },
    {
    path: 'signup',
    component: SignupComponent,
    data: { fullBleed: true },
  },


  {
    path: 'browse',
    loadComponent: () => import('./features/livros/pages/browse/browse.component').then(m => m.BrowseComponent),
    canActivate: [authGuard]
  },

  {
    path: 'livros/:id',
    loadComponent: () => import('./features/livros/pages/livro-detail/livro-detail.component').then(m => m.LivroDetailComponent)
  }


];
