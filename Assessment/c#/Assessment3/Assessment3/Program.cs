using System;

namespace Assessment3
{
    internal class CricketTeam

    {
        public (int matchCount, int sum, double average) Pointscalculation(int no_of_matches)
        {
            int sum = 0;
            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter score for match{i + 1}: ");
                int score = Convert.ToInt32(Console.ReadLine());
                sum += score;
            }

            double average = (double)sum / no_of_matches;
            return (no_of_matches, sum, average);
        }
    }

    class ipl
    {
        static void Main(string[] args)
        {
            CricketTeam team = new CricketTeam();

            Console.Write("Enter number of matches: ");
            int matches = Convert.ToInt32(Console.ReadLine());

            var result = team.Pointscalculation(matches);

            Console.WriteLine("\nIPL Team Performance");
            Console.WriteLine("Number of Matches: " + result.matchCount);
            Console.WriteLine("Total Points (Sum): " + result.sum);
            Console.WriteLine("Average Points: " + result.average);
        }
    }
}
