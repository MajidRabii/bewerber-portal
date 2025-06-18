import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Abschlussart {
  id?: number;	
  code: number;
  name_DE: string;
  name_EN?: string;
  aktiv: boolean;
}

@Injectable({ providedIn: 'root' })
export class AbschlussartService {
  private apiUrl = 'https://localhost:7159/api/abschlussart';	
  //private baseUrl = 'https://localhost:7159/api/stadt';  

  constructor(private http: HttpClient) {}

  getAbschlussartAll(): Observable<Abschlussart[]> {
    return this.http.get<Abschlussart[]>(this.apiUrl);
  }

  getAbschlussartById(id: number): Observable<Abschlussart> {
    return this.http.get<Abschlussart>(`${this.apiUrl}/${id}`);
  }

  addAbschlussart(abschlussart: Omit<Abschlussart, 'id'>): Observable<Abschlussart> {
    return this.http.post<Abschlussart>(this.apiUrl, abschlussart);
  }

  updateAbschlussart(abschlussart: Abschlussart): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${abschlussart.id}`, abschlussart);
  }

  deleteAbschlussart(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
