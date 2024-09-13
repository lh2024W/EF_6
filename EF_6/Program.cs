using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System.Diagnostics;

namespace EF_6
{
    public class Program
    {
        private static DatabaseService databaseService;
        static void Main()
        {
            databaseService = new DatabaseService();
            databaseService.EnsurePopulated();

            databaseService.GetCountBooksByGenre(1);//1
            databaseService.GetMinPriceBookByGenre(2);//2
            databaseService.GetAvgPriceBookByGenre(2);//3
            databaseService.GetSumPriceBookByGenre(2);//4
            databaseService.GetGroupBookByGenre();//5
            databaseService.GetNameBooksByGenre(1);//6
            databaseService.GetBooksNotThisGenre(2);//7
            databaseService.GetGroupBooksTwoAuthors(1, 3);//8
            databaseService.GetTwoMostExpensiveBooks();//9
            databaseService.GetTwoBooksInOne();//10
        }
    }
}


