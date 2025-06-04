import { Component, Renderer2, OnInit } from '@angular/core';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-theme-toggle',
  template: `
    <button
      (click)="toggleTheme()"
      class="theme-toggle-btn"
      [attr.aria-label]="isDark ? 'Chế độ sáng' : 'Chế độ tối'"
    >
      <i class="bi" [ngClass]="isDark ? 'bi-sun-fill' : 'bi-moon-fill'"></i>
    </button>
  `,
  styles: [
    `
      .theme-toggle-btn {
        background: none;
        border: none;
        cursor: pointer;
        font-size: 1.7rem;
        color: #fbc02d;
        margin-left: 10px;
        outline: none;
        transition: color 0.2s;
      }
      .theme-toggle-btn .bi-moon-fill {
        color: #222;
      }
      .theme-toggle-btn .bi-sun-fill {
        color: #fbc02d;
      }
    `,
  ],
  standalone: true,
  imports: [NgClass],
})
export class ThemeToggleComponent implements OnInit {
  isDark = false;

  constructor(private renderer: Renderer2) {}

  ngOnInit(): void {
    if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
      const stored = localStorage.getItem('theme');
      if (stored) {
        this.isDark = stored === 'dark';
      } else if (window.matchMedia('(prefers-color-scheme: dark)').matches) {
        this.isDark = true;
      }
    }
    this.updateBodyClass();
  }

  toggleTheme(): void {
    this.isDark = !this.isDark;
    this.updateBodyClass();
  }

  private updateBodyClass(): void {
    if (typeof window === 'undefined' || typeof localStorage === 'undefined') {
      return;
    }
    if (this.isDark) {
      this.renderer.addClass(document.body, 'dark-theme');
      localStorage.setItem('theme', 'dark');
    } else {
      this.renderer.removeClass(document.body, 'dark-theme');
      localStorage.setItem('theme', 'light');
    }
  }
}

