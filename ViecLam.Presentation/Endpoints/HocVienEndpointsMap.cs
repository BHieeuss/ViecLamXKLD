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
            hocvien.MapPost("/", HocVienActions.Post).WithName("AddHocVien");          
            return app;
        }
    }
}
