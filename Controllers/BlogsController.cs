using ApexTravels.Data;
using ApexTravels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApexTravels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/blogs
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = _context.Blogs.ToList();
            return new JsonResult(blogs);
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id) 
        {
            var blog = await _context.Blogs.FindAsync(id);

            if (blog == null) 
            {
                return NotFound();
            }

            return Ok(blog);
        }

        // POST api/blogs
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog (Blog blog)
        {
            _context.Blogs.Add(blog);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException) 
            {
                return Conflict();
            }

            return Ok(blog);
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }
            
            _context.Entry(blog).State = EntityState.Modified;
            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch(DbUpdateException)
            {
                return Conflict();
            }
            return NoContent();
        
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
