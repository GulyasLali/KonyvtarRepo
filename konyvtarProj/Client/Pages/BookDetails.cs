using java.lang;
using konyvtarProj.Client.Services;
using konyvtarProj.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace konyvtarProj.Client.Pages
{
    public partial class BookDetails
    {
        protected string message = string.Empty;
        protected Books book { get; set; } = new Books();
        [Parameter]
        public string LibNumber { get; set; }

        [Inject]
        private IBookService bookService {  get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            if(string.IsNullOrEmpty(LibNumber))
            {

            }
            else
            {
                var libn = Convert.ToInt32(LibNumber);
                var apiBook = await bookService.GetBook(libn);

               if (apiBook != null) { }
                {
                    book = apiBook;
                }


            }
        }
    }
}
