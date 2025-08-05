import { Component, OnInit } from '@angular/core';
import { ProductService, Product } from './product.service';
// AppComponent is the root component of the Angular app

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
    })
    export class AppComponent implements OnInit {
    products: Product[] = []; 
    newProduct: Partial<Product> = { name: '', price: 0 }; 
    editProduct: Product | null = null; 
    constructor(private productService: ProductService) {}
    ngOnInit() { this.load(); } 
    load() { this.productService.getProducts().subscribe(ps => this.products =
    ps); }
    save() {
    if (!this.newProduct.name || this.newProduct.price === undefined) return;
    this.productService.addProduct(this.newProduct).subscribe(() => {
    this.newProduct = { name: '', price: 0 };
    this.load();
    });
    }
    startEdit(product: Product) { this.editProduct = { ...product }; }
    update() {
    if (!this.editProduct) return;
    this.productService.updateProduct(this.editProduct).subscribe(() => {
    this.editProduct = null;
    this.load();
    });
    }
    delete(id: number) { this.productService.deleteProduct(id).subscribe(() =>
    this.load()); }
    cancelEdit() { this.editProduct = null; }
    }