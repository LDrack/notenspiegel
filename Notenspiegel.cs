using System;

namespace noten;

public class Notenspiegel
{
    private int mMaxPunkte = -1;
    private int mNNoten = -1;
    private List<double> mNotenGrenzen = new List<double>();

    public Notenspiegel(int maxPunkte, int nNoten)
    {
        if (nNoten < 5 || nNoten > 6)
        {
            throw new ArgumentException("Notenspiegel with less than 5 or more than 6 grades not allowed.");
        }
        else if (maxPunkte <= 0)
        {
            throw new ArgumentException("Notenspiegel with <= 0 max. points not allowed.");
        }
        
        mMaxPunkte = maxPunkte;
        mNNoten = nNoten;

        CalculateTable();
    }


    private void CalculateTable()
    {
        bool isUneven = mMaxPunkte % 2 != 0;

        double maxPunkte = isUneven ? mMaxPunkte - 1 : mMaxPunkte;
        double negativGrenze = maxPunkte / 2;
        double notenSpanne = negativGrenze / 4;

        for (int i = 0; i < mNNoten; i++)
        {
            double lastValue = mNotenGrenzen.Count > 0 ? mNotenGrenzen[i-1] : maxPunkte;
            double notenGrenze = lastValue - notenSpanne;

            if (notenGrenze % 0.5 > 0)
            {
                notenGrenze += 0.25;
            }

            mNotenGrenzen.Add(notenGrenze);
        }
    }


    public void PrintTable()
    {
        System.Console.WriteLine();
        System.Console.WriteLine(" Punkte         | Note");
        System.Console.WriteLine("-----------------------");

        for (int i = 0; i < mNotenGrenzen.Count; i++)
        {
            int note = i + 1;
            double highValue = i > 0 ? mNotenGrenzen[i-1] - 0.5 : mMaxPunkte;
            double lowValue = i == mNotenGrenzen.Count - 1 ? 0 : mNotenGrenzen[i];

            System.Console.WriteLine($" {highValue,5:F2} - {lowValue,5:F2}  |   {note}");
        }

        System.Console.WriteLine();
    }
}
