using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day4b();
        }

        static void Day4a()
        {
            var txt = File.ReadAllText("input.txt");
            long totalPoints = 0;
            txt = txt.Replace("\r", "");            
            foreach (var lin in txt.Split('\n'))
            {
                var lps = lin.Split(':')[1].Split('|');
                var wnrs = lps[0].Trim().Replace("  "," ").Split(' ').ToList().Select(an => int.Parse(an)).ToList();
                var mnrs = lps[1].Trim().Replace("  ", " ").Split(' ').ToList().Select(an => int.Parse(an)).ToList();

                var nrWin = mnrs.Count(m => wnrs.Contains(m));
                double points = 0;
                if(nrWin > 0)
                    points = Math.Pow(2, nrWin-1);
                totalPoints += (long) points;
            }

            Console.WriteLine("Points : " + totalPoints);
            Console.ReadLine();
        }

        static void Day4b()
        {
            var txt = File.ReadAllText("input.txt");            
            txt = txt.Replace("\r", "");
            var allCards = new Dictionary<int, long>();
            var allLines = txt.Split('\n');
            // Init cards to 1
            for (int i = 1; i <= allLines.Length; i++) allCards.Add(i, 1);            
            int cardNr = 1;
            foreach (var lin in allLines)
            {
                var lps = lin.Split(':')[1].Split('|');
                var wnrs = lps[0].Trim().Replace("  ", " ").Split(' ').ToList().Select(an => int.Parse(an)).ToList();
                var mnrs = lps[1].Trim().Replace("  ", " ").Split(' ').ToList().Select(an => int.Parse(an)).ToList();

                var nrWin = mnrs.Count(m => wnrs.Contains(m));
                
                for(int i=cardNr+1;i<=cardNr+nrWin && i<=allLines.Length;i++)
                {
                    allCards[i] += 1 * allCards[cardNr];
                }
                cardNr++;
            }

            long totalCards = allCards.Sum(c => c.Value);
            Console.WriteLine("Total Cards : " + totalCards);
            Console.ReadLine();
        }
    }
}
