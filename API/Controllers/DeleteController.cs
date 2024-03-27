using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("{id}")]
        [ActionName("GenreDelete")]
        public int DeleteAGenre(int id)
        {
            Genre genre = GenreDB.SelectById(id);
            GenreDB db = new GenreDB();
            db.Delete(genre);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("BooksDelete")]
        public int DeleteABook(int id)
        {
            Books books = BooksDB.SelectById(id);
            BooksDB db = new BooksDB();
            db.Delete(books);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("BooksLibraryDelete")]
        public int DeleteABookLibrary(int id)
        {
            BooksLibrary booksLibrary = BooksLibraryDB.SelectById(id);
            BooksLibraryDB db = new BooksLibraryDB();
            db.Delete(booksLibrary);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("CategoryDelete")]
        public int DeleteACategory(int id)
        {
            Category category = CategoryDB.SelectById(id);
            CategoryDB db = new CategoryDB();
            db.Delete(category);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("CommentsDelete")]
        public int DeleteAComments(int id)
        {
            Comments comments = CommentsDB.SelectById(id);
            CommentsDB db = new CommentsDB();
            db.Delete(comments);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("DigitalBooksDelete")]
        public int DeleteADigitalBooks(int id)
        {
            DigitalBooks comments = DigitalBooksDB.SelectById(id);
            DigitalBooksDB db = new DigitalBooksDB();
            db.Delete(comments);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("MovieBooksDelete")]
        public int DeleteAMovieBooks(int id)
        {
            MovieBooks movieBooks = MovieBooksDB.SelectById(id);
            MovieBooksDB db = new MovieBooksDB();
            db.Delete(movieBooks);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("ReviewDelete")]
        public int DeleteAReview(int id)
        {
            Review review = ReviewDB.SelectById(id);
            ReviewDB db = new ReviewDB();
            db.Delete(review);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("UserDelete")]
        public int DeleteAUser(int id)
        {
            User user = UserDB.SelectById(id);
            UserDB db = new UserDB();
            db.Delete(user);
            int x = db.SaveChanges();
            return x;
        }

        [HttpDelete("{id}")]
        [ActionName("WriterDelete")]
        public int DeleteAWriter(int id)
        {
            Writer writer = WriterDB.SelectById(id);
            WriterDB db = new WriterDB();
            db.Delete(writer);
            int x = db.SaveChanges();
            return x;
        }
    }
}
