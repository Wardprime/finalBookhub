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
    public class PublicationController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly Dbookhub _context;
        public PublicationController(Dbookhub context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<PublicationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listaPublication = await _context.Publications.ToListAsync();
                return Ok(listaPublication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        // POST api/<PublicationController>
        [HttpPost]
        public async Task<IActionResult> Save(publicationVM objVM)
        {
            try
            {
                Publication publication = _mapper.Map<Publication>(objVM);
                _context.Add(publication);
                await _context.SaveChangesAsync();
                return Ok(publication);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<PublicationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] publicationVM objVM)
        {
            try
            {
                if (id != objVM.PublicationId)
                {
                    return NotFound();
                }
                Publication publication = _mapper.Map<Publication>(objVM);
                _context.Update(publication);
                await _context.SaveChangesAsync();
                return Ok(new { message = "actulizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<PublicationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var publication = await _context.Publications.FindAsync(id);
                if (id != publication.PublicationId)
                {
                    return NotFound();
                }
                _context.Publications.Remove(publication);
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
