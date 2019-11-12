import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Package } from '../_models/Package';

@Injectable({
  providedIn: 'root'
})
export class PackagesService {
  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl + "api/packages";
  }

  getPackages(): Observable<Package[]> {
    return this.http.get<Package[]>(this.baseUrl);
  }

  getPackage(packageId: number): Observable<Package> {
    return this.http.get<Package>(this.baseUrl + '/' + packageId.toString());
  }

  postPackage(packageObj: Package): Observable<Package> {
    return this.http.post<Package>(this.baseUrl, packageObj);
  }

  deleteProperty(packageId: number): Observable<any> {
    return this.http.delete(this.baseUrl + '/' + packageId.toString());
  }

  putProperty(packageObj: Package): Observable<any> {
    return this.http.put(this.baseUrl + '/' + packageObj.id.toString(), packageObj);
  }
}
