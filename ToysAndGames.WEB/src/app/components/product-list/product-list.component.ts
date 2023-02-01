import { Component, OnInit, TrackByFunction } from '@angular/core';
import { Product } from 'src/app/interfaces/product.interface';
import { ToysService } from 'src/app/services/toys.service.service';


@Component({
  selector: 'product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  
  products: Product[] = [];
  placements = ['top', 'left', 'right', 'bottom'];
  popoverTitle = 'Delete product';
  popoverMessage = 'Are you really <b>sure</b> you want to do this product?';
  confirmText = 'Yes <i class="fas fa-check"></i>';
  cancelText = 'No <i class="fas fa-times"></i>';
  confirmClicked = false;
  cancelClicked = false;
  trackByValue: TrackByFunction<string> = (index, value) => value;

  constructor(private service: ToysService) {}

  ngOnInit(): void {
    this.service.getProducts$().subscribe(result =>{
      this.products = result;
    });
  }

  deleteProduct(id:any):void
  {
    this.service.deleteProducts$(id).subscribe();
    this.products = this.products.filter(p => p.id!=id);
  }
}
