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
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly Dbookhub _context;
        public UserController(Dbookhub context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<SserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lista_users = await _context.Users.ToListAsync();
                return Ok(lista_users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SserController>/5
        [HttpGet("{username}, {password}")]
        public async Task<IActionResult> login(string username, string password)
        {
            try
            {
                var a = _context.Users.Where(x => x.Correo == username && x.Contra == password).FirstOrDefault();
                if (a == null)
                {
                    return Ok(new { message = "email or password invalid" });
                }
                var userId = _context.Users.Where(s => s.Name == username).Select(x => x.UserId);
                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<SserController>
        [HttpPost]
        public async Task<IActionResult> Register(userVM objVM)
        {
            try
            {
                User user = _mapper.Map<User>(objVM);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<SserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] userVM objVM)
        {
            try
            {
                if (id != objVM.UserId)
                {
                    return NotFound();
                }
                User user = _mapper.Map<User>(objVM);
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "actulizado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<SserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (id != user.UserId)
                {
                    return NotFound();
                }
                _context.Users.Remove(user);
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
