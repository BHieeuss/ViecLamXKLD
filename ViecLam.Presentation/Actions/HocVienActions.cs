using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViecLam.Application.Commands.HocVien;

namespace ViecLam.Presentation.Actions
{

    [Route("api/[controller]")]
    [ApiController]
    public class HocVienActions : ControllerBase
    {

        [HttpPost]
        public static async Task<IResult> PostThongTinSinhVien([FromBody] CreateThongTinHocVienRequest request, IMediator mediator)
        {
            var results = await mediator.Send(request);
            if (results.IsSuccess)
            {
                var validLocation = Uri.EscapeDataString($"/hocviens/{results}");
                return Results.Created(validLocation, results);
            }
            return TypedResults.BadRequest(results);
        }

        [HttpPost]
        public static async Task<IResult> PostQuaTrinhHocTap([FromBody] CreateQuaTrinhHocTapRequest request, IMediator mediator)
        {
            try
            {
                var results = await mediator.Send(request);
                if (results.IsSuccess)
                {
                    var validLocation = Uri.EscapeDataString($"/hocviens/{results}");
                    return Results.Created(validLocation, results);
                }
                return TypedResults.BadRequest(results);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public static async Task<IResult> PostQuaTrinhLamViec([FromBody] CreateQuaTrinhLamViecRequest request, IMediator mediator)
        {
            var results = await mediator.Send(request);
            if (results.IsSuccess)
            {
                var validLocation = Uri.EscapeDataString($"/hocviens/{results}");
                return Results.Created(validLocation, results);
            }
            return TypedResults.BadRequest(results);
        }

        [HttpPost]
        public static async Task<IResult> PostThanhPhanGiaDinh([FromBody] CreateThanhPhanGiaDinhRequest request, IMediator mediator)
        {
            var results = await mediator.Send(request);
            if (results.IsSuccess)
            {
                var validLocation = Uri.EscapeDataString($"/hocviens/{results}");
                return Results.Created(validLocation, results);
            }
            return TypedResults.BadRequest(results);
        }
    }
}
