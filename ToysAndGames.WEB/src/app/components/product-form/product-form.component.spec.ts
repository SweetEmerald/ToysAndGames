import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ProductFormComponent } from './product-form.component';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { ToysService } from 'src/app/services/toys.service.service';
import { ToysServiceMock } from 'src/app/services/toys.service.mock';
import { By } from '@angular/platform-browser';

describe('ProductFormComponent', () => {
  let component: ProductFormComponent;
  let fixture: ComponentFixture<ProductFormComponent>;
  let service: ToysService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule, 
        RouterTestingModule, 
        ReactiveFormsModule], 
      declarations: [ ProductFormComponent ],
      providers: [
        {provide: ToysService, useClass:ToysServiceMock}]
    })
    .compileComponents();
  });

  beforeEach(()=>{
    fixture = TestBed.createComponent(ProductFormComponent);
    component = fixture.componentInstance;
    service = TestBed.inject(ToysService);

    fixture.detectChanges();
  });

  it('should create', () => {
    expect(service).toBeTruthy();
    expect(component).toBeTruthy();
  });

  it('should return invalid form', () => {
    const app =  fixture.componentInstance;
    fixture.detectChanges();

    const form = app.productForm;
    const name = app.productForm.controls["name"];
    const description = app.productForm.controls["description"];
    const ageRestriction = app.productForm.controls["ageRestriction"];
    const companyId = app.productForm.controls["companyId"];
    const price = app.productForm.controls["price"];
    const image = app.productForm.controls["image"];
    
    name.setValue("");
    description.setValue("");
    ageRestriction.setValue(1);
    companyId.setValue(2);
    price.setValue(0);
    image.setValue("");

    expect(form.invalid).toBeTrue();

    fixture.destroy();
  });

  it('should return valid form', () => {
    const app =  fixture.componentInstance;
    fixture.detectChanges();

    const form = app.productForm;
    const name = app.productForm.controls["name"];
    const description = app.productForm.controls["description"];
    const ageRestriction = app.productForm.controls["ageRestriction"];
    const companyId = app.productForm.controls["companyId"];
    const price = app.productForm.controls["price"];
    const image = app.productForm.controls["image"];
    
    name.setValue("Testing");
    description.setValue("Testing description");
    ageRestriction.setValue(1);
    companyId.setValue(2);
    price.setValue(200);
    image.setValue("");

    expect(form.invalid).toBeFalse();

    fixture.destroy();
  });

  it('should return not null companies', () => {
    component.getCompanies(); //returns info from toys.service.mock.ts
    expect(component.companies).not.toBeNull();
  });

  it('should return not null ages', () => {
    component.getAges();
    expect(component.ages).not.toBeNull();
  });

  it('should display title "New Product"',()=>{
    const expected = 'New Product';
    const title = fixture.debugElement.nativeElement.querySelector('legend');
    expect(title.innerHTML).toBe(expected);
  });

  it('should loadData when is an Update', ()=>{
    component.loadData(13); //returns info from toys.service.mock.ts
    expect(component.product.id).toEqual(13);
    expect(component.productForm.get('id')?.value).toEqual(13);
  })

  it('should update a product when send method is called', () => {
    expect(component.productForm.valid).toBeFalsy();
    component.isAnUpdate=true;
    component.productForm.get('id')?.setValue(13);
    component.productForm.get('name')?.setValue('Match box Update');
    component.productForm.get('description')?.setValue('Matchbox Work Team Pack 4 cars');
    component.productForm.get('ageRestriction')?.setValue(6);
    component.productForm.get('companyId')?.setValue(1);
    component.productForm.get('price')?.setValue(125);
    component.productForm.get('image')?.setValue('https://localhost:7239/products/c1b6a9b9-e34f-4a78-8911-f3d982bee04d.jpg')
    expect(component.productForm.valid).toBeTruthy();

    component.send();

    const name = fixture.debugElement.nativeElement.querySelector("#name").value;
    expect(name).toEqual("Match box Update");
    expect(component.isAlert).toBeTrue();

    // const title = fixture.debugElement.nativeElement.querySelector('legend').innerHTML;
    // expect(title).toBe('Update Product');
  });

  it('should call the submitForm method when the button save is submitted',()=>{
    const submitButton = fixture.debugElement.query(By.css('.btn-primary'));
    const fnc = spyOn(component,'send');

    submitButton.triggerEventHandler('ngSubmit', component.send());
    
    expect(fnc).toHaveBeenCalled();
  })

  it('should submit the form when the submit button is clicked',()=>{
    const submitButton = fixture.debugElement.query(By.css('.btn-primary'));
    const fnc = spyOn(component,'send');

    (submitButton.nativeElement as HTMLButtonElement).disabled=false;
    (submitButton.nativeElement as HTMLButtonElement).click();
    fixture.detectChanges();

    expect(fnc).toHaveBeenCalled();
  })  
});
