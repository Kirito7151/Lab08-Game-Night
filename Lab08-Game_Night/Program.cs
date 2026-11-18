/*
*Name: Jonathan Parkhurst
*Course: CSCI 1250, Section 001
*Assigenment: Lab 08, Game Night
*Date: November 18,2026
*Descripition:Keeps a game night leaderboard in three text files. Shows the
*              season so far, records tonight's points, saves the new totals,
*              and adds tonight's result to a history that grows every week
*/

const string PLAYERS_FILE = "players.txt";
const string POINTS_FILE = "points.txt";
const string HISTORY_FILE = "history.txt";
const int MAX_POINTS = 20;

// Look for the data files next to Program.cs, however the program is started.
string projectFolder = Path.GetFullPath(
Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
Directory.SetCurrentDirectory(projectFolder);

static int LeaderIndex(string[] points)
static int TotalPoints(string[] points)
static string HistoryEntry(int night, string winner, int points);

// Part 1
System.Console.Write("=== GAME NIGHT LEADERBOARD ===");
string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
Console.WriteLine("PLAYER".PadRight(11) + "POINTS");
for (int i = 0; i < players.Length; i++)
{
    Console.WriteLine(players[i].PadRight(11) + points[i]);
}
int leader = LeaderIndex(points);
Console.WriteLine($"Leader: {players[leader]} with {points[leader]}");
Console.WriteLine($"Season total: {TotalPoints(points)}");

//Part 2

int bestofthenight = -1;
string winnerofthenight = "";
for (int i = 0; i < players.Length; i++)
{
    Console.Write($"Points tonight for {players[i]}: ");
    int tonight = Convert.ToInt32(Console.ReadLine());
    while (tonight < 0 || tonight > MAX_POINTS)
    {
        Console.WriteLine($"Points must be from 0 to {MAX_POINTS}.");
        Console.Write($"Points tonight for {players[i]}: ");
        tonight = Convert.ToInt32(Console.ReadLine());
    }
    int season = Convert.ToInt32(points[i]) + tonight;
points[i] = season.ToString();

 if (tonight > bestofthenight)
    {
        bestofthenight = tonight;
        winnerofthenight = players[i];
    }
}

Console.WriteLine($"Tonight's winner: {winnerofthenight} with {bestofthenight}");
File.WriteAllLines(POINTS_FILE, points);
Console.WriteLine("Saved points.txt.");

// Part 3

string[] history = File.ReadAllLines(HISTORY_FILE);