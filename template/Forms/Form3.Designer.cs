namespace Policlinic.Forms
{
    partial class Form3
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
            comboBox2RedactorVrachKategory = new ComboBox();
            comboBox1RedactorVrachSpec = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox3RedactorVrachOtchestvo = new TextBox();
            textBox2RedactorVrachName = new TextBox();
            textBox1RedactorVrachFamilia = new TextBox();
            button1Redactor = new Button();
            button1Otmena = new Button();
            SuspendLayout();
            // 
            // comboBox2RedactorVrachKategory
            // 
            comboBox2RedactorVrachKategory.FormattingEnabled = true;
            comboBox2RedactorVrachKategory.Items.AddRange(new object[] { "Лаборант", "Вторая категории", "Первая категория", "Высшая категория" });
            comboBox2RedactorVrachKategory.Location = new Point(157, 108);
            comboBox2RedactorVrachKategory.Name = "comboBox2RedactorVrachKategory";
            comboBox2RedactorVrachKategory.Size = new Size(125, 28);
            comboBox2RedactorVrachKategory.TabIndex = 29;
            comboBox2RedactorVrachKategory.SelectedIndexChanged += comboBox2RedactorVrachKategory_SelectedIndexChanged;
            // 
            // comboBox1RedactorVrachSpec
            // 
            comboBox1RedactorVrachSpec.FormattingEnabled = true;
            comboBox1RedactorVrachSpec.Items.AddRange(new object[] { "Терапевт", "Невролог", "Кардиолог", "Онколог", "Психиатр", "Эндокринолог", "Офтальмолог", "Педиатр" });
            comboBox1RedactorVrachSpec.Location = new Point(12, 108);
            comboBox1RedactorVrachSpec.Name = "comboBox1RedactorVrachSpec";
            comboBox1RedactorVrachSpec.Size = new Size(125, 28);
            comboBox1RedactorVrachSpec.TabIndex = 28;
            comboBox1RedactorVrachSpec.SelectedIndexChanged += comboBox1RedactorVrachSpec_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(157, 74);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 27;
            label6.Text = "Категория";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 74);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 26;
            label5.Text = "Специальность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(301, 16);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 25;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 16);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 24;
            label3.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 23;
            label2.Text = "Фамилия";
            // 
            // textBox3RedactorVrachOtchestvo
            // 
            textBox3RedactorVrachOtchestvo.Location = new Point(301, 44);
            textBox3RedactorVrachOtchestvo.Name = "textBox3RedactorVrachOtchestvo";
            textBox3RedactorVrachOtchestvo.Size = new Size(125, 27);
            textBox3RedactorVrachOtchestvo.TabIndex = 22;
            textBox3RedactorVrachOtchestvo.TextChanged += textBox3RedactorVrachOtchestvo_TextChanged;
            // 
            // textBox2RedactorVrachName
            // 
            textBox2RedactorVrachName.Location = new Point(157, 44);
            textBox2RedactorVrachName.Name = "textBox2RedactorVrachName";
            textBox2RedactorVrachName.Size = new Size(125, 27);
            textBox2RedactorVrachName.TabIndex = 21;
            textBox2RedactorVrachName.TextChanged += textBox2RedactorVrachName_TextChanged;
            // 
            // textBox1RedactorVrachFamilia
            // 
            textBox1RedactorVrachFamilia.Location = new Point(12, 44);
            textBox1RedactorVrachFamilia.Name = "textBox1RedactorVrachFamilia";
            textBox1RedactorVrachFamilia.Size = new Size(125, 27);
            textBox1RedactorVrachFamilia.TabIndex = 20;
            textBox1RedactorVrachFamilia.TextChanged += textBox1RedactorVrachFamilia_TextChanged;
            // 
            // button1Redactor
            // 
            button1Redactor.Location = new Point(12, 168);
            button1Redactor.Name = "button1Redactor";
            button1Redactor.Size = new Size(125, 29);
            button1Redactor.TabIndex = 30;
            button1Redactor.Text = "Применить";
            button1Redactor.UseVisualStyleBackColor = true;
            button1Redactor.Click += button1Redactor_Click;
            // 
            // button1Otmena
            // 
            button1Otmena.Location = new Point(157, 168);
            button1Otmena.Name = "button1Otmena";
            button1Otmena.Size = new Size(125, 29);
            button1Otmena.TabIndex = 31;
            button1Otmena.Text = "Отменить";
            button1Otmena.UseVisualStyleBackColor = true;
            button1Otmena.Click += button1Otmena_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(488, 256);
            Controls.Add(button1Otmena);
            Controls.Add(button1Redactor);
            Controls.Add(comboBox2RedactorVrachKategory);
            Controls.Add(comboBox1RedactorVrachSpec);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox3RedactorVrachOtchestvo);
            Controls.Add(textBox2RedactorVrachName);
            Controls.Add(textBox1RedactorVrachFamilia);
            Name = "Form3";
            Text = "Редактирование записи";
            Load += Form3_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox2RedactorVrachKategory;
        private ComboBox comboBox1RedactorVrachSpec;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox3RedactorVrachOtchestvo;
        private TextBox textBox2RedactorVrachName;
        private TextBox textBox1RedactorVrachFamilia;
        private Button button1Redactor;
        private Button button1Otmena;
    }
}