import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
export interface Product {
id: number;
name: string;
price: number;
}
@Injectable({ providedIn: 'root' })
export class ProductService {
apiUrl = 'http://localhost:5000/api/products';
constructor(private http: HttpClient) {}
getProducts(): Observable<Product[]> 
{ return this.http.get<Product[]>(this.apiUrl); }
addProduct(product: Partial<Product>): Observable<Product> 
{ return this.http.post<Product>(this.apiUrl, product); }
updateProduct(product: Product): Observable<void> 
{ return this.http.put<void>(`${this.apiUrl}/${product.id}`, product); }
deleteProduct(id: number): Observable<void> { return this.http.delete<void>(`$
{this.apiUrl}/${id}`); }
}