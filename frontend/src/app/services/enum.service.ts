import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnumItem } from '../models/enum-item.model';

@Injectable({ providedIn: 'root' })
export class EnumService {
  private apiUrl = 'https://localhost:7159/api/enums';

  constructor(private http: HttpClient) {}

  getDeutsch(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/deutsch`);
  }
  getNiveau(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/niveau`);
  }
  getEnglisch(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/englisch`);
  }
  getZertifikate(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/zertifikate`);
  }
  getPersisch(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/persisch`);
  }
  getFuehrerschein(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/fuehrerschein`);
  }
  getEinsatzwunsch(): Observable<EnumItem[]> {
    return this.http.get<EnumItem[]>(`${this.apiUrl}/einsatzwunsch`);
  }
}
