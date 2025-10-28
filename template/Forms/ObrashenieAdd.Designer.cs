namespace Policlinic.Forms
{
    partial class ObrashenieAdd
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
            components = new System.ComponentModel.Container();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            textBox1Diagnos = new TextBox();
            textBox1Stoimost = new TextBox();
            comboBox1VrachFromDoctorcs = new ComboBox();
            doctorBindingSource = new BindingSource(components);
            comboBox1PatientfromPatientcs = new ComboBox();
            patientBindingSource = new BindingSource(components);
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1AddObrashenie = new Button();
            button2Otmena = new Button();
            polyclinicDbContextBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)doctorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)polyclinicDbContextBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 34);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 1;
            label1.Text = "Дата обращения";
            // 
            // textBox1Diagnos
            // 
            textBox1Diagnos.Location = new Point(13, 93);
            textBox1Diagnos.Name = "textBox1Diagnos";
            textBox1Diagnos.Size = new Size(290, 27);
            textBox1Diagnos.TabIndex = 2;
            textBox1Diagnos.TextChanged += textBox1Diagnos_TextChanged;
            // 
            // textBox1Stoimost
            // 
            textBox1Stoimost.Location = new Point(12, 151);
            textBox1Stoimost.Name = "textBox1Stoimost";
            textBox1Stoimost.Size = new Size(291, 27);
            textBox1Stoimost.TabIndex = 3;
            textBox1Stoimost.TextChanged += textBox1Stoimost_TextChanged;
            // 
            // comboBox1VrachFromDoctorcs
            // 
            comboBox1VrachFromDoctorcs.DataSource = doctorBindingSource;
            comboBox1VrachFromDoctorcs.FormattingEnabled = true;
            comboBox1VrachFromDoctorcs.Location = new Point(12, 215);
            comboBox1VrachFromDoctorcs.Name = "comboBox1VrachFromDoctorcs";
            comboBox1VrachFromDoctorcs.Size = new Size(291, 28);
            comboBox1VrachFromDoctorcs.TabIndex = 4;
            comboBox1VrachFromDoctorcs.SelectedIndexChanged += comboBox1VrachFromDoctorcs_SelectedIndexChanged;
            // 
            // doctorBindingSource
            // 
            doctorBindingSource.DataSource = typeof(Models.Doctor);
            // 
            // comboBox1PatientfromPatientcs
            // 
            comboBox1PatientfromPatientcs.DataSource = patientBindingSource;
            comboBox1PatientfromPatientcs.DisplayMember = "FullName";
            comboBox1PatientfromPatientcs.FormattingEnabled = true;
            comboBox1PatientfromPatientcs.Location = new Point(12, 273);
            comboBox1PatientfromPatientcs.Name = "comboBox1PatientfromPatientcs";
            comboBox1PatientfromPatientcs.Size = new Size(291, 28);
            comboBox1PatientfromPatientcs.TabIndex = 5;
            comboBox1PatientfromPatientcs.SelectedIndexChanged += comboBox1PatientfromPatientcs_SelectedIndexChanged;
            // 
            // patientBindingSource
            // 
            patientBindingSource.DataSource = typeof(Models.Patient);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 70);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 6;
            label2.Text = "Диагноз";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 128);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 7;
            label3.Text = "Стоимость";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 192);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 8;
            label4.Text = "Врач";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 250);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 9;
            label5.Text = "Пациент";
            // 
            // button1AddObrashenie
            // 
            button1AddObrashenie.Location = new Point(11, 322);
            button1AddObrashenie.Name = "button1AddObrashenie";
            button1AddObrashenie.Size = new Size(292, 29);
            button1AddObrashenie.TabIndex = 10;
            button1AddObrashenie.Text = "Добавить";
            button1AddObrashenie.UseVisualStyleBackColor = true;
            button1AddObrashenie.Click += button1AddObrashenie_Click;
            // 
            // button2Otmena
            // 
            button2Otmena.Location = new Point(13, 370);
            button2Otmena.Name = "button2Otmena";
            button2Otmena.Size = new Size(290, 29);
            button2Otmena.TabIndex = 11;
            button2Otmena.Text = "Отменить";
            button2Otmena.UseVisualStyleBackColor = true;
            button2Otmena.Click += button2Otmena_Click;
            // 
            // polyclinicDbContextBindingSource
            // 
            polyclinicDbContextBindingSource.DataSource = typeof(Data.PolyclinicDbContext);
            // 
            // ObrashenieAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(325, 403);
            Controls.Add(button2Otmena);
            Controls.Add(button1AddObrashenie);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1PatientfromPatientcs);
            Controls.Add(comboBox1VrachFromDoctorcs);
            Controls.Add(textBox1Stoimost);
            Controls.Add(textBox1Diagnos);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Name = "ObrashenieAdd";
            Text = "ObrashenieAdd";
            Load += ObrashenieAdd_Load_1;
            ((System.ComponentModel.ISupportInitialize)doctorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)polyclinicDbContextBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Label label1;
        private TextBox textBox1Diagnos;
        private TextBox textBox1Stoimost;
        private ComboBox comboBox1VrachFromDoctorcs;
        private ComboBox comboBox1PatientfromPatientcs;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1AddObrashenie;
        private Button button2Otmena;
        private BindingSource doctorBindingSource;
        private BindingSource patientBindingSource;
        private BindingSource polyclinicDbContextBindingSource;
    }
}