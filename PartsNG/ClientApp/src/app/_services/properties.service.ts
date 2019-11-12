import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Property } from '../_models/Property';

@Injectable({
  providedIn: 'root'
})
export class PropertiesService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/properties";
  }

  getProperties(): Observable<Property[]> {
    return this.http.get<Property[]>(this.baseUrl);
  }

  getProperty(PropertyId: number): Observable<Property> {
    return this.http.get<Property>(this.baseUrl + '/' + PropertyId.toString());
  }

  postProperty(Property: Property): Observable<Property> {
    return this.http.post<Property>(this.baseUrl, Property);
  }

  deleteProperty(PropertyId: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/' + PropertyId.toString());
  }

  putProperty(Property: Property): Observable<any> {
    return this.http.put(this.baseUrl + '/' + Property.id.toString(), Property);
  }
}
