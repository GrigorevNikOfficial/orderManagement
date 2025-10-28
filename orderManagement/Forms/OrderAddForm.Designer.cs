namespace orderManagement.Forms;

partial class OrderAddForm
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
        labelCustomer = new System.Windows.Forms.Label();
        comboBoxCustomer = new System.Windows.Forms.ComboBox();
        labelItem = new System.Windows.Forms.Label();
        comboBoxItem = new System.Windows.Forms.ComboBox();
        labelQuantity = new System.Windows.Forms.Label();
        numericQuantity = new System.Windows.Forms.NumericUpDown();
        labelDate = new System.Windows.Forms.Label();
        dateTimePickerOrderDate = new System.Windows.Forms.DateTimePicker();
        buttonSave = new System.Windows.Forms.Button();
        buttonCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numericQuantity).BeginInit();
        SuspendLayout();
        // 
        // labelCustomer
        // 
        labelCustomer.AutoSize = true;
        labelCustomer.Location = new System.Drawing.Point(12, 15);
        labelCustomer.Name = "labelCustomer";
        labelCustomer.Size = new System.Drawing.Size(61, 20);
        labelCustomer.TabIndex = 0;
        labelCustomer.Text = "Клиент";
        // 
        // comboBoxCustomer
        // 
        comboBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxCustomer.FormattingEnabled = true;
        comboBoxCustomer.Location = new System.Drawing.Point(12, 38);
        comboBoxCustomer.Name = "comboBoxCustomer";
        comboBoxCustomer.Size = new System.Drawing.Size(360, 28);
        comboBoxCustomer.TabIndex = 1;
        // 
        // labelItem
        // 
        labelItem.AutoSize = true;
        labelItem.Location = new System.Drawing.Point(12, 78);
        labelItem.Name = "labelItem";
        labelItem.Size = new System.Drawing.Size(47, 20);
        labelItem.TabIndex = 2;
        labelItem.Text = "Товар";
        // 
        // comboBoxItem
        // 
        comboBoxItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxItem.FormattingEnabled = true;
        comboBoxItem.Location = new System.Drawing.Point(12, 101);
        comboBoxItem.Name = "comboBoxItem";
        comboBoxItem.Size = new System.Drawing.Size(360, 28);
        comboBoxItem.TabIndex = 3;
        // 
        // labelQuantity
        // 
        labelQuantity.AutoSize = true;
        labelQuantity.Location = new System.Drawing.Point(12, 141);
        labelQuantity.Name = "labelQuantity";
        labelQuantity.Size = new System.Drawing.Size(82, 20);
        labelQuantity.TabIndex = 4;
        labelQuantity.Text = "Количество";
        // 
        // numericQuantity
        // 
        numericQuantity.Location = new System.Drawing.Point(12, 164);
        numericQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numericQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericQuantity.Name = "numericQuantity";
        numericQuantity.Size = new System.Drawing.Size(180, 27);
        numericQuantity.TabIndex = 5;
        numericQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // labelDate
        // 
        labelDate.AutoSize = true;
        labelDate.Location = new System.Drawing.Point(12, 204);
        labelDate.Name = "labelDate";
        labelDate.Size = new System.Drawing.Size(94, 20);
        labelDate.TabIndex = 6;
        labelDate.Text = "Дата заказа";
        // 
        // dateTimePickerOrderDate
        // 
        dateTimePickerOrderDate.Location = new System.Drawing.Point(12, 227);
        dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
        dateTimePickerOrderDate.Size = new System.Drawing.Size(360, 27);
        dateTimePickerOrderDate.TabIndex = 7;
        // 
        // buttonSave
        // 
        buttonSave.Location = new System.Drawing.Point(12, 274);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new System.Drawing.Size(172, 32);
        buttonSave.TabIndex = 8;
        buttonSave.Text = "Сохранить";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        buttonCancel.Location = new System.Drawing.Point(200, 274);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(172, 32);
        buttonCancel.TabIndex = 9;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // OrderAddForm
        // 
        AcceptButton = buttonSave;
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        CancelButton = buttonCancel;
        ClientSize = new System.Drawing.Size(386, 323);
        Controls.Add(buttonCancel);
        Controls.Add(buttonSave);
        Controls.Add(dateTimePickerOrderDate);
        Controls.Add(labelDate);
        Controls.Add(numericQuantity);
        Controls.Add(labelQuantity);
        Controls.Add(comboBoxItem);
        Controls.Add(labelItem);
        Controls.Add(comboBoxCustomer);
        Controls.Add(labelCustomer);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "OrderAddForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Добавить заказ";
        Load += OrderAddForm_Load;
        ((System.ComponentModel.ISupportInitialize)numericQuantity).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label labelCustomer;
    private System.Windows.Forms.ComboBox comboBoxCustomer;
    private System.Windows.Forms.Label labelItem;
    private System.Windows.Forms.ComboBox comboBoxItem;
    private System.Windows.Forms.Label labelQuantity;
    private System.Windows.Forms.NumericUpDown numericQuantity;
    private System.Windows.Forms.Label labelDate;
    private System.Windows.Forms.DateTimePicker dateTimePickerOrderDate;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonCancel;
}
