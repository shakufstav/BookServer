using Microsoft.AspNetCore.Mvc;
using Model;
using System.Text.Json;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class InsertController : ControllerBase
    {
        [HttpPost]
        [ActionName("GenreInsert")]
        //אינסרט מחזיר כמה שדות השתנו
        public int InsertAGenre([FromBody] Genre genre)
        {
            GenreDB db = new GenreDB(); 
            db.Insert(genre);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("BooksInsert")]
        public int InsertABooks([FromBody] Books books)
        {
            BooksDB db = new BooksDB();
            db.Insert(books);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("BooksLibraryInsert")]
        public int InsertABooksLibrary([FromBody] BooksLibrary booksLibrary)
        {
            BooksLibraryDB db = new BooksLibraryDB();
            db.Insert(booksLibrary);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("CategoryInsert")]
        public int InsertACategory([FromBody] Category category)
        {
            CategoryDB db = new CategoryDB();
            db.Insert(category);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("CommentsInsert")]
        public int InsertAComments([FromBody] Comments comments)
        {
            CommentsDB db = new CommentsDB();
            db.Insert(comments);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("DigitalBooksInsert")]
        public int InsertADigitalBooks([FromBody] DigitalBooks digitalBooks)
        {
            DigitalBooksDB db = new DigitalBooksDB();
            db.Insert(digitalBooks);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("MovieBooksInsert")]
        public int InsertAMovieBooks([FromBody] MovieBooks movieBooks)
        {
            MovieBooksDB db = new MovieBooksDB();
            db.Insert(movieBooks);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("ReviewInsert")]
        public int InsertAReview([FromBody] Review review)
        {
            ReviewDB db = new ReviewDB();
            db.Insert(review);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("UserInsert")]
        public int InsertAUser([FromBody] User user)
        {
            UserDB db = new UserDB();
            db.Insert(user);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("WriterInsert")]
        public int InsertAWriter([FromBody] Writer writer)
        {
            WriterDB db = new WriterDB();
            db.Insert(writer);
            int x = db.SaveChanges();
            return x;
        }

        [HttpPost]
        [ActionName("LoginInsert")]
        public ActionResult InsertALogin([FromBody] JsonElement login)
        {
           string  email=login.GetProperty("email").GetString();
           string userName = login.GetProperty("userName").GetString();
           int ppassword = login.GetProperty("ppassword1").GetInt32();

            UserList allUsers = new SelectController().SelectAllUser() ;
            User u= allUsers.Find(x=>x.UserName == userName)   ;
                if (u == null) { return BadRequest(); }
                return Ok(u);

       
           
        }

        [HttpPost]
        [ActionName("RegisterInsert")]
        public ActionResult InsertARegister([FromBody] JsonElement register)
        {
            UserDB db= new UserDB();
            string email = register.GetProperty("email").GetString();
            string userName = register.GetProperty("userName").GetString();
            string ppassword = register.GetProperty("ppassword").GetString();
            User user=db.SelectAll().Find(x=>x.UserName == userName);
            if(user == null) 
                return BadRequest();
            User newUsers = new User {Email=email ,UserName = userName, Ppassword1 = int.Parse(ppassword) };
            InsertAUser(newUsers);
            return Ok(newUsers);
        }


    }
}
