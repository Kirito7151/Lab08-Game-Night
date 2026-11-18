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

//Start Part 1
Console.WriteLine("=== GAME NIGHT LEADERBOARD ===");
string[] history = File.ReadAllLines(HISTORY_FILE);

if (history.Length == 0)
{
    Console.WriteLine("No nights played yet.");
}
else
{
    Console.WriteLine($"Nights played: {history.Length}");
    //foreach: this is only meant to read the night before does no need a index
    foreach (string night in history)
    {
        Console.WriteLine("  " + night);
    }
}
int tonightsnumber = history.Length + 1;
Console.WriteLine($"Tonight is Night {tonightsnumber}.");
System.Console.WriteLine("");
//Part 1

string[] players = File.ReadAllLines(PLAYERS_FILE);
string[] points = File.ReadAllLines(POINTS_FILE);
Console.WriteLine("PLAYER".PadRight(11) + "POINTS");
//for: for the names and the points that live in the two arrays
// and the shared index is what keeps them together
for (int i = 0; i < players.Length; i++)
{
    Console.WriteLine(players[i].PadRight(11) + points[i]);
}
int leader = LeaderIndex(points);
Console.WriteLine($"Leader: {players[leader]} with {points[leader]}");
Console.WriteLine($"Season total: {TotalPoints(points)}");
System.Console.WriteLine("");
//Part 2
int bestofthenight = -1;
string winnerofthenight = "";
// For: you need the i so that you can match player to the
// same spot in the points array, and so that the number of players is known
for (int i = 0; i < players.Length; i++)
{
    Console.Write($"Points tonight for {players[i]}: ");
    int tonight = Convert.ToInt32(Console.ReadLine());
    //While: This is here because we dont know how many bad answers the person will input
    // so keep asking untill the number is vaild
    while (tonight < 0 || tonight > MAX_POINTS)
    {
        Console.WriteLine($"Points must be from 0 to {MAX_POINTS}.");
        Console.Write($"Points tonight for {players[i]}: ");
        tonight = Convert.ToInt32(Console.ReadLine());
    }
    int season = Convert.ToInt32(points[i]) + tonight;
points[i] = season.ToString();
//Tracks tonights best score and which player was the one to get it
 if (tonight > bestofthenight)
    {
        bestofthenight = tonight;
        winnerofthenight = players[i];
    }
}

Console.WriteLine($"Tonight's winner: {winnerofthenight} with {bestofthenight}");
File.WriteAllLines(POINTS_FILE, points);
System.Console.WriteLine("");
Console.WriteLine("Saved points.txt.");

//Part 3
string[] entry = { HistoryEntry(tonightsnumber, winnerofthenight, bestofthenight) };
File.AppendAllLines(HISTORY_FILE, entry);
Console.WriteLine($"Added to history.txt: {entry[0]}");

//Methods
static int LeaderIndex(string[] points)
{
    int leader = 0;
    // For: we need the index to hand back what we put in, so we start at 1
    // because position 0 is the first leader comapred agianst it
    for (int i = 1; i < points.Length; i++)
    {
        if (Convert.ToInt32(points[i]) > Convert.ToInt32(points[leader]))
        {
            leader = i;
        }
    }

    return leader;
}
static int TotalPoints(string[] points)
{
    int total = 0;
    //Foreach: every single vaule gets added just once, and the position dosent matter
    foreach (string p in points)
    {
        total += Convert.ToInt32(p);
    }

    return total;
}
static string HistoryEntry(int night, string winner, int points)
{
    return $"Night {night}: {winner} won with {points} points";
}