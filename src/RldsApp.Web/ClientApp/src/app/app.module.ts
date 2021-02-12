import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from './shared/shared.module';
import { ConfirmationService, MessageService } from 'primeng/api';
import { API_BASE_URL } from '../infrastructure/services-api/rlds-api';
import { UserModule } from './user/user.module';
import { LayoutModule } from './layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';

import PL_LOCALE from '@angular/common/locales/pl'; 
registerLocaleData(PL_LOCALE, 'pl');

const routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'user', component: UserModule, pathMatch: 'full' },
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    SharedModule,
    LayoutModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ],
  providers: [
    ConfirmationService,
    MessageService,
    { provide: LOCALE_ID, useValue: 'pl' },
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
