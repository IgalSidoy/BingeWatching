# Binge Watching

Checkmarx SCA Group Coding Question.

Dear candidate,

In this exercise we want to see clean "production-ready" code that does exactly what we asked for and nothing more. 

- If you know C#, that's our preferred language. If you prefer to implement it in a different language, let us know beforehand.
- The exercise is not a riddle. If something isn't clear, ask us. Don't waste time on figuring out or guess our intentions. We love feedback.
- We want to see a working solution, even if it's not complete. A compiled and running code with missing features is better than a solution that doesn't compile or errors out.
- There's no need for over-engineering but we do wish to see good separation of concerns, and simple, clean and testable code.
- Storage should be done in-memory only, there's absolutely no need for a real database.

## The exercise
We want to build a Netflix Binge-Watching console application that picks a random TV show or a movie to watch.

### Flow and features

- Each user will enter their user ID (any ID is valid, no actual authentication)
- They’ll then be asked to choose between C, S, E and H
    - If they choose C - content:
        - Ask them what kind of content (1 – TV Show, 2 – Movie, 3 – Any)
        - Randomly choose something to print to the user:
            - Make sure that we don’t offer the same content twice for the same user.
            - Print the title, i.e. "You are now watching 'In Bruges'"
        - Once the user is "watching" a movie, ask him whether he finished watching (Y/N)
            - If the answer is ‘N’, sleep for 2 seconds before asking again.
            - If the answer is ‘Y’:
                - Ask the user to rank the content (0-10)
    - If they choose S – switch user, ask for a user ID again.
    - If they choose H – history - show them the user’s history (make sure the history shown is only for the correct user):
        - User ID
        - Watched content, and for each content:
            - Title, Overview, ImdbRanking and UserRanking (if exists)      
- When their choice's flow is finished, they will again be asked to choose between C, S, E and H


### API

The API you’ll use to get a random series is:

https://api.reelgood.com/v3.0/content/random?availability=onAnySource&content_kind=both&nocache=true&region=us&sources=netflix

- We want to support different content_kind requests for TV shows, Movies or Both: content_kind possible values are: {both, movie, show}
- Each request will give a new random show/movie to watch.

Response – is a JSON object, for example:
```json
{
   "id":"29fbd74a-f25a-40eb-9393-449e35c9f118",
   "slug":"hirschen-da-machst-was-mit-2015",
   "title":"Hirschen - Da machst was mit!",
   "overview":"The residents of Hirschen stumble on a creative idea to boost their struggling village's economy after a driver runs into a deer and seeks their help.",
   "tagline":"",
   "classification":null,
   "runtime":90,
   "released_on":"2015-06-04T00:00:00",
   "has_poster":true,
   "has_backdrop":true,
   "imdb_rating":5.2,
   "rt_critics_rating":null,
   "genres":[9],
   "watchlisted":false,
   "seen":false,
   "content_type":"m"
}
```

The fields `title`, `overview` and `imdb_rating` should be saved and displayed when the user views his history.

## Bonus - Followers

> **This is an optional bonus question** - We respect your free time and do not require or expect you to complete this bonus question. It is only provided as an oppurtinity for you to "show-off" your coding and design skills if you choose to do so.

We would like to add a “follow user” feature. Each user can follow other users upon request. Then, the user can ask the service for a recommendation, and will receive a highly rated movie or TV-show that was watched by the users they follow.

Additionally, users can view their followers.

Requirements:
- After the users enter their user ID, they have the additional options to follow, unfollow and print followers (F, U, P)
    - If they choose F – they are requested to enter a user ID to follow. An appropriate success / failure message will be printed, and the users will return to the main menu
    - If they choose U – they are requested to enter a user ID to unfollow. Again, they will receive success / failure message and return to the main menu
    - If they choose P – A list of all the user’s followers will be printed (pay attention: this is the list of the users who follow the current user. Not a user’s “following” list)
    - If they choose C on the main menu (content), an additional option will be available:
        - Recommendation
            - If they choose 4, the movie with the highest IMDB rating is selected from the view history of users that the current user follows
            - Make sure the same movie is not recommended twice
            - If there are no movies to recommend (not followers or the current user has watched everything) – print an appropriate message and return to the main menu

When designing the solution, make sure you understand the runtime complexity of each operation (Follow, unfollow, recommend a movie, finish watching a movie, etc…)
You are not requested for the best performance available but:
- Design a reasonable solution
- Be prepared to explain how it can be optimized for runtime and how (data structures, tradeoffs, etc…)

### Example
Suppose a user “Danny” is following the users “Ronny” and “Daphne”. Ronny has 2 shows in the view history with ratings 8.5 & 4. Daphne has watched 1 movie with rating 7. 1
When Danny will ask for recommendation, the service will return the 8.5 show from Ronny’s list. On the next request, the 7.1 movie from Daphne’s list will be returned.





