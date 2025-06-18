import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Beruf {
  id?: number;	
  code: number;
  name_DE: string;
  name_EN?: string;
  aktiv: boolean;
}

@Injectable({ providedIn: 'root' })
export class BerufService {
  private apiUrl = 'https://localhost:7159/api/beruf';	
  //private baseUrl = 'https://localhost:7159/api/stadt';  

  constructor(private http: HttpClient) {}

  getBerufAll(): Observable<Beruf[]> {
    return this.http.get<Beruf[]>(this.apiUrl);
  }

  getBerufById(id: number): Observable<Beruf> {
    return this.http.get<Beruf>(`${this.apiUrl}/${id}`);
  }

  addBeruf(beruf: Omit<Beruf, 'id'>): Observable<Beruf> {
    return this.http.post<Beruf>(this.apiUrl, beruf);
  }

  updateBeruf(beruf: Beruf): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${beruf.id}`, beruf);
  }

  deleteBeruf(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
