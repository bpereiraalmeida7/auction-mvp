import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DataTablesModule } from 'angular-datatables';
import { CurrencyMaskModule, CurrencyMaskConfig, CURRENCY_MASK_CONFIG } from "ng2-currency-mask";
import { NgxSpinnerModule } from "ngx-spinner";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuctionListComponent } from './auction/auctions-list/auction-list.component';
import { AuctionFormComponent } from './auction/auction-form/auction-form.component';

import { LoginComponent } from './account/login/login.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { HomeComponent } from './layout/home/home.component';

import { httpInterceptorProviders } from './account/shared/http-interceptors';

export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "left",
  allowNegative: false,
  decimal: ",",
  precision: 2,
  prefix: "R$ ",
  suffix: "",
  thousands: "."
};
@NgModule({
  declarations: [
    AppComponent,
    AuctionListComponent,
    AuctionFormComponent,
    LoginComponent,
    AuthenticationComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    DataTablesModule,
    CurrencyMaskModule,
    NgxSpinnerModule
  ],
  providers: [
    httpInterceptorProviders,
    { provide: CURRENCY_MASK_CONFIG, useValue: CustomCurrencyMaskConfig }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
