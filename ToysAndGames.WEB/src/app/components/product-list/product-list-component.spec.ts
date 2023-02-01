import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ToysService } from 'src/app/services/toys.service.service';
import { RouterTestingModule } from '@angular/router/testing';
import { ProductListComponent } from './product-list.component';

describe('ProductListComponent', () => {
  let component: ProductListComponent;
  let fixture: ComponentFixture<ProductListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule, RouterTestingModule], 
      declarations: [ ProductListComponent ],
      providers: [ToysService]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    const service: ToysService = TestBed.inject(ToysService);
    expect(service).toBeTruthy();
    expect(component).toBeTruthy();
  });
});
