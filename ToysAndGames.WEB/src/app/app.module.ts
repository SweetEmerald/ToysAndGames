import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmationPopoverModule }  from 'angular-confirmation-popover';

import { HomeComponent } from './home.component';
import { NotFoundComponent } from './not-found.component';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { TokenInterceptorService } from './services/token.interceptor.service';
import { ProductFormComponent } from './components/product-form/product-form.component';

const routes:Routes=[
  {path:'', component:ProductListComponent, pathMatch:'full'},
  {path:'product/:id', component:ProductFormComponent},
  {path:'product', component:ProductFormComponent},
  {path:'**', component:NotFoundComponent}
]

@NgModule({
  declarations: [
    HomeComponent,
    NotFoundComponent,
    AppComponent,
    NavbarComponent,
    ProductListComponent,
    ProductFormComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ConfirmationPopoverModule.forRoot({confirmButtonType:'danger'})    
  ],
  providers: [{provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi:true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
