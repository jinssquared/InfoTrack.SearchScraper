import { Component } from '@angular/core';
import {FormControl } from '@angular/forms';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(private appService: AppService) {}
  searchTerm = new FormControl('');
  urlToMatch = new FormControl('');

  title = 'InfoTrack Search Scraper';
  searchResult: number[] = [];

  searchGoogle() {
    this.appService.searchGoogle(this.searchTerm.value, this.urlToMatch.value).subscribe(x => this.searchResult = x);
  }

  
}
