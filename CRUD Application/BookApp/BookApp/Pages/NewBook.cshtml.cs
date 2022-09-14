using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookApp.Models;

namespace BookApp.Pages
{
    public class NewBookModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;

        public NewBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Book book = new Book();

            book.Title = Request.Form["bookTitle"];
            book.Isbn = Request.Form["bookIsbn"];
            book.PublisherName = Request.Form["bookPublisher"];
            book.AuthorName = Request.Form["bookAuthor"];
            book.CategoryName = Request.Form["bookCategory"];

            connectionString = _configuration.GetConnectionString("ConnectionString");

            book.CreateBook(connectionString, book);

            Response.Redirect("./Books");
        }
    }
}
