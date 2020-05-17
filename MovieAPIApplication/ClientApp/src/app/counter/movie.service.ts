import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import "rxjs/add/operator/map"
import { CommonConstants } from './commonConstants';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable()

export class MovieService {

  constructor(private http: HttpClient) { }

  public SearchMovie(searchKey: string, searchType: string) {
    var url: string = 'https://www.omdbapi.com/?apikey=8a75ab28&{type}=';
    url = url.replace('{type}', searchType);
    return this.http.get(url + searchKey);
  }
}
