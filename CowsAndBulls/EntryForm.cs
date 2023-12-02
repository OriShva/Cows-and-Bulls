namespace CowsAndBulls
{
using System;
using System.Windows.Forms;

public partial class EntryForm : Form
    {
        public EntryForm()
        {
            this.InitializeComponent();
        }

        // return number of chances
        private int m_NumberOfGuesses = 4;

        public int NumberOfGuesses 
        {
            get { return this.m_NumberOfGuesses; }
        }

        private void buttonNumOfChances_Click(object sender, EventArgs e)
        {
            if (this.m_NumberOfGuesses < 10)
            {
                this.m_NumberOfGuesses++;
                this.NumOfChances.Text = string.Format("Number of chances: {0}", this.m_NumberOfGuesses);
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Game game = new Game(this.m_NumberOfGuesses);
            this.Visible = false;
            game.Show();
        }
    }
}
