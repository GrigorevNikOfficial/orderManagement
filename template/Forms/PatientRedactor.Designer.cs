namespace Policlinic.Forms
{
    partial class PatientRedactor
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
            label3 = new Label();
            dateTimePicker1DateRozdenieRedactor = new DateTimePicker();
            button1Otmena = new Button();
            button_RedactorPatient = new Button();
            textPatientOtchestvoRedactor = new TextBox();
            textVOtchestvo = new Label();
            textPatientNameRedactor = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textPatientFamiliaRedactor = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 216);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 38;
            label3.Text = "Дата рождения";
            // 
            // dateTimePicker1DateRozdenieRedactor
            // 
            dateTimePicker1DateRozdenieRedactor.Location = new Point(20, 255);
            dateTimePicker1DateRozdenieRedactor.Name = "dateTimePicker1DateRozdenieRedactor";
            dateTimePicker1DateRozdenieRedactor.Size = new Size(250, 27);
            dateTimePicker1DateRozdenieRedactor.TabIndex = 37;
            dateTimePicker1DateRozdenieRedactor.ValueChanged += dateTimePicker1DateRozdenieRedactor_ValueChanged;
            // 
            // button1Otmena
            // 
            button1Otmena.Location = new Point(158, 297);
            button1Otmena.Name = "button1Otmena";
            button1Otmena.Size = new Size(112, 34);
            button1Otmena.TabIndex = 36;
            button1Otmena.Text = "Отменить";
            button1Otmena.UseVisualStyleBackColor = true;
            button1Otmena.Click += button1Otmena_Click;
            // 
            // button_RedactorPatient
            // 
            button_RedactorPatient.Location = new Point(20, 297);
            button_RedactorPatient.Name = "button_RedactorPatient";
            button_RedactorPatient.Size = new Size(132, 34);
            button_RedactorPatient.TabIndex = 35;
            button_RedactorPatient.Text = "Применить";
            button_RedactorPatient.UseVisualStyleBackColor = true;
            button_RedactorPatient.Click += button_RedactorPatient_Click;
            // 
            // textPatientOtchestvoRedactor
            // 
            textPatientOtchestvoRedactor.Location = new Point(20, 172);
            textPatientOtchestvoRedactor.Name = "textPatientOtchestvoRedactor";
            textPatientOtchestvoRedactor.Size = new Size(250, 27);
            textPatientOtchestvoRedactor.TabIndex = 34;
            textPatientOtchestvoRedactor.TextChanged += textPatientOtchestvoRedactor_TextChanged;
            // 
            // textVOtchestvo
            // 
            textVOtchestvo.AutoSize = true;
            textVOtchestvo.Location = new Point(20, 149);
            textVOtchestvo.Name = "textVOtchestvo";
            textVOtchestvo.Size = new Size(72, 20);
            textVOtchestvo.TabIndex = 33;
            textVOtchestvo.Text = "Отчество";
            // 
            // textPatientNameRedactor
            // 
            textPatientNameRedactor.Location = new Point(20, 107);
            textPatientNameRedactor.Name = "textPatientNameRedactor";
            textPatientNameRedactor.Size = new Size(250, 27);
            textPatientNameRedactor.TabIndex = 32;
            textPatientNameRedactor.TextChanged += textPatientNameRedactor_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 84);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 31;
            label2.Text = "Имя";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 30;
            label1.Text = "Фамилия";
            // 
            // textPatientFamiliaRedactor
            // 
            textPatientFamiliaRedactor.Location = new Point(20, 41);
            textPatientFamiliaRedactor.Name = "textPatientFamiliaRedactor";
            textPatientFamiliaRedactor.Size = new Size(250, 27);
            textPatientFamiliaRedactor.TabIndex = 29;
            textPatientFamiliaRedactor.TextChanged += textPatientFamiliaRedactor_TextChanged;
            // 
            // PatientRedactor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(dateTimePicker1DateRozdenieRedactor);
            Controls.Add(button1Otmena);
            Controls.Add(button_RedactorPatient);
            Controls.Add(textPatientOtchestvoRedactor);
            Controls.Add(textVOtchestvo);
            Controls.Add(textPatientNameRedactor);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textPatientFamiliaRedactor);
            Name = "PatientRedactor";
            Text = "PatientRedactor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DateTimePicker dateTimePicker1DateRozdenieRedactor;
        private Button button1Otmena;
        private Button button_RedactorPatient;
        private TextBox textPatientOtchestvoRedactor;
        private Label textVOtchestvo;
        private TextBox textPatientNameRedactor;
        private Label label2;
        private Label label1;
        private TextBox textPatientFamiliaRedactor;
    }
}