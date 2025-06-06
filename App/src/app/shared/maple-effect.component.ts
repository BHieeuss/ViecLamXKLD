import { AfterViewInit, Component } from '@angular/core';

@Component({
  selector: 'app-maple-leaves',
  template: `<canvas
    id="maple-canvas"
    style="position: fixed; top: 0; left: 0; width: 100vw; height: 100vh; display: block; pointer-events: none; z-index: 9999;"
  ></canvas>`,
  standalone: true,
})
export class MapleLeavesComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    this.initMapleLeaves();
  }

  private initMapleLeaves() {
    if (typeof window === 'undefined' || typeof document === 'undefined')
      return;
    const canvas = document.getElementById('maple-canvas') as HTMLCanvasElement;
    if (!canvas) return;
    const ctx = canvas.getContext('2d');
    if (!ctx) return;

    const mapleLeaves: any[] = [];
    const leafCount = 30;

    // Màu sắc lá phong Nhật Bản (momiji)
    const leafColors = [
      '#FF6B6B',
      '#FF8E53',
      '#FFA726',
      '#FFD54F',
      '#DC143C',
      '#B22222',
      '#FF4500',
    ];

    function randomBetween(a: number, b: number) {
      return Math.random() * (b - a) + a;
    }

    function resizeCanvas() {
      canvas.width = window.innerWidth;
      canvas.height = window.innerHeight;
      for (let i = 0; i < leafCount; i++) {
        if (mapleLeaves[i]) {
          mapleLeaves[i].x = randomBetween(0, canvas.width);
          mapleLeaves[i].y = randomBetween(-canvas.height, 0);
        }
      }
    }

    resizeCanvas();
    for (let i = 0; i < leafCount; i++) {
      mapleLeaves.push({
        x: randomBetween(0, canvas.width),
        y: randomBetween(-canvas.height, 0),
        size: randomBetween(12, 25),
        speed: randomBetween(0.8, 2.5),
        rotation: randomBetween(0, 360),
        rotationSpeed: randomBetween(-3, 3),
        swaySpeed: randomBetween(0.3, 1.2),
        color: leafColors[Math.floor(Math.random() * leafColors.length)],
        opacity: randomBetween(0.6, 0.9),
      });
    }
    window.addEventListener('resize', resizeCanvas);

    function drawMapleLeaf(
      ctx: CanvasRenderingContext2D,
      x: number,
      y: number,
      size: number,
      rotation: number,
      color: string,
      opacity: number
    ) {
      ctx.save();
      ctx.translate(x, y);
      ctx.rotate((rotation * Math.PI) / 180);
      ctx.globalAlpha = opacity;

      const scale = size / 20;

      // Thân lá
      ctx.strokeStyle = '#8B4513';
      ctx.lineWidth = 2 * scale;
      ctx.beginPath();
      ctx.moveTo(0, 8 * scale);
      ctx.lineTo(0, -2 * scale);
      ctx.stroke();

      // Vẽ lá phong 5 cánh
      ctx.fillStyle = color;
      ctx.strokeStyle = '#654321';
      ctx.lineWidth = 1 * scale;

      ctx.beginPath();

      // Cánh giữa (trên)
      ctx.moveTo(0, -15 * scale);
      ctx.lineTo(-3 * scale, -8 * scale);
      ctx.lineTo(-1 * scale, -2 * scale);
      ctx.lineTo(1 * scale, -2 * scale);
      ctx.lineTo(3 * scale, -8 * scale);
      ctx.closePath();

      // Cánh trái trên
      ctx.moveTo(-1 * scale, -2 * scale);
      ctx.lineTo(-8 * scale, -12 * scale);
      ctx.lineTo(-10 * scale, -8 * scale);
      ctx.lineTo(-6 * scale, -6 * scale);
      ctx.lineTo(-3 * scale, -2 * scale);
      ctx.closePath();

      // Cánh phải trên
      ctx.moveTo(1 * scale, -2 * scale);
      ctx.lineTo(8 * scale, -12 * scale);
      ctx.lineTo(10 * scale, -8 * scale);
      ctx.lineTo(6 * scale, -6 * scale);
      ctx.lineTo(3 * scale, -2 * scale);
      ctx.closePath();

      // Cánh trái dưới
      ctx.moveTo(-1 * scale, 2 * scale);
      ctx.lineTo(-7 * scale, 1 * scale);
      ctx.lineTo(-8 * scale, 4 * scale);
      ctx.lineTo(-5 * scale, 6 * scale);
      ctx.lineTo(-2 * scale, 4 * scale);
      ctx.closePath();

      // Cánh phải dưới
      ctx.moveTo(1 * scale, 2 * scale);
      ctx.lineTo(7 * scale, 1 * scale);
      ctx.lineTo(8 * scale, 4 * scale);
      ctx.lineTo(5 * scale, 6 * scale);
      ctx.lineTo(2 * scale, 4 * scale);
      ctx.closePath();

      ctx.fill();
      ctx.stroke();

      // Vẽ gân lá
      ctx.strokeStyle = '#8B4513';
      ctx.lineWidth = 0.5 * scale;
      ctx.beginPath();
      // Gân chính
      ctx.moveTo(0, -2 * scale);
      ctx.lineTo(0, -10 * scale);
      // Gân phụ
      ctx.moveTo(-2 * scale, -4 * scale);
      ctx.lineTo(-6 * scale, -8 * scale);
      ctx.moveTo(2 * scale, -4 * scale);
      ctx.lineTo(6 * scale, -8 * scale);
      ctx.moveTo(-1 * scale, 0);
      ctx.lineTo(-5 * scale, 2 * scale);
      ctx.moveTo(1 * scale, 0);
      ctx.lineTo(5 * scale, 2 * scale);
      ctx.stroke();

      ctx.restore();
    }

    function drawMapleLeaves() {
      if (!ctx) return;
      ctx.clearRect(0, 0, canvas.width, canvas.height);

      for (let i = 0; i < leafCount; i++) {
        const leaf = mapleLeaves[i];
        drawMapleLeaf(
          ctx,
          leaf.x,
          leaf.y,
          leaf.size,
          leaf.rotation,
          leaf.color,
          leaf.opacity
        );
      }
      moveMapleLeaves();
    }

    function moveMapleLeaves() {
      for (let i = 0; i < leafCount; i++) {
        const leaf = mapleLeaves[i];
        leaf.y += leaf.speed;
        leaf.x += Math.sin(leaf.y / 80) * leaf.swaySpeed;
        leaf.rotation += leaf.rotationSpeed;

        // Tạo hiệu ứng gió nhẹ
        if (Math.random() < 0.01) {
          leaf.swaySpeed = randomBetween(-1.5, 1.5);
        }

        if (leaf.y > canvas.height + 50) {
          leaf.y = randomBetween(-100, -50);
          leaf.x = randomBetween(0, canvas.width);
          leaf.rotation = randomBetween(0, 360);
          leaf.color =
            leafColors[Math.floor(Math.random() * leafColors.length)];
          leaf.size = randomBetween(12, 25);
          leaf.speed = randomBetween(0.8, 2.5);
        }

        if (leaf.x > canvas.width + 50) {
          leaf.x = -50;
        } else if (leaf.x < -50) {
          leaf.x = canvas.width + 50;
        }
      }
    }

    function animate() {
      drawMapleLeaves();
      requestAnimationFrame(animate);
    }

    animate();
  }
}
