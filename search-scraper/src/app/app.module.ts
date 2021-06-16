import { NgModule, APP_INITIALIZER } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ConfigurationProvider } from './configuration-provider';
import { AppService } from './app.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';

export function configurationProviderFactory(provider: ConfigurationProvider) {
  return () =>  provider.loadConfig(); 
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule 
  ],
  providers: [
    ConfigurationProvider,    
    { 
      provide: APP_INITIALIZER, 
      useFactory: configurationProviderFactory, 
      deps: [ConfigurationProvider], 
      multi: true 
    }, 
    AppService
  ],
  entryComponents: [
    AppComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
