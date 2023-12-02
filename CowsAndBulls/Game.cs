namespace CowsAndBulls
{
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Game : Form
    {
        private const int k_XOffset = 10;
        private const int k_YOffset = 0;
        private readonly int r_NumOfLines;
        private readonly string r_RandomSequence;
        private readonly Row[] r_Rows;
        private int m_RowIndex;
        private Button[] m_BlackBoxes;

        public delegate void Submit_Click(object sender, EventArgs e);

        public Game(int i_NumOfLines)
        {
            this.InitializeComponent();
            this.r_NumOfLines = i_NumOfLines;
            this.r_Rows = new Row[this.r_NumOfLines];
            this.r_RandomSequence = RandomSequence.GenerateRandomSequence();
            this.buildBoardGame();
            this.playGame();
        }

        private void playGame()
        {
            this.m_RowIndex = 0;
            this.r_Rows[this.m_RowIndex].EnableGuessing();
        }

        private void buildBoardGame()
        {
            this.createBlackBoxes();
            for (int i = 0; i < this.r_NumOfLines; i++)
            {
                this.r_Rows[i] = new Row(this.Controls, k_XOffset, i);
                this.r_Rows[i].GuessSubmitted += this.game_GuessSubmitted;
            }
        }

        private void game_GuessSubmitted(GuessSubmitArgs i_GuessSubmitArgs)
        {
            bool isCorrect = false;
            string userGuess = i_GuessSubmitArgs.Guess;
            string evaluation = string.Empty;
            isCorrect = UsersGuess.IsGuessCorrect(this.r_RandomSequence, userGuess, out evaluation);
            i_GuessSubmitArgs.Result = evaluation;

            // if player got the sequence then reveal the pattern
            this.r_Rows[this.m_RowIndex].UnableGuessing();
            if (isCorrect)
            {
                RandomSequence.GenerateButtonSequence(this.r_RandomSequence, this.m_BlackBoxes);
                YouWin youWin = new YouWin();
                youWin.Show();
            }

            // if player is out of guesses
            if (!isCorrect && this.m_RowIndex + 1 == this.r_NumOfLines)
            {
                RandomSequence.GenerateButtonSequence(this.r_RandomSequence, this.m_BlackBoxes);
                YouLose youLose = new YouLose();
                youLose.Show();
            }

            // if player didn't get the sequence right - open another row
            else if (!isCorrect)
            {
                this.m_RowIndex++;
                this.r_Rows[this.m_RowIndex].EnableGuessing();
            }
        }

        private void createBlackBoxes()
        {
        this.m_BlackBoxes = new Button[4];
        for (int i = 0; i < 4; i++)
            {
                this.m_BlackBoxes[i] = new Button
                {
                    Name = string.Format($"blackBoxes{i}"),
                    Size = new Size(40, 40),
                    Location = new Point(i * 45, k_YOffset),
                    BackColor = Color.Black,
                    Enabled = false,
                };
                this.Controls.Add(this.m_BlackBoxes[i]);
            }
        }
    }
}
