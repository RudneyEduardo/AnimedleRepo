import { Component, inject } from '@angular/core';
import { Hello } from '../hello';
import { HelloService } from '../hello.service';

@Component({
 selector: 'app-home',
 imports: [],
 templateUrl: './home.component.html',
 styleUrl: './home.component.css'
})

export class HomeComponent {
 hello: Hello = {};
 helloService: HelloService = inject(HelloService);

 constructor() {
  this.init();
 }

 async init() {
  const result = await this.helloService.getHello();
  this.hello = result;
 }
}