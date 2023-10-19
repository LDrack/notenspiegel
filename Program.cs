using System;

namespace noten;
class Program
{
    private static int maxPunkte = -1;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, small cat!");

        if (args.Length == 0)
        {
            System.Console.Write("Maximale Punktzahl: ");
            string s = Console.ReadLine() ?? "";
            maxPunkte = int.Parse(s);
            System.Console.WriteLine("Gelesen: " + maxPunkte);
        }
        else if (args.Length != 1 || !int.TryParse(args[0], out maxPunkte))
        {
            PrintHelp();
            return;
        }

        Notenspiegel ns = new Notenspiegel(maxPunkte, 6);
        ns.PrintTable();
    }


    static void PrintHelp()
    {
        Console.WriteLine("Usage: dotnet noten [ PUNKTEANZAHL ]");
        Console.WriteLine();
        Console.WriteLine("Berechnet den Notenspiegel. Der Wert PUNKTEANZAHL repräsentiert die maximale Anazhl an erreichbaren Punkten.");
        Console.WriteLine("Notenspiegel: 6 Noten; 5 und 6 sind negativ; 1-4 positiv und gleichmäßig verteilt.");
        Console.WriteLine("Punkte werden auf 0.5 gerundet.");
        Console.WriteLine("\r\n\r\n");
    }
}
