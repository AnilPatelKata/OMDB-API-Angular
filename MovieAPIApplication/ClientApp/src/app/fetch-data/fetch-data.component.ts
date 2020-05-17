import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public movies: Movie[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Movie[]>(baseUrl + 'api/MovieSearch/Movies').subscribe(result =>
    {
      this.movies = result;
    }
    ,error => console.error(error));
  }
}

interface Movie {
  title: string;
  year: string;
  rated: string;
  released: string;
  runtime: string;
  Genre: string;
  Director: string;
  Writer: string;
  actors: string;
  plot: string;
  language: string;
  country: string;
  awards: string;
  metascore: string;

}
