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


namespace Policlinic
{
    public partial class VrachForm : Form
    {
        private PolyclinicDbContext dbContext;

        public VrachForm(PolyclinicDbContext context)
        {
            InitializeComponent();
            dbContext = context;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void VrachForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboSpec_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textVName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textVOtch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_addVrach_Click(object sender, EventArgs e)
        {
            try
            {
                Doctor newDoctor = new Doctor
                {
                    FirstName = textVName.Text.Trim(),
                    LastName = textVFio.Text.Trim(),
                    MiddleName = textVOtch.Text.Trim(),
                    Specialty = comboSpec.SelectedItem?.ToString(),
                    Category = comboCategory.SelectedItem?.ToString()
                };

                dbContext.Doctors.Add(newDoctor);
                dbContext.SaveChanges();

                MessageBox.Show("Врач успешно добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении врача: {ex.Message}");
            }
        }

        private void button1Otmena_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
