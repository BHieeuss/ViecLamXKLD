import { Component, Renderer2 } from '@angular/core';
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
export class ThemeToggleComponent {
  isDark = false;

  constructor(private renderer: Renderer2) {
    // Chỉ chạy trên trình duyệt (browser), tránh lỗi SSR
    if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
      const theme = localStorage.getItem('theme');
      if (theme === 'dark') {
        this.isDark = true;
        this.renderer.addClass(document.body, 'dark-theme');
      }
    }
  }

  toggleTheme() {
    this.isDark = !this.isDark;
    if (typeof window !== 'undefined' && typeof localStorage !== 'undefined') {
      if (this.isDark) {
        this.renderer.addClass(document.body, 'dark-theme');
        localStorage.setItem('theme', 'dark');
      } else {
        this.renderer.removeClass(document.body, 'dark-theme');
        localStorage.setItem('theme', 'light');
      }
    }
  }
}
