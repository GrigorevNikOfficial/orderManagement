namespace orderManagement;

partial class MainForm
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dataGridView1 = new System.Windows.Forms.DataGridView();
        dataGridView2 = new System.Windows.Forms.DataGridView();
        dataGridView3 = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.Location = new System.Drawing.Point(27, 29);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new System.Drawing.Size(402, 184);
        dataGridView1.TabIndex = 0;
        // 
        // dataGridView2
        // 
        dataGridView2.Location = new System.Drawing.Point(27, 219);
        dataGridView2.Name = "dataGridView2";
        dataGridView2.Size = new System.Drawing.Size(402, 184);
        dataGridView2.TabIndex = 1;
        // 
        // dataGridView3
        // 
        dataGridView3.Location = new System.Drawing.Point(27, 409);
        dataGridView3.Name = "dataGridView3";
        dataGridView3.Size = new System.Drawing.Size(402, 184);
        dataGridView3.TabIndex = 2;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 620);
        Controls.Add(dataGridView3);
        Controls.Add(dataGridView2);
        Controls.Add(dataGridView1);
        Text = "MainForm";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.DataGridView dataGridView3;

    private System.Windows.Forms.DataGridView dataGridView2;

    private System.Windows.Forms.DataGridView dataGridView1;

    #endregion
}