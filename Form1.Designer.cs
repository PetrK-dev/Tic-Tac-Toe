namespace TicTacToe
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing){
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private Button[,] buttons = new Button[3, 3];
        private void InitializeComponent()
        {

            SuspendLayout();
 
            int buttonSize = 75;
            int startX = 12, startY = 12;

            // 
            // buttons
            // 
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++){
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new System.Drawing.Size(buttonSize, buttonSize);
                    buttons[i, j].Location = new System.Drawing.Point(startX + j * buttonSize, startY + i * buttonSize);
                    buttons[i, j].Name = $"button{i * 3 + j + 1}";
                    buttons[i, j].UseVisualStyleBackColor = true;

                    buttons[i, j].Click += Button_Click;

                    this.Controls.Add(buttons[i, j]);
                }
            }
            // 
            // informative label
            //
            infoLabel = new Label();
            infoLabel.Location = new System.Drawing.Point(startX, startY + 3 * buttonSize + 10);
            infoLabel.Size = new System.Drawing.Size(buttonSize * 3, 23);
            infoLabel.Name = "label1";
            infoLabel.TabIndex = 9;
            infoLabel.Text = "Hráč 1 (X) je na tahu";
            infoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            ClientSize = new Size(284, 291);
            Controls.Add(infoLabel);
            Name = "Form1";
            Text = "Tic Tac Toe";
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label infoLabel;
    }
}