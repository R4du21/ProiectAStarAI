namespace ProiectAStarAI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textX = new TextBox();
            textY = new TextBox();
            textBox3 = new TextBox();
            textXF = new TextBox();
            textYF = new TextBox();
            btnFindPath = new Button();
            testText = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Menu;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(222, 12);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ShortcutsEnabled = false;
            textBox1.Size = new Size(354, 26);
            textBox1.TabIndex = 0;
            textBox1.TabStop = false;
            textBox1.Text = "Problema navigarii robotului spre casa";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Menu;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(21, 79);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.ShortcutsEnabled = false;
            textBox2.Size = new Size(98, 15);
            textBox2.TabIndex = 1;
            textBox2.TabStop = false;
            textBox2.Text = "Punctele de plecare:";
            // 
            // textX
            // 
            textX.BorderStyle = BorderStyle.FixedSingle;
            textX.Location = new Point(125, 77);
            textX.Name = "textX";
            textX.Size = new Size(26, 23);
            textX.TabIndex = 2;
            // 
            // textY
            // 
            textY.BorderStyle = BorderStyle.FixedSingle;
            textY.Location = new Point(157, 77);
            textY.Name = "textY";
            textY.Size = new Size(26, 23);
            textY.TabIndex = 3;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.Menu;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Arial Narrow", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox3.Location = new Point(21, 125);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.ShortcutsEnabled = false;
            textBox3.Size = new Size(98, 15);
            textBox3.TabIndex = 4;
            textBox3.TabStop = false;
            textBox3.Text = "Punctele de sosire:";
            // 
            // textXF
            // 
            textXF.BorderStyle = BorderStyle.FixedSingle;
            textXF.Location = new Point(125, 124);
            textXF.Name = "textXF";
            textXF.Size = new Size(26, 23);
            textXF.TabIndex = 5;
            // 
            // textYF
            // 
            textYF.BorderStyle = BorderStyle.FixedSingle;
            textYF.Location = new Point(157, 124);
            textYF.Name = "textYF";
            textYF.Size = new Size(26, 23);
            textYF.TabIndex = 6;
            // 
            // btnFindPath
            // 
            btnFindPath.Location = new Point(343, 214);
            btnFindPath.Name = "btnFindPath";
            btnFindPath.Size = new Size(89, 23);
            btnFindPath.TabIndex = 8;
            btnFindPath.Text = "Gaseste calea";
            btnFindPath.UseVisualStyleBackColor = true;
            btnFindPath.Click += btnFindPath_Click;
            // 
            // testText
            // 
            testText.Location = new Point(370, 114);
            testText.Name = "testText";
            testText.Size = new Size(100, 23);
            testText.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(testText);
            Controls.Add(btnFindPath);
            Controls.Add(textYF);
            Controls.Add(textXF);
            Controls.Add(textBox3);
            Controls.Add(textY);
            Controls.Add(textX);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "AStarAI";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textX;
        private TextBox textY;
        private TextBox textBox3;
        private TextBox textXF;
        private TextBox textYF;
        private Button btnFindPath;
        private TextBox testText;
    }
}