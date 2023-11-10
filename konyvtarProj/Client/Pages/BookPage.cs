using com.sun.tools.corba.se.idl.constExpr;
using java.lang;
using konyvtarProj.Client.Services;
using konyvtarProj.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace konyvtarProj.Client.Pages
{
    public partial class BookPage
    {
        [Inject]
        private IBookService bookService { get; set; }

        public IEnumerable<Books> _books { get; set; } = new List<Books>();

        protected async override Task OnInitializedAsync()
        {
            var apiBooks = await bookService.All();

            if (apiBooks != null && apiBooks.Any())
                _books = apiBooks;
        }
    }
}
