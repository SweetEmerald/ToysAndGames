import { HttpClient } from "@angular/common/http";
import { TestBed } from "@angular/core/testing";
import { of } from "rxjs";
import { ToysService } from "./toys.service.service";

describe('ToysService',()=>{
    let httpClientSpy: jasmine.SpyObj<HttpClient>;
    let service: ToysService;
    let PRODUCTS = [
        {
          "id": 13,
          "name": "Match box2",
          "description": "Matchbox Work Team Pack 4 cars",
          "ageRestriction": 6,
          "companyId": 1,
          "companyName": "Mattel",
          "price": 125,
          "image": "https://localhost:7239/products/c1b6a9b9-e34f-4a78-8911-f3d982bee04d.jpg"
        },
        {
          "id": 14,
          "name": "The Razor Crest2",
          "description": "Display base for the Mandalorian LEGO Star Wars minifigures",
          "ageRestriction": 3,
          "companyId": 3,
          "companyName": "Lego",
          "price": 3000,
          "image": "https://localhost:7239/products/6d2585c1-a82e-4f7e-9aed-5ed99f75c085.jpg"
        },
        {
          "id": 18,
          "name": "Potato Head",
          "description": "Potato Head - Mr. Potato Head",
          "ageRestriction": 3,
          "companyId": 6,
          "companyName": "Hasbro",
          "price": 1000,
          "image": "https://localhost:7239/products/14909e38-3bc5-48cf-9e64-7b472231fc23.jpg"
        },
        {
          "id": 19,
          "name": "Superman 2",
          "description": "DC Comics Stylized Superman",
          "ageRestriction": 6,
          "companyId": 5,
          "companyName": "Bandai",
          "price": 524,
          "image": "https://localhost:7239/products/a93a9669-bb67-4f3b-852a-d0edf7e272d1.jpg"
        },
        {
          "id": 59,
          "name": "safs",
          "description": "saFAS",
          "ageRestriction": 5,
          "companyId": 1,
          "companyName": "Mattel",
          "price": 235,
          "image": "https://localhost:7239/products/a031719c-af8d-4aeb-8905-66a8863a1c2a.jpg"
        }
      ];
    
    let COMPANIES=[
        {
          "id": 1,
          "name": "Mattel",
          "products": null
        },
        {
          "id": 2,
          "name": "Disney ",
          "products": null
        },
        {
          "id": 3,
          "name": "Lego",
          "products": null
        },
        {
          "id": 4,
          "name": "Fisher-Price",
          "products": null
        },
        {
          "id": 5,
          "name": "Bandai",
          "products": null
        },
        {
          "id": 6,
          "name": "Hasbro",
          "products": null
        }
      ];

    beforeEach(() => {
      let httpClientSpyObj = jasmine.createSpyObj('HttpClient', ['get']);
      TestBed.configureTestingModule({
        providers: [
          ToysService,
          {
            provide: HttpClient,
            useValue: httpClientSpyObj,
          },
        ],
      });
      service = TestBed.inject(ToysService);
      httpClientSpy = TestBed.inject(HttpClient) as jasmine.SpyObj<HttpClient>;
    });

    it('should return expected products when getProducts is called', (done: DoneFn) => {
        httpClientSpy.get.and.returnValue(of(PRODUCTS));
        service.getProducts$().subscribe({
          next: (products) => {
            expect(products).toEqual(PRODUCTS);
            done();
          },
          error: () => {
          done.fail;
          },
        });
        expect(httpClientSpy.get).toHaveBeenCalledTimes(1);
    });

    it('should return expected single product', (done: DoneFn) => {
        httpClientSpy.get.and.returnValue(of(PRODUCTS[0]));
        service.getProduct$(13).subscribe({
          next: (product) => {
            expect(product).toEqual(PRODUCTS[0]);
            done();
          },
          error: () => {
          done.fail;
          },
        });
        expect(httpClientSpy.get).toHaveBeenCalledTimes(1);
    });

    it('should return expected companies when getCompanies is called', (done: DoneFn) => {
        httpClientSpy.get.and.returnValue(of(COMPANIES));
        service.getCompanies$().subscribe({
          next: (companies) => {
            expect(companies).toEqual(COMPANIES);
            done();
          },
          error: () => {
          done.fail;
          },
        });
        expect(httpClientSpy.get).toHaveBeenCalledTimes(1);
    });

})