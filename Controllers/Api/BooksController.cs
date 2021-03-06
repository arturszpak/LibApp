using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers.Api
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase { 

        public BooksController( ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [System.Web.Http.HttpGet]
        [Authorize(Roles = "User")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetBooks()
        {
            var books = _context.Books.Include(b => b.Genre).ToList().Select(_mapper.Map<Book, BookDto>);
            return Ok(books);
        }


        public IEnumerable<BookDto> GetBooks(string query = null)
        {
            var booksQuery = _context.Books.Where(b => b.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                booksQuery = booksQuery.Where(b => b.Name.Contains(query));
            }

            return booksQuery.ToList().Select(_mapper.Map<Book, BookDto>);
        }


        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
    }
}
