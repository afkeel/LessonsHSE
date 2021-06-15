
namespace LabControls
{
    partial class ColorControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorTextBoxBlue = new LabControls.ColorTextBox(this.components);
            this.colorTextBoxGreen = new LabControls.ColorTextBox(this.components);
            this.colorTextBoxRed = new LabControls.ColorTextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(36, 131);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Dec";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(102, 131);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(44, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Hex";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(165, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 128);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // colorTextBoxBlue
            // 
            this.colorTextBoxBlue.Color = 0;
            this.colorTextBoxBlue.Location = new System.Drawing.Point(86, 87);
            this.colorTextBoxBlue.Name = "colorTextBoxBlue";
            this.colorTextBoxBlue.Size = new System.Drawing.Size(60, 20);
            this.colorTextBoxBlue.TabIndex = 7;
            this.colorTextBoxBlue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colorTextBoxBlue.TextChanged += new System.EventHandler(this.colorTextBoxBlue_TextChanged);
            // 
            // colorTextBoxGreen
            // 
            this.colorTextBoxGreen.Color = 0;
            this.colorTextBoxGreen.Location = new System.Drawing.Point(86, 53);
            this.colorTextBoxGreen.Name = "colorTextBoxGreen";
            this.colorTextBoxGreen.Size = new System.Drawing.Size(60, 20);
            this.colorTextBoxGreen.TabIndex = 6;
            this.colorTextBoxGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colorTextBoxGreen.TextChanged += new System.EventHandler(this.colorTextBoxGreen_TextChanged);
            // 
            // colorTextBoxRed
            // 
            this.colorTextBoxRed.Color = 0;
            this.colorTextBoxRed.Location = new System.Drawing.Point(86, 20);
            this.colorTextBoxRed.Name = "colorTextBoxRed";
            this.colorTextBoxRed.Size = new System.Drawing.Size(60, 20);
            this.colorTextBoxRed.TabIndex = 5;
            this.colorTextBoxRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colorTextBoxRed.TextChanged += new System.EventHandler(this.colorTextBoxRed_TextChanged);
            // 
            // ColorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.colorTextBoxBlue);
            this.Controls.Add(this.colorTextBoxGreen);
            this.Controls.Add(this.colorTextBoxRed);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ColorControl";
            this.Size = new System.Drawing.Size(326, 161);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private ColorTextBox colorTextBoxRed;
        private ColorTextBox colorTextBoxGreen;
        private ColorTextBox colorTextBoxBlue;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
