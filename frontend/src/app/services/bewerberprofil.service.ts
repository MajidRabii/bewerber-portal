import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BewerberProfilViewModel } from '../models/bewerberprofil.model';

@Injectable({
  providedIn: 'root'
})
export class BewerberProfilService {
  private apiUrl = 'https://localhost:7159/api/BewerberProfil';

  constructor(private http: HttpClient) {}

  getAll(): Observable<BewerberProfilViewModel[]> {
    return this.http.get<BewerberProfilViewModel[]>(this.apiUrl);
  }

  getById(id: number): Observable<BewerberProfilViewModel> {
    return this.http.get<BewerberProfilViewModel>(`${this.apiUrl}/${id}`);
  }

  create(data: BewerberProfilViewModel): Observable<BewerberProfilViewModel> {
    return this.http.post<BewerberProfilViewModel>(this.apiUrl, data);
  }

  update(id: number, data: BewerberProfilViewModel): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, data);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
