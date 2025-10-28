using Policlinic.Data;
using Policlinic.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class ObrashenieAdd : Form
    {
        private readonly PolyclinicDbContext dbContext;

        public ObrashenieAdd(PolyclinicDbContext context)
        {
            InitializeComponent();
            dbContext = context;
            this.Load += ObrashenieAdd_Load;
        }

        private void ObrashenieAdd_Load(object sender, EventArgs e)
        {
            var doctors = dbContext.Doctors.ToList();
            comboBox1VrachFromDoctorcs.DataSource = doctors;
            comboBox1VrachFromDoctorcs.DisplayMember = "FullName";
            comboBox1VrachFromDoctorcs.ValueMember = "DoctorId";

            var patients = dbContext.Patients.ToList();
            comboBox1PatientfromPatientcs.DataSource = patients;
            comboBox1PatientfromPatientcs.DisplayMember = "FullName";
            comboBox1PatientfromPatientcs.ValueMember = "PatientId";

            dateTimePicker1.Value = DateTime.Today;
        }

        private void button1AddObrashenie_Click(object sender, EventArgs e)
        {
            if (comboBox1VrachFromDoctorcs.SelectedItem == null || comboBox1PatientfromPatientcs.SelectedItem == null)
            {
                MessageBox.Show("Выберите врача и пациента.");
                return;
            }

            string diagnosis = textBox1Diagnos.Text.Trim();
            if (string.IsNullOrWhiteSpace(diagnosis))
            {
                MessageBox.Show("Введите диагноз.");
                return;
            }

            if (!float.TryParse(textBox1Stoimost.Text.Replace(',', '.'), out float cost))
            {
                MessageBox.Show("Введите корректную стоимость (например, 1200.50).");
                return;
            }

            var doctor = (Doctor)comboBox1VrachFromDoctorcs.SelectedItem;
            var patient = (Patient)comboBox1PatientfromPatientcs.SelectedItem;

            var newVisit = new Visit
            {
                DoctorId = doctor.DoctorId,
                PatientId = patient.PatientId,
                VisitDate = DateOnly.FromDateTime(dateTimePicker1.Value),
                Diagnosis = diagnosis,
                TreatmentCost = (decimal)cost
            };

            try
            {
                dbContext.Visits.Add(newVisit);
                dbContext.SaveChanges();
                MessageBox.Show("Обращение успешно добавлено.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
            }
        }

        private void button2Otmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void textBox1Diagnos_TextChanged(object sender, EventArgs e) { }
        private void textBox1Stoimost_TextChanged(object sender, EventArgs e) { }
        private void comboBox1VrachFromDoctorcs_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1PatientfromPatientcs_SelectedIndexChanged(object sender, EventArgs e) { }

        private void ObrashenieAdd_Load_1(object sender, EventArgs e)
        {

        }
    }
}
