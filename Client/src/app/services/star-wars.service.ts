import { PeopleVm } from './../models/people-vm';
import { SearchResults } from './../models/search-results';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class StarWarsService {
  baseUrl = environment.apiUrl + 'swapi/';

  constructor(private http: HttpClient) { }
  getAll(): Observable<PeopleVm> {
    return this.http.get<PeopleVm>(`${this.baseUrl}getAll`);
  }
  get(id: string): Observable<Person> {
    return this.http.get<Person>(`${this.baseUrl}?id=${id}`);
  }
  getPeople(entity:{url: string}): Observable<PeopleVm> {
    return this.http.post<PeopleVm>(`${this.baseUrl}getPeople`, entity);
  }
}
