using Policlinic.Models;

namespace Policlinic
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            doctorBindingSource = new BindingSource(components);
            patientBindingSource = new BindingSource(components);
            visitBindingSource = new BindingSource(components);
            userControl1BindingSource = new BindingSource(components);
            form1BindingSource = new BindingSource(components);
            userControl1BindingSource1 = new BindingSource(components);
            button1 = new Button();
            visitBindingSource1 = new BindingSource(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tabPage3 = new TabPage();
            buttonWordOtchetObrashenie = new Button();
            buttonWordWithoutTable = new Button();
            buttonVisitDelete = new Button();
            label15 = new Label();
            label14 = new Label();
            textBoxFilterStoimostDo = new TextBox();
            textBoxFilterStoimostOt = new TextBox();
            label13 = new Label();
            label12 = new Label();
            dateTimePickerFilterVisit = new DateTimePicker();
            buttonClearFilterVisit = new Button();
            buttonFilterVisit = new Button();
            label12FioPatient = new Label();
            comboBoxFioPatient = new ComboBox();
            label11 = new Label();
            buttonRedactorObrashenie = new Button();
            comboBox1FioVrach = new ComboBox();
            button_obrashenie = new Button();
            dataGridView3 = new DataGridView();
            visitIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doctorIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            patientIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            visitDateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            diagnosisDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            treatmentCostDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            doctorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            patientDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            button3ClearPatientFilter = new Button();
            dateTimePicker1DateRozdenie = new DateTimePicker();
            button3FilterPatient = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            textBox1OtchestvoPatient = new TextBox();
            textBox1NamePatient = new TextBox();
            textBox1FamiliaPatient = new TextBox();
            button3DeletePatient = new Button();
            button3RedactorPatient = new Button();
            button_pacient = new Button();
            dataGridView2 = new DataGridView();
            patientIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            middleNameDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            birthYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            button3RedactorVrach = new Button();
            buttonClearFilter = new Button();
            comboBox2VrachKategory = new ComboBox();
            comboBox1VrachSpec = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox3VrachOtchestvo = new TextBox();
            textBox2VrachName = new TextBox();
            textBox1VrachFamilia = new TextBox();
            label1 = new Label();
            button2 = new Button();
            deleteDoctor_Click = new Button();
            button_vrach = new Button();
            dataGridView1 = new DataGridView();
            doctorIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lastNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            firstNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            middleNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            specialtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            ((System.ComponentModel.ISupportInitialize)doctorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)visitBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userControl1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userControl1BindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)visitBindingSource1).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // doctorBindingSource
            // 
            doctorBindingSource.DataSource = typeof(Doctor);
            // 
            // patientBindingSource
            // 
            patientBindingSource.DataSource = typeof(Patient);
            // 
            // visitBindingSource
            // 
            visitBindingSource.DataSource = typeof(Visit);
            // 
            // userControl1BindingSource
            // 
            userControl1BindingSource.DataSource = typeof(UserControl1);
            // 
            // form1BindingSource
            // 
            form1BindingSource.DataSource = typeof(Form1);
            // 
            // userControl1BindingSource1
            // 
            userControl1BindingSource1.DataSource = typeof(UserControl1);
            // 
            // button1
            // 
            button1.Location = new Point(885, -121);
            button1.Name = "button1";
            button1.Size = new Size(358, 88);
            button1.TabIndex = 3;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // visitBindingSource1
            // 
            visitBindingSource1.DataSource = typeof(Visit);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(buttonWordOtchetObrashenie);
            tabPage3.Controls.Add(buttonWordWithoutTable);
            tabPage3.Controls.Add(buttonVisitDelete);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label14);
            tabPage3.Controls.Add(textBoxFilterStoimostDo);
            tabPage3.Controls.Add(textBoxFilterStoimostOt);
            tabPage3.Controls.Add(label13);
            tabPage3.Controls.Add(label12);
            tabPage3.Controls.Add(dateTimePickerFilterVisit);
            tabPage3.Controls.Add(buttonClearFilterVisit);
            tabPage3.Controls.Add(buttonFilterVisit);
            tabPage3.Controls.Add(label12FioPatient);
            tabPage3.Controls.Add(comboBoxFioPatient);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(buttonRedactorObrashenie);
            tabPage3.Controls.Add(comboBox1FioVrach);
            tabPage3.Controls.Add(button_obrashenie);
            tabPage3.Controls.Add(dataGridView3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1247, 479);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Таблица обращения";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonWordOtchetObrashenie
            // 
            buttonWordOtchetObrashenie.Location = new Point(234, 357);
            buttonWordOtchetObrashenie.Name = "buttonWordOtchetObrashenie";
            buttonWordOtchetObrashenie.Size = new Size(185, 29);
            buttonWordOtchetObrashenie.TabIndex = 23;
            buttonWordOtchetObrashenie.Text = "Отчёт по обращениям";
            buttonWordOtchetObrashenie.UseVisualStyleBackColor = true;
            buttonWordOtchetObrashenie.Click += buttonWordOtchetObrashenie_Click;
            // 
            // buttonWordWithoutTable
            // 
            buttonWordWithoutTable.Location = new Point(6, 357);
            buttonWordWithoutTable.Name = "buttonWordWithoutTable";
            buttonWordWithoutTable.Size = new Size(207, 29);
            buttonWordWithoutTable.TabIndex = 22;
            buttonWordWithoutTable.Text = "Создать квитанцию";
            buttonWordWithoutTable.UseVisualStyleBackColor = true;
            buttonWordWithoutTable.Click += buttonWordWithoutTable_Click;
            // 
            // buttonVisitDelete
            // 
            buttonVisitDelete.Location = new Point(518, 221);
            buttonVisitDelete.Name = "buttonVisitDelete";
            buttonVisitDelete.Size = new Size(237, 29);
            buttonVisitDelete.TabIndex = 21;
            buttonVisitDelete.Text = "Удалить выбранную запись";
            buttonVisitDelete.UseVisualStyleBackColor = true;
            buttonVisitDelete.Click += buttonVisitDelete_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(890, 298);
            label15.Name = "label15";
            label15.Size = new Size(28, 20);
            label15.TabIndex = 20;
            label15.Text = "До";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(692, 297);
            label14.Name = "label14";
            label14.Size = new Size(26, 20);
            label14.TabIndex = 19;
            label14.Text = "От";
            // 
            // textBoxFilterStoimostDo
            // 
            textBoxFilterStoimostDo.Location = new Point(919, 291);
            textBoxFilterStoimostDo.Name = "textBoxFilterStoimostDo";
            textBoxFilterStoimostDo.Size = new Size(158, 27);
            textBoxFilterStoimostDo.TabIndex = 18;
            textBoxFilterStoimostDo.TextChanged += textBoxFilterStoimostDo_TextChanged;
            // 
            // textBoxFilterStoimostOt
            // 
            textBoxFilterStoimostOt.Location = new Point(726, 291);
            textBoxFilterStoimostOt.Name = "textBoxFilterStoimostOt";
            textBoxFilterStoimostOt.Size = new Size(158, 27);
            textBoxFilterStoimostOt.TabIndex = 16;
            textBoxFilterStoimostOt.TextChanged += textBoxFilterStoimostOt_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(690, 259);
            label13.Name = "label13";
            label13.Size = new Size(158, 20);
            label13.TabIndex = 17;
            label13.Text = "Фильтр по стоимость";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(425, 266);
            label12.Name = "label12";
            label12.Size = new Size(116, 20);
            label12.TabIndex = 15;
            label12.Text = "Фильтр по дате";
            // 
            // dateTimePickerFilterVisit
            // 
            dateTimePickerFilterVisit.Location = new Point(425, 289);
            dateTimePickerFilterVisit.Name = "dateTimePickerFilterVisit";
            dateTimePickerFilterVisit.Size = new Size(250, 27);
            dateTimePickerFilterVisit.TabIndex = 14;
            dateTimePickerFilterVisit.ValueChanged += dateTimePickerFilterVisit_ValueChanged;
            // 
            // buttonClearFilterVisit
            // 
            buttonClearFilterVisit.Location = new Point(1004, 221);
            buttonClearFilterVisit.Name = "buttonClearFilterVisit";
            buttonClearFilterVisit.Size = new Size(237, 29);
            buttonClearFilterVisit.TabIndex = 13;
            buttonClearFilterVisit.Text = "Очистить фильтр";
            buttonClearFilterVisit.UseVisualStyleBackColor = true;
            buttonClearFilterVisit.Click += buttonClearFilterVisit_Click;
            // 
            // buttonFilterVisit
            // 
            buttonFilterVisit.Location = new Point(761, 221);
            buttonFilterVisit.Name = "buttonFilterVisit";
            buttonFilterVisit.Size = new Size(237, 29);
            buttonFilterVisit.TabIndex = 12;
            buttonFilterVisit.Text = "Применить фильтр";
            buttonFilterVisit.UseVisualStyleBackColor = true;
            buttonFilterVisit.Click += buttonFilterVisit_Click;
            // 
            // label12FioPatient
            // 
            label12FioPatient.AutoSize = true;
            label12FioPatient.Location = new Point(234, 266);
            label12FioPatient.Name = "label12FioPatient";
            label12FioPatient.Size = new Size(114, 20);
            label12FioPatient.TabIndex = 11;
            label12FioPatient.Text = "ФИО Пациента";
            // 
            // comboBoxFioPatient
            // 
            comboBoxFioPatient.FormattingEnabled = true;
            comboBoxFioPatient.Location = new Point(234, 289);
            comboBoxFioPatient.Name = "comboBoxFioPatient";
            comboBoxFioPatient.Size = new Size(185, 28);
            comboBoxFioPatient.TabIndex = 10;
            comboBoxFioPatient.SelectedIndexChanged += comboBoxFioPatient_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 266);
            label11.Name = "label11";
            label11.Size = new Size(88, 20);
            label11.TabIndex = 9;
            label11.Text = "ФИО Врача";
            // 
            // buttonRedactorObrashenie
            // 
            buttonRedactorObrashenie.Location = new Point(253, 221);
            buttonRedactorObrashenie.Name = "buttonRedactorObrashenie";
            buttonRedactorObrashenie.Size = new Size(237, 29);
            buttonRedactorObrashenie.TabIndex = 8;
            buttonRedactorObrashenie.Text = "Редактировать";
            buttonRedactorObrashenie.UseVisualStyleBackColor = true;
            buttonRedactorObrashenie.Click += buttonRedactorObrashenie_Click;
            // 
            // comboBox1FioVrach
            // 
            comboBox1FioVrach.FormattingEnabled = true;
            comboBox1FioVrach.Location = new Point(6, 289);
            comboBox1FioVrach.Name = "comboBox1FioVrach";
            comboBox1FioVrach.Size = new Size(207, 28);
            comboBox1FioVrach.TabIndex = 7;
            comboBox1FioVrach.SelectedIndexChanged += comboBox1FioVrach_SelectedIndexChanged;
            // 
            // button_obrashenie
            // 
            button_obrashenie.Location = new Point(0, 221);
            button_obrashenie.Name = "button_obrashenie";
            button_obrashenie.Size = new Size(237, 29);
            button_obrashenie.TabIndex = 6;
            button_obrashenie.Text = "Добавить обращение";
            button_obrashenie.UseVisualStyleBackColor = true;
            button_obrashenie.Click += button_obrashenie_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToOrderColumns = true;
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { visitIdDataGridViewTextBoxColumn, doctorIdDataGridViewTextBoxColumn1, patientIdDataGridViewTextBoxColumn1, visitDateDataGridViewTextBoxColumn, diagnosisDataGridViewTextBoxColumn, treatmentCostDataGridViewTextBoxColumn, doctorDataGridViewTextBoxColumn, patientDataGridViewTextBoxColumn });
            dataGridView3.DataSource = visitBindingSource;
            dataGridView3.Location = new Point(0, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(1251, 212);
            dataGridView3.TabIndex = 2;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // visitIdDataGridViewTextBoxColumn
            // 
            visitIdDataGridViewTextBoxColumn.DataPropertyName = "VisitId";
            visitIdDataGridViewTextBoxColumn.HeaderText = "ID";
            visitIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            visitIdDataGridViewTextBoxColumn.Name = "visitIdDataGridViewTextBoxColumn";
            visitIdDataGridViewTextBoxColumn.ReadOnly = true;
            visitIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // doctorIdDataGridViewTextBoxColumn1
            // 
            doctorIdDataGridViewTextBoxColumn1.DataPropertyName = "DoctorId";
            doctorIdDataGridViewTextBoxColumn1.HeaderText = "Доктор_ID";
            doctorIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            doctorIdDataGridViewTextBoxColumn1.Name = "doctorIdDataGridViewTextBoxColumn1";
            doctorIdDataGridViewTextBoxColumn1.ReadOnly = true;
            doctorIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // patientIdDataGridViewTextBoxColumn1
            // 
            patientIdDataGridViewTextBoxColumn1.DataPropertyName = "PatientId";
            patientIdDataGridViewTextBoxColumn1.HeaderText = "Пациент_ID";
            patientIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            patientIdDataGridViewTextBoxColumn1.Name = "patientIdDataGridViewTextBoxColumn1";
            patientIdDataGridViewTextBoxColumn1.ReadOnly = true;
            patientIdDataGridViewTextBoxColumn1.Visible = false;
            // 
            // visitDateDataGridViewTextBoxColumn
            // 
            visitDateDataGridViewTextBoxColumn.DataPropertyName = "VisitDate";
            visitDateDataGridViewTextBoxColumn.HeaderText = "Дата обращения";
            visitDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            visitDateDataGridViewTextBoxColumn.Name = "visitDateDataGridViewTextBoxColumn";
            // 
            // diagnosisDataGridViewTextBoxColumn
            // 
            diagnosisDataGridViewTextBoxColumn.DataPropertyName = "Diagnosis";
            diagnosisDataGridViewTextBoxColumn.HeaderText = "Диагноз";
            diagnosisDataGridViewTextBoxColumn.MinimumWidth = 6;
            diagnosisDataGridViewTextBoxColumn.Name = "diagnosisDataGridViewTextBoxColumn";
            // 
            // treatmentCostDataGridViewTextBoxColumn
            // 
            treatmentCostDataGridViewTextBoxColumn.DataPropertyName = "TreatmentCost";
            treatmentCostDataGridViewTextBoxColumn.HeaderText = "Стоимость";
            treatmentCostDataGridViewTextBoxColumn.MinimumWidth = 6;
            treatmentCostDataGridViewTextBoxColumn.Name = "treatmentCostDataGridViewTextBoxColumn";
            // 
            // doctorDataGridViewTextBoxColumn
            // 
            doctorDataGridViewTextBoxColumn.DataPropertyName = "DoctorName";
            doctorDataGridViewTextBoxColumn.HeaderText = "Врач";
            doctorDataGridViewTextBoxColumn.MinimumWidth = 6;
            doctorDataGridViewTextBoxColumn.Name = "doctorDataGridViewTextBoxColumn";
            doctorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // patientDataGridViewTextBoxColumn
            // 
            patientDataGridViewTextBoxColumn.DataPropertyName = "PatientName";
            patientDataGridViewTextBoxColumn.HeaderText = "Пациент";
            patientDataGridViewTextBoxColumn.MinimumWidth = 6;
            patientDataGridViewTextBoxColumn.Name = "patientDataGridViewTextBoxColumn";
            patientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button3ClearPatientFilter);
            tabPage2.Controls.Add(dateTimePicker1DateRozdenie);
            tabPage2.Controls.Add(button3FilterPatient);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(label7);
            tabPage2.Controls.Add(textBox1OtchestvoPatient);
            tabPage2.Controls.Add(textBox1NamePatient);
            tabPage2.Controls.Add(textBox1FamiliaPatient);
            tabPage2.Controls.Add(button3DeletePatient);
            tabPage2.Controls.Add(button3RedactorPatient);
            tabPage2.Controls.Add(button_pacient);
            tabPage2.Controls.Add(dataGridView2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1247, 479);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Таблица пациенты";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3ClearPatientFilter
            // 
            button3ClearPatientFilter.Location = new Point(885, 217);
            button3ClearPatientFilter.Name = "button3ClearPatientFilter";
            button3ClearPatientFilter.Size = new Size(183, 29);
            button3ClearPatientFilter.TabIndex = 18;
            button3ClearPatientFilter.Text = "Очистить фильтр";
            button3ClearPatientFilter.UseVisualStyleBackColor = true;
            button3ClearPatientFilter.Click += button3ClearPatientFilter_Click;
            // 
            // dateTimePicker1DateRozdenie
            // 
            dateTimePicker1DateRozdenie.Location = new Point(696, 171);
            dateTimePicker1DateRozdenie.Name = "dateTimePicker1DateRozdenie";
            dateTimePicker1DateRozdenie.Size = new Size(250, 27);
            dateTimePicker1DateRozdenie.TabIndex = 17;
            dateTimePicker1DateRozdenie.ValueChanged += dateTimePicker1DateRozdenie_ValueChanged;
            // 
            // button3FilterPatient
            // 
            button3FilterPatient.Location = new Point(696, 217);
            button3FilterPatient.Name = "button3FilterPatient";
            button3FilterPatient.Size = new Size(183, 29);
            button3FilterPatient.TabIndex = 16;
            button3FilterPatient.Text = "Применить фильтр";
            button3FilterPatient.UseVisualStyleBackColor = true;
            button3FilterPatient.Click += button3FilterPatient_Click_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(696, 137);
            label10.Name = "label10";
            label10.Size = new Size(116, 20);
            label10.TabIndex = 15;
            label10.Text = "Дата рождения";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(994, 61);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 14;
            label9.Text = "Отчество";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(846, 61);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 13;
            label8.Text = "Имя";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(696, 61);
            label7.Name = "label7";
            label7.Size = new Size(73, 20);
            label7.TabIndex = 12;
            label7.Text = "Фамилия";
            // 
            // textBox1OtchestvoPatient
            // 
            textBox1OtchestvoPatient.Location = new Point(994, 94);
            textBox1OtchestvoPatient.Name = "textBox1OtchestvoPatient";
            textBox1OtchestvoPatient.Size = new Size(125, 27);
            textBox1OtchestvoPatient.TabIndex = 10;
            textBox1OtchestvoPatient.TextChanged += textBox1OtchestvoPatient_TextChanged;
            // 
            // textBox1NamePatient
            // 
            textBox1NamePatient.Location = new Point(846, 94);
            textBox1NamePatient.Name = "textBox1NamePatient";
            textBox1NamePatient.Size = new Size(125, 27);
            textBox1NamePatient.TabIndex = 9;
            textBox1NamePatient.TextChanged += textBox1NamePatient_TextChanged;
            // 
            // textBox1FamiliaPatient
            // 
            textBox1FamiliaPatient.Location = new Point(696, 94);
            textBox1FamiliaPatient.Name = "textBox1FamiliaPatient";
            textBox1FamiliaPatient.Size = new Size(125, 27);
            textBox1FamiliaPatient.TabIndex = 8;
            textBox1FamiliaPatient.TextChanged += textBox1FamiliaPatient_TextChanged;
            // 
            // button3DeletePatient
            // 
            button3DeletePatient.Location = new Point(1064, 0);
            button3DeletePatient.Name = "button3DeletePatient";
            button3DeletePatient.Size = new Size(183, 29);
            button3DeletePatient.TabIndex = 7;
            button3DeletePatient.Text = "Удалить запись";
            button3DeletePatient.UseVisualStyleBackColor = true;
            button3DeletePatient.Click += button3DeletePatient_Click;
            // 
            // button3RedactorPatient
            // 
            button3RedactorPatient.Location = new Point(873, 0);
            button3RedactorPatient.Name = "button3RedactorPatient";
            button3RedactorPatient.Size = new Size(183, 29);
            button3RedactorPatient.TabIndex = 6;
            button3RedactorPatient.Text = "Редактировать запись";
            button3RedactorPatient.UseVisualStyleBackColor = true;
            button3RedactorPatient.Click += button3RedactorPatient_Click;
            // 
            // button_pacient
            // 
            button_pacient.Location = new Point(684, 0);
            button_pacient.Name = "button_pacient";
            button_pacient.Size = new Size(183, 29);
            button_pacient.TabIndex = 5;
            button_pacient.Text = "Добавить пациента";
            button_pacient.UseVisualStyleBackColor = true;
            button_pacient.Click += button_pacient_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { patientIdDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn1, firstNameDataGridViewTextBoxColumn1, middleNameDataGridViewTextBoxColumn1, birthYearDataGridViewTextBoxColumn });
            dataGridView2.DataSource = patientBindingSource;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(678, 246);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // patientIdDataGridViewTextBoxColumn
            // 
            patientIdDataGridViewTextBoxColumn.DataPropertyName = "PatientId";
            patientIdDataGridViewTextBoxColumn.HeaderText = "ID";
            patientIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            patientIdDataGridViewTextBoxColumn.Name = "patientIdDataGridViewTextBoxColumn";
            // 
            // lastNameDataGridViewTextBoxColumn1
            // 
            lastNameDataGridViewTextBoxColumn1.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            lastNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn1.Name = "lastNameDataGridViewTextBoxColumn1";
            // 
            // firstNameDataGridViewTextBoxColumn1
            // 
            firstNameDataGridViewTextBoxColumn1.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn1.HeaderText = "Имя";
            firstNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn1.Name = "firstNameDataGridViewTextBoxColumn1";
            // 
            // middleNameDataGridViewTextBoxColumn1
            // 
            middleNameDataGridViewTextBoxColumn1.DataPropertyName = "MiddleName";
            middleNameDataGridViewTextBoxColumn1.HeaderText = "Отчество";
            middleNameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            middleNameDataGridViewTextBoxColumn1.Name = "middleNameDataGridViewTextBoxColumn1";
            // 
            // birthYearDataGridViewTextBoxColumn
            // 
            birthYearDataGridViewTextBoxColumn.DataPropertyName = "BirthYear";
            birthYearDataGridViewTextBoxColumn.HeaderText = "Дата рождения";
            birthYearDataGridViewTextBoxColumn.MinimumWidth = 6;
            birthYearDataGridViewTextBoxColumn.Name = "birthYearDataGridViewTextBoxColumn";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button3RedactorVrach);
            tabPage1.Controls.Add(buttonClearFilter);
            tabPage1.Controls.Add(comboBox2VrachKategory);
            tabPage1.Controls.Add(comboBox1VrachSpec);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox3VrachOtchestvo);
            tabPage1.Controls.Add(textBox2VrachName);
            tabPage1.Controls.Add(textBox1VrachFamilia);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(deleteDoctor_Click);
            tabPage1.Controls.Add(button_vrach);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1247, 479);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Таблица врачи";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click_1;
            // 
            // button3RedactorVrach
            // 
            button3RedactorVrach.Location = new Point(997, 35);
            button3RedactorVrach.Name = "button3RedactorVrach";
            button3RedactorVrach.Size = new Size(238, 29);
            button3RedactorVrach.TabIndex = 21;
            button3RedactorVrach.Text = "Редактировать запись";
            button3RedactorVrach.UseVisualStyleBackColor = true;
            button3RedactorVrach.Click += button3RedactorVrach_Click;
            // 
            // buttonClearFilter
            // 
            buttonClearFilter.Location = new Point(1087, 312);
            buttonClearFilter.Name = "buttonClearFilter";
            buttonClearFilter.Size = new Size(154, 29);
            buttonClearFilter.TabIndex = 20;
            buttonClearFilter.Text = "Очистить фильтр";
            buttonClearFilter.UseVisualStyleBackColor = true;
            buttonClearFilter.Click += buttonClearFilter_Click;
            // 
            // comboBox2VrachKategory
            // 
            comboBox2VrachKategory.FormattingEnabled = true;
            comboBox2VrachKategory.Items.AddRange(new object[] { "Лаборант", "Вторая категории", "Первая категория", "Высшая категория" });
            comboBox2VrachKategory.Location = new Point(956, 266);
            comboBox2VrachKategory.Name = "comboBox2VrachKategory";
            comboBox2VrachKategory.Size = new Size(125, 28);
            comboBox2VrachKategory.TabIndex = 19;
            comboBox2VrachKategory.SelectedIndexChanged += comboBox2VrachKategory_SelectedIndexChanged;
            // 
            // comboBox1VrachSpec
            // 
            comboBox1VrachSpec.FormattingEnabled = true;
            comboBox1VrachSpec.Items.AddRange(new object[] { "Терапевт", "Невролог", "Кардиолог", "Онколог", "Психиатр", "Эндокринолог", "Офтальмолог", "Педиатр" });
            comboBox1VrachSpec.Location = new Point(811, 266);
            comboBox1VrachSpec.Name = "comboBox1VrachSpec";
            comboBox1VrachSpec.Size = new Size(125, 28);
            comboBox1VrachSpec.TabIndex = 18;
            comboBox1VrachSpec.SelectedIndexChanged += comboBox1VrachSpec_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(956, 232);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 17;
            label6.Text = "Категория";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(811, 232);
            label5.Name = "label5";
            label5.Size = new Size(116, 20);
            label5.TabIndex = 16;
            label5.Text = "Специальность";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1100, 174);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 15;
            label4.Text = "Отчество";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(956, 174);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 14;
            label3.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(811, 179);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 13;
            label2.Text = "Фамилия";
            label2.Click += label2_Click;
            // 
            // textBox3VrachOtchestvo
            // 
            textBox3VrachOtchestvo.Location = new Point(1100, 202);
            textBox3VrachOtchestvo.Name = "textBox3VrachOtchestvo";
            textBox3VrachOtchestvo.Size = new Size(125, 27);
            textBox3VrachOtchestvo.TabIndex = 10;
            textBox3VrachOtchestvo.TextChanged += textBox3VrachOtchestvo_TextChanged;
            // 
            // textBox2VrachName
            // 
            textBox2VrachName.Location = new Point(956, 202);
            textBox2VrachName.Name = "textBox2VrachName";
            textBox2VrachName.Size = new Size(125, 27);
            textBox2VrachName.TabIndex = 9;
            textBox2VrachName.TextChanged += textBox2VrachName_TextChanged;
            // 
            // textBox1VrachFamilia
            // 
            textBox1VrachFamilia.Location = new Point(811, 202);
            textBox1VrachFamilia.Name = "textBox1VrachFamilia";
            textBox1VrachFamilia.Size = new Size(125, 27);
            textBox1VrachFamilia.TabIndex = 7;
            textBox1VrachFamilia.TextChanged += textBox1VrachFamilia_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(938, 143);
            label1.Name = "label1";
            label1.Size = new Size(162, 20);
            label1.TabIndex = 8;
            label1.Text = "Поля для фильтрации";
            // 
            // button2
            // 
            button2.Location = new Point(811, 312);
            button2.Name = "button2";
            button2.Size = new Size(270, 29);
            button2.TabIndex = 6;
            button2.Text = "Применить фильтр";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // deleteDoctor_Click
            // 
            deleteDoctor_Click.Location = new Point(811, 89);
            deleteDoctor_Click.Name = "deleteDoctor_Click";
            deleteDoctor_Click.Size = new Size(178, 29);
            deleteDoctor_Click.TabIndex = 5;
            deleteDoctor_Click.Text = "Удалить запись";
            deleteDoctor_Click.UseVisualStyleBackColor = true;
            deleteDoctor_Click.Click += deleteDoctor_Click_Click;
            // 
            // button_vrach
            // 
            button_vrach.Location = new Point(811, 35);
            button_vrach.Name = "button_vrach";
            button_vrach.Size = new Size(180, 29);
            button_vrach.TabIndex = 4;
            button_vrach.Text = "Добавить врача";
            button_vrach.UseVisualStyleBackColor = true;
            button_vrach.Click += button_add_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { doctorIdDataGridViewTextBoxColumn, lastNameDataGridViewTextBoxColumn, firstNameDataGridViewTextBoxColumn, middleNameDataGridViewTextBoxColumn, specialtyDataGridViewTextBoxColumn, categoryDataGridViewTextBoxColumn });
            dataGridView1.DataSource = doctorBindingSource;
            dataGridView1.Location = new Point(3, 35);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(802, 400);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // doctorIdDataGridViewTextBoxColumn
            // 
            doctorIdDataGridViewTextBoxColumn.DataPropertyName = "DoctorId";
            doctorIdDataGridViewTextBoxColumn.HeaderText = "ID";
            doctorIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            doctorIdDataGridViewTextBoxColumn.Name = "doctorIdDataGridViewTextBoxColumn";
            doctorIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastNameDataGridViewTextBoxColumn
            // 
            lastNameDataGridViewTextBoxColumn.DataPropertyName = "LastName";
            lastNameDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            lastNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            lastNameDataGridViewTextBoxColumn.Name = "lastNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            firstNameDataGridViewTextBoxColumn.HeaderText = "Имя";
            firstNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            // 
            // middleNameDataGridViewTextBoxColumn
            // 
            middleNameDataGridViewTextBoxColumn.DataPropertyName = "MiddleName";
            middleNameDataGridViewTextBoxColumn.HeaderText = "Отчество";
            middleNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            middleNameDataGridViewTextBoxColumn.Name = "middleNameDataGridViewTextBoxColumn";
            // 
            // specialtyDataGridViewTextBoxColumn
            // 
            specialtyDataGridViewTextBoxColumn.DataPropertyName = "Specialty";
            specialtyDataGridViewTextBoxColumn.HeaderText = "Специальность";
            specialtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            specialtyDataGridViewTextBoxColumn.Name = "specialtyDataGridViewTextBoxColumn";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            categoryDataGridViewTextBoxColumn.HeaderText = "Категория";
            categoryDataGridViewTextBoxColumn.MinimumWidth = 6;
            categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1255, 512);
            tabControl1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1255, 512);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Поликлиника";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)doctorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)patientBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)visitBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userControl1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)form1BindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)userControl1BindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)visitBindingSource1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private BindingSource userControl1BindingSource;
        private BindingSource form1BindingSource;
        private BindingSource userControl1BindingSource1;
        private BindingSource doctorBindingSource;
        private BindingSource patientBindingSource;
        private BindingSource visitBindingSource;
        private Button button1;
        private BindingSource visitBindingSource1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TabPage tabPage3;
        private Button buttonVisitDelete;
        private Label label15;
        private Label label14;
        private TextBox textBoxFilterStoimostDo;
        private TextBox textBoxFilterStoimostOt;
        private Label label13;
        private Label label12;
        private DateTimePicker dateTimePickerFilterVisit;
        private Button buttonClearFilterVisit;
        private Button buttonFilterVisit;
        private Label label12FioPatient;
        private ComboBox comboBoxFioPatient;
        private Label label11;
        private Button buttonRedactorObrashenie;
        private ComboBox comboBox1FioVrach;
        private Button button_obrashenie;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn visitIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn doctorIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn patientIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn visitDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn diagnosisDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn treatmentCostDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn doctorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn patientDataGridViewTextBoxColumn;
        private TabPage tabPage2;
        private Button button3ClearPatientFilter;
        private DateTimePicker dateTimePicker1DateRozdenie;
        private Button button3FilterPatient;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private TextBox textBox1OtchestvoPatient;
        private TextBox textBox1NamePatient;
        private TextBox textBox1FamiliaPatient;
        private Button button3DeletePatient;
        private Button button3RedactorPatient;
        private Button button_pacient;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn patientIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn birthYearDataGridViewTextBoxColumn;
        private TabPage tabPage1;
        private Button button3RedactorVrach;
        private Button buttonClearFilter;
        private ComboBox comboBox2VrachKategory;
        private ComboBox comboBox1VrachSpec;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox3VrachOtchestvo;
        private TextBox textBox2VrachName;
        private TextBox textBox1VrachFamilia;
        private Label label1;
        private Button button2;
        private Button deleteDoctor_Click;
        private Button button_vrach;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn doctorIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lastNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn middleNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn specialtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private TabControl tabControl1;
        private Button buttonWordWithoutTable;
        private Button buttonWordOtchetObrashenie;
    }
}
