import { Component, OnInit } from '@angular/core';
import { BannerComponent } from '../../Layout/banner/banner.component';
import { CommonModule } from '@angular/common';
import { Color, NgxChartsModule, ScaleType } from '@swimlane/ngx-charts';
import { ApiService } from '../../api.service';
import { LazyLoadDirective } from '../../shared/lazy-load.directive';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [BannerComponent, CommonModule, NgxChartsModule, LazyLoadDirective],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent implements OnInit {
  constructor(private api: ApiService) {}
  ngOnInit(): void {}

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

  steps = [
    {
      title: 'Tìm hiểu, tư vấn đơn hàng',
      description: 'Cán bộ tư vấn',
      icon: 'bi-search',
      color: '#ff6b6b',
    },
    {
      title: 'Kiểm tra sức khỏe',
      description: 'Bệnh viện theo chỉ định',
      icon: 'bi-heart-pulse',
      color: '#ff9f43',
    },
    {
      title: 'Phỏng vấn thi tuyển',
      description: 'Tham gia phỏng vấn',
      icon: 'bi-clipboard-check',
      color: '#1dd1a1',
    },
    {
      title: 'Đào tạo trước phỏng vấn',
      description: 'Học kỹ năng',
      icon: 'bi-person-workspace',
      color: '#54a0ff',
    },
    {
      title: 'Ký hợp đồng lao động',
      description: 'Hoàn tất ký kết hợp đồng',
      icon: 'bi-file-earmark-text',
      color: '#5f27cd',
    },
    {
      title: 'Đào tạo tiếng Nhật',
      description: 'Học trong 4 - 6 tháng',
      icon: 'bi-globe',
      color: '#c8d6e5',
    },
    {
      title: 'Xin tư cách lưu trú và visa',
      description: 'Hoàn thiện hồ sơ',
      icon: 'bi-passport',
      color: '#222f3e',
    },
    {
      title: 'Đào tạo chuyên môn và định hướng',
      description: 'Chuẩn bị trước khi sang Nhật',
      icon: 'bi-person-bounding-box',
      color: '#ee5253',
    },
    {
      title: 'Hoàn thiện thủ tục xuất cảnh',
      description: 'Chuẩn bị xuất cảnh',
      icon: 'bi-check-circle',
      color: '#feca57',
    },
    {
      title: 'Xuất cảnh sang Nhật',
      description: 'Bắt đầu làm việc',
      icon: 'bi-airplane',
      color: '#48dbfb',
    },
    {
      title: 'Gia hạn hoặc về nước',
      description: 'Hoàn thuế Nenkin',
      icon: 'bi-house-door',
      color: '#00d2d3',
    },
  ];

  chartData = this.steps.map((step, index) => ({
    name: step.title,
    value: index + 1,
    extra: { color: step.color, description: step.description },
  }));

  colorScheme: Color = {
    name: 'custom',
    selectable: true,
    group: ScaleType.Ordinal,
    domain: this.steps.map((step) => step.color),
  };
}
