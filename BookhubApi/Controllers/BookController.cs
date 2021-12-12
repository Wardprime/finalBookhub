using AutoMapper;
using BookhubApi.Modelss;
using BookhubApi.viewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace BookhubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly Dbookhub _context;
        public BookController(Dbookhub context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaBook = await _context.Books.ToListAsync();
                return Ok(listaBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*// GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Save(bookVM objVM)
        {
            try
            {
                Book book = _mapper.Map<Book>(objVM);
                _context.Add(book);
                await _context.SaveChangesAsync();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] bookVM objVM)
        {
            try
            {
                if (id != objVM.BookId)
                {
                    return NotFound();
                }
                Book book = _mapper.Map<Book>(objVM);
                _context.Update(book);
                await _context.SaveChangesAsync();
                return Ok(new { message = "actulizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);
                if (id != book.BookId)
                {
                    return NotFound();
                }
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Borrado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
