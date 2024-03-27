using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.Json;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    // סלקט מחזיר את הטבלה
    public class SelectController : ControllerBase
    {
        [HttpGet]//ייחוס לפעולה שאנו רוצים לבצע
        [ActionName("GenreSelector")]
        public GenreList SelectAllGenres()
        {
            GenreDB db = new GenreDB();
            GenreList genres = db.SelectAll();
            return genres;
        }

        [HttpGet]
        [ActionName("BooksSelector")]
        public BooksList SelectAllBooks()
        {
            BooksDB db = new BooksDB();
            BooksList books = db.SelectAll();
            return books;
        }

        [HttpGet]
        [ActionName("BooksLibrarySelector")]
        public BooksLibraryList SelectAllBooksLibrary()
        {
            BooksLibraryDB db = new BooksLibraryDB();
            BooksLibraryList booksLibrary = db.SelectAll();
            return booksLibrary;
        }

        [HttpGet]
        [ActionName("CategorySelector")]
        public CategoryList SelectAllCategory()
        {
            CategoryDB db = new CategoryDB();
            CategoryList category = db.SelectAll();
            return category;
        }

        [HttpGet]
        [ActionName("CommentsSelector")]
        public CommentsList SelectAllComments()
        {
            CommentsDB db = new CommentsDB();
            CommentsList comments = db.SelectAll();
            return comments;
        }

        [HttpGet]
        [ActionName("DigitalBooksSelector")]
        public DigitalBooksList SelectAllDigitalBooks()
        {
            DigitalBooksDB db = new DigitalBooksDB();
            DigitalBooksList digitalBooks = db.SelectAll();
            return digitalBooks;
        }

        [HttpGet]
        [ActionName("MovieBooksSelector")]
        public MovieBooksList SelectAllMovieBooks()
        {
            MovieBooksDB db = new MovieBooksDB();
            MovieBooksList movieBooks = db.SelectAll();
            return movieBooks;
        }

        [HttpGet]
        [ActionName("ReviewSelector")]
        public ReviewList SelectAllReview()
        {
            ReviewDB db = new ReviewDB();
            ReviewList review = db.SelectAll();
            return review;
        }

        [HttpGet]
        [ActionName("UserSelector")]
        public UserList SelectAllUser()
        {
            UserDB db = new UserDB();
            UserList user = db.SelectAll();
            return user;
        }

        [HttpGet]
        [ActionName("WriterSelector")]
        public WriterList SelectAllWriter()
        {
            WriterDB db = new WriterDB();
            WriterList writer = db.SelectAll();
            return writer;
        }

        [HttpGet]
        [ActionName("LoginInsert")]
        public User? InsertALogin([FromBody] JsonElement login)
        {
            string email = login.GetProperty("email").GetString();
            string userName = login.GetProperty("userName").GetString();
            int ppassword = int.Parse(login.GetProperty("ppassword").GetString());

            UserList allUsers = new SelectController().SelectAllUser();
            User u = allUsers.Find(x => x.UserName == userName && x.Email == email && x.Ppassword1 == ppassword);
            if (u == null)
                return null;
            else return u;
        }


        [HttpGet]
        [ActionName("CloseConnection")]
        public void CloseConnection()
        {
        BaseDB.CloseConnection();
        }
    }
}
