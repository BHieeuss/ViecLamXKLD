import { CommonModule } from '@angular/common';
import { Component, HostListener, OnInit } from '@angular/core';
import { ThemeToggleComponent } from '../../shared/theme-toggle.component';

@Component({
  selector: 'app-header',
  imports: [CommonModule, ThemeToggleComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent implements OnInit {
  isMenuOpen = false;

  ngOnInit(): void {
    this.onScroll();
  }

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }

  scrollToSection(event: Event) {
    event.preventDefault();
    const targetId = (event.target as HTMLAnchorElement)
      .getAttribute('href')
      ?.substring(1);
    const target = document.getElementById(targetId!);
    if (target) {
      target.scrollIntoView({ behavior: 'smooth', block: 'start' });
      this.isMenuOpen = false;
    }
  }

  @HostListener('window:scroll', [])
  onScroll(): void {
    const scrollPos = window.pageYOffset;
    const anchors = document.querySelectorAll('.nav a');

    anchors.forEach((anchor) => {
      const href = anchor.getAttribute('href');
      if (!href || !href.startsWith('#')) return;

      const section = document.querySelector(href);
      if (section) {
        const top = (section as HTMLElement).offsetTop;
        const bottom = top + (section as HTMLElement).offsetHeight;

        if (scrollPos >= top && scrollPos < bottom) {
          anchors.forEach((a) => a.classList.remove('active'));
          anchor.classList.add('active');
        }
      }
    });
  }
}
