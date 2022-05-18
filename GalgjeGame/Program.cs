using GalgjeGame;
using GalgjeGame.Core;
using GalgjeGame.Core.Services;
using GalgjeGame.Infrastructure.Data;
using GalgjeGame.Infrastructure.Repositories;
using GalgjeGame.Views;
using Microsoft.EntityFrameworkCore;

bool keepGoing = true;

var playerView = new PlayerView();
var gameView = new GameView();
var options = new DbContextOptions<GalgjeContext>();
var galgjeRepository = new GameRepository(options);
var wordsRepository = new WordsRepository(options);
var playerRepository = new PlayerRepository(options);
var gameService = new GameService(wordsRepository);
var playerService = new PlayerService(playerRepository);

//using (var context = new GalgjeContext()) {
//    context.Database.EnsureDeleted();
//    context.Database.EnsureCreated();
//}

var game = gameService.CreateGame();

string username = playerView.RequestUserName();

var player = playerService.CreatePlayer(username, game);

gameView.PlayGame(game);





void ReturnToMenu()
{
    Console.WriteLine("\nPress any key to return to the menu...");
    Console.ReadLine();
    Console.Clear();
}

//void EndOfGameProcessing(UserGameScore user)
//{
//    stopwatch.StopTimer();
//    user.TimeElapsedInGuessing = stopwatch.SecondsPassed;

//    galgjeRepository.AddUserToOverallScoreboard(user);
//    galgjeRepository.AddUserToGameScoreboard(user);
//    galgjeRepository.UpdateOverallScoreboard(user);

//    stopwatch.ResetTimer();
//    gameResultMessenger.ShowHangmanStatus(user);
//}