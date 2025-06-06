import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
import { BannerComponent } from '../../Layout/banner/banner.component';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../api.service';
import { AOSService } from '../../shared/aos.service';
import { LazySectionComponent } from '../../shared/lazy-section.component';
import { AssetPreloadService } from '../../shared/asset-preload.service';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerComponent, CommonModule, LazySectionComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit, AfterViewInit, OnDestroy {
  constructor(
    private api: ApiService,
    public aosService: AOSService,
    private assetPreloadService: AssetPreloadService
  ) {}
  ngOnInit(): void {
    // Preload critical assets
    this.assetPreloadService.preloadImages([
      'assets/images/portfolio-image.png',
      'assets/images/big-blog-thumb.jpg',
      'assets/images/blog-thumb-01.jpg',
      'assets/images/blog-dec.png',
      'assets/images/contact-decoration.png',
    ]);

    // Initialize AOS with custom settings
    this.aosService.init({
      duration: 1000,
      easing: 'ease-out-cubic',
      once: true,
      mirror: false,
      offset: 100,
      delay: 0,
    });
  }

  ngAfterViewInit(): void {
    // Refresh AOS after view initialization
    setTimeout(() => {
      this.aosService.refresh();
    }, 100);
  }

  ngOnDestroy(): void {
    // Cleanup if needed
  }

  // Gọi hàm để tải file Excel
  downloadExcelFile() {
    this.api.downloadExcel().subscribe(
      (response: Blob) => {
        const blob = new Blob([response], {
          type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
        });
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = 'Cv_Updated.xlsx'; // Tên file khi tải xuống
        link.click();
      },
      (error) => {
        console.error('Error downloading file', error);
      }
    );
  }
}
