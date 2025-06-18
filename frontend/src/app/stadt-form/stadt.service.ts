import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Stadt {
  id?: number;	
  code: number;
  name: string;
  bundesland?: string;
  aktiv: boolean;
}

@Injectable({ providedIn: 'root' })
export class StadtService {
  private apiUrl = 'https://localhost:7159/api/stadt';	
  //private baseUrl = 'https://localhost:7159/api/stadt';  

  constructor(private http: HttpClient) {}

  getStadtAll(): Observable<Stadt[]> {
    return this.http.get<Stadt[]>(this.apiUrl);
  }

  getStadtById(id: number): Observable<Stadt> {
    return this.http.get<Stadt>(`${this.apiUrl}/${id}`);
  }

  addStadt(stadt: Omit<Stadt, 'id'>): Observable<Stadt> {
    return this.http.post<Stadt>(this.apiUrl, stadt);
  }

  updateStadt(stadt: Stadt): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${stadt.id}`, stadt);
  }

  deleteStadt(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
