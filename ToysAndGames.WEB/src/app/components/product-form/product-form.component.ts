import { ResourceLoader } from '@angular/compiler';
import { Component, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Age } from 'src/app/interfaces/age.interface';
import { Companies } from 'src/app/interfaces/companies.interface';
import { Product } from 'src/app/interfaces/product.interface';
import { ToysService } from 'src/app/services/toys.service.service';

@Component({
  selector: 'product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  @Input() isAnUpdate!:boolean;

  product!: Product;
  companies: Companies[] = [];
  ages: Age[] = [];
  isAlert:boolean = false;
  savedProduct:boolean = false;
  title:string ="New Product";

 
  constructor(private formBuilder: FormBuilder, private service: ToysService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getAges();
    this.getCompanies();

    this.route.paramMap.subscribe((paramMap:any)=>{
      const{params}=paramMap
      if(params.id!=null)
      {
        this.loadData(params.id);
        this.isAnUpdate = true;
        this.title="Update Product";
      }
    });
  }

  loadData(id:any)
  {
    this.service.getProduct$(id).subscribe((result:Product) => {
      this.product=result;
      this.productForm.setValue({
        id:this.product.id,
        name:this.product.name,
        description: this.product.description,
        ageRestriction: this.product.ageRestriction,
        companyId: this.product.companyId,
        price: this.product.price,
        image: this.product.image
      })
    });
  }

  productForm = new FormGroup(
    {
      id: new FormControl({value:0, disabled:!this.isAnUpdate}),
      name: new FormControl("", Validators.required),
      description: new FormControl("", Validators.required),
      ageRestriction: new FormControl(1, Validators.required),
      companyId: new FormControl(0, Validators.required),
      price: new FormControl(0, Validators.required),
      image: new FormControl()
    });

  getCompanies()
  {
    this.service.getCompanies$().subscribe(result =>{
      this.companies = result;
    });
  }

  getAges()
  {
    for (let i = 0; i <= 100; i++) {
      this.ages[i] = {ageId:i, numberage:i};
    }
  }

  onFileSelect(event: any)
  {
    //console.log(event);
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.productForm.patchValue({
        image: file
      });
    }
  }

  // cambia(event:any)
  // {
  //   console.log(event)
  //   console.log(this.productForm.get('companyId')?.value);
  // }

  send(){
    if(this.productForm.valid)
    {
      var formData: any = new FormData();
      
      if(this.isAnUpdate)
        formData.append('id', this.productForm.get('id')?.value);  

      formData.append('name', this.productForm.get('name')?.value);
      formData.append('description', this.productForm.get('description')?.value);
      formData.append('ageRestriction', this.productForm.get('ageRestriction')?.value);
      formData.append('companyId', this.productForm.get('companyId')?.value);
      formData.append('price', this.productForm.get('price')?.value);
      formData.append('image', this.productForm.get('image')?.value);
      
      if(this.isAnUpdate)
      {
        this.service.updateProduct$(formData).subscribe(result=>this.product=result);
      }
      else
      {
        console.log(formData);
        this.service.createProduct$(formData).subscribe(result=>this.product=result);
        this.savedProduct=true;
      }
      this.isAlert=true;
    }
  }

  closeAlert()
  {
    this.isAlert=false;
  }

}
