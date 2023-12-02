namespace CowsAndBulls
{
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class RandomSequence
    {
        public static string GenerateRandomSequence()
        {
            Random random = new Random();
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            letters = letters.OrderBy(c => random.Next()).ToArray();

            return new string(letters, 0, 4);
        }

        public static void GenerateButtonSequence(string i_RandomSequence, Button[] i_BlackBoxes)
        {
            int index = 0;
            foreach (char c in i_RandomSequence)
            {
                Color currentColor = ConvertColorsAndStrings.CharToColor(c);
                i_BlackBoxes[index].BackColor = currentColor;
                index++;
            }
        }
    }
}
