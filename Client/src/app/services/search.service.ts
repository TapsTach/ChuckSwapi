import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SearchResults } from '../models/search-results';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  baseUrl = environment.apiUrl + 'search/';

  constructor(private http: HttpClient) { }
  search(text: string): Observable<SearchResults> {
    return this.http.get<SearchResults>(`${this.baseUrl}?query=${text}`);
  }
}
