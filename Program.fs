open System


// Define the discriminated union for genres
type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

// Define the record type for Director
type Director = {
    Name: string
    Movies: int
}

// Define the record type for Movie
type Movie = {
    Name: string
    RunLength: int
    Genre: Genre
    Director: Director
    IMDBRating: float
}

// Create movie instances based on the table
let movie1 = { Name = "CODA"; RunLength = 111; Genre = Drama; Director = { Name = "Sian Heder"; Movies = 9 }; IMDBRating = 8.1 }
let movie2 = { Name = "Belfast"; RunLength = 98; Genre = Comedy; Director = { Name = "Kenneth Branagh"; Movies = 23 }; IMDBRating = 7.3 }
let movie3 = { Name = "Don't Look Up"; RunLength = 138; Genre = Comedy; Director = { Name = "Adam McKay"; Movies = 27 }; IMDBRating = 7.2 }
let movie4 = { Name = "Drive My Car"; RunLength = 179; Genre = Drama; Director = { Name = "Ryosuke Hamaguchi"; Movies = 16 }; IMDBRating = 7.6 }
let movie5 = { Name = "Dune"; RunLength = 155; Genre = Fantasy; Director = { Name = "Denis Villeneuve"; Movies = 24 }; IMDBRating = 8.1 }
let movie6 = { Name = "King Richard"; RunLength = 144; Genre = Sport; Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }; IMDBRating = 7.5 }
let movie7 = { Name = "Licorice Pizza"; RunLength = 133; Genre = Comedy; Director = { Name = "Paul Thomas Anderson"; Movies = 49 }; IMDBRating = 7.4 }
let movie8 = { Name = "Nightmare Alley"; RunLength = 150; Genre = Thriller; Director = { Name = "Guillermo Del Toro"; Movies = 22 }; IMDBRating = 7.1 }

// Create a list of movies
let movies = [movie1; movie2; movie3; movie4; movie5; movie6; movie7; movie8]

// Identify probable Oscar winners (IMDB rating > 7.4)
let probableOscarWinners = 
    movies 
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)

// Function to convert run length to hours and minutes
let convertToHoursMinutes runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    $"{hours}h {minutes}min"

// Convert movie run length to hours and minutes format
let movieDurations =
    movies
    |> List.map (fun movie -> (movie.Name, convertToHoursMinutes movie.RunLength))

// Output the results
printfn "Probable Oscar Winners:"
probableOscarWinners 
|> List.iter (fun movie -> printfn "%s (IMDB: %.1f)" movie.Name movie.IMDBRating)

printfn "\nMovie Durations (Hours and Minutes):"
movieDurations 
|> List.iter (fun (name, duration) -> printfn "%s: %s" name duration)
