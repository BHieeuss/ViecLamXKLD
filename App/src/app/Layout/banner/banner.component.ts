import { Component } from '@angular/core';
import { LazyLoadDirective } from '../../shared/lazy-load.directive';

@Component({
  selector: 'app-banner',
  imports: [LazyLoadDirective],
  templateUrl: './banner.component.html',
  styleUrl: './banner.component.css',
  standalone: true,
})
export class BannerComponent {}
