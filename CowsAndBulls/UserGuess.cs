namespace CowsAndBulls
{
using System.Linq;
using System.Text;

internal class UsersGuess
    {
        public static bool IsGuessCorrect(string i_RandomSequence, string i_UsersGuess, out string o_Result)
        {
            int m_CountStrikes = 0;
            int m_CountCorrectLetter = 0;
            for (int i = 0; i < 4; i++)
            {
                char c = i_RandomSequence[i];

                // if the users guess & random sequence have the same letter and same position
                if (i_UsersGuess[i] == c)
                {
                    m_CountStrikes++;
                }

                // if the users guess & random sequence have the same letter but different position
                else if (i_UsersGuess.Contains(c))
                {
                    m_CountCorrectLetter++;
                }
            }

            o_Result = evaluateGuessToString(m_CountStrikes, m_CountCorrectLetter);

            return m_CountStrikes == 4;
        }

        private static string evaluateGuessToString(int i_Strike, int i_CorrectCharacter)
        {
            StringBuilder evalution = new StringBuilder(4);
            evalution.Append('V', i_Strike);
            evalution.Append('X', i_CorrectCharacter);
            evalution.Append(' ', 4 - i_Strike - i_CorrectCharacter);

            return evalution.ToString();
        }
    }
}
