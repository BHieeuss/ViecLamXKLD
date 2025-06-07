import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { HeaderComponent } from './Layout/header/header.component';
import { CherryBlossomsComponent } from './shared/sakura-effect.component';

/**
 * App Root Component
 * Main application component that includes header navigation and cherry blossoms animation
 */
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, CherryBlossomsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'App';
}
