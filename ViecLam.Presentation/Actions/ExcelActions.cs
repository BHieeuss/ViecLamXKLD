using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using ViecLam.Infrastructure.Context;

namespace ViecLam.Presentation.Actions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExcelController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("UpdateExcel")]
        public async Task<IActionResult> UpdateExcel()
        {
            // Lấy dữ liệu từ bảng học viên có Id = 1
            var hocVien = await _context.ThongTinHocViens.FirstOrDefaultAsync(hv => hv.Id == 1);

            if (hocVien == null)
            {
                return BadRequest("Không tìm thấy học viên với Id = 1.");
            }

            // Đường dẫn đến file Excel
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Cv.xlsx");

            try
            {
                // Mở file Excel
                var fileInfo = new FileInfo(filePath);
                using (var package = new ExcelPackage(fileInfo))
                {
                    // Lấy worksheet đầu tiên trong workbook
                    var worksheet = package.Workbook.Worksheets[0];

                    // Thêm hoặc cập nhật dữ liệu vào các ô
                    worksheet.Cells["B3"].Value = hocVien.HoTen;
                    ((ExcelShape)worksheet.Drawings["Shape 22"]).Text = "✓";

                    // Lưu lại thay đổi
                    package.Save();
                }

                // Sau khi lưu, trả về file để tải xuống
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileName = "Cv_Updated.xlsx";

                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (System.Exception ex)
            {
                return BadRequest($"Lỗi khi cập nhật Excel: {ex.Message}");
            }
        }
    }
}