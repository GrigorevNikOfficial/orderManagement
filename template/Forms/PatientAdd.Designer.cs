namespace Policlinic.Forms
{
    partial class PatientAdd
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
            button1Otmena = new Button();
            button_addPatient = new Button();
            textPatientOtchestvo = new TextBox();
            textVOtchestvo = new Label();
            textPatientName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textPatientFamilia = new TextBox();
            dateTimePicker1DateRozdenie = new DateTimePicker();
            label3 = new Label();
            SuspendLayout();
            // 
            // button1Otmena
            // 
            button1Otmena.Location = new Point(185, 297);
            button1Otmena.Name = "button1Otmena";
            button1Otmena.Size = new Size(112, 34);
            button1Otmena.TabIndex = 25;
            button1Otmena.Text = "Отменить";
            button1Otmena.UseVisualStyleBackColor = true;
            button1Otmena.Click += button1Otmena_Click;
            // 
            // button_addPatient
            // 
            button_addPatient.Location = new Point(47, 297);
            button_addPatient.Name = "button_addPatient";
            button_addPatient.Size = new Size(132, 34);
            button_addPatient.TabIndex = 24;
            button_addPatient.Text = "Добавить";
            button_addPatient.UseVisualStyleBackColor = true;
            button_addPatient.Click += button_addPatient_Click;
            // 
            // textPatientOtchestvo
            // 
            textPatientOtchestvo.Location = new Point(47, 172);
            textPatientOtchestvo.Name = "textPatientOtchestvo";
            textPatientOtchestvo.Size = new Size(250, 27);
            textPatientOtchestvo.TabIndex = 19;
            // 
            // textVOtchestvo
            // 
            textVOtchestvo.AutoSize = true;
            textVOtchestvo.Location = new Point(47, 149);
            textVOtchestvo.Name = "textVOtchestvo";
            textVOtchestvo.Size = new Size(72, 20);
            textVOtchestvo.TabIndex = 18;
            textVOtchestvo.Text = "Отчество";
            // 
            // textPatientName
            // 
            textPatientName.Location = new Point(47, 107);
            textPatientName.Name = "textPatientName";
            textPatientName.Size = new Size(250, 27);
            textPatientName.TabIndex = 17;
            textPatientName.TextChanged += textPatientName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 84);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 16;
            label2.Text = "Имя";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 15;
            label1.Text = "Фамилия";
            // 
            // textPatientFamilia
            // 
            textPatientFamilia.Location = new Point(47, 41);
            textPatientFamilia.Name = "textPatientFamilia";
            textPatientFamilia.Size = new Size(250, 27);
            textPatientFamilia.TabIndex = 14;
            textPatientFamilia.TextChanged += textPatientFamilia_TextChanged;
            // 
            // dateTimePicker1DateRozdenie
            // 
            dateTimePicker1DateRozdenie.Location = new Point(47, 255);
            dateTimePicker1DateRozdenie.Name = "dateTimePicker1DateRozdenie";
            dateTimePicker1DateRozdenie.Size = new Size(250, 27);
            dateTimePicker1DateRozdenie.TabIndex = 27;
            dateTimePicker1DateRozdenie.ValueChanged += dateTimePicker1DateRozdenie_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(48, 216);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 28;
            label3.Text = "Дата рождения";
            label3.Click += label3_Click;
            // 
            // PatientAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 393);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1DateRozdenie);
            Controls.Add(button1Otmena);
            Controls.Add(button_addPatient);
            Controls.Add(textPatientOtchestvo);
            Controls.Add(textVOtchestvo);
            Controls.Add(textPatientName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textPatientFamilia);
            Name = "PatientAdd";
            Text = "PatientAdd";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1Otmena;
        private Button button_addPatient;
        private TextBox textPatientOtchestvo;
        private Label textVOtchestvo;
        private TextBox textPatientName;
        private Label label2;
        private Label label1;
        private TextBox textPatientFamilia;
        private DateTimePicker dateTimePicker1DateRozdenie;
        private Label label3;
    }
}