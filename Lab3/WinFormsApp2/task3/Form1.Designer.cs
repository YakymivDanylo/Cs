namespace task3;

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
        this.txtInput = new TextBox();
        this.btnFind = new Button();
        this.lblResult = new Label();
        this.SuspendLayout();

        
        this.txtInput.Location = new System.Drawing.Point(12, 12);
        this.txtInput.Multiline = true;
        this.txtInput.Size = new System.Drawing.Size(260, 100);

        
        this.btnFind.Location = new System.Drawing.Point(12, 120);
        this.btnFind.Size = new System.Drawing.Size(260, 30);
        this.btnFind.Text = "Знайти слова з більш ніж 3 'А'";
        this.btnFind.Click += new EventHandler(this.BtnFind_Click);

        
        this.lblResult.AutoSize = true;
        this.lblResult.Location = new System.Drawing.Point(12, 160);
        this.lblResult.Size = new System.Drawing.Size(260, 20);

        
        this.ClientSize = new System.Drawing.Size(284, 200);
        this.Controls.Add(this.txtInput);
        this.Controls.Add(this.btnFind);
        this.Controls.Add(this.lblResult);
        this.Text = "Пошук слів";

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}