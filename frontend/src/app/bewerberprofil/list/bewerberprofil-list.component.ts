import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BewerberProfilService } from '../../services/bewerberprofil.service';
import { BewerberProfilViewModel } from '../../models/bewerberprofil.model';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatDividerModule } from '@angular/material/divider';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSortModule } from '@angular/material/sort';
import { MatRippleModule } from '@angular/material/core';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../../dialogs/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-bewerber-profil-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatPaginatorModule,
    MatDividerModule,
    MatTooltipModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatSortModule,
    MatRippleModule,
    MatCheckboxModule,
    MatListModule,
    MatSelectModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    FormsModule
  ],
  templateUrl: './bewerberprofil-list.component.html',
  styleUrls: ['./bewerberprofil-list.component.scss']
})
export class BewerberProfilListComponent implements OnInit {
  dataSource = new MatTableDataSource<BewerberProfilViewModel>();
  displayedColumns: string[] = ['anrede', 'vorname', 'nachname', 'geburtstag', 'beruf1', 'erfahrung1', 'status', 'actions'];
  loading = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private bewerberProfilService: BewerberProfilService,
    private snackBar: MatSnackBar,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadBewerberProfile();
  }

  loadBewerberProfile(): void {
    this.loading = true;
    this.bewerberProfilService.getAll().subscribe(data => {
      this.dataSource.data = data;
      this.loading = false;
      this.dataSource.paginator = this.paginator;
    });
  }

  createNewBewerberProfil() {
    this.router.navigate(['/bewerberprofil-form']);
  }

  viewBewerberProfil(item: BewerberProfilViewModel): void {
    this.router.navigate(['/bewerberprofil-form', item.personId], { queryParams: { view: true } });
    //this.router.navigate(['/bewerberprofil-form', item.personId]);
  }

  editBewerberProfil(item: BewerberProfilViewModel): void {
    this.router.navigate(['/bewerberprofil-form', item.personId]);
  }

  deleteBewerberProfil(id: number): void {
    this.bewerberProfilService.delete(id).subscribe({
      next: () => {
        this.snackBar.open('Profil gelöscht.', 'OK', { duration: 3000 });
        this.  loadBewerberProfile(); // refresh list
      },
      error: (err) => {
        console.error('Fehler beim Löschen:', err);
        this.snackBar.open('Fehler beim Löschen des Profils.', 'OK', { duration: 4000 });
      }
    });
  }

  confirmDelete(row: any) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteBewerberProfil(result.person_Id);
      }
    });
  }
}
