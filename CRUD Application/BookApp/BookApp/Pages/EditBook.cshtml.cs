using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookApp.Models;

namespace BookApp.Pages
{
    public class EditBookModel : PageModel
    {
        readonly IConfiguration _configuration;

        public Book bookdb = new Book();

        public string connectionString;

        public int bookId;

        public EditBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {

            bookId = Convert.ToInt16(Request.Query["bookid"]);

            Book book = new Book();

            connectionString = _configuration.GetConnectionString("ConnectionString");

            bookdb = book.GetBookData(connectionString, bookId);

        }

        public void OnPost()
        {
            Book book = new Book();

            book.BookId = Convert.ToInt16(Request.Form["bookId"]);
            book.Title = Request.Form["bookTitle"];
            book.Isbn = Request.Form["bookIsbn"];
            book.PublisherName = Request.Form["bookPublisher"];
            book.AuthorName = Request.Form["bookAuthor"];
            book.CategoryName = Request.Form["bookCategory"];

            connectionString = _configuration.GetConnectionString("ConnectionString");

            book.EditBook(connectionString, book);

            Response.Redirect("./Books");
        }
    }
}
