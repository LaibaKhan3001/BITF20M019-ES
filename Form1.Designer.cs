namespace Ass_4_2
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
            btn7 = new Button();
            btn8 = new Button();
            btnSub = new Button();
            btnDiv = new Button();
            btn9 = new Button();
            btnClear1 = new Button();
            btnMul = new Button();
            btn6 = new Button();
            btn3 = new Button();
            btnPlus = new Button();
            btnClear = new Button();
            btnEqual = new Button();
            btnDec = new Button();
            btn0 = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn2 = new Button();
            btn1 = new Button();
            historyLabel = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(546, 113);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btn7
            // 
            btn7.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn7.Location = new Point(228, 235);
            btn7.Name = "btn7";
            btn7.Size = new Size(78, 71);
            btn7.TabIndex = 7;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = true;
            btn7.Click += btn7_Click;
            // 
            // btn8
            // 
            btn8.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn8.Location = new Point(312, 235);
            btn8.Name = "btn8";
            btn8.Size = new Size(78, 71);
            btn8.TabIndex = 8;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = true;
            btn8.Click += btn8_Click;
            // 
            // btnSub
            // 
            btnSub.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnSub.Location = new Point(312, 158);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(78, 71);
            btnSub.TabIndex = 16;
            btnSub.Text = "-";
            btnSub.UseVisualStyleBackColor = true;
            btnSub.Click += btnSub_Click;
            // 
            // btnDiv
            // 
            btnDiv.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnDiv.Location = new Point(396, 158);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(78, 71);
            btnDiv.TabIndex = 15;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = true;
            btnDiv.Click += btnDiv_Click;
            // 
            // btn9
            // 
            btn9.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn9.Location = new Point(396, 235);
            btn9.Name = "btn9";
            btn9.Size = new Size(78, 71);
            btn9.TabIndex = 9;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = true;
            btn9.Click += btn9_Click;
            // 
            // btnClear1
            // 
            btnClear1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear1.Location = new Point(480, 158);
            btnClear1.Name = "btnClear1";
            btnClear1.Size = new Size(78, 71);
            btnClear1.TabIndex = 14;
            btnClear1.Text = "CE";
            btnClear1.UseVisualStyleBackColor = true;
            btnClear1.Click += button6_Click;
            // 
            // btnMul
            // 
            btnMul.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnMul.Location = new Point(480, 235);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(78, 71);
            btnMul.TabIndex = 13;
            btnMul.Text = "X";
            btnMul.UseVisualStyleBackColor = true;
            btnMul.Click += btnMul_Click;
            // 
            // btn6
            // 
            btn6.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn6.Location = new Point(396, 312);
            btn6.Name = "btn6";
            btn6.Size = new Size(78, 71);
            btn6.TabIndex = 6;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = true;
            btn6.Click += btn6_Click;
            // 
            // btn3
            // 
            btn3.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn3.Location = new Point(396, 389);
            btn3.Name = "btn3";
            btn3.Size = new Size(78, 71);
            btn3.TabIndex = 3;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = true;
            btn3.Click += btn3_Click;
            // 
            // btnPlus
            // 
            btnPlus.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btnPlus.Location = new Point(480, 312);
            btnPlus.Name = "btnPlus";
            btnPlus.Size = new Size(78, 148);
            btnPlus.TabIndex = 12;
            btnPlus.Text = "+";
            btnPlus.UseVisualStyleBackColor = true;
            btnPlus.Click += btnPlus_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlLight;
            btnClear.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new Point(228, 158);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(78, 71);
            btnClear.TabIndex = 17;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnEqual
            // 
            btnEqual.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnEqual.Location = new Point(480, 466);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(78, 71);
            btnEqual.TabIndex = 11;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = true;
            btnEqual.Click += btnEqual_Click;
            // 
            // btnDec
            // 
            btnDec.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btnDec.Location = new Point(396, 466);
            btnDec.Name = "btnDec";
            btnDec.Size = new Size(78, 71);
            btnDec.TabIndex = 10;
            btnDec.Text = ".";
            btnDec.TextAlign = ContentAlignment.BottomLeft;
            btnDec.UseVisualStyleBackColor = true;
            btnDec.Click += btnDec_Click;
            // 
            // btn0
            // 
            btn0.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn0.Location = new Point(228, 466);
            btn0.Name = "btn0";
            btn0.Size = new Size(162, 71);
            btn0.TabIndex = 0;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = true;
            btn0.Click += btn0_Click;
            // 
            // btn4
            // 
            btn4.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn4.Location = new Point(228, 312);
            btn4.Name = "btn4";
            btn4.Size = new Size(78, 71);
            btn4.TabIndex = 4;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = true;
            btn4.Click += btn4_Click;
            // 
            // btn5
            // 
            btn5.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn5.Location = new Point(312, 312);
            btn5.Name = "btn5";
            btn5.Size = new Size(78, 71);
            btn5.TabIndex = 5;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = true;
            btn5.Click += btn5_Click;
            // 
            // btn2
            // 
            btn2.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn2.Location = new Point(312, 389);
            btn2.Name = "btn2";
            btn2.Size = new Size(78, 71);
            btn2.TabIndex = 2;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // btn1
            // 
            btn1.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point);
            btn1.Location = new Point(228, 389);
            btn1.Name = "btn1";
            btn1.Size = new Size(78, 71);
            btn1.TabIndex = 1;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += btn1_Click;
            // 
            // historyLabel
            // 
            historyLabel.BackColor = SystemColors.ActiveBorder;
            historyLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            historyLabel.ForeColor = SystemColors.ActiveCaptionText;
            historyLabel.Location = new Point(12, 219);
            historyLabel.Name = "historyLabel";
            historyLabel.Size = new Size(210, 318);
            historyLabel.TabIndex = 18;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 158);
            label1.Name = "label1";
            label1.Size = new Size(210, 61);
            label1.TabIndex = 19;
            label1.Text = "History";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(585, 574);
            Controls.Add(label1);
            Controls.Add(historyLabel);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn5);
            Controls.Add(btn4);
            Controls.Add(btn0);
            Controls.Add(btnDec);
            Controls.Add(btnEqual);
            Controls.Add(btnClear);
            Controls.Add(btnPlus);
            Controls.Add(btn3);
            Controls.Add(btn6);
            Controls.Add(btnMul);
            Controls.Add(btnClear1);
            Controls.Add(btn9);
            Controls.Add(btnDiv);
            Controls.Add(btnSub);
            Controls.Add(btn8);
            Controls.Add(btn7);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Calculator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btn7;
        private Button btn8;
        private Button btnSub;
        private Button btnDiv;
        private Button btn9;
        private Button btnClear1;
        private Button btnMul;
        private Button btn6;
        private Button btn3;
        private Button btnPlus;
        private Button btnClear;
        private Button btnEqual;
        private Button btnDec;
        private Button btn0;
        private Button btn4;
        private Button btn5;
        private Button btn2;
        private Button btn1;
        private Label historyLabel;
        private Label label1;
    }
}