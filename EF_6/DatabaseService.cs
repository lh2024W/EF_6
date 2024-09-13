using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6
{
    public class DatabaseService
    {

        DbContextOptions<ApplicationContext> options;

        public void EnsurePopulated()
        {

            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");


            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            options = optionsBuilder.UseSqlServer(connectionString).Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //List<Author> authors = new List<Author>
                //{
                //    new Author{ Name = "Джером Клапка Джером"},
                //    new Author { Name = "Теодор Драйзер" },
                //    new Author { Name = "Маргарет Митчелл"}
                //};
                //db.AddRange(authors);


                //List<Genre> genres = new List<Genre>
                //{
                //    new Genre { Name = "Повесть"},
                //    new Genre { Name = "Роман"}
                //};
                //db.AddRange(genres);

                List<Book> books = new List<Book>
                {
                new Book { Title = "Трое в лодке, не считая собаки", AuthorId = 1, GenreId = 1, Price = 150 },
                new Book { Title = "Финансист", AuthorId = 2, GenreId = 2, Price = 136},
                new Book { Title = "Унесённые ветром", AuthorId = 3, GenreId = 2, Price = 187}
                };
                db.AddRange(books);

                db.SaveChanges();
            }
        }

            //1) Получить количество книг определенного жанра.
            public void GetCountBooksByGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var countBooksByGenre = db.Books.Where(e => e.GenreId == idGenre).Count();
                }
            }

        //2) Получить минимальную цену для книг определенного автора.
            public void GetMinPriceBookByGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var minPriceBookByGenre = db.Books.Where(e => e.GenreId == idGenre).Min(e => e.Price);
                }
            }

        //3) Получить среднюю цену книг в определенном жанре.
            public void GetAvgPriceBookByGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var avgPriceBookByGenre = db.Books.Where(e => e.GenreId == idGenre).Average(e => e.Price);
                }
            }

        //4) Получить суммарную стоимость всех книг определенного автора.
            public void GetSumPriceBookByGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var sumPriceBookByGenre = db.Books.Where(e => e.GenreId == idGenre).Sum(e => e.Price);
                }
            }

        //5) Выполнить группировку книг по жанрам.
            public void GetGroupBookByGenre()
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var groupBookByGenre = db.Books.GroupBy(e => e.Genre).ToList();
                }
            }

        //6) Выбрать только названия книг определенного жанра.
            public void GetNameBooksByGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var nameBooksByGenre = db.Books.Where(e => e.GenreId == idGenre).Select(e => e.Title).ToList();
                }
            }

        //7) Выбрать все книги, кроме тех, что относятся к определенному жанру, используя метод Except.
            public void GetBooksNotThisGenre(int idGenre)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var booksNotThisGenre = db.Books.Except(db.Books.Where(e => e.GenreId != idGenre)).ToList();
                }
            }

        //8) Объединить книги от двух авторов, используя метод Union.
            public void GetGroupBooksTwoAuthors(int idAuthor1, int idAuthor2)
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var groupBooksTwoAuthors = db.Books.Where(e => e.AuthorId == idAuthor1)
                    .Union(db.Books.Where(e => e.AuthorId == idAuthor2)).ToList();
                }
            }

        //9) Достать 5 - ть самых дорогих книг.
            public void GetTwoMostExpensiveBooks()
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var twoMostExpensiveBooks = db.Books.Take(2).Max(e => e.Price);
                }
            }

        //10) Пропустить первые 10 книг и взять следующие 5.
            public void GetTwoBooksInOne()
            {
                using (ApplicationContext db = new ApplicationContext(options))
                {
                    var twoMostExpensiveBooks = db.Books.Skip(1).Take(2).ToList();
                }
            }

    }
}


    

