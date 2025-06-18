import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Studiengang {
  id?: number;	
  code: number;
  name_DE: string;
  name_EN?: string;
  aktiv: boolean;
}

@Injectable({ providedIn: 'root' })
export class StudiengangService {
  private apiUrl = 'https://localhost:7159/api/studiengang';	
  //private baseUrl = 'https://localhost:7159/api/stadt';  

  constructor(private http: HttpClient) {}

  getStudiengangAll(): Observable<Studiengang[]> {
    return this.http.get<Studiengang[]>(this.apiUrl);
  }

  getStudiengaengById(id: number): Observable<Studiengang> {
    return this.http.get<Studiengang>(`${this.apiUrl}/${id}`);
  }

  addStudiengaeng(studiengang: Omit<Studiengang, 'id'>): Observable<Studiengang> {
    return this.http.post<Studiengang>(this.apiUrl, studiengang);
  }

  updateStudiengaeng(studiengang: Studiengang): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${studiengang.id}`, studiengang);
  }

  deleteStudiengaeng(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
