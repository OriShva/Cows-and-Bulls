namespace CowsAndBulls
{
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class GuessSubmitArgs : EventArgs
    {
        public string Guess { get; set; }

        public string Result { get; set; }
    }

internal class Row
    {
        private const int k_GuessLength = 4;
        private readonly Button[] r_UserGuess;
        private readonly bool[] r_WasGuessButtonClicked;
        private readonly Button r_Submit;
        private readonly Button[,] r_Result;
        private readonly Control.ControlCollection r_Controls;
        private readonly int r_YOffset;
        private readonly int r_XOffset;

        public event Action<GuessSubmitArgs> GuessSubmitted;

        public Row(Control.ControlCollection i_Controls, int i_XOffset, int i_YOffset)
        {
            this.r_Controls = i_Controls;
            this.r_YOffset = i_YOffset;
            this.r_XOffset = i_XOffset;
            this.r_UserGuess = this.createUserGuessButtons();
            this.r_Submit = this.createSubmitButton();
            this.r_Result = this.createResultButtons();
            this.r_WasGuessButtonClicked = new bool[k_GuessLength];
        }

        private bool isGuessValid()
        {
            bool allColorsPicked = this.r_WasGuessButtonClicked.All(x => x);
            string userGuess = ConvertColorsAndStrings.ConvertColorsToString(this.r_UserGuess);

            return allColorsPicked && ValidGuess.IsValid(userGuess);
        }

        private Button[,] createResultButtons()
        {
            Button[,] result = new Button[2, 2];

            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    result[row, col] = new Button
                    {
                        Name = string.Format($"BtnEvaluation{row},{col}_{this.r_YOffset}"),
                        Size = new Size(15, 15),
                        Location = new Point(225 + (col * 15), (row * 15) + 65 + (this.r_YOffset * 40)),
                        Enabled = false,
                    };
                    this.r_Controls.Add(result[row, col]);
                }
            }

            return result;
        }

        private Button[] createUserGuessButtons()
        {
            Button[] userGuess = new Button[k_GuessLength];
            for (int i = 0; i < k_GuessLength; i++)
            {
                userGuess[i] = new Button
                {
                    Name = string.Format($"{i}"),
                    Size = new Size(40, 40),
                    Location = new Point(i * 45, 60 + (this.r_YOffset * 40)),
                    Enabled = false,
                    BackColor = Color.WhiteSmoke,
                };
                userGuess[i].Click += this.buttonChangeColor_Click;
                this.r_Controls.Add(userGuess[i]);
            }

            return userGuess;
        }

        private Button createSubmitButton()
        {
            Button submit = new Button
            {
                Text = "-->>",
                Name = string.Format($"BtnToEvaluate{this.r_YOffset}"),
                Size = new Size(25, 10),
                AutoSize = true,
                Location = new Point(this.r_XOffset + 170, 67 + (this.r_YOffset * 40)),
                Enabled = false,
            };
            submit.Click += this.Submit_Click;
            this.r_Controls.Add(submit);

            return submit;
        }

        public void Submit_Click(object sender, EventArgs e)
        {
            GuessSubmitArgs guessSubmitArgs = new GuessSubmitArgs
            {
                Guess = ConvertColorsAndStrings.ConvertColorsToString(this.r_UserGuess),
            };

            this.GuessSubmitted?.Invoke(guessSubmitArgs);
            int i = 0;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (guessSubmitArgs.Result[i] == 'V')
                    {
                        this.r_Result[row, col].BackColor = Color.Black;
                    }

                    if (guessSubmitArgs.Result[i] == 'X')
                    {
                        this.r_Result[row, col].BackColor = Color.Yellow;
                    }

                    if (guessSubmitArgs.Result[i] == ' ')
                    {
                        this.r_Result[row, col].BackColor = Color.WhiteSmoke;
                    }

                    i++;
                }
            }
        }

        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            PickAColor pickAColor = new PickAColor();
            Button button = sender as Button;

            pickAColor.ColorSelected += selectedColor =>
            {
                button.BackColor = selectedColor;
                int buttonIndex = int.Parse(button.Name);
                this.r_WasGuessButtonClicked[buttonIndex] = true;
            };

            pickAColor.ShowDialog();
            this.r_Submit.Enabled = this.isGuessValid();
        }

        public void EnableGuessing()
        {
            for (int i = 0; i < k_GuessLength; i++)
            {
                this.r_UserGuess[i].Enabled = true;
            }
        }

        public void UnableGuessing()
        {
            for (int i = 0; i < k_GuessLength; i++)
            {
                this.r_UserGuess[i].Enabled = false;
                this.r_Submit.Enabled = false;
            }
        }
    }
}
