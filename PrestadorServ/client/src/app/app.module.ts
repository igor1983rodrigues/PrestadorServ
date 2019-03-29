import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { NgxCurrencyModule } from 'ngx-currency';
import { CurrencyMaskConfig } from 'ngx-currency/src/currency-mask.config';
// import localePtExtra from '';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

// registerLocaleData(localePt, 'pt', localePtExtra);
registerLocaleData(localePt, 'pt');

const optionNgxCurrency:CurrencyMaskConfig = {
  align: "right",
  allowNegative: true,
  allowZero: true,
  decimal: ",",
  precision: 2,
  prefix: "R$ ",
  suffix: "",
  thousands: ".",
  nullable: true
};

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxCurrencyModule.forRoot(optionNgxCurrency),
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: LOCALE_ID,
      useValue: "pt-BR"
    }
  ],
  exports: [NgxCurrencyModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
