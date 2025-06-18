import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Benutzer {
  id: number;	
  name: string;
  email: string;
  password: string;
  type: string;
  status: boolean;
}

@Injectable({ providedIn: 'root' })
export class BenutzerService {
  private apiUrl = 'https://localhost:7159/api/user';	
  //private baseUrl = 'https://localhost:7159/api/stadt';  

  constructor(private http: HttpClient) {}

  getBenutzerAll(): Observable<Benutzer[]> {
    return this.http.get<Benutzer[]>(this.apiUrl);
  }

  getBenutzerById(id: number): Observable<Benutzer> {
    return this.http.get<Benutzer>(`${this.apiUrl}/${id}`);
  }

  addBenutzer(benutzer: Omit<Benutzer, 'id'>): Observable<Benutzer> {
    return this.http.post<Benutzer>(this.apiUrl, benutzer);
  }

  updateBenutzer(benutzer: Benutzer): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${benutzer.id}`, benutzer);
  }

  deleteBenutzer(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
