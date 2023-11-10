using konyvtarProj.Shared.Models;

namespace konyvtarProj.Client.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Books>?> All();
        Task<Books?> GetBook(int LibNumber);
        Task<Books?> AddBook(Books book);
        Task<bool> UpdateBook(Books book);
        Task<bool> DeleteBook(int LibNumber);
    }
}
