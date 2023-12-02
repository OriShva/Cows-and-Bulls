namespace CowsAndBulls
{
using System.Drawing;
using System.Text;
using System.Windows.Forms;

internal class ConvertColorsAndStrings
{
        private const int k_GuessLength = 4;

        public static string ConvertColorsToString(Button[] i_UsersGuess)
            {
                StringBuilder guessBuilder = new StringBuilder(k_GuessLength);
                int i = 0;
                foreach (Button button in i_UsersGuess)
                {
                    guessBuilder.Append(convertColorToChar(button.BackColor));
                    i++;
                }

                return guessBuilder.ToString();
            }

        public static Color CharToColor(char i_Char)
        {
            Color buttonColor = Color.Empty;
            switch (i_Char)
            {
                case 'A':
                    {
                        buttonColor = Color.Red;
                        break;
                    }

                case 'B':
                    {
                        buttonColor = Color.Yellow;
                        break;
                    }

                case 'C':
                    {
                        buttonColor = Color.Lime;
                        break;
                    }

                case 'D':
                    {
                        buttonColor = Color.DarkOrchid;
                        break;
                    }

                case 'E':
                    {
                        buttonColor = Color.HotPink;
                        break;
                    }

                case 'F':
                    {
                        buttonColor = Color.DarkOrange;
                        break;
                    }

                case 'G':
                    {
                        buttonColor = Color.Sienna;
                        break;
                    }

                case 'H':
                    {
                        buttonColor = Color.DeepSkyBlue;
                        break;
                    }

                default:
                    buttonColor = Color.WhiteSmoke;
                    break;
            }

            return buttonColor;
        }

        private static char convertColorToChar(Color i_Color)
            {
                char c = 'K';
                switch (i_Color.Name)
                {
                    case "Red":
                        {
                            c = 'A';
                            break;
                        }

                    case "Yellow":
                        {
                            c = 'B';
                            break;
                        }

                    case "Lime":
                        {
                            c = 'C';
                            break;
                        }

                    case "DarkOrchid":
                        {
                            c = 'D';
                            break;
                        }

                    case "HotPink":
                        {
                            c = 'E';
                            break;
                        }

                    case "DarkOrange":
                        {
                            c = 'F';
                            break;
                        }

                    case "Sienna":
                        {
                            c = 'G';
                            break;
                        }

                    case "DeepSkyBlue":
                        {
                            c = 'H';
                            break;
                        }
                }

                return c;
            }
        }
    }