using Policlinic.Data;
using Policlinic.Models;
using System;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class PatientRedactor : Form
    {
        private readonly Patient patient;
        private readonly PolyclinicDbContext dbContext;

        public PatientRedactor(Patient selectedPatient, PolyclinicDbContext context)
        {
            InitializeComponent();
            patient = selectedPatient;
            dbContext = context;
            this.Load += PatientRedactor_Load;
        }

        private void PatientRedactor_Load(object sender, EventArgs e)
        {
            textPatientFamiliaRedactor.Text = patient.LastName;
            textPatientNameRedactor.Text = patient.FirstName;
            textPatientOtchestvoRedactor.Text = patient.MiddleName;

            dateTimePicker1DateRozdenieRedactor.ShowCheckBox = true;

            if (patient.BirthYear.HasValue)
            {
                dateTimePicker1DateRozdenieRedactor.Value = patient.BirthYear.Value.ToDateTime(TimeOnly.MinValue);
                dateTimePicker1DateRozdenieRedactor.Checked = true;
            }
            else
            {
                dateTimePicker1DateRozdenieRedactor.Value = DateTime.Today;
                dateTimePicker1DateRozdenieRedactor.Checked = false;
            }
        }



        private void button_RedactorPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textPatientFamiliaRedactor.Text))
                    patient.LastName = textPatientFamiliaRedactor.Text.Trim();

                if (!string.IsNullOrWhiteSpace(textPatientNameRedactor.Text))
                    patient.FirstName = textPatientNameRedactor.Text.Trim();

                patient.MiddleName = string.IsNullOrWhiteSpace(textPatientOtchestvoRedactor.Text)
                    ? null
                    : textPatientOtchestvoRedactor.Text.Trim();

                if (dateTimePicker1DateRozdenieRedactor.Checked)
                    patient.BirthYear = DateOnly.FromDateTime(dateTimePicker1DateRozdenieRedactor.Value);
                else
                    patient.BirthYear = null;

                dbContext.SaveChanges();
                MessageBox.Show("Изменения сохранены.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void button1Otmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textPatientFamiliaRedactor_TextChanged(object sender, EventArgs e) { }
        private void textPatientNameRedactor_TextChanged(object sender, EventArgs e) { }
        private void textPatientOtchestvoRedactor_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1DateRozdenieRedactor_ValueChanged(object sender, EventArgs e) { }
    }
}
