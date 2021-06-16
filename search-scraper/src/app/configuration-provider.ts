import {Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable()
export class ConfigurationProvider {
 
  config: any;

  private httpClient: HttpClient;

  constructor(private handler: HttpBackend) {  
    this.httpClient = new HttpClient(handler);
  }
  
  public loadConfig(): Promise<any> {
    const promise = this.httpClient.get('../../assets/config_client.json').pipe(
      map(res => {
        this.config = res; 
      })).toPromise();

    return promise;
  }
}