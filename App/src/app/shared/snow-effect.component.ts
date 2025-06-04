import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-snow-effect',
  template: `<canvas
    id="snow-canvas"
    style="position: fixed; top: 0; left: 0; width: 100vw; height: 100vh; display: block; pointer-events: none; z-index: 9999;"
  ></canvas>`,
  standalone: true,
})
export class SnowEffectComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    this.initSnow();
  }

  private initSnow() {
    if (typeof window === 'undefined' || typeof document === 'undefined')
      return;
    const canvas = document.getElementById('snow-canvas') as HTMLCanvasElement;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    const snowflakes: any[] = [];
    const snowflakeCount = 80;

    function randomBetween(a: number, b: number) {
      return Math.random() * (b - a) + a;
    }

    function resizeCanvas() {
      canvas.width = window.innerWidth;
      canvas.height = window.innerHeight;
      for (let i = 0; i < snowflakeCount; i++) {
        if (snowflakes[i]) {
          snowflakes[i].x = randomBetween(0, canvas.width);
          snowflakes[i].y = randomBetween(0, canvas.height);
        }
      }
    }

    resizeCanvas();
    for (let i = 0; i < snowflakeCount; i++) {
      snowflakes.push({
        x: randomBetween(0, canvas.width),
        y: randomBetween(0, canvas.height),
        r: randomBetween(1, 4),
        d: randomBetween(1, 2),
        opacity: randomBetween(0.5, 1),
      });
    }
    window.addEventListener('resize', resizeCanvas);

    function drawSnowflakes() {
      if (!ctx) return;
      ctx.clearRect(0, 0, canvas.width, canvas.height);
      ctx.save();
      ctx.fillStyle = 'white';
      ctx.beginPath();
      for (let i = 0; i < snowflakeCount; i++) {
        const f = snowflakes[i];
        ctx.globalAlpha = f.opacity;
        ctx.moveTo(f.x, f.y);
        ctx.arc(f.x, f.y, f.r, 0, Math.PI * 2, true);
      }
      ctx.fill();
      ctx.restore();
      moveSnowflakes();
    }

    function moveSnowflakes() {
      for (let i = 0; i < snowflakeCount; i++) {
        const f = snowflakes[i];
        f.y += f.d;
        f.x += Math.sin(f.y / 30) * 0.5;
        if (f.y > canvas.height) {
          f.y = -f.r;
          f.x = randomBetween(0, canvas.width);
        }
      }
    }

    function animate() {
      drawSnowflakes();
      requestAnimationFrame(animate);
    }

    animate();
  }
}
