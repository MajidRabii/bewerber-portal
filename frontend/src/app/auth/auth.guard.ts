// src/app/guards/auth.guard.ts
import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = async () => {
  const authService = inject(AuthService);

  const eingeloggt = await authService.istEingeloggtAsync();

  // اگر وارد نشده، هیچ کاری نکن، فقط اجازه نده وارد بشه
  if (!eingeloggt) {
    // توجه: ما اینجا به مسیر لاگین هدایت نمی‌کنیم چون LoginComponent الان به صورت دیالوگ هست
    console.warn('authGuard: Zugriff verweigert – nicht eingeloggt.');
    return false;
  }

  return true;
};
