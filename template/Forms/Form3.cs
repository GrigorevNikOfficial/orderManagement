using Microsoft.EntityFrameworkCore;
using Policlinic.Data;
using Policlinic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class Form3 : Form
    {
        private Doctor doctor;
        private PolyclinicDbContext dbContext;

        public Form3(Doctor selectedDoctor, PolyclinicDbContext context)
        {
            InitializeComponent();
            doctor = selectedDoctor;
            dbContext = context;
        }


        private void textBox1RedactorVrachFamilia_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2RedactorVrachName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3RedactorVrachOtchestvo_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1RedactorVrachSpec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2RedactorVrachKategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // Заполнение текстовых полей
            textBox1RedactorVrachFamilia.Text = doctor.LastName ?? "";
            textBox2RedactorVrachName.Text = doctor.FirstName ?? "";
            textBox3RedactorVrachOtchestvo.Text = doctor.MiddleName ?? "";

            // Получение уникальных значений специальностей и категорий
            var specialties = dbContext.Doctors
                .Select(d => d.Specialty)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToList();

            var categories = dbContext.Doctors
                .Select(d => d.Category)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .ToList();

            // Очистка и заполнение ComboBox'ов
            comboBox1RedactorVrachSpec.Items.Clear();
            comboBox1RedactorVrachSpec.Items.AddRange(specialties.ToArray());

            comboBox2RedactorVrachKategory.Items.Clear();
            comboBox2RedactorVrachKategory.Items.AddRange(categories.ToArray());

            // Установка выбранных значений
            if (!string.IsNullOrWhiteSpace(doctor.Specialty) && comboBox1RedactorVrachSpec.Items.Contains(doctor.Specialty))
                comboBox1RedactorVrachSpec.SelectedItem = doctor.Specialty;
            else
                comboBox1RedactorVrachSpec.SelectedIndex = -1;

            if (!string.IsNullOrWhiteSpace(doctor.Category) && comboBox2RedactorVrachKategory.Items.Contains(doctor.Category))
                comboBox2RedactorVrachKategory.SelectedItem = doctor.Category;
            else
                comboBox2RedactorVrachKategory.SelectedIndex = -1;
        }


        private void button1Redactor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1RedactorVrachFamilia.Text))
                    doctor.LastName = textBox1RedactorVrachFamilia.Text.Trim();

                if (!string.IsNullOrWhiteSpace(textBox2RedactorVrachName.Text))
                    doctor.FirstName = textBox2RedactorVrachName.Text.Trim();

                if (!string.IsNullOrWhiteSpace(textBox3RedactorVrachOtchestvo.Text))
                    doctor.MiddleName = textBox3RedactorVrachOtchestvo.Text.Trim();

                if (comboBox1RedactorVrachSpec.SelectedItem != null)
                    doctor.Specialty = comboBox1RedactorVrachSpec.SelectedItem.ToString();

                if (comboBox2RedactorVrachKategory.SelectedItem != null)
                    doctor.Category = comboBox2RedactorVrachKategory.SelectedItem.ToString();

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

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}
