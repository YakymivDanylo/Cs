namespace Lab3._1;

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
        this.txtInput = new System.Windows.Forms.TextBox();
        this.btnCount = new System.Windows.Forms.Button();
        this.lblResult = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        // TextBox
        this.txtInput.Location = new System.Drawing.Point(12, 12);
        this.txtInput.Multiline = true;
        this.txtInput.Size = new System.Drawing.Size(260, 100);
        
        // Button
        this.btnCount.Location = new System.Drawing.Point(12, 120);
        this.btnCount.Size = new System.Drawing.Size(260, 30);
        this.btnCount.Text = "Підрахувати";
        this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
    
        // Label
        this.lblResult.AutoSize = true;
        this.lblResult.Location = new System.Drawing.Point(12, 160);
        this.lblResult.Size = new System.Drawing.Size(260, 20);
    
        // Form
        this.ClientSize = new System.Drawing.Size(284, 200);
        this.Controls.Add(this.txtInput);
        this.Controls.Add(this.btnCount);
        this.Controls.Add(this.lblResult);
        this.Text = "Аналізатор тексту";
    
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}