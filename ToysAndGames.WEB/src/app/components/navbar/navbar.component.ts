import { Component, OnInit, Input } from '@angular/core';

interface Nav{
  link: string,
  name: string,
  exact: boolean
}


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  @Input() titulo: string;
  constructor() { 
    this.titulo='';
  }

  nav:Nav[]=[
    {
    link:'/',
    name:'Products',
    exact: true
    }
  ]

  ngOnInit(): void {
    
  }

}
