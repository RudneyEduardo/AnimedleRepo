import { Injectable } from '@angular/core';
import { Hello } from './hello';

@Injectable({
  providedIn: 'root'
})
export class HelloService {
  readonly url: string = 'http://localhost:8080/api/hello';

  constructor() { }

  async getHello(): Promise<Hello> {
    const response = await fetch(`${this.url}`);
    const text = await response.json();
    const hello: Hello = { text };

    return hello;
  }
}