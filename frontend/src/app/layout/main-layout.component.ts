import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatDividerModule } from '@angular/material/divider';
import { AuthService } from '../services/auth.service';
import { OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { LoginComponent } from '../auth/login/login.component';
import { BenutzerService } from '../services/benutzer.service';
import { Observable } from 'rxjs';
import { BenutzerModel } from '../models/benutzer.model';

@Component({
  selector: 'app-main-layout',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatDividerModule
  ],
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})

export class MainLayoutComponent {
  menuGeoeffnet = false;
  istEingeloggtStatus = false;
  benutzer$!: Observable<BenutzerModel | null>;
  private sub?: Subscription;
  constructor(
    private dialog: MatDialog, 
    private authService: AuthService,
    private benutzerService: BenutzerService, 
    private router: Router
  ) {}

  async ngOnInit(): Promise<void> {
    const eingeloggt = await this.authService.istEingeloggtAsync();
    if (!eingeloggt) {
      this.dialog.open(LoginComponent, {
        disableClose: true,
        width: '400px'
      });
    }
    this.benutzer$ = this.authService.benutzer$;
    // وضعیت لاگین را گوش بده و وضعیت داخلی را به‌روز کن
    this.authService.eingeloggt$.subscribe(status => {
      this.istEingeloggtStatus = status;
    });
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/mainform']).then(() => {
      this.dialog.open(LoginComponent, {
        disableClose: true,
        width: '400px'
      });
    });
  }

  istEingeloggt(): boolean {
    return this.istEingeloggtStatus;
  }

  benutzername(): string {
    return this.authService.getAktuellerBenutzer()?.name || '';
  }

  toggleMenu() {
    this.menuGeoeffnet = !this.menuGeoeffnet;
  }

  private ladeDaten(): void {
/*    this.benutzerService.getBenutzerAll().subscribe({
      next: benutzerListe => {
        console.log('Benutzer geladen:', benutzerListe);
        this.benutzerListe = benutzerListe;
      },
      error: err => {
        console.error('Fehler beim Laden der Benutzer:', err);
        if (err.status === 401) {
          // nicht eingeloggt
          this.authService.logout();
        }
      }
    });

    this.stadtService.getStaedte().subscribe({
      next: staedte => {
        console.log('Städte geladen:', staedte);
        this.staedte = staedte;
      },
      error: err => {
        console.error('Fehler beim Laden der Städte:', err);
      }
    });

    this.bewerberService.getBewerberprofile().subscribe({
      next: profile => {
        console.log('Bewerberprofile geladen:', profile);
        this.bewerberListe = profile;
      },
      error: err => {
        console.error('Fehler beim Laden der Bewerberprofile:', err);
      }
    });
*/
  }
}
