using Microsoft.AspNetCore.Mvc;
using Model;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut]
        [ActionName("GenreUpdate")]
        public int UpdateAGenre([FromBody] Genre genre)
        {
            GenreDB db = new GenreDB();
            db.Update(genre);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("BooksUpdate")]
        public int UpdateABooks([FromBody] Books books)
        {
            BooksDB db = new BooksDB();
            db.Update(books);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("BooksLibraryUpdate")]
        public int UpdateABooksLibrary([FromBody] BooksLibrary booksLibrary)
        {
            BooksLibraryDB db = new BooksLibraryDB();
            db.Update(booksLibrary);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("CategoryUpdate")]
        public int UpdateACategory([FromBody] Category category)
        {
            CategoryDB db = new CategoryDB();
            db.Update(category);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("CommentsUpdate")]
        public int UpdateAComments([FromBody] Comments comments)
        {
            CommentsDB db = new CommentsDB();
            db.Update(comments);
            int x = db.SaveChanges();
            return x;
        }
        

        [HttpPut]
        [ActionName("DigitalBooksUpdate")]
        public int UpdateADigitalBooks([FromBody] DigitalBooks digitalBooks)
        {
            DigitalBooksDB db = new DigitalBooksDB();
            db.Update(digitalBooks);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("MovieBooksUpdate")]
        public int UpdateAMovieBooks([FromBody] MovieBooks movieBooks)
        {
            MovieBooksDB db = new MovieBooksDB();
            db.Update(movieBooks);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("ReviewUpdate")]
        public int UpdateAReview([FromBody] Review review)
        {
            ReviewDB db = new ReviewDB();
            db.Update(review);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("UserUpdate")]
        public int UpdateAUser([FromBody] User user)
        {
            UserDB db = new UserDB();
            db.Update(user);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPut]
        [ActionName("WriterUpdate")]
        public int UpdateAWriter([FromBody] Writer writer)
        {
            WriterDB db = new WriterDB();
            db.Update(writer);
            int x = db.SaveChanges();
            return x;
        }
    }
}
