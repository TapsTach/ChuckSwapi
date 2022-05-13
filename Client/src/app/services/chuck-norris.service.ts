import { Joke } from './../models/joke';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChuckNorrisService {

  baseUrl = environment.apiUrl + 'chuck/';

  constructor(private http: HttpClient) { }
  getCategories(): Observable<string[]> {
    return this.http.get<string[]>(`${this.baseUrl}getCategories`);
  }
  getRandomJoke(category:string): Observable<Joke> {
    return this.http.get<Joke>(`${this.baseUrl}getRandomJoke?category=${category}`);
  }
}
