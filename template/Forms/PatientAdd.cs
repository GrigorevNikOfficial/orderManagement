using Policlinic.Data;
using Policlinic.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class PatientAdd : Form
    {
        private readonly PolyclinicDbContext dbContext;

        public PatientAdd(PolyclinicDbContext context)
        {
            InitializeComponent();
            dbContext = context;
        }

        private void button_addPatient_Click(object sender, EventArgs e)
        {
            string lastName = textPatientFamilia.Text.Trim();
            string firstName = textPatientName.Text.Trim();
            string middleName = textPatientOtchestvo.Text.Trim();

            if (string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Фамилия и имя обязательны для заполнения.");
                return;
            }

            try
            {
                var newPatient = new Patient
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = string.IsNullOrWhiteSpace(middleName) ? null : middleName,
                    BirthYear = dateTimePicker1DateRozdenie.Checked
                        ? DateOnly.FromDateTime(dateTimePicker1DateRozdenie.Value)
                        : null
                };

                dbContext.Patients.Add(newPatient);
                dbContext.SaveChanges();

                MessageBox.Show("Пациент успешно добавлен.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пациента: {ex.Message}");
            }
        }

        private void button1Otmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e) { }
        private void textPatientFamilia_TextChanged(object sender, EventArgs e) { }
        private void textPatientName_TextChanged(object sender, EventArgs e) { }
        private void dateTimePicker1DateRozdenie_ValueChanged(object sender, EventArgs e) { }
    }
}
