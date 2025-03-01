using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using ViecLam.Presentation.Actions;

namespace ViecLam.Presentation.Endpoints
{

    public static class HocVienEndpointsMap
    {
        public static IEndpointRouteBuilder MapHocVienEndpoints(this IEndpointRouteBuilder app)
        {
            var hocvien = app.MapGroup("/api/hocviens/");
            hocvien.MapPost("/thongtinhocvien", HocVienActions.PostThongTinSinhVien).WithName("AddThongTinHocVien");
            hocvien.MapPost("/quatrinhhoctap", HocVienActions.PostQuaTrinhHocTap).WithName("AddQuaTrinhHocTap");
            hocvien.MapPost("/quatrinhlamviec", HocVienActions.PostQuaTrinhLamViec).WithName("AddQuaTrinhLamViec");
            hocvien.MapPost("/thanhphangiadinh", HocVienActions.PostThanhPhanGiaDinh).WithName("AddThanhPhanGiaDinh");
            return app;
        }
    }
}
