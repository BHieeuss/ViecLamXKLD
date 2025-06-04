import { Directive, ElementRef, Input, Renderer2, OnInit } from '@angular/core';

@Directive({
  selector: '[appLazyLoad]',
})
export class LazyLoadDirective implements OnInit {
  @Input('appLazyLoad') src!: string;
  private observer?: IntersectionObserver;

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
    this.renderer.setStyle(this.el.nativeElement, 'opacity', '0.3');
    if ('IntersectionObserver' in window) {
      this.observer = new IntersectionObserver((entries) => {
        entries.forEach((entry) => {
          if (entry.isIntersecting) {
            setTimeout(() => {
              this.loadImage();
              this.observer?.disconnect();
            }, 2000); // Delay 2 giây
          }
        });
      });
      this.observer.observe(this.el.nativeElement);
    } else {
      this.loadImage();
    }
  }

  private loadImage() {
    this.renderer.setAttribute(this.el.nativeElement, 'src', this.src);
    this.el.nativeElement.onload = () => {
      this.renderer.setStyle(
        this.el.nativeElement,
        'transition',
        'opacity 0.5s'
      );
      this.renderer.setStyle(this.el.nativeElement, 'opacity', '1');
    };
  }
}
