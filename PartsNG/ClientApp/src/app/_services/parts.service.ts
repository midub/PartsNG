import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Part } from '../_models/part';

@Injectable({
  providedIn: 'root'
})
export class PartsService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/parts";
  }

  getParts(): Observable<Part[]> {
    return this.http.get<Part[]>(this.baseUrl);
  }

  getPart(partId: number): Observable<Part> {
    return this.http.get<Part>(this.baseUrl + '/' + partId.toString());
  }

  postPart(part: Part): Observable<Part> {
    return this.http.post<Part>(this.baseUrl, part);
  }

  deletePart(partId: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/' + partId.toString());
  }

  putPart(part: Part): Observable<any> {
    return this.http.put(this.baseUrl + '/' + part.id.toString(), part);
  }

}
