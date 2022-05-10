using GalgjeGame;
using GalgjeGame.Core;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

bool keepGoing = true;

var gameResultMessenger = new GameResultMessenger();
var scoreLogger = new ScoreLogger();
var verifyMessenger = new VerifyMessenger();
var inputValidator = new UserInputValidation();
var stopwatch = new PassedTimeCalculator();
var options = new DbContextOptions<GalgjeContext>();
var galgjeRepository = new GalgjeRepository(options); 

while (keepGoing)
{
    var game = new Game();
    var user = new UserGameScore();

    string wordToGuessByPlayer = galgjeRepository.GetWordToGuess();

    string hiddenWordToGuessByPlayer = game.CreateHiddenWord(wordToGuessByPlayer);

    Console.Clear();
    Console.WriteLine("Please enter your username: ");
    string username = Console.ReadLine();
    if (!verifyMessenger.VerifyUserNameInput(inputValidator.VerifyUserName(username)))
        continue;
    user.UserName = username;

    stopwatch.StartTimer();
    do
    {
        gameResultMessenger.ShowHangmanStatus(user);
        Console.WriteLine($"\n\n{hiddenWordToGuessByPlayer}\n");

        if (gameResultMessenger.GetAlreadyChosenLetters(user) != "")
            Console.WriteLine($"Letters already picked: {gameResultMessenger.GetAlreadyChosenLetters(user)}");

        Console.WriteLine($"\n{user.UserName}, please choose a new letter to guess the word: ");
        string userInput = Console.ReadLine().Trim().ToLower();
        if (!verifyMessenger.VerifyUserInput((inputValidator.VerifyChosenLetter(userInput, user))))
            continue;

        hiddenWordToGuessByPlayer = game.CheckIfLetterInToBeGuessedWord(userInput, wordToGuessByPlayer, user);
    }
    while (hiddenWordToGuessByPlayer.Contains("_") && user.IncorrectGuesses < 7);

    EndOfGameProcessing(user);

    gameResultMessenger.GetResultOfGame(wordToGuessByPlayer, user, stopwatch);

    ShowEndOfGameMenu();
}

void ShowEndOfGameMenu()
{
    bool loopThroughMenu = true;

    while(loopThroughMenu)
    {
        Console.WriteLine("\nPress 1 to see the top 10 overall stats per player");
        Console.WriteLine("Press 2 to see the top 10 topscores");
        Console.WriteLine("Press 3 to reset all scoreboards");
        Console.WriteLine("Press 'Q' to exit out of the game");
        Console.WriteLine("Press any other key to play another round");
        var userinput = Console.ReadLine().Trim().ToUpper();
        switch (userinput)
        {
            case "1":
                var Top10OverallScores = galgjeRepository.GetTop10OverallScores();
                scoreLogger.PrintOverallScores(Top10OverallScores);
                ReturnToMenu();
                break;
            case "2":
                var Top10GameScores = galgjeRepository.GetTop10GameScores();
                scoreLogger.PrintTop10Scores(Top10GameScores);
                ReturnToMenu();
                break;
            case "3":
                Console.Clear();
                galgjeRepository.ResetAllScoreboards();
                Console.WriteLine("Scoreboard has been cleared of all results...");
                ReturnToMenu();
                break;
            case "Q":
                loopThroughMenu = keepGoing = false;
                break;
            default:
                loopThroughMenu = false;
                break;
        }
    }
}

void ReturnToMenu()
{
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadLine();
    Console.Clear();
}

void EndOfGameProcessing(UserGameScore user)
{
    stopwatch.StopTimer();
    user.TimeElapsedInGuessing = stopwatch.SecondsPassed;

    galgjeRepository.AddUserToOverallScoreboard(user);
    galgjeRepository.AddUserToGameScoreboard(user);
    galgjeRepository.UpdateOverallScoreboard(user);

    stopwatch.ResetTimer();
    gameResultMessenger.ShowHangmanStatus(user);
}