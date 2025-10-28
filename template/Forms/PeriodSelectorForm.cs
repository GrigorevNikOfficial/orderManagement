using System;
using System.Windows.Forms;

namespace Policlinic.Forms
{
    public partial class PeriodSelectorForm : Form
    {
        public DateOnly DateFrom => DateOnly.FromDateTime(dateTimePickerPeriodNachalo.Value.Date);
        public DateOnly DateTo => DateOnly.FromDateTime(dateTimePickerPeriodOkonchanie.Value.Date);

        public PeriodSelectorForm()
        {
            InitializeComponent();
            this.Load += PeriodSelectorForm_Load;
        }

        private void PeriodSelectorForm_Load(object sender, EventArgs e)
        {
            dateTimePickerPeriodNachalo.Value = DateTime.Today.AddDays(-7);
            dateTimePickerPeriodOkonchanie.Value = DateTime.Today;
        }

        private void dateTimePickerPeriodNachalo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerPeriodNachalo.Value > dateTimePickerPeriodOkonchanie.Value)
            {
                MessageBox.Show("Начальная дата не может быть позже конечной.");
                dateTimePickerPeriodNachalo.Value = dateTimePickerPeriodOkonchanie.Value;
            }
        }

        private void dateTimePickerPeriodOkonchanie_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerPeriodOkonchanie.Value < dateTimePickerPeriodNachalo.Value)
            {
                MessageBox.Show("Конечная дата не может быть раньше начальной.");
                dateTimePickerPeriodOkonchanie.Value = dateTimePickerPeriodNachalo.Value;
            }
        }

        private void buttonViborPerioda_Click(object sender, EventArgs e)
        {
            if (dateTimePickerPeriodNachalo.Value > dateTimePickerPeriodOkonchanie.Value)
            {
                MessageBox.Show("Выбранный период некорректен.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonOtmena_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
