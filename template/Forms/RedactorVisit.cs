using Policlinic.Data;
using Policlinic.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class RedactorVisit : Form
    {
        private readonly Visit visit;
        private readonly PolyclinicDbContext dbContext;

        public RedactorVisit(Visit selectedVisit, PolyclinicDbContext context)
        {
            InitializeComponent();
            visit = selectedVisit;
            dbContext = context;
            this.Load += RedactorVisit_Load;
        }

        private void RedactorVisit_Load(object sender, EventArgs e)
        {
            // Загрузка врачей
            var doctors = dbContext.Doctors.ToList();
            comboBox1VrachFromDoctorcsRedact.DataSource = doctors;
            comboBox1VrachFromDoctorcsRedact.DisplayMember = "FullName";
            comboBox1VrachFromDoctorcsRedact.ValueMember = "DoctorId";
            comboBox1VrachFromDoctorcsRedact.SelectedValue = visit.DoctorId;

            // Загрузка пациентов
            var patients = dbContext.Patients.ToList();
            comboBox1PatientfromPatientcsRedact.DataSource = patients;
            comboBox1PatientfromPatientcsRedact.DisplayMember = "FullName";
            comboBox1PatientfromPatientcsRedact.ValueMember = "PatientId";
            comboBox1PatientfromPatientcsRedact.SelectedValue = visit.PatientId;

            // Диагноз и стоимость
            textBox1DiagnosRedact.Text = visit.Diagnosis;
            textBox1StoimostRedact.Text = visit.TreatmentCost.ToString("0.00");

            // Дата обращения
            dateTimePicker1VisitRedact.ShowCheckBox = true;
            if (visit.VisitDate != default)
            {
                dateTimePicker1VisitRedact.Value = visit.VisitDate.ToDateTime(TimeOnly.MinValue);
                dateTimePicker1VisitRedact.Checked = true;
            }
            else
            {
                dateTimePicker1VisitRedact.Value = DateTime.Today;
                dateTimePicker1VisitRedact.Checked = false;
            }
        }

        private void button1RedactObrashenie_Click(object sender, EventArgs e)
        {
            if (comboBox1VrachFromDoctorcsRedact.SelectedItem == null || comboBox1PatientfromPatientcsRedact.SelectedItem == null)
            {
                MessageBox.Show("Выберите врача и пациента.");
                return;
            }

            string diagnosis = textBox1DiagnosRedact.Text.Trim();
            if (string.IsNullOrWhiteSpace(diagnosis))
            {
                MessageBox.Show("Введите диагноз.");
                return;
            }

            if (!decimal.TryParse(textBox1StoimostRedact.Text.Replace(',', '.'), out decimal cost))
            {
                MessageBox.Show("Введите корректную стоимость.");
                return;
            }

            visit.DoctorId = (int)comboBox1VrachFromDoctorcsRedact.SelectedValue;
            visit.PatientId = (int)comboBox1PatientfromPatientcsRedact.SelectedValue;
            visit.Diagnosis = diagnosis;
            visit.TreatmentCost = cost;

            visit.VisitDate = dateTimePicker1VisitRedact.Checked
                ? DateOnly.FromDateTime(dateTimePicker1VisitRedact.Value)
                : default;

            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Обращение успешно обновлено.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void button2Otmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker1VisitRedact_ValueChanged(object sender, EventArgs e)
        {
            // Визуальная подсветка активности чекбокса
            if (dateTimePicker1VisitRedact.Checked)
            {
                dateTimePicker1VisitRedact.CalendarTitleBackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                dateTimePicker1VisitRedact.CalendarTitleBackColor = System.Drawing.SystemColors.Highlight;
            }
        }

        private void textBox1DiagnosRedact_TextChanged(object sender, EventArgs e) { }
        private void textBox1StoimostRedact_TextChanged(object sender, EventArgs e) { }
        private void comboBox1VrachFromDoctorcsRedact_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox1PatientfromPatientcsRedact_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
