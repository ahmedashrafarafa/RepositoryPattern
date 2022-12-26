using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.Core;
using RepoPattern.Core.Interfaces;
using RepoPattern.Core.Models;

namespace RepoPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorsRepository;
        private readonly IUnitOfWork _authorsRepository;

        //public AuthorsController(IBaseRepository<Author> authorRepository)
        public AuthorsController(IUnitOfWork authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_authorsRepository.Authors.GetById(1));
        }
        //end piont
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _authorsRepository.Authors.GetByIdAsync(1));
        }
    }
}
