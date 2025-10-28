namespace Policlinic.Forms
{
    partial class RedactorVisit
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
            button2Otmena = new Button();
            button1RedactObrashenie = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox1PatientfromPatientcsRedact = new ComboBox();
            comboBox1VrachFromDoctorcsRedact = new ComboBox();
            textBox1StoimostRedact = new TextBox();
            textBox1DiagnosRedact = new TextBox();
            label1 = new Label();
            dateTimePicker1VisitRedact = new DateTimePicker();
            SuspendLayout();
            // 
            // button2Otmena
            // 
            button2Otmena.Location = new Point(13, 370);
            button2Otmena.Name = "button2Otmena";
            button2Otmena.Size = new Size(125, 29);
            button2Otmena.TabIndex = 23;
            button2Otmena.Text = "Отменить";
            button2Otmena.UseVisualStyleBackColor = true;
            button2Otmena.Click += button2Otmena_Click;
            // 
            // button1RedactObrashenie
            // 
            button1RedactObrashenie.Location = new Point(11, 322);
            button1RedactObrashenie.Name = "button1RedactObrashenie";
            button1RedactObrashenie.Size = new Size(140, 29);
            button1RedactObrashenie.TabIndex = 22;
            button1RedactObrashenie.Text = "Отредактировать";
            button1RedactObrashenie.UseVisualStyleBackColor = true;
            button1RedactObrashenie.Click += button1RedactObrashenie_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 250);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 21;
            label5.Text = "Пациент";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 192);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 20;
            label4.Text = "Врач";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 128);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 19;
            label3.Text = "Стоимость";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 70);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 18;
            label2.Text = "Диагноз";
            // 
            // comboBox1PatientfromPatientcsRedact
            // 
            comboBox1PatientfromPatientcsRedact.DisplayMember = "FullName";
            comboBox1PatientfromPatientcsRedact.FormattingEnabled = true;
            comboBox1PatientfromPatientcsRedact.Location = new Point(12, 273);
            comboBox1PatientfromPatientcsRedact.Name = "comboBox1PatientfromPatientcsRedact";
            comboBox1PatientfromPatientcsRedact.Size = new Size(151, 28);
            comboBox1PatientfromPatientcsRedact.TabIndex = 17;
            comboBox1PatientfromPatientcsRedact.SelectedIndexChanged += comboBox1PatientfromPatientcsRedact_SelectedIndexChanged;
            // 
            // comboBox1VrachFromDoctorcsRedact
            // 
            comboBox1VrachFromDoctorcsRedact.FormattingEnabled = true;
            comboBox1VrachFromDoctorcsRedact.Location = new Point(12, 215);
            comboBox1VrachFromDoctorcsRedact.Name = "comboBox1VrachFromDoctorcsRedact";
            comboBox1VrachFromDoctorcsRedact.Size = new Size(151, 28);
            comboBox1VrachFromDoctorcsRedact.TabIndex = 16;
            comboBox1VrachFromDoctorcsRedact.SelectedIndexChanged += comboBox1VrachFromDoctorcsRedact_SelectedIndexChanged;
            // 
            // textBox1StoimostRedact
            // 
            textBox1StoimostRedact.Location = new Point(12, 151);
            textBox1StoimostRedact.Name = "textBox1StoimostRedact";
            textBox1StoimostRedact.Size = new Size(125, 27);
            textBox1StoimostRedact.TabIndex = 15;
            textBox1StoimostRedact.TextChanged += textBox1StoimostRedact_TextChanged;
            // 
            // textBox1DiagnosRedact
            // 
            textBox1DiagnosRedact.Location = new Point(13, 93);
            textBox1DiagnosRedact.Name = "textBox1DiagnosRedact";
            textBox1DiagnosRedact.Size = new Size(125, 27);
            textBox1DiagnosRedact.TabIndex = 14;
            textBox1DiagnosRedact.TextChanged += textBox1DiagnosRedact_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 13;
            label1.Text = "Дата обращения";
            // 
            // dateTimePicker1VisitRedact
            // 
            dateTimePicker1VisitRedact.Location = new Point(12, 34);
            dateTimePicker1VisitRedact.Name = "dateTimePicker1VisitRedact";
            dateTimePicker1VisitRedact.Size = new Size(250, 27);
            dateTimePicker1VisitRedact.TabIndex = 12;
            dateTimePicker1VisitRedact.ValueChanged += dateTimePicker1VisitRedact_ValueChanged;
            // 
            // RedactorVisit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2Otmena);
            Controls.Add(button1RedactObrashenie);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1PatientfromPatientcsRedact);
            Controls.Add(comboBox1VrachFromDoctorcsRedact);
            Controls.Add(textBox1StoimostRedact);
            Controls.Add(textBox1DiagnosRedact);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1VisitRedact);
            Name = "RedactorVisit";
            Text = "RedactorVisit";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2Otmena;
        private Button button1RedactObrashenie;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox1PatientfromPatientcsRedact;
        private ComboBox comboBox1VrachFromDoctorcsRedact;
        private TextBox textBox1StoimostRedact;
        private TextBox textBox1DiagnosRedact;
        private Label label1;
        private DateTimePicker dateTimePicker1VisitRedact;
    }
}