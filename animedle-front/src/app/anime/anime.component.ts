import { Component, inject } from '@angular/core';
import { Anime } from '../anime';
import { AnimeService } from '../anime.service';

@Component({
 selector: 'app-anime',
 imports: [],
 templateUrl: './anime.component.html',
 styleUrl: './anime.component.css'
})

export class AnimeComponent {
 anime: Anime = {};
 animeService: AnimeService = inject(AnimeService);

 constructor() {
  this.init();
 }

 async init() {
  const result = await this.animeService.getHello();
  this.anime = result;
 }
}