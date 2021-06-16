import {throwError as observableThrowError,  Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigurationProvider } from './configuration-provider';
import { map } from 'rxjs/operators';

@Injectable()
export class AppService {

    private authHeaders: HttpHeaders = new HttpHeaders();;
    private options = ({ headers: this.authHeaders });
  
    constructor(private http: HttpClient,
      private configurationProvider: ConfigurationProvider) {
        this.authHeaders.append('Content-Type', 'application/json');
    }

    searchGoogle(searchTerm: string, urlToMatch: string): Observable<number[]> {
        const url = `${this.configurationProvider.config.environment.api}/Search/SearchGoogle/${searchTerm}/Match/${urlToMatch}/`;
        return this.http.get<number[]>(url, this.options).pipe(
          map((res) => {
            return res;
          }));
      }
}