import { Injectable } from '@angular/core';
import { Anime } from './anime';

@Injectable({
  providedIn: 'root'
})
export class AnimeService {
  readonly url: string = 'http://localhost:8080/api/hello';

  constructor() { }

  async getHello(): Promise<Anime> {
    const response = await fetch(`${this.url}`);
    const text = await response.json();
    const anime: Anime = { text };

    return anime;
  }
}