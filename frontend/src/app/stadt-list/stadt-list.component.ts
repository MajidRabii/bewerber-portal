import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { StadtService, Stadt } from '../stadt-form/stadt.service';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCardModule } from '@angular/material/card';
import { RouterModule, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../dialogs/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-stadt-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatPaginatorModule,
  ],
  templateUrl: './stadt-list.component.html',
  styleUrls: ['./stadt-list.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class StadtListComponent implements OnInit {
  dataSource = new MatTableDataSource<Stadt>();
  loading = true;
  displayedColumns = ['code', 'name', 'bundesland', 'aktiv', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private stadtService: StadtService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadStaedte();
  }

  loadStaedte(): void {
    this.stadtService.getStadtAll().subscribe({
      next: (data) => {
        this.dataSource.data = data;
        this.dataSource.paginator = this.paginator;
        this.loading = false;
      },
      error: (err) => {
        console.error('Fehler beim Laden der Städte:', err);
        this.loading = false;
      }
    });
  }

  editStadt(stadt: Stadt): void {
    this.router.navigate(['/stadt-form'], { state: { stadt } });
  }

  createNew(): void {
    this.router.navigate(['/stadt-form']);
  }

  deleteStadt(id: number): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result === true) {
        this.stadtService.deleteStadt(id).subscribe({
          next: () => this.loadStaedte(),
          error: err => console.error('Fehler beim Löschen der Stadt:', err)
        });
      }
    });
  }

  confirmDelete(row: any) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.deleteStadt(row.id);
      }
    });
  }
}
