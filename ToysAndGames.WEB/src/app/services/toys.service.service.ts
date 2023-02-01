import { HttpClient, HttpParams} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Companies } from '../interfaces/companies.interface';
import { Product } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root'
})
export class ToysService {

  url:string = 'https://localhost:7175/api/products';
  
  constructor(private http: HttpClient) { }
  
  getCompanies$():Observable <Companies[]>
  {
    return this.http.get<Companies[]>('https://localhost:7175/api/companies');
  }

  getProducts$():Observable <Product[]>
  {
    return this.http.get<Product[]>(this.url);
  }

  getProduct$(id:any):Observable <Product>
  {
    return this.http.get<Product>(this.url + '/' + id);
  }

  updateProduct$(formData: FormData)
  {
    // formData.forEach((value,key) => {
    //   console.log(key+" "+value)
    // });
    return this.http.put<Product>(this.url, formData);
  }

  createProduct$(formData: FormData):Observable<Product>
  {
    return this.http.post<Product>(this.url, formData);
  }

  deleteProducts$(id:any)
  {
    return this.http.delete(this.url+'/'+id,id);
  }

}
