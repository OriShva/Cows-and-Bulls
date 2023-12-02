namespace CowsAndBulls
{
using System;
using System.Drawing;
using System.Windows.Forms;

public partial class PickAColor : Form
    {
        public event Action<Color> ColorSelected;

        public PickAColor()
        {
            this.InitializeComponent();
        }

        public void ButtonChangeColor_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Color selectedColor = button.BackColor;
                this.ColorSelected?.Invoke(selectedColor);
                this.Close();
            }
        }
    }
}
