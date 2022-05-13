import { ChuckNorrisService } from './../services/chuck-norris.service';
import { Joke } from './../models/joke';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.scss']
})
export class JokesComponent implements OnInit {

  categories: string[] = [];
  activeCategory = '';
  joke: Joke = new Joke();

  constructor(private jokeSvc: ChuckNorrisService) { }
  changeCategory(cat: string) {
    this.activeCategory = cat;
    this.getRandomJoke();
  }
  ngOnInit(): void {
    this.jokeSvc.getCategories().subscribe(cats => {
      this.categories = cats;
      this.activeCategory = cats[0];
      this.getRandomJoke();
    });
  }
  getRandomJoke() {
    this.jokeSvc.getRandomJoke(this.activeCategory).subscribe(joke => {
      this.joke = joke;
    })
  }

}
