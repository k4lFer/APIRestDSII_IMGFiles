import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private http: HttpClient) { }
  apiURL = "http://localhost:5216/Gallery";
 // http = inject(HttpClient);

  insertGallery(gallery : FormData):Observable<any>{
    return  this.http.post<FormData>(`${this.apiURL}/Insert/`,gallery);
  }

}
