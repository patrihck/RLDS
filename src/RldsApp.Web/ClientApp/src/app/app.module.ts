import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './shared/shared.module';
import { MessageService } from 'primeng/api';
import { API_BASE_URL } from '../infrastructure/services-api/rlds-api';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    SharedModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
    ], { relativeLinkResolution: 'legacy' })
  ],
  providers: [MessageService,
    {
      provide: API_BASE_URL,
      useFactory: () => {
        return 'https://localhost:44304/';
       }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
