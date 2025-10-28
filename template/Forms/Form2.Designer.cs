namespace Policlinic
{
    partial class VrachForm
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
            textVFio = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textVName = new TextBox();
            textVOtchestvo = new Label();
            textVOtch = new TextBox();
            labelSpec = new Label();
            label3 = new Label();
            comboSpec = new ComboBox();
            comboCategory = new ComboBox();
            button_addVrach = new Button();
            button1Otmena = new Button();
            SuspendLayout();
            // 
            // textVFio
            // 
            textVFio.Location = new Point(11, 41);
            textVFio.Name = "textVFio";
            textVFio.Size = new Size(250, 27);
            textVFio.TabIndex = 0;
            textVFio.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 1;
            label1.Text = "Фамилия";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 84);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 2;
            label2.Text = "Имя";
            // 
            // textVName
            // 
            textVName.Location = new Point(11, 107);
            textVName.Name = "textVName";
            textVName.Size = new Size(250, 27);
            textVName.TabIndex = 3;
            textVName.TextChanged += textVName_TextChanged;
            // 
            // textVOtchestvo
            // 
            textVOtchestvo.AutoSize = true;
            textVOtchestvo.Location = new Point(11, 149);
            textVOtchestvo.Name = "textVOtchestvo";
            textVOtchestvo.Size = new Size(72, 20);
            textVOtchestvo.TabIndex = 4;
            textVOtchestvo.Text = "Отчество";
            // 
            // textVOtch
            // 
            textVOtch.Location = new Point(11, 172);
            textVOtch.Name = "textVOtch";
            textVOtch.Size = new Size(250, 27);
            textVOtch.TabIndex = 5;
            textVOtch.TextChanged += textVOtch_TextChanged;
            // 
            // labelSpec
            // 
            labelSpec.AutoSize = true;
            labelSpec.Location = new Point(12, 215);
            labelSpec.Name = "labelSpec";
            labelSpec.Size = new Size(116, 20);
            labelSpec.TabIndex = 8;
            labelSpec.Text = "Специальность";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 278);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 9;
            label3.Text = "Категория";
            // 
            // comboSpec
            // 
            comboSpec.Items.AddRange(new object[] { "Терапевт", "Невролог", "Кардиолог", "Онколог", "Психиатр", "Эндокринолог", "Офтальмолог", "Педиатр" });
            comboSpec.Location = new Point(11, 238);
            comboSpec.Name = "comboSpec";
            comboSpec.Size = new Size(250, 28);
            comboSpec.TabIndex = 10;
            comboSpec.SelectedIndexChanged += comboSpec_SelectedIndexChanged;
            // 
            // comboCategory
            // 
            comboCategory.Items.AddRange(new object[] { "Лаборант", "Вторая категории", "Первая категория", "Высшая категория" });
            comboCategory.Location = new Point(11, 301);
            comboCategory.Name = "comboCategory";
            comboCategory.Size = new Size(250, 28);
            comboCategory.TabIndex = 11;
            comboCategory.SelectedIndexChanged += comboCategory_SelectedIndexChanged;
            // 
            // button_addVrach
            // 
            button_addVrach.Location = new Point(12, 358);
            button_addVrach.Name = "button_addVrach";
            button_addVrach.Size = new Size(132, 34);
            button_addVrach.TabIndex = 12;
            button_addVrach.Text = "Добавить";
            button_addVrach.UseVisualStyleBackColor = true;
            button_addVrach.Click += button_addVrach_Click;
            // 
            // button1Otmena
            // 
            button1Otmena.Location = new Point(159, 358);
            button1Otmena.Name = "button1Otmena";
            button1Otmena.Size = new Size(132, 34);
            button1Otmena.TabIndex = 13;
            button1Otmena.Text = "Отменить";
            button1Otmena.UseVisualStyleBackColor = true;
            button1Otmena.Click += button1Otmena_Click;
            // 
            // VrachForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 408);
            Controls.Add(button1Otmena);
            Controls.Add(button_addVrach);
            Controls.Add(comboCategory);
            Controls.Add(comboSpec);
            Controls.Add(label3);
            Controls.Add(labelSpec);
            Controls.Add(textVOtch);
            Controls.Add(textVOtchestvo);
            Controls.Add(textVName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textVFio);
            Name = "VrachForm";
            Text = "Добавить врача";
            Load += VrachForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textVFio;
        private Label label1;
        private Label label2;
        private TextBox textVName;
        private Label textVOtchestvo;
        private TextBox textVOtch;
        private Label labelSpec;
        private Label label3;
        private ComboBox comboSpec;
        private ComboBox comboCategory;
        private Button button_addVrach;
        private Button button1Otmena;
    }
}