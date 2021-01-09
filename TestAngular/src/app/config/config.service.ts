import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Query } from './query.model';
import { Observable } from 'rxjs';
import { Palindromes } from './palindromes.model';

@Injectable({
  providedIn: 'root'
})

export class ConfigService {
  constructor(private http: HttpClient) { }

  requestOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json',
      'Access-Control-Allow-Headers': 'Content-Type',
    }),
  };

  configUrl = 'http://localhost:5000/api/Query';


  sendPostRequest(request: Query): Observable<Palindromes> {
    return this.http.post<Palindromes>(this.configUrl, request, this.requestOptions);
  }

}
