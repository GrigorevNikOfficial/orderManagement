using System;
using System.Windows.Forms;

namespace orderManagement.Forms;

public partial class PeriodSelectorForm : Form
{
    public DateOnly DateFrom => DateOnly.FromDateTime(dateTimePickerFrom.Value.Date);
    public DateOnly DateTo => DateOnly.FromDateTime(dateTimePickerTo.Value.Date);

    private bool isInitialized;

    public PeriodSelectorForm()
    {
        InitializeComponent();
    }

    private void PeriodSelectorForm_Load(object? sender, EventArgs e)
    {
        isInitialized = false;
        dateTimePickerTo.Value = DateTime.Today;
        dateTimePickerFrom.Value = DateTime.Today.AddDays(-7);
        isInitialized = true;
    }

    private void dateTimePickerFrom_ValueChanged(object? sender, EventArgs e)
    {
        if (!isInitialized)
        {
            return;
        }

        if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
        {
            MessageBox.Show("Начальная дата не может быть позже конечной.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dateTimePickerFrom.Value = dateTimePickerTo.Value;
        }
    }

    private void dateTimePickerTo_ValueChanged(object? sender, EventArgs e)
    {
        if (!isInitialized)
        {
            return;
        }

        if (dateTimePickerTo.Value < dateTimePickerFrom.Value)
        {
            MessageBox.Show("Конечная дата не может быть раньше начальной.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dateTimePickerTo.Value = dateTimePickerFrom.Value;
        }
    }

    private void buttonOk_Click(object? sender, EventArgs e)
    {
        if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
        {
            MessageBox.Show("Выбранный период некорректен.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    private void buttonCancel_Click(object? sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
