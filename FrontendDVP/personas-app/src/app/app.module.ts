import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { IndicatorsModule } from './shared';
import { NotificationModule } from './services';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatListModule } from '@angular/material/list';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { StoreModule } from '@ngrx/store'; 
import { effects, reducers } from './store';
import { EffectsModule } from '@ngrx/effects';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { environment } from '@src/environments/environment.dev';
import { MenuListComponent } from './components/menu-list/menu-list.component';
import { HeaderComponent } from './components/header/header.component';
import { AuthInterceptor } from './AuthInterceptor';

const StoreDevTools = !environment.production ? StoreDevtoolsModule.instrument({maxAge: 50}) : [];

@NgModule({
  declarations: [
    AppComponent,
    MenuListComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    IndicatorsModule,
    NotificationModule.forRoot(),

    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    FlexLayoutModule,
    MatListModule,
    StoreDevTools,
    StoreModule.forRoot(reducers, {
      runtimeChecks:{
        strictActionImmutability: true,
        strictStateImmutability: true
      }
    }),
    EffectsModule.forRoot(effects),
    HttpClientModule,


    
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
