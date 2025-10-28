namespace orderManagement.Forms;

partial class PeriodSelectorForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        labelFrom = new System.Windows.Forms.Label();
        dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
        labelTo = new System.Windows.Forms.Label();
        dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
        buttonOk = new System.Windows.Forms.Button();
        buttonCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // labelFrom
        // 
        labelFrom.AutoSize = true;
        labelFrom.Location = new System.Drawing.Point(12, 15);
        labelFrom.Name = "labelFrom";
        labelFrom.Size = new System.Drawing.Size(24, 20);
        labelFrom.TabIndex = 0;
        labelFrom.Text = "От";
        // 
        // dateTimePickerFrom
        // 
        dateTimePickerFrom.Location = new System.Drawing.Point(12, 38);
        dateTimePickerFrom.Name = "dateTimePickerFrom";
        dateTimePickerFrom.Size = new System.Drawing.Size(326, 27);
        dateTimePickerFrom.TabIndex = 1;
        dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;
        // 
        // labelTo
        // 
        labelTo.AutoSize = true;
        labelTo.Location = new System.Drawing.Point(12, 78);
        labelTo.Name = "labelTo";
        labelTo.Size = new System.Drawing.Size(28, 20);
        labelTo.TabIndex = 2;
        labelTo.Text = "До";
        // 
        // dateTimePickerTo
        // 
        dateTimePickerTo.Location = new System.Drawing.Point(12, 101);
        dateTimePickerTo.Name = "dateTimePickerTo";
        dateTimePickerTo.Size = new System.Drawing.Size(326, 27);
        dateTimePickerTo.TabIndex = 3;
        dateTimePickerTo.ValueChanged += dateTimePickerTo_ValueChanged;
        // 
        // buttonOk
        // 
        buttonOk.Location = new System.Drawing.Point(12, 148);
        buttonOk.Name = "buttonOk";
        buttonOk.Size = new System.Drawing.Size(150, 32);
        buttonOk.TabIndex = 4;
        buttonOk.Text = "Выбрать";
        buttonOk.UseVisualStyleBackColor = true;
        buttonOk.Click += buttonOk_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        buttonCancel.Location = new System.Drawing.Point(188, 148);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(150, 32);
        buttonCancel.TabIndex = 5;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // PeriodSelectorForm
        // 
        AcceptButton = buttonOk;
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        CancelButton = buttonCancel;
        ClientSize = new System.Drawing.Size(350, 195);
        Controls.Add(buttonCancel);
        Controls.Add(buttonOk);
        Controls.Add(dateTimePickerTo);
        Controls.Add(labelTo);
        Controls.Add(dateTimePickerFrom);
        Controls.Add(labelFrom);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PeriodSelectorForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Выбор периода";
        Load += PeriodSelectorForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label labelFrom;
    private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    private System.Windows.Forms.Label labelTo;
    private System.Windows.Forms.DateTimePicker dateTimePickerTo;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonCancel;
}
