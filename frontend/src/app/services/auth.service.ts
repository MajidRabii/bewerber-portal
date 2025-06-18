import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of, firstValueFrom } from 'rxjs';
import { delay, tap, catchError } from 'rxjs/operators';
import { BenutzerService } from './benutzer.service';
import { BenutzerModel } from '../models/benutzer.model';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private eingeloggtSubjekt = new BehaviorSubject<boolean>(false);
  eingeloggt$ = this.eingeloggtSubjekt.asObservable();

  private benutzerSubjekt = new BehaviorSubject<BenutzerModel | null>(null);
  benutzer$ = this.benutzerSubjekt.asObservable();

  private aktuellerBenutzer: BenutzerModel | null = null;

  private codeStorage = new Map<string, string>();
  private zwischenDaten: {
    benutzername: string;
    email: string;
    code: string;
  } | null = null;

  private apiUrl = 'https://localhost:7159/api/auth/login';

  constructor(
    private benutzerService: BenutzerService,
    private router: Router,
    private http: HttpClient
  ) {}

  // ✅ شبیه‌سازی ارسال کد
  sendCode(email: string): Observable<string> {
    const code = Math.floor(100000 + Math.random() * 900000).toString();
    console.log(`Code für ${email}: ${code}`);
    return of(code).pipe(delay(1000));
  }

  // ✅ ذخیره اطلاعات موقت ثبت‌نام
  setZwischenspeicher(daten: { benutzername: string; email: string; code: string }): void {
    this.zwischenDaten = daten;
  }

  getZwischenspeicher(): { benutzername: string; email: string; code: string } | null {
    return this.zwischenDaten;
  }

  verifyCode(email: string, code: string): boolean {
    return this.codeStorage.get(email) === code;
  }

  // ✅ ثبت‌نام کاربر
  registrieren(benutzer: Omit<BenutzerModel, 'id'>): Observable<BenutzerModel> {
    return this.benutzerService.addBenutzer(benutzer);
  }

  // ✅ ورود
  anmelden(benutzernameOderEmail: string, passwort: string): Observable<BenutzerModel | null> {
    return this.http.post<BenutzerModel>(this.apiUrl, {
      benutzernameOderEmail,
      passwort
    }).pipe(
      tap((antwort: any) => {
        this.aktuellerBenutzer = antwort.benutzer;
        this.benutzerSubjekt.next(antwort.benutzer);
        localStorage.setItem('token', antwort.token);
        this.eingeloggtSubjekt.next(true);
      }),
      catchError(err => {
        console.error('Login fehlgeschlagen:', err);
        return of(null);
      })
    );
  }

  // ✅ بررسی ورود همگام
  istEingeloggt(): boolean {
    return !!this.aktuellerBenutzer;
  }

  // ✅ بررسی ورود ناهمگام (مثلاً هنگام F5)
  async istEingeloggtAsync(): Promise<boolean> {
    const token = localStorage.getItem('token');
    if (!token) {
      this.eingeloggtSubjekt.next(false);
      return false;
    }

    try {
      const benutzer = await firstValueFrom(this.http.get<BenutzerModel>('/api/auth/me'));
      this.aktuellerBenutzer = benutzer;
      this.benutzerSubjekt.next(benutzer);
      this.eingeloggtSubjekt.next(true);
      return true;
    } catch (error) {
      console.error('Token ungültig oder abgelaufen', error);
      localStorage.removeItem('token');
      this.eingeloggtSubjekt.next(false); 
      return false;
    }
  }

  // ✅ خروج
  logout(): void {
    localStorage.removeItem('token');
    this.aktuellerBenutzer = null;
    this.benutzerSubjekt.next(null);
    this.eingeloggtSubjekt.next(false);
    this.router.navigate(['/login']);
  }

  // ✅ گرفتن یا ست‌کردن کاربر جاری
  getAktuellerBenutzer(): BenutzerModel | null {
    return this.aktuellerBenutzer;
  }

  setAktuellerBenutzer(benutzer: BenutzerModel): void {
    this.aktuellerBenutzer = benutzer;
    this.benutzerSubjekt.next(benutzer);
  }

  // ✅ اعمال دستی وضعیت ورود (مثلاً در تست)
  setzeEingeloggtStatus(status: boolean): void {
    this.eingeloggtSubjekt.next(status);
  }
}
