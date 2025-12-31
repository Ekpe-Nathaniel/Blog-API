
using BlogAPI.DTOs;
using BlogAPI.Models;
using BlogAPI.Persistence.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpPost]

    public IActionResult CreateBlog(CreateBlogRequestDTO request)
    {
        var blog = new Blog
        {
            Author = request.Author,
            Title = request.Title,
            Content = request.Content
        };

        _blogRepository.Add(blog);
        return Ok(blog);

    }



    [HttpGet]

    public IActionResult GetAllBlogs()
    {
        return Ok(_blogRepository.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetBlogById(Guid id)
    {
        var blog = _blogRepository.GetById(id);
        if(blog==null)
        {
            return NotFound();  
        }
        
        return Ok(blog);
    }

    [HttpDelete]
    public IActionResult DeleteAllBlog()
    {
        _blogRepository.Clear();
        return NoContent();
    }



    [HttpDelete("{id}")]
    public IActionResult DeleteBlogById(Guid id)
    {
        var blog = _blogRepository.DeleteById(id);
        if (blog == null)
        {
            return NotFound();
        }

        return NoContent();
    }

  [HttpPut("{id}")]
public IActionResult UpdateBlogById(Guid id, [FromBody] Blog updatedBlog)
{
    if (updatedBlog == null)
    {
        return BadRequest("Blog data is required.");
    }

    var updated = _blogRepository.Update(id, updatedBlog);

    if (updated == null)
    {
        return NotFound($"Blog with ID {id} not found.");
    }

    return Ok(updated);
}


}

