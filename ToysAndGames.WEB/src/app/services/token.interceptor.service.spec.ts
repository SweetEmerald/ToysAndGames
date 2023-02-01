import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";
import { TokenInterceptorService } from "./token.interceptor.service";

describe('TokenInterceptorService',()=>{
    let service: TokenInterceptorService;
    let httpMock: HttpTestingController;

    beforeEach(()=>{
        TestBed.configureTestingModule({
            imports:[HttpClientTestingModule]
        })
        service = TestBed.inject(TokenInterceptorService);
        httpMock = TestBed.inject(HttpTestingController);
    });

    afterEach(()=>{
        httpMock.verify(); //Aftter each test we verify if there are any request in the stack, if it is true then release it
    })

    it('should be created',()=>{
        expect(service).toBeTruthy();
    });

});