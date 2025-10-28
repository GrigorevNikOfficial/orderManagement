namespace Policlinic.Forms
{
    partial class PeriodSelectorForm
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
            dateTimePickerPeriodNachalo = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateTimePickerPeriodOkonchanie = new DateTimePicker();
            buttonViborPerioda = new Button();
            buttonOtmena = new Button();
            SuspendLayout();
            // 
            // dateTimePickerPeriodNachalo
            // 
            dateTimePickerPeriodNachalo.Location = new Point(84, 51);
            dateTimePickerPeriodNachalo.Name = "dateTimePickerPeriodNachalo";
            dateTimePickerPeriodNachalo.Size = new Size(250, 27);
            dateTimePickerPeriodNachalo.TabIndex = 0;
            dateTimePickerPeriodNachalo.ValueChanged += dateTimePickerPeriodNachalo_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(84, 9);
            label1.Name = "label1";
            label1.Size = new Size(237, 20);
            label1.TabIndex = 1;
            label1.Text = "Выберите необходимый период";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 56);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 2;
            label2.Text = "С";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 98);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 3;
            label3.Text = "До";
            // 
            // dateTimePickerPeriodOkonchanie
            // 
            dateTimePickerPeriodOkonchanie.Location = new Point(94, 93);
            dateTimePickerPeriodOkonchanie.Name = "dateTimePickerPeriodOkonchanie";
            dateTimePickerPeriodOkonchanie.Size = new Size(250, 27);
            dateTimePickerPeriodOkonchanie.TabIndex = 4;
            dateTimePickerPeriodOkonchanie.ValueChanged += dateTimePickerPeriodOkonchanie_ValueChanged;
            // 
            // buttonViborPerioda
            // 
            buttonViborPerioda.Location = new Point(60, 137);
            buttonViborPerioda.Name = "buttonViborPerioda";
            buttonViborPerioda.Size = new Size(122, 29);
            buttonViborPerioda.TabIndex = 5;
            buttonViborPerioda.Text = "Подтвердить";
            buttonViborPerioda.UseVisualStyleBackColor = true;
            buttonViborPerioda.Click += buttonViborPerioda_Click;
            // 
            // buttonOtmena
            // 
            buttonOtmena.Location = new Point(227, 137);
            buttonOtmena.Name = "buttonOtmena";
            buttonOtmena.Size = new Size(94, 29);
            buttonOtmena.TabIndex = 6;
            buttonOtmena.Text = "Отмена";
            buttonOtmena.UseVisualStyleBackColor = true;
            buttonOtmena.Click += buttonOtmena_Click;
            // 
            // PeriodSelectorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonOtmena);
            Controls.Add(buttonViborPerioda);
            Controls.Add(dateTimePickerPeriodOkonchanie);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerPeriodNachalo);
            Name = "PeriodSelectorForm";
            Text = "PeriodSelectorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePickerPeriodNachalo;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerPeriodOkonchanie;
        private Button buttonViborPerioda;
        private Button buttonOtmena;
    }
}