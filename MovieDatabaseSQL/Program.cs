using MovieDatabaseSQL;
using MovieDatabaseSQL.Models;

//populate table with 10-15 movies.
static void AddMovies()
{
    using (MovieDBContext context = new MovieDBContext())
    {
        List<Movie> movies = new List<Movie>()
    {
        new Movie(){Title = "Shrek", Genre = "Animated", Runtime = 90},
        new Movie(){Title = "Shrek 2", Genre = "Animated", Runtime = 105},
        new Movie(){Title = "Shrek the Third", Genre = "Animated", Runtime = 93},
        new Movie(){Title = "Shrek Forever After", Genre = "Animated", Runtime = 93},
        new Movie(){Title = "Moonlight", Genre = "Drama", Runtime = 110},
        new Movie(){Title = "Airplane!", Genre = "Comedy", Runtime = 87},
        new Movie(){Title = "Monty Python and the Holy Grail", Genre = "Comedy", Runtime = 89},
        new Movie(){Title = "But I'm a Cheerleader", Genre = "Comedy", Runtime = 84},
        new Movie(){Title = "Hairspray", Genre = "Musical", Runtime = 117},
        new Movie(){Title = "Cats", Genre = "Musical", Runtime = 110}
    };

        foreach (Movie m in movies)
        {
            context.Movies.Add(m);
        }

        context.SaveChanges();
    }

}

//AddMovies();

//Add static methods to search by movie genre and title.
static List<Movie> SearchByGenre()
{
    while (true)
    {
        //get input
        Console.WriteLine("Enter a genre to search by.");
        string choice = Console.ReadLine().Trim().ToLower();

        //create list of matching movies
        using (MovieDBContext context = new MovieDBContext())
        {
            List<Movie> movies = context.Movies.Where(m => m.Genre.Trim().ToLower() == choice).ToList();
            if (movies.Count > 0)
            {
                return movies;
                break;
            }
            else
            {
                Console.WriteLine("That entry did not match any available movies. Please try again.");
            }
        }
    }
    
}

static List<Movie> SearchByTitle()
{
    while (true)
    {
        //get input
        Console.WriteLine("Enter a title to search by.");
        string choice = Console.ReadLine().Trim().ToLower();

        //create list of matching movies
        using (MovieDBContext context = new MovieDBContext())
        {
            List<Movie> movies = context.Movies.Where(m => m.Title.Trim().ToLower() == choice).ToList();
            if (movies.Count > 0)
            {
                return movies;
                break;
            }
            else
            {
                Console.WriteLine("That entry did not match any available movies. Please try again.");
            }
        }
    }
}

//Main program where you allow search by genre or title
Console.WriteLine("Would you like to search by genre or title?");
List<Movie> movies;
while (true)
{
    string choice = Console.ReadLine().ToLower().Trim();
    if (choice == "genre")
    {
        movies = SearchByGenre();
        break;
    }
    else if (choice == "title")
    {
        movies = SearchByTitle();
        break;
    }
    else
    {
        Console.WriteLine("Please enter 'genre' or 'title'.");
    }
}
foreach (Movie m in movies)
{
    Console.WriteLine($"{m.Title} is a {m.Genre} movie. Its duration is {m.Runtime} minutes.");
}