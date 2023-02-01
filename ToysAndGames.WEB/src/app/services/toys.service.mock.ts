import { Observable, of } from "rxjs";
import { Product } from "../interfaces/product.interface";

//This mock ir for the component test where the service is called
export class ToysServiceMock{
    getProduct$(id:any)
  {
    return of({
        "id": 13,
        "name": "Match box Mock",
        "description": "Matchbox Work Team Pack 4 cars",
        "ageRestriction": 6,
        "companyId": 1,
        "companies": {
          "companyId": 1,
          "name": "Mattel",
          "products": [
            null
          ]
        },
        "price": 125,
        "image": "https://localhost:7239/products/378a32cc-f990-4819-bb95-28331613407b.jpg"
      });
  }

  getCompanies$()
  {
    return of([{
        "companyId": 1,
        "name": "Mattel Mock",
        "products": null
      },
      {
        "companyId": 2,
        "name": "Disney ",
        "products": null
      },
      {
        "companyId": 3,
        "name": "Lego",
        "products": null
      },
      {
        "companyId": 4,
        "name": "Fisher-Price",
        "products": null
      },
      {
        "companyId": 5,
        "name": "Bandai",
        "products": null
      },
      {
        "companyId": 6,
        "name": "Hasbro",
        "products": null
      }]);
  }

  getProducts$()
  {
    return of ([
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
    ]);
  }

  updateProduct$(formData:FormData)
  {
    return of({
      "id": 13,
      "name": "Match box Update",
      "description": "Matchbox Work Team Pack 4 cars",
      "ageRestriction": 6,
      "companyId": 1,
      "companies": null,
      "price": 125,
      "image": "https://localhost:7239/products/c1b6a9b9-e34f-4a78-8911-f3d982bee04d.jpg"
    });
  }

  createProduct$(formData:FormData)
  {
    return of({
      "id": 13,
      "name": "Match box",
      "description": "Matchbox Work Team Pack 4 cars",
      "ageRestriction": 6,
      "companyId": 1,
      "companies": null,
      "price": 125,
      "image": "https://localhost:7239/products/c1b6a9b9-e34f-4a78-8911-f3d982bee04d.jpg"
    });
  }
}