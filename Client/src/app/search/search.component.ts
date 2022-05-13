import { SearchService } from './../services/search.service';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { SearchResults } from '../models/search-results';
import { debounceTime, distinctUntilChanged, filter, tap } from 'rxjs/operators';
import { fromEvent } from 'rxjs';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent implements OnInit, AfterViewInit {
  @ViewChild('search') input: ElementRef;

  searchResult: SearchResults = new SearchResults();
  searchText = '';

  constructor(
    private searchSvc: SearchService
  ) {
    this.search();
  }

  ngOnInit(): void {
  }

  search() {
    this.searchSvc.search(this.searchText).subscribe(results => {
      this.searchResult = results;
    });
  }
  ngAfterViewInit() {
    fromEvent(this.input.nativeElement, 'keyup')
      .pipe(
        filter(Boolean),
        debounceTime(800),
        distinctUntilChanged(),
        tap((text) => {
          this.searchText = this.input.nativeElement.value;
          this.search()
        })
      )
      .subscribe();
  }
}
