namespace orderManagement.Forms;

partial class CustomerAddForm
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
        labelName = new System.Windows.Forms.Label();
        textBoxName = new System.Windows.Forms.TextBox();
        labelContact = new System.Windows.Forms.Label();
        textBoxContact = new System.Windows.Forms.TextBox();
        labelPhone = new System.Windows.Forms.Label();
        textBoxPhone = new System.Windows.Forms.TextBox();
        labelAddress = new System.Windows.Forms.Label();
        textBoxAddress = new System.Windows.Forms.TextBox();
        buttonSave = new System.Windows.Forms.Button();
        buttonCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // labelName
        // 
        labelName.AutoSize = true;
        labelName.Location = new System.Drawing.Point(12, 15);
        labelName.Name = "labelName";
        labelName.Size = new System.Drawing.Size(73, 20);
        labelName.TabIndex = 0;
        labelName.Text = "Название";
        // 
        // textBoxName
        // 
        textBoxName.Location = new System.Drawing.Point(12, 38);
        textBoxName.Name = "textBoxName";
        textBoxName.Size = new System.Drawing.Size(360, 27);
        textBoxName.TabIndex = 1;
        // 
        // labelContact
        // 
        labelContact.AutoSize = true;
        labelContact.Location = new System.Drawing.Point(12, 78);
        labelContact.Name = "labelContact";
        labelContact.Size = new System.Drawing.Size(114, 20);
        labelContact.TabIndex = 2;
        labelContact.Text = "Контактное лицо";
        // 
        // textBoxContact
        // 
        textBoxContact.Location = new System.Drawing.Point(12, 101);
        textBoxContact.Name = "textBoxContact";
        textBoxContact.Size = new System.Drawing.Size(360, 27);
        textBoxContact.TabIndex = 3;
        // 
        // labelPhone
        // 
        labelPhone.AutoSize = true;
        labelPhone.Location = new System.Drawing.Point(12, 141);
        labelPhone.Name = "labelPhone";
        labelPhone.Size = new System.Drawing.Size(62, 20);
        labelPhone.TabIndex = 4;
        labelPhone.Text = "Телефон";
        // 
        // textBoxPhone
        // 
        textBoxPhone.Location = new System.Drawing.Point(12, 164);
        textBoxPhone.Name = "textBoxPhone";
        textBoxPhone.Size = new System.Drawing.Size(360, 27);
        textBoxPhone.TabIndex = 5;
        // 
        // labelAddress
        // 
        labelAddress.AutoSize = true;
        labelAddress.Location = new System.Drawing.Point(12, 204);
        labelAddress.Name = "labelAddress";
        labelAddress.Size = new System.Drawing.Size(50, 20);
        labelAddress.TabIndex = 6;
        labelAddress.Text = "Адрес";
        // 
        // textBoxAddress
        // 
        textBoxAddress.Location = new System.Drawing.Point(12, 227);
        textBoxAddress.Multiline = true;
        textBoxAddress.Name = "textBoxAddress";
        textBoxAddress.Size = new System.Drawing.Size(360, 80);
        textBoxAddress.TabIndex = 7;
        // 
        // buttonSave
        // 
        buttonSave.Location = new System.Drawing.Point(12, 323);
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
        buttonCancel.Location = new System.Drawing.Point(200, 323);
        buttonCancel.Name = "buttonCancel";
        buttonCancel.Size = new System.Drawing.Size(172, 32);
        buttonCancel.TabIndex = 9;
        buttonCancel.Text = "Отмена";
        buttonCancel.UseVisualStyleBackColor = true;
        buttonCancel.Click += buttonCancel_Click;
        // 
        // CustomerAddForm
        // 
        AcceptButton = buttonSave;
        AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        CancelButton = buttonCancel;
        ClientSize = new System.Drawing.Size(386, 371);
        Controls.Add(buttonCancel);
        Controls.Add(buttonSave);
        Controls.Add(textBoxAddress);
        Controls.Add(labelAddress);
        Controls.Add(textBoxPhone);
        Controls.Add(labelPhone);
        Controls.Add(textBoxContact);
        Controls.Add(labelContact);
        Controls.Add(textBoxName);
        Controls.Add(labelName);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "CustomerAddForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Добавить клиента";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox textBoxName;
    private System.Windows.Forms.Label labelContact;
    private System.Windows.Forms.TextBox textBoxContact;
    private System.Windows.Forms.Label labelPhone;
    private System.Windows.Forms.TextBox textBoxPhone;
    private System.Windows.Forms.Label labelAddress;
    private System.Windows.Forms.TextBox textBoxAddress;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.Button buttonCancel;
}
