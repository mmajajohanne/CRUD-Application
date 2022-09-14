using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookApp.Models;
using Microsoft.Extensions.Configuration;

namespace BookApp.Pages
{
    public class DeleteBookModel : PageModel
    {
        readonly IConfiguration _configuration;

        public string connectionString;

        public int bookId;

        public DeleteBookModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            bookId = Convert.ToInt16(Request.Query["bookid"]);

            connectionString = _configuration.GetConnectionString("ConnectionString");

            Book book = new Book();

            book.DeleteBook(connectionString, bookId);

            Response.Redirect("./Books");
        }
    }
}
