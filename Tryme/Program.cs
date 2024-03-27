using Model;
using ViewModel;

//בדיקות סלקטאול לכל המחלקות//////////////////////////////////////////////////////////
//עובד
//CategoryDB categoryDB = new CategoryDB();
//CategoryList listC = categoryDB.SelectAll();
//foreach (var c in listC)
//{
//   Console.WriteLine(c.BookCategory);
//}

//עובד 
//DigitalBooksDB digitalbooksDB = new DigitalBooksDB();
//DigitalBooksList listD = digitalbooksDB.SelectAll();
//foreach (var d in listD)
//{
//    Console.WriteLine(d.AudioLink);
//}

//עובד
//GenreDB genreDB = new GenreDB();
//GenreList listG = genreDB.SelectAll();
//foreach (var g in listG)
//{
//    Console.WriteLine(g.GenreName);
//}

//עובד
//MovieBooksDB moviebooksDB = new MovieBooksDB();
//MovieBooksList listM = moviebooksDB.SelectAll();
//foreach (var c in listM)
//{
//    Console.WriteLine(c.Trailer);
//}

//עובד
//WriterDB writerDB = new WriterDB();
//WriterList listW = writerDB.SelectAll();
//foreach (var c in listW)
//{
//    Console.WriteLine(c.WriterName);
//}

//עובד
//BooksDB booksDB = new BooksDB();
//BooksList listb = booksDB.SelectAll();
//foreach (var c in listb)
//{
//    Console.WriteLine(c.BookName +"" +c.Genre.GenreName +""+ c.Writer.WriterName);
//}

//עובד
//CommentsDB commentsDB = new CommentsDB();
//CommentsList listc = commentsDB.SelectAll();
//foreach (var c in listc)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.Comment);
//}

//עובד
//ReviewDB reviewDB = new ReviewDB();
//ReviewList listr = reviewDB.SelectAll();
//foreach (var c in listr)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.Star);
//}

//עובד
//BooksLibraryDB booksLibraryDB = new BooksLibraryDB();
//BooksLibraryList listbl = booksLibraryDB.SelectAll();
//foreach (var c in listbl)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.AddDate + " " +c.BookCategory.BookCategory);
//}

//UserDB userDB = new UserDB();
//UserList listbl = userDB.SelectAll();
//foreach (var c in listbl)
//{
//    Console.WriteLine(c.UserName + "" + c.Ppassword1 + "" + c.Email);
//}

// בדיקות לבוקס////////////////////////////////////////////////////////////////////////////////
//BooksDB db = new BooksDB();
//BooksList lst = db.SelectAll();

// הוספה לבוקס עובד
//Books b1 = new Books();
//b1.BookName = "the archer";
//WriterDB writerdb = new WriterDB();
//b1.Writer = writerdb.SelectAll().First();
//GenreDB genredb = new GenreDB();
//b1.Genre = genredb.SelectAll().First();
//db.Insert(b1);
//db.SaveChanges();

// מחיקה לבוקס עובד
//db.Delete(lst.Last());
//db.SaveChanges();

//עדכון לבוקס עובד
//Books b= lst.Last();
//b.BookName = "the lion";
//b.Genre.Id = 3; 
//db.Update(b);   
//db.SaveChanges();

//BooksDB booksDB = new BooksDB();
//BooksList listb = booksDB.SelectAll();
//foreach (var c in listb)
//{
//    Console.WriteLine(c.BookName + "" + c.Genre.GenreName + "" + c.Writer.WriterName);
//}

//בדיקה לבוקס ליברארי////////////////////////////////////////////////////////////////////////////////////////////

//BooksLibraryDB db = new BooksLibraryDB();
//BooksLibraryList lst = db.SelectAll();

//הוספה לבוקס ליברארי עובד
//BooksLibrary b1 = new BooksLibrary();
//UserDB userdb = new UserDB();
//b1.UserId = userdb.SelectAll().First();
//BooksDB booksdb = new BooksDB();
//b1.BookId = booksdb.SelectAll().First();
//b1.AddDate = DateTime.Now;
//CategoryDB categorydb  = new CategoryDB();
//b1.BookCategory = categorydb.SelectAll().First();
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לבוקס ליברארי עובד
//db.Delete(lst.First());
//db.SaveChanges();

//עדכון לבוקס ליברארי עובד
//BooksLibrary b = lst.Last();
//b.UserId.Id = 3;
//b.BookId.Id = 6;
//b.AddDate= DateTime.Now;
//b.BookCategory.Id = 3;
//db.Update(b);
//db.SaveChanges();

//BooksLibraryDB booksLibraryDB = new BooksLibraryDB();
//BooksLibraryList listbl = booksLibraryDB.SelectAll();
//foreach (var c in listbl)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.AddDate + " " + c.BookCategory.BookCategory);
//}

//בדיקה לקטגורי////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//CategoryDB db = new CategoryDB();
//CategoryList lst = db.SelectAll();

//הוספה לקטגורי עובד//////////////////////////////////////////////////
//Category b1 = new Category();
//b1.BookCategory = "קומיקס";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לקטגורי עובד
//db.Delete(lst.Last());
//db.SaveChanges();

//עדכון לקטגורי עובד
//Category b = lst.Last();
//b.BookCategory = "ckv";
//db.Update(b);
//db.SaveChanges();

//CategoryDB categoryDB = new CategoryDB();
//CategoryList listC = categoryDB.SelectAll();
//foreach (var c in listC)
//{
//    Console.WriteLine(c.BookCategory);
//}

//בדיקות לקומנטס//////////////////////////////////////////////////////////////////////////

//CommentsDB db = new CommentsDB();
//CommentsList lst = db.SelectAll();

//הוספה לקומנאס עובד
//Comments b1 = new Comments();
//UserDB userdb = new UserDB();
//b1.UserId = userdb.SelectAll().Last();
//BooksDB booksdb = new BooksDB();
//b1.BookId = booksdb.SelectAll().Last();
//b1.Comment = "cool book, i really enjoyed";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לקומנטס עובד
//db.Delete(lst.First());
//db.SaveChanges();

//עדכון לקומנטס עובד
//Comments b = lst.Last();
//b.UserId = UserDB.SelectById(2);
//b.BookId = BooksDB.SelectById(6);
//b.Comment = "cool book, i really enjoyed!!!!!";
//db.Update(b);
//db.SaveChanges();

//CommentsDB commentsDB = new CommentsDB();
//CommentsList listc = commentsDB.SelectAll();
//foreach (var c in listc)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.Comment);
//}

// בדיקות לדיגיטל בוקס////////////////////////////////////////////////////////////////////////////////////////////

//DigitalBooksDB db = new DigitalBooksDB();
//DigitalBooksList lst = db.SelectAll();

//הוספה לדיגיטל בוקס עובד
//DigitalBooks b1 = new DigitalBooks();
//b1.Id = 7;
//b1.AudioLink = "קומיקס";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לדיגיטל בוקס עובד
//db.Delete(lst.First());
//db.SaveChanges();

//עדכון לדיגיטל בוקס עובד
//DigitalBooks b = lst.Last();
//b.AudioLink = "מותחן קומיקס";
//db.Update(b);
//db.SaveChanges();

//DigitalBooksList listD = db.SelectAll();
//foreach (var d in listD)
//{
//    Console.WriteLine(d.Id+""+d.AudioLink);
//}

//בדיקות לזאנר///////////////////////////////////////////////////////////////////////////////////////////////////////

//GenreDB db = new GenreDB();
//GenreList lst = db.SelectAll();

//הוספה לזאנר
//Genre b1 = new Genre();
//b1.GenreName = "עדויות";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לזאנר עובד
//db.Delete(lst.Last());
//db.SaveChanges();


//עדכון לזאנר עובד
//Genre b = lst.Last();
//b.GenreName = "עדויותתתתתתת";
//db.Update(b);
//db.SaveChanges();

//GenreDB genreDB = new GenreDB();
//GenreList listG = genreDB.SelectAll();
//foreach (var g in listG)
//{
//    Console.WriteLine(g.GenreName);
//}

//בדיקות למובי בוקס//////////////////////////////////////////////////////////////////////////

//MovieBooksDB db = new MovieBooksDB();
//MovieBooksList lst = db.SelectAll();

//הוספה לדיגיטל בוקס עובד
//MovieBooks b1 = new MovieBooks();
//b1.Id = 7;
//b1.Trailer = "קישור";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לדיגיטל בוקס עובד
//db.Delete(lst.Last());
//db.SaveChanges();

//עדכון לדיגיטל בוקס עובד
//MovieBooks b = lst.Last();
//b.Trailer = "טריילר מותחן קומיקס";
//db.Update(b);
//db.SaveChanges();

//MovieBooksDB moviebooksDB = new MovieBooksDB();
//MovieBooksList listM = moviebooksDB.SelectAll();
//foreach (var c in listM)
//{
//    Console.WriteLine(c.Trailer);
//}

//בדיקות לריוויו//////////////////////////////////////////////////////////////////////////

//ReviewDB db = new ReviewDB();
//ReviewList lst = db.SelectAll();

//הוספה לריוויו עובד
//Review b1 = new Review();
//UserDB userdb = new UserDB();
//b1.UserId = userdb.SelectAll().Last();
//BooksDB booksdb = new BooksDB();
//b1.BookId = booksdb.SelectAll().Last();
//b1.Star = 3;
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לריוויו עובד
//db.Delete(lst.First());
//db.SaveChanges();

//עדכון ריוויו עובד
//Review b = lst.Last();
//b.UserId = UserDB.SelectById(2);
//b.BookId = BooksDB.SelectById(6);
//b.Star = 5;
//db.Update(b);
//db.SaveChanges();

//ReviewDB reviewDB = new ReviewDB();
//ReviewList listr = reviewDB.SelectAll();
//foreach (var c in listr)
//{
//    Console.WriteLine(c.UserId.UserName + "" + c.BookId.BookName + "" + c.Star);
//}

//בדיקות ליוזר//////////////////////////////////////////////////////////////////////////////////

//UserDB db = new UserDB();
//UserList lst = db.SelectAll();

//הוספה יוזר עובד
//User b1 = new User();
//b1.UserName = "רוני";
//b1.Ppassword1 = 663662;
//b1.Email = " roni.gmail";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה ליוזר עובד
//db.Delete(lst.Last());
//db.SaveChanges();


//עדכון ליוזר עובד
//User b = lst.Last();
//b.UserName = "רוני קרול";
//b.Ppassword1 = 8888899;
//b.Email = "rony.kerol.gmail.com";
//db.Update(b);
//db.SaveChanges();

//UserDB userDB = new UserDB();
//UserList listbl = userDB.SelectAll();
//foreach (var c in listbl)
//{
//    Console.WriteLine(c.UserName + "" + c.Ppassword1 + "" + c.Email);
//}

//בדיקות לרייטרס/////////////////////////////////////////////////////////////////////////////////////////////////////////

//WriterDB db = new WriterDB();
//WriterList lst = db.SelectAll();

//הוספה לרייטרס עובד
//Writer b1 = new Writer();
//b1.WriterName = "שרון צוהljjjj";
//db.Insert(b1);
//db.SaveChanges();

//מחיקה לרייטרס עובד
//db.Delete(lst.Last());
//db.SaveChanges();


//עדכון לרייטרס עובד
//Writer b = lst.Last();
//b.WriterName = "שרון צוהר";
//db.Update(b);
//db.SaveChanges();

//WriterDB writerDB = new WriterDB();
//WriterList listW = writerDB.SelectAll();
//foreach (var c in listW)
//{
//    Console.WriteLine(c.WriterName);
//}