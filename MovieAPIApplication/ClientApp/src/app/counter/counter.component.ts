import { Component, NgModule } from '@angular/core';
import { MovieService } from './movie.service';
import { CommonConstants } from './commonConstants';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.css']
})
export class CounterComponent
{
  searchType: string = 't';
  searchKey: string = '';
  response: any;
  commons: CommonConstants = CommonConstants.getInstance();


  constructor(public service: MovieService) {

  }

  DoSearch() {
    this.commons.requestCount++;
    this.service.SearchMovie(this.searchKey, this.searchType).subscribe(
      res => this.response = res,
      error => {
        console.log("Error: ", error);
        this.commons.requestCount--;
        this.response = null;
      },
      () => this.commons.requestCount--
    );

  }

  changeSearchType(type: string) {
    console.log(type);
    this.searchType = type;
  }
}
