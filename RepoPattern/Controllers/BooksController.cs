using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPattern.API.DTOs;
using RepoPattern.Core;
using RepoPattern.Core.Consts;
using RepoPattern.Core.Interfaces;
using RepoPattern.Core.Models;

namespace RepoPattern.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        public BooksController(IMapper mapper, IUnitOfWork booksRepository)
        {
            _mapper = mapper;
            _booksRepository = booksRepository;
        }

        //private readonly IBaseRepository<Book> _booksRepository;
        private readonly IUnitOfWork _booksRepository;

        
        
        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_booksRepository.Books.GetById(1));
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            //return Ok(_booksRepository.Books.GetAll());
            return Ok(_mapper.Map<IEnumerable<BookDTO>>(_booksRepository.Books.GetAll()));
        }
        
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_booksRepository.Books.Find(b => b.Title == "New Book", new[] { "Author" }));
        }
        
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_booksRepository.Books.FindAll(b => b.Title.Contains("New Book"), new[] { "Author" }));
        }
        
        [HttpGet("GetAllOrdered")]
        public IActionResult GetAllOrdered()
        {
            return Ok(_booksRepository.Books.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }
        
        [HttpPost("AddBook")]
        public IActionResult AddBook()
        {
            return Ok(_booksRepository.Books.Add(new Book { Title = "Test3", AuthorId = 1 }));
        }
    }
}
