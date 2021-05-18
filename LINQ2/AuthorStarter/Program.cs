using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace AuthorStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new AuthorRepo();
            var authors = repo.GetAuthors();

            //-How many books are collaborations(have more than one author)?
             List<Book> allBooks = authors.SelectMany(x => x.Books).OrderBy(x =>x.ID).ToList();
            
            List<int> collaborations= allBooks.GroupBy(x =>x.ID)
                                 .Where(y =>y.Count() > 1)
                                 .Select(y =>y.Key)
                                 .ToList();
                                 
            Console.WriteLine($"Total of {collaborations.Count} books are collaborations!");
            Console.WriteLine("=========================");
                             
            //-Which book has the most authors(and how many) ?
            int maxCollaborations= allBooks.GroupBy(x =>x.ID)
                                           .Select(y =>y.Count())
                                           .Max();
            Book bookWithMostAuthors=allBooks.GroupBy(x =>x.ID)
                                                      .Where(y =>y.Count()==maxCollaborations)
                                                      .SelectMany(z =>z).FirstOrDefault();
                        
            Console.WriteLine($"The book with the most authors is {bookWithMostAuthors.Title}, with {maxCollaborations} authors precisely!");                
            Console.WriteLine("=========================");
          
          //  -What author wrote most collaborations ? "
               int maxColabsAuthor=authors.Select(x =>x.Books.Select(y =>y.ID)
                                                             .Where(y=>collaborations.Any(z =>z==y))
                                                             .Count())
                                                             .ToList()
                                                             .Max();
               Author authorWithMaxCollabs=authors.Where(x=>x.Books.Select(y =>y.ID)
                                                  .Where(y => collaborations.Any(z =>z==y))
                                                  .Count()==maxColabsAuthor)
                                                  .SingleOrDefault();  

               Console.WriteLine($"{authorWithMaxCollabs.Name} is the author with maximum collaborations, precisely he has  {maxColabsAuthor} collaborations!");                               
            Console.WriteLine("=========================");
                                                
            //-In what year were published most books in a specific genre? Which genre ?
            int maxScienceFictionInYear=allBooks.GroupBy(x=>x.Year)
                                  .Select(x =>x.SelectMany(y =>y.Genres.Where(z =>z==Genre.ScienceFiction)))
                                  .Select(x =>x.Count())
                                  .Max();
                                  
            int maxFantasyInYear=allBooks.GroupBy(x=>x.Year)
                                  .Select(x =>x.SelectMany(y =>y.Genres.Where(z =>z==Genre.Fantasy)))
                                  .Select(x =>x.Count())
                                  .Max();
            
            int maxHorrorInYear=allBooks.GroupBy(x=>x.Year)
                                  .Select(x =>x.SelectMany(y =>y.Genres.Where(z =>z==Genre.Horror)))
                                  .Select(x =>x.Count())
                                  .Max();
            List<int> allGenresMaximum=new List<int>(){maxScienceFictionInYear,maxFantasyInYear,maxHorrorInYear};
            int maximumSpecificGenre=allGenresMaximum.Max();

             int yearForMaxSpecificGenre=allBooks.GroupBy(x=>x.Year)
                                  .Where(x =>x.SelectMany(y =>y.Genres.Where(z =>z==Genre.Fantasy)).Count()==maximumSpecificGenre)
                                  .Select(x =>x.Key)
                                  .SingleOrDefault();
                Console.WriteLine($"In {yearForMaxSpecificGenre} were published most books in genre Fantasy !");
                                
            Console.WriteLine("=========================");
                    
            //-Which author has most books nominated for an award?

            int maxBooksOfAuthorNominatedForAward= authors.Select(x =>x.Books.Where(y =>y.Nominations>0).Count())
                                                          .Max();
            Author authorWithMostBooksNominatedForAward=authors.Where(x =>x.Books.Where(y =>y.Nominations>0).Count()==maxBooksOfAuthorNominatedForAward)
                                                            .SingleOrDefault();
            Console.WriteLine($"{authorWithMostBooksNominatedForAward.Name} is the author who has most books nominated for an award or in total exactly {maxBooksOfAuthorNominatedForAward} books!");
            Console.WriteLine("=========================");
                               
            //-Which author has most books that won an award ?
            int booksPerAuthorWithMaxWons=authors.Select(x =>x.Books.Where(y =>y.Wins>0).Count()).Max();
            List<Author> authorWithMostBooksThatWonAnAward=authors.Where(x =>x.Books.Where(y =>y.Wins>0).Count()==booksPerAuthorWithMaxWons)
                                                            .ToList();
        
            Console.WriteLine($"{authorWithMostBooksThatWonAnAward[0].Name}, {authorWithMostBooksThatWonAnAward[1].Name}, {authorWithMostBooksThatWonAnAward[2].Name} are the authors with most books that won an award or in total {booksPerAuthorWithMaxWons} books each!");
            Console.WriteLine("=========================");
          
            //-Which author has most books nominated for an award, without winning a single award ?
            int booksNominatedWithoutAward = authors.Where(x =>x.Books.Where(y =>y.Wins==0).Count()==x.Books.Count())
                             .Select(x =>x.Books.Where(y =>y.Nominations>0).Count())
                             .Max();

            Author authorMostNominationsNoAward =authors.Where(x =>x.Books.Where(y =>y.Wins==0).Count()==x.Books.Count())
                             .Where(x =>x.Books.Where(y =>y.Nominations>0).Count()==booksNominatedWithoutAward)
                             .SingleOrDefault();
                             
            Console.WriteLine($"{authorMostNominationsNoAward.Name} is the author that has most books nominated for an award, without single award!");
            Console.WriteLine($"Actually he has {booksNominatedWithoutAward} books nominated without wining a single award!");
                              
            Console.WriteLine("=========================");
          
            //-Make a histogram of books published per decade per genre.
           
            var histogram=allBooks.Distinct().OrderBy(x =>x.Year)
                            .GroupBy(x =>x.Year/10 *10)
                            .Select(x =>new {
                                Decade=x.Key, 
                                Fantasy=x.SelectMany(y => y.Genres.ToList().Where(z =>z==Genre.Fantasy)),
                                ScienceFiction=x.SelectMany(y => y.Genres.ToList().Where(z =>z==Genre.ScienceFiction)),
                                Horror=x.SelectMany(y =>y.Genres.ToList().Where(z =>z==Genre.Horror))})
                            .ToList();
      
             Console.WriteLine(string.Format(" {0,5}  {1,5} {2,5} {3,5}", "Decade:", "SciFi:","F-sy:","Horr:"));
             histogram.ForEach(x => Console.WriteLine(string.Format(" {0,5}  {1,5} {2,5} {3,5}", x.Decade, x.ScienceFiction.Count(),x.Fantasy.Count(),x.Horror.Count())));

                 
                                    
                           
            Console.WriteLine("=========================");
             
            
            //- Which author has a highest percentage of nominated books ?
            int highestPercentage =authors.Select(x =>x.Books.Where(y =>y.Nominations>0).Count()/x.Books.Count()).Max();
            int booksHighestPercentage=authors.Where(x =>x.Books.Where(y =>y.Nominations>0).Count()/x.Books.Count()==highestPercentage)
                           .Select(x =>x.Books.Count())
                           .Max();
            int mostWins=authors.Where(x =>x.Books.Where(y =>y.Nominations>0).Count()/x.Books.Count()==1)
                           .Where(x =>x.Books.Count()==booksHighestPercentage)
                           .Select(x =>x.Wins)
                           .Max();
            Author authorHighestPercentageNominatedBooks=authors.Where(x =>x.Books.Where(y =>y.Nominations>0).Count()/x.Books.Count()==1)
                           .Where(x =>x.Books.Count()==booksHighestPercentage)
                           .Where(x =>x.Wins==mostWins)
                           .SingleOrDefault();
             Console.WriteLine($"{authorHighestPercentageNominatedBooks.Name} is the author with highest percentage of nominated books!");
             Console.WriteLine($"In fact he has {highestPercentage *100} % of his books nominated!");

            

        }
    }
}
