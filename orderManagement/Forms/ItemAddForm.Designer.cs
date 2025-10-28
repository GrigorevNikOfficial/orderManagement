namespace orderManagement.Forms;

partial class ItemAddForm
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
        labelDescription = new System.Windows.Forms.Label();
        textBoxDescription = new System.Windows.Forms.TextBox();
        labelPrice = new System.Windows.Forms.Label();
        numericPrice = new System.Windows.Forms.NumericUpDown();
        checkBoxDelivery = new System.Windows.Forms.CheckBox();
        buttonSave = new System.Windows.Forms.Button();
        buttonCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)numericPrice).BeginInit();
        SuspendLayout();
        // 
        // labelDescription
        // 
        labelDescription.AutoSize = true;
        labelDescription.Location = new System.Drawing.Point(12, 15);
        labelDescription.Name = "labelDescription";
        labelDescription.Size = new System.Drawing.Size(83, 20);
        labelDescription.TabIndex = 0;
        labelDescription.Text = "Описание";
        // 
        // textBoxDescription
        // 
        textBoxDescription.Location = new System.Drawing.Point(12, 38);
        textBoxDescription.Multiline = true;
        textBoxDescription.Name = "textBoxDescription";
        textBoxDescription.Size = new System.Drawing.Size(360, 96);
        textBoxDescription.TabIndex = 1;
        // 
        // labelPrice
        // 
        labelPrice.AutoSize = true;
        labelPrice.Location = new System.Drawing.Point(12, 146);
        labelPrice.Name = "labelPrice";
        labelPrice.Size = new System.Drawing.Size(37, 20);
        labelPrice.TabIndex = 2;
        labelPrice.Text = "Цена";
        // 
        // numericPrice
        // 
        numericPrice.Location = new System.Drawing.Point(12, 169);
        numericPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numericPrice.Name = "numericPrice";
        numericPrice.Size = new System.Drawing.Size(180, 27);
        numericPrice.TabIndex = 3;
        // 
        // checkBoxDelivery
        // 
        checkBoxDelivery.AutoSize = true;
        checkBoxDelivery.Location = new System.Drawing.Point(12, 212);
        checkBoxDelivery.Name = "checkBoxDelivery";
        checkBoxDelivery.Size = new System.Drawing.Size(97, 24);
        checkBoxDelivery.TabIndex = 4;
        checkBoxDelivery.Text = "Доставка";
        checkBoxDelivery.UseVisualStyleBackColor = true;
        // 
        // buttonSave
        // 
        buttonSave.Location = new System.Drawing.Point(12, 254);
        buttonSave.Name = "buttonSave";
        buttonSave.Size = new System.Drawing.Size(172, 32);
        buttonSave.TabIndex = 5;
        buttonSave.Text = "Сохранить";
        buttonSave.UseVisualStyleBackColor = true;
        buttonSave.Click += buttonSave_Click;
        // 
        // buttonCancel
        // 
        buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        buttonCancel.Location = new System.Drawing.Point(200, 254);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(172, 32);
        buttonCancel.TabIndex = 6;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // ItemAddForm
        // 
        AcceptButton = buttonSave;
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        CancelButton = buttonCancel;
        ClientSize = new System.Drawing.Size(386, 303);
        Controls.Add(buttonCancel);
        Controls.Add(buttonSave);
        Controls.Add(checkBoxDelivery);
        Controls.Add(numericPrice);
        Controls.Add(labelPrice);
        Controls.Add(textBoxDescription);
        Controls.Add(labelDescription);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ItemAddForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Добавить товар";
        ((System.ComponentModel.ISupportInitialize)numericPrice).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label labelDescription;
    private System.Windows.Forms.TextBox textBoxDescription;
    private System.Windows.Forms.Label labelPrice;
    private System.Windows.Forms.NumericUpDown numericPrice;
    private System.Windows.Forms.CheckBox checkBoxDelivery;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonCancel;
}
