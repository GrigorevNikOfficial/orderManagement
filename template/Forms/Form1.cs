using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Policlinic.Data;
using Policlinic.Forms;
using Policlinic.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Policlinic
{
    public partial class Form1 : Form
    {
        private PolyclinicDbContext dbContext;

        public Form1()
        {
            InitializeComponent();
            dbContext = new PolyclinicDbContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dbContext.Database.EnsureCreated();

                dbContext.Doctors.Load();
                dataGridView1.DataSource = dbContext.Doctors.Local.ToBindingList();

                dbContext.Patients.Load();
                dataGridView2.DataSource = dbContext.Patients.Local.ToBindingList();

                dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).Load();

                var visitDisplayList = dbContext.Visits.Local
                    .Select(v => new
                    {
                        Дата = v.VisitDate.ToString("dd.MM.yyyy"),
                        Диагноз = v.Diagnosis,
                        Стоимость = v.TreatmentCost,
                        Врач = $"{v.Doctor.LastName} {v.Doctor.FirstName} {v.Doctor.MiddleName}",
                        Пациент = $"{v.Patient.LastName} {v.Patient.FirstName} {v.Patient.MiddleName}"
                    }).ToList();

                dataGridView3.DataSource = visitDisplayList;

                comboBox1VrachSpec.SelectedIndex = -1;
                comboBox2VrachKategory.SelectedIndex = -1;

                comboBox1FioVrach.DataSource = dbContext.Doctors.ToList();
                comboBox1FioVrach.DisplayMember = "FullName";
                comboBox1FioVrach.ValueMember = "DoctorId";
                comboBox1FioVrach.SelectedIndex = -1;

                comboBoxFioPatient.DataSource = dbContext.Patients.ToList();
                comboBoxFioPatient.DisplayMember = "FullName";
                comboBoxFioPatient.ValueMember = "PatientId";
                comboBoxFioPatient.SelectedIndex = -1;

                dateTimePickerFilterVisit.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка данных: {ex.Message}");
            }
        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbContext?.Dispose();
            dbContext = null!;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbContext.SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            VrachForm vrachForm = new VrachForm(dbContext);
            vrachForm.ShowDialog();
            dataGridView1.Refresh();
        }

        private void deleteDoctor_Click_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите врача для удаления.");
                return;
            }

            var selectedDoctor = dataGridView1.CurrentRow.DataBoundItem as Doctor;

            if (selectedDoctor == null)
            {
                MessageBox.Show("Ошибка выбора записи.");
                return;
            }

            var confirm = MessageBox.Show($"Удалить врача: {selectedDoctor.LastName} {selectedDoctor.FirstName}?",
                                          "Подтверждение удаления",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    dbContext.Doctors.Remove(selectedDoctor);
                    dbContext.SaveChanges();
                    dataGridView1.Refresh();
                    MessageBox.Show("Врач удалён.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lastName = textBox1VrachFamilia.Text.Trim().ToLower();
            string firstName = textBox2VrachName.Text.Trim().ToLower();
            string middleName = textBox3VrachOtchestvo.Text.Trim().ToLower();
            string specialty = comboBox1VrachSpec.SelectedItem?.ToString();
            string category = comboBox2VrachKategory.SelectedItem?.ToString();

            var filteredDoctors = dbContext.Doctors.Local.Where(d =>
                (string.IsNullOrEmpty(lastName) || d.LastName.ToLower().StartsWith(lastName)) &&
                (string.IsNullOrEmpty(firstName) || d.FirstName.ToLower().StartsWith(firstName)) &&
                (string.IsNullOrEmpty(middleName) || (d.MiddleName ?? "").ToLower().StartsWith(middleName)) &&
                (string.IsNullOrEmpty(specialty) || d.Specialty == specialty) &&
                (string.IsNullOrEmpty(category) || d.Category == category)
            ).ToList();

            dataGridView1.DataSource = new BindingList<Doctor>(filteredDoctors);
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void textBox1VrachFamilia_TextChanged(object sender, EventArgs e) { }

        private void textBox2VrachName_TextChanged(object sender, EventArgs e) { }

        private void textBox3VrachOtchestvo_TextChanged(object sender, EventArgs e) { }

        private void comboBox1VrachSpec_SelectedIndexChanged(object sender, EventArgs e) { }

        private void comboBox2VrachKategory_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_obrashenie_Click(object sender, EventArgs e)
        {
            var obrashenieForm = new ObrashenieAdd(dbContext);
            obrashenieForm.ShowDialog();

            dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).Load();
            dataGridView3.DataSource = dbContext.Visits.Local.ToBindingList();

            dataGridView3.Columns["doctorDataGridViewTextBoxColumn"].HeaderText = "Врач";
            dataGridView3.Columns["patientDataGridViewTextBoxColumn"].HeaderText = "Пациент";
            dataGridView3.Columns["treatmentCostDataGridViewTextBoxColumn"].HeaderText = "Стоимость";
            dataGridView3.Columns["diagnosisDataGridViewTextBoxColumn"].HeaderText = "Диагноз";
            dataGridView3.Columns["visitDateDataGridViewTextBoxColumn"].HeaderText = "Дата обращения";
        }


        private void tabPage1_Click(object sender, EventArgs e) { }

        private void tabPage1_Click_1(object sender, EventArgs e) { }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            textBox1VrachFamilia.Text = "";
            textBox2VrachName.Text = "";
            textBox3VrachOtchestvo.Text = "";

            comboBox1VrachSpec.SelectedIndex = -1;
            comboBox2VrachKategory.SelectedIndex = -1;

            dataGridView1.DataSource = dbContext.Doctors.Local.ToBindingList();
        }

        private void button3RedactorVrach_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.DataBoundItem is not Doctor selectedDoctor)
            {
                MessageBox.Show("Выберите врача для редактирования.");
                return;
            }

            var editForm = new Form3(selectedDoctor, dbContext);
            editForm.ShowDialog();

            dbContext.Entry(selectedDoctor).Reload();
            dbContext.Doctors.Load();
            dataGridView1.DataSource = dbContext.Doctors.Local.ToBindingList();
        }



        private void button_pacient_Click(object sender, EventArgs e)
        {
            PatientAdd addForm = new PatientAdd(dbContext);
            addForm.ShowDialog();
            dataGridView2.Refresh();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1DateRozdenie_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3FilterPatient_Click_1(object sender, EventArgs e)
        {
            string lastName = textBox1FamiliaPatient.Text.Trim().ToLower();
            string firstName = textBox1NamePatient.Text.Trim().ToLower();
            string middleName = textBox1OtchestvoPatient.Text.Trim().ToLower();
            bool useDate = dateTimePicker1DateRozdenie.Checked;
            int selectedYear = dateTimePicker1DateRozdenie.Value.Year;

            var filteredPatients = dbContext.Patients.Local.Where(p =>
                (string.IsNullOrEmpty(lastName) || p.LastName.ToLower().StartsWith(lastName)) &&
                (string.IsNullOrEmpty(firstName) || p.FirstName.ToLower().StartsWith(firstName)) &&
                (string.IsNullOrEmpty(middleName) || (p.MiddleName ?? "").ToLower().StartsWith(middleName)) &&
                (!useDate || (p.BirthYear.HasValue && p.BirthYear.Value.Year == selectedYear))
            ).ToList();

            dataGridView2.DataSource = new BindingList<Patient>(filteredPatients);
        }





        private void textBox1FamiliaPatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1NamePatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1OtchestvoPatient_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1DateRozdenie_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1DateRozdenie.ShowCheckBox = true;
        }

        private void button3ClearPatientFilter_Click(object sender, EventArgs e)
        {
            textBox1FamiliaPatient.Text = "";
            textBox1NamePatient.Text = "";
            textBox1OtchestvoPatient.Text = "";
            dateTimePicker1DateRozdenie.Value = DateTime.Today;

            dataGridView2.DataSource = dbContext.Patients.Local.ToBindingList();
        }

        private void button3DeletePatient_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Выберите пациента для удаления.");
                return;
            }

            var selectedPatient = dataGridView2.CurrentRow.DataBoundItem as Patient;

            if (selectedPatient == null)
            {
                MessageBox.Show("Ошибка выбора записи.");
                return;
            }

            var confirm = MessageBox.Show($"Удалить пациента: {selectedPatient.LastName} {selectedPatient.FirstName}?",
                                          "Подтверждение удаления",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    dbContext.Patients.Remove(selectedPatient);
                    dbContext.SaveChanges();
                    dataGridView2.Refresh();
                    MessageBox.Show("Пациент удалён.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}");
                }
            }
        }

        private void button3RedactorPatient_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Выберите пациента для редактирования.");
                return;
            }

            var selectedPatient = dataGridView2.CurrentRow.DataBoundItem as Patient;
            if (selectedPatient != null)
            {
                PatientRedactor editForm = new PatientRedactor(selectedPatient, dbContext);
                editForm.ShowDialog();
                dataGridView2.Refresh();
            }
        }

        private void buttonRedactorObrashenie_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null || dataGridView3.CurrentRow.DataBoundItem is not Visit selectedVisit)
            {
                MessageBox.Show("Выберите обращение для редактирования.");
                return;
            }

            var redactForm = new RedactorVisit(selectedVisit, dbContext);
            redactForm.ShowDialog();

            dbContext.Entry(selectedVisit).Reload();
            dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).Load();
            dataGridView3.DataSource = dbContext.Visits.Local.ToBindingList();
        }


        private void buttonFilterVisit_Click(object sender, EventArgs e)
        {
            int? selectedDoctorId = comboBox1FioVrach.SelectedValue as int?;
            int? selectedPatientId = comboBoxFioPatient.SelectedValue as int?;
            bool useDate = dateTimePickerFilterVisit.Checked;
            DateOnly selectedDate = DateOnly.FromDateTime(dateTimePickerFilterVisit.Value);

            decimal? costFrom = decimal.TryParse(textBoxFilterStoimostOt.Text.Replace(',', '.'), out var fromVal) ? fromVal : null;
            decimal? costTo = decimal.TryParse(textBoxFilterStoimostDo.Text.Replace(',', '.'), out var toVal) ? toVal : null;

            var filtered = dbContext.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Where(v =>
                    (!selectedDoctorId.HasValue || v.DoctorId == selectedDoctorId.Value) &&
                    (!selectedPatientId.HasValue || v.PatientId == selectedPatientId.Value) &&
                    (!useDate || v.VisitDate == selectedDate) &&
                    (!costFrom.HasValue || v.TreatmentCost >= costFrom.Value) &&
                    (!costTo.HasValue || v.TreatmentCost <= costTo.Value)
                )
                .ToList();

            dataGridView3.DataSource = new BindingSource { DataSource = filtered };
        }

        private void buttonClearFilterVisit_Click(object sender, EventArgs e)
        {
            comboBox1FioVrach.SelectedIndex = -1;
            comboBoxFioPatient.SelectedIndex = -1;
            dateTimePickerFilterVisit.Value = DateTime.Today;
            textBoxFilterStoimostOt.Clear();
            textBoxFilterStoimostDo.Clear();

            dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).Load();
            dataGridView3.DataSource = dbContext.Visits.Local.ToBindingList();
        }

        private void comboBox1FioVrach_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFioPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFilterVisit_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFilterVisit.ShowCheckBox = true;

            bool useDate = dateTimePickerFilterVisit.Checked;

            if (useDate)
            {
                dateTimePickerFilterVisit.CalendarTitleBackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                dateTimePickerFilterVisit.CalendarTitleBackColor = System.Drawing.SystemColors.Highlight;
            }

        }

        private void textBoxFilterStoimostOt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxFilterStoimostDo_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonVisitDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null || dataGridView3.CurrentRow.DataBoundItem is not Visit selectedVisit)
            {
                MessageBox.Show("Выберите обращение для удаления.");
                return;
            }

            var confirm = MessageBox.Show("Вы уверены, что хотите удалить выбранное обращение?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                dbContext.Visits.Remove(selectedVisit);
                dbContext.SaveChanges();

                dbContext.Visits.Include(v => v.Doctor).Include(v => v.Patient).Load();
                dataGridView3.DataSource = dbContext.Visits.Local.ToBindingList();

                MessageBox.Show("Обращение успешно удалено.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }

        private Paragraph CreateParagraph(string text, bool bold, int fontSize, JustificationValues align)
        {
            var runProps = new RunProperties(
                new FontSize { Val = (fontSize * 2).ToString() }
            );

            if (bold)
                runProps.Append(new Bold());

            return new Paragraph(
                new ParagraphProperties(new Justification { Val = align }),
                new Run(runProps, new Text(text))
            );
        }

        private Paragraph CreateParagraph(string text, bool bold = false, int fontSize = 12)
        {
            return CreateParagraph(text, bold, fontSize, JustificationValues.Left);
        }

        private string NumberToWords(int number)
        {
            return number switch
            {
                <= 0 => "ноль",
                1 => "один",
                2 => "два",
                3 => "три",
                4 => "четыре",
                5 => "пять",
                6 => "шесть",
                7 => "семь",
                8 => "восемь",
                9 => "девять",
                10 => "десять",
                _ => number.ToString() // временно — можно расширить
            };
        }

        private void buttonWordWithoutTable_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow == null || dataGridView3.CurrentRow.DataBoundItem is not Visit selectedVisit)
            {
                MessageBox.Show("Выберите обращение для формирования документа.");
                return;
            }

            var confirm = MessageBox.Show("Сформировать квитанцию на оплату по выбранному обращению?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            var doctor = dbContext.Doctors.FirstOrDefault(d => d.DoctorId == selectedVisit.DoctorId);
            var patient = dbContext.Patients.FirstOrDefault(p => p.PatientId == selectedVisit.PatientId);
            var visitDate = selectedVisit.VisitDate;
            var cost = selectedVisit.TreatmentCost;

            string folderPath = @"C:\Word and excel";
            Directory.CreateDirectory(folderPath);
            string fileName = $"Справка_{patient.LastName}_{visitDate:yyyyMMdd}.docx";
            string filePath = Path.Combine(folderPath, fileName);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                body.Append(CreateParagraph("СПРАВКА", true, 14, JustificationValues.Center));
                body.Append(CreateParagraph("ОБ ОПЛАТЕ МЕДИЦИНСКИХ УСЛУГ ДЛЯ ПРЕДСТАВЛЕНИЯ", false, 12, JustificationValues.Center));
                body.Append(CreateParagraph("В НАЛОГОВЫЕ ОРГАНЫ РОССИЙСКОЙ ФЕДЕРАЦИИ", false, 12, JustificationValues.Center));
                body.Append(CreateParagraph($"от \"{visitDate.Day:00}\" {visitDate.ToString("MMMM")} {visitDate.Year} г.", false, 12));

                body.Append(CreateParagraph($"Выдана налогоплательщику (Ф.И.О.): {patient.LastName} {patient.FirstName} {patient.MiddleName}"));
                body.Append(CreateParagraph("ИНН налогоплательщика: ____________________________"));
                body.Append(CreateParagraph($"В том, что он(а) оплатил(а) медицинские услуги стоимостью: {cost:0.00} руб."));
                body.Append(CreateParagraph($"(сумма прописью): {NumberToWords((int)cost)} рублей"));
                body.Append(CreateParagraph($"оказанные: ему (ей), супругу(е), сыну(дочери), матери(отцу): {patient.LastName} {patient.FirstName} {patient.MiddleName}"));
                body.Append(CreateParagraph($"Дата оплаты: \"{visitDate.Day:00}\" {visitDate.ToString("MMMM")} {visitDate.Year} г."));
                body.Append(CreateParagraph($"Фамилия, имя, отчество и должность лица, выдавшего справку: {doctor.LastName} {doctor.FirstName} {doctor.MiddleName}, {doctor.Category}"));
                body.Append(CreateParagraph("Телефон: _____________________"));
                body.Append(CreateParagraph("Код: _____________________"));
                body.Append(CreateParagraph("(личная подпись лица, выдавшего справку)", false, 12, JustificationValues.Right));
                body.Append(CreateParagraph("Бланк. Формат А5. Срок хранения 3 года.", false, 10, JustificationValues.Right));

                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
        private TableCell CreateCell(string text)
        {
            return new TableCell(new Paragraph(new Run(new Text(text))));
        }
        private void buttonWordOtchetObrashenie_Click(object sender, EventArgs e)
        {
            var periodForm = new PeriodSelectorForm();
            if (periodForm.ShowDialog() != DialogResult.OK)
                return;

            var dateFrom = periodForm.DateFrom;
            var dateTo = periodForm.DateTo;

            var visits = dbContext.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Where(v => v.VisitDate >= dateFrom && v.VisitDate <= dateTo)
                .ToList();

            if (!visits.Any())
            {
                MessageBox.Show("Нет обращений за выбранный период.");
                return;
            }

            string folderPath = @"C:\Word and excel";
            Directory.CreateDirectory(folderPath);
            string fileName = $"Отчет_Обращения_{dateFrom:yyyyMMdd}_{dateTo:yyyyMMdd}.docx";
            string filePath = Path.Combine(folderPath, fileName);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                var mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new Document();
                var body = new Body();

                body.Append(CreateParagraph("ОТЧЕТ ПО ОБРАЩЕНИЯМ", true, 14, JustificationValues.Center));
                body.Append(CreateParagraph($"Период: с {dateFrom:dd.MM.yyyy} по {dateTo:dd.MM.yyyy}", false, 12, JustificationValues.Center));
                body.Append(new Paragraph(new Run(new Text("")))); // пустая строка

                var table = new Table();
                table.AppendChild(new TableProperties(
                    new TableBorders(
                        new TopBorder { Val = BorderValues.Single, Size = 4 },
                        new BottomBorder { Val = BorderValues.Single, Size = 4 },
                        new LeftBorder { Val = BorderValues.Single, Size = 4 },
                        new RightBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideHorizontalBorder { Val = BorderValues.Single, Size = 4 },
                        new InsideVerticalBorder { Val = BorderValues.Single, Size = 4 }
                    )));

                var headerRow = new TableRow();
                headerRow.Append(
                    CreateCell("Дата"),
                    CreateCell("Пациент"),
                    CreateCell("Врач"),
                    CreateCell("Диагноз"),
                    CreateCell("Стоимость")
                );
                table.Append(headerRow);

                foreach (var visit in visits)
                {
                    var row = new TableRow();
                    row.Append(
                        CreateCell(visit.VisitDate.ToString("dd.MM.yyyy")),
                        CreateCell($"{visit.Patient.LastName} {visit.Patient.FirstName}"),
                        CreateCell($"{visit.Doctor.LastName} {visit.Doctor.FirstName}"),
                        CreateCell(visit.Diagnosis),
                        CreateCell($"{visit.TreatmentCost:0.00} руб.")
                    );
                    table.Append(row);
                }

                body.Append(table);
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }

            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
