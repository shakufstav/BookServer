using Model;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace API_service
{
    public class APIservice : IapiService
    {
        private HttpClient _httpClient;
        private string URI;
        public APIservice(){ _httpClient = new(); URI = "http://localhost:5213/api"; }

        //פעולות על בוקס/////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<int> DeleteBook(Books books)
        {

            return (await _httpClient.DeleteAsync(URI + "/Delete/BooksDelete/" + books.Id)).IsSuccessStatusCode ? 1 : 0;
        }
        public  async Task<int> DeleteBookLibrary(BooksLibrary booksLibrary)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/BooksLibraryDelete/" + booksLibrary.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteCategory(Category category)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/CategoryDelete/" + category.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteComments(Comments comments)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/CommentsDelete/" + comments.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteDigitalBooks(DigitalBooks digitalBooks)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/DigitalBooksDelete/" + digitalBooks.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public  async Task<int> DeleteGenre(Genre genre)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/GenreDelete/" + genre.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public  async Task<int> DeleteMovieBooks(MovieBooks movieBooks)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/MovieBooksDelete/" + movieBooks.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public  async Task<int> DeleteReview(Review review)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/ReviewDelete/" + review.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> DeleteUser(User user)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/UserDelete/" + user.Id)).IsSuccessStatusCode ? 1 : 0;
        }

        public  async Task<int> DeleteWriter(Writer writer)
        {
            return (await _httpClient.DeleteAsync(URI + "/Delete/WriterDelete/" + writer.Id)).IsSuccessStatusCode ? 1 : 0;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///






        public async Task<BooksList> GetBooks()
        {
            return await _httpClient.GetFromJsonAsync<BooksList>(URI+ "/Select/BooksSelector");
        }

        public async  Task<BooksLibraryList> GetBooksLibrary()
        {
            return await _httpClient.GetFromJsonAsync<BooksLibraryList>(URI + "/Select/BooksLibrarySelector");
        }

        public async Task<CategoryList> GetCategory()
        {
            return await _httpClient.GetFromJsonAsync<CategoryList>(URI + "/Select/CategorySelector");
        }

        public async Task<CommentsList> GetComments()
        {
            return await _httpClient.GetFromJsonAsync<CommentsList>(URI + "/Select/CommentsSelector");
        }

        public async Task<DigitalBooksList> GetDigitalBooks()
        {
            return await _httpClient.GetFromJsonAsync<DigitalBooksList>(URI + "/Select/DigitalBooksSelector");
        }

        public async Task<GenreList> GetGenre()
        {
            return await _httpClient.GetFromJsonAsync<GenreList>(URI + "/Select/GenreSelector");
        }

        public async Task<MovieBooksList> GetMovieBooks()
        {
            return await _httpClient.GetFromJsonAsync<MovieBooksList>(URI + "/Select/MovieBooksSelector");
        }

        public async Task<ReviewList> GetReview()
        {
            return await _httpClient.GetFromJsonAsync<ReviewList>(URI + "/Select/ReviewSelector");
        }

        public async Task<UserList> GetUser()
        {
            return await _httpClient.GetFromJsonAsync<UserList>(URI + "/Select/UserSelector");
        }

        public async Task<WriterList> GetWriter()
        {
            return await _httpClient.GetFromJsonAsync<WriterList>(URI + "/Select/WriterSelector");
        }

        public async Task<HttpResponseMessage> Login(string Email, string username ,int ppassword1)
        {
            return await _httpClient.PostAsJsonAsync(URI + "/Insert/LoginInsert", new { Email=Email , UserName=username , Ppassword1=ppassword1 });
        }

        public async Task<int> Register(User user)
        {
            string uri = URI + "/Insert/RegisterInsert";
            var responseMessage = await _httpClient.PostAsJsonAsync<User>(uri, user);
            if(responseMessage.IsSuccessStatusCode == true)
            {
                return 1;
            }
            return 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        


        public async Task<int> InsertBook(Books books)
        {
            return (await _httpClient.PostAsJsonAsync < Books >( URI + "/Insert/BooksInsert",books)).IsSuccessStatusCode?1:0;
        }

        public async Task<int> InsertBookLibrary(BooksLibrary BooksLibrary)
        {
            return (await _httpClient.PostAsJsonAsync<BooksLibrary>(URI + "/Insert/BooksLibraryInsert", BooksLibrary)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertCategory(Category category)
        {
            return (await _httpClient.PostAsJsonAsync<Category>(URI + "/Insert/CategoryInsert", category)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertComments(Comments comments)
        {
            return (await _httpClient.PostAsJsonAsync<Comments>(URI + "/Insert/CommentsInsert", comments)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertDigitalBooks(DigitalBooks digitalBooks)
        {
            return (await _httpClient.PostAsJsonAsync<DigitalBooks>(URI + "/Insert/DigitalBooksInsert", digitalBooks)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertGenre(Genre genre)
        {
            return (await _httpClient.PostAsJsonAsync<Genre>(URI + "/Insert/GenreInsert", genre)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertMovieBooks(MovieBooks movieBookks)
        {
            return (await _httpClient.PostAsJsonAsync<MovieBooks>(URI + "/Insert/MovieBooksInsert", movieBookks)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertReview(Review review)
        {
            return (await _httpClient.PostAsJsonAsync<Review>(URI + "/Insert/ReviewInsert", review)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertUser(User user)
        {
            return (await _httpClient.PostAsJsonAsync<User>(URI + "/Insert/UserInsert", user)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> InsertWriter(Writer writer)
        {
            return (await _httpClient.PostAsJsonAsync<Writer>(URI + "/Insert/WriterInsert", writer)).IsSuccessStatusCode ? 1 : 0;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        





        public async Task<int> UpdateBook(Books books)
        {
            return (await _httpClient.PutAsJsonAsync<Books>(URI + "Put/BooksPut", books)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateBookLibrary(BooksLibrary booksLibrary)
        {
            return (await _httpClient.PutAsJsonAsync<BooksLibrary>(URI + "Put/BooksLibraryPut", booksLibrary)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            return (await _httpClient.PutAsJsonAsync<Category>(URI + "Put/CategoryPut", category)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateComments(Comments comments)
        {
            return (await _httpClient.PutAsJsonAsync<Comments>(URI + "Put/CommentsPut", comments)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateDigitalBooks(DigitalBooks digitalBooks)
        {
            return (await _httpClient.PutAsJsonAsync<DigitalBooks>(URI + "Put/DigitalBooksPut", digitalBooks)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateGenre(Genre genre)
        {
            return (await _httpClient.PutAsJsonAsync<Genre>(URI + "Put/GenrePut", genre)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateMovieBooks(MovieBooks movieBookks)
        {
            return (await _httpClient.PutAsJsonAsync<MovieBooks>(URI + "Put/MovieBooksPut", movieBookks)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateReview(Review review)
        {
            return (await _httpClient.PutAsJsonAsync<Review>(URI + "Put/ReviewPut", review)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateUser(User user)
        {
            return (await _httpClient.PutAsJsonAsync<User>(URI + "Put/UserPut", user)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task<int> UpdateWriter(Writer writer)
        {
            return (await _httpClient.PutAsJsonAsync<Writer>(URI + "Put/WriterPut", writer)).IsSuccessStatusCode ? 1 : 0;
        }

        public async Task CloseConnection()
        {
            HttpClient httpClient = new HttpClient();
            string uri = "http://localhost:5213/api/Select/CloseConnection";
            await httpClient.GetFromJsonAsync<string>(uri);
        }

    }
    public interface IapiService
    { 
        public Task<BooksList> GetBooks();
        public Task<int> InsertBook(Books books);
        public Task<int> UpdateBook(Books books);
        public Task<int> DeleteBook(Books books);

        public Task<BooksLibraryList> GetBooksLibrary();
        public Task<int> InsertBookLibrary(BooksLibrary booksLibrary);
        public Task<int> UpdateBookLibrary(BooksLibrary booksLibrary);
        public Task<int> DeleteBookLibrary(BooksLibrary booksLibrary);

        public Task<CategoryList> GetCategory();
        public Task<int> InsertCategory(Category category);
        public Task<int> UpdateCategory(Category category);
        public Task<int> DeleteCategory(Category category);

        public Task<CommentsList> GetComments();
        public Task<int> InsertComments(Comments comments);
        public Task<int> UpdateComments(Comments comments);
        public Task<int> DeleteComments(Comments comments);

        public Task<DigitalBooksList> GetDigitalBooks();
        public Task<int> InsertDigitalBooks(DigitalBooks digitalBooks);
        public Task<int> UpdateDigitalBooks(DigitalBooks digitalBooks);
        public Task<int> DeleteDigitalBooks(DigitalBooks digitalBooks);

        public Task<GenreList> GetGenre();
        public Task<int> InsertGenre(Genre genre);
        public Task<int> UpdateGenre(Genre genre);
        public Task<int> DeleteGenre(Genre genre);

        public Task<MovieBooksList> GetMovieBooks();
        public Task<int> InsertMovieBooks(MovieBooks movieBookks);
        public Task<int> UpdateMovieBooks(MovieBooks movieBookks);
        public Task<int> DeleteMovieBooks(MovieBooks movieBookks);

        public Task<ReviewList> GetReview();
        public Task<int> InsertReview(Review review);
        public Task<int> UpdateReview(Review review);
        public Task<int> DeleteReview(Review review);

        public Task<UserList> GetUser();
        public Task<int> InsertUser(User user);
        public Task<int> UpdateUser(User user);
        public Task<int> DeleteUser(User user);

        public Task<WriterList> GetWriter();
        public Task<int> InsertWriter(Writer writer);
        public Task<int> UpdateWriter(Writer writer);
        public Task<int> DeleteWriter(Writer writer);

        public Task CloseConnection();
    };
}