import { Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout.component';
import { authGuard } from './auth/auth.guard';
import { DummyBlankComponent } from './shared/dummy-blank.component';

export const routes: Routes = [
  // مسیر پیش‌فرض: به mainform برو، ولی فقط اگه login شده باشه
  //{ path: '', component: DummyBlankComponent },

  // ✅ صفحات محافظت‌شده، بعد از لاگین با منوی MainLayoutComponent
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      {
        path: 'mainform',
        canActivate: [authGuard],
        component: DummyBlankComponent, // صفحه خالی اولیه همراه با منو
      },
      {
        path: 'stadt-liste',
        canActivate: [authGuard],
        loadComponent: () =>
          import('./stadt-list/stadt-list.component').then(m => m.StadtListComponent),
      },
      {
        path: 'stadt-form',
        canActivate: [authGuard],
        loadComponent: () =>
          import('./stadt-form/stadt-form.component').then(m => m.StadtFormComponent),
      },
      {
        path: 'bewerberprofil-list',
        canActivate: [authGuard],
        loadComponent: () =>
          import('./bewerberprofil/list/bewerberprofil-list.component').then(
            m => m.BewerberProfilListComponent
          ),
      },
      {
        path: 'bewerberprofil-form',
        canActivate: [authGuard],
        loadComponent: () =>
          import('./bewerberprofil/form/bewerberprofil-form.component').then(
            m => m.BewerberprofilFormComponent
          ),
      },
      {
        path: 'bewerberprofil-form/:id',
        canActivate: [authGuard],
        loadComponent: () =>
          import('./bewerberprofil/form/bewerberprofil-form.component').then(
            m => m.BewerberprofilFormComponent
          ),
      },
      {
        path: '',
        component: DummyBlankComponent
      }
    ],
  },

  // مسیر fallback برای هر آدرس اشتباه
  { path: '**', redirectTo: '' },
];
