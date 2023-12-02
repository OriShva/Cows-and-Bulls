namespace CowsAndBulls
{
using System.Linq;

internal class ValidGuess
    {
        private const int k_ValidLength = 4;

        public static bool IsValid(string i_UsersGuess)
        {
            bool isValid = true;

            foreach (char ch in i_UsersGuess)
            {
                if (ch < 'A' || ch > 'H')
                {
                    isValid = false;
                    break;
                }
            }

            if (i_UsersGuess.Distinct().Count() != k_ValidLength)
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
