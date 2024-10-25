import { Component, inject, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// import { debug } from 'console';

@Component({
  selector: 'app-hero-list',
  templateUrl: './hero-list.component.html'
})
export class HeroListComponent {
  public heroes: Hero[] = [];

  baseUrl: string = ''
  http = inject(HttpClient)

  constructor(@Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl)
    this.baseUrl = baseUrl
    this.getHeroes()
  }


  getHeroes() {
    this.http.get<Hero[]>(`${this.baseUrl}api/heroes/getall`).subscribe(result => {
      console.log(result)
      this.heroes = result;
    }, error => console.error(error));
  }

  softDeleteHero(hero: Hero) {

    this.http.delete(`${this.baseUrl}api/heroes/delete/${hero.Id}`).subscribe(result => {
      this.heroes = this.heroes.filter(x => x != hero)
    }, error => {
    }
    );
  }

}

interface Hero {
  Id: number;
  Name: string;
  Alias: string;
  BrandName: string;
  IsActive: boolean;
}
