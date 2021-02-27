import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component'; 
import { SharedModule } from './shared/shared.module';
import { ConfirmationService, MessageService } from 'primeng/api';
import { API_BASE_URL } from '../infrastructure/services-api/rlds-api';
import { UserModule } from './user/user.module';
import { LayoutModule } from './layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import { RldsModule } from './rlds/rlds.module';

import PL_LOCALE from '@angular/common/locales/pl'; 
import { AuthInterceptor } from '../infrastructure/interceptors/auth-interceptor';
import { DictionaryModule } from './dictionary/dictionary.module';
registerLocaleData(PL_LOCALE, 'pl');

const routes = [
  { path: '', loadChildren: () => import('./rlds/rlds.module').then(m => m.RldsModule) },
  { path: 'user', loadChildren: () => import('./user/user.module').then(m => m.UserModule)},
  { path: 'rlds', loadChildren: () => import('./rlds/rlds.module').then(m => m.RldsModule)},
  { path: 'dictionary', loadChildren: () => import('./dictionary/dictionary.module').then(m => m.DictionaryModule)},
];

@NgModule({
  declarations: [
    AppComponent,
    
  ],
  imports: [
    BrowserAnimationsModule,

    RldsModule,
    UserModule,
    DictionaryModule,

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
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
    {
      provide: API_BASE_URL,
      useFactory: () => {
        return 'https://localhost:44378';
       }
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
