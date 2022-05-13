import { PeopleVm } from './../models/people-vm';
import { StarWarsService } from './../services/star-wars.service';
import { Person } from './../models/person';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {
  people: Person[] = [];
  result: PeopleVm;
  constructor(private swapSvc: StarWarsService) { }

  ngOnInit(): void {
    this.getAll();
  }
  getAll() {
    this.swapSvc.getAll().subscribe(result=> {
      this.result = result;
    })
  }

  getPeople(url: string) {
    this.swapSvc.getPeople({url}).subscribe(results => {
      this.result = results;
    })
  }
}
