using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ViecLam.Application.Commands.Blogs;
namespace ViecLam.Presentation.Actions
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogActions : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateBlogRequest request, IMediator mediator)
        {
            var result = await mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, IMediator mediator)
        {
            var request = new DeleteBlogRequest(id);
            var result = await mediator.Send(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBlogRequest request, IMediator mediator)
        {
            var result = await mediator.Send(request);

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs(IMediator mediator)
        {
            var result = await mediator.Send(new GetAllBlogsRequest());

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id, IMediator mediator)
        {
            var result = await mediator.Send(new GetByIdBlogRequest(id));

            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return StatusCode(result.StatusCode, result);
        }
        [HttpGet("images/{filename}")]
        public IActionResult GetImage(string filename, IWebHostEnvironment environment)
        {
            var contentPath = environment.ContentRootPath;
            var imagePath = Path.Combine(contentPath, "Uploads", filename);
            if (System.IO.File.Exists(imagePath))
            {
                var image = System.IO.File.OpenRead(imagePath);
                return File(image, "image/jpeg"); 
            }
            return NotFound();
        }

    }
}
