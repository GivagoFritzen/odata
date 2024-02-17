using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Contract;
using WebApplication.Entity;
using WebApplication.Infra;
using WebApplication.Service;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookContext _dbContext;
        private readonly BookMapper mapper;

        public BookController(ILogger<BookController> logger, BookContext dbContext, BookMapper mapper)
        {
            _logger = logger;
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task Post(CreateBookCommand book)
        {
            await _dbContext.Books.AddAsync(mapper.Convert(book));
            await _dbContext.SaveChangesAsync();
            return;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _dbContext.Books.ToListAsync();
        }
    }
}
