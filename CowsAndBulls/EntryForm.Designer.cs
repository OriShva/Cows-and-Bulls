
namespace CowsAndBulls
{
    partial class EntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NumOfChances = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NumOfChances
            // 
            this.NumOfChances.Location = new System.Drawing.Point(47, 33);
            this.NumOfChances.Name = "NumOfChances";
            this.NumOfChances.Size = new System.Drawing.Size(317, 41);
            this.NumOfChances.TabIndex = 0;
            this.NumOfChances.Text = "Number of chances: 4 ";
            this.NumOfChances.UseVisualStyleBackColor = true;
            this.NumOfChances.Click += new System.EventHandler(this.buttonNumOfChances_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(253, 129);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(111, 33);
            this.Start.TabIndex = 3;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(415, 197);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.NumOfChances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EntryForm";
            this.Text = "Bool Pgia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NumOfChances;
        private System.Windows.Forms.Button Start;
    }
}

