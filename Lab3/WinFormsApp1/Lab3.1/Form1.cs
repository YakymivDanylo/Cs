using System;
using System.Linq;
using System.Windows.Forms;

namespace Lab3._1;


public partial class Form1 : Form
{
    private TextBox txtInput;
    private Label lblResult;
    private Button btnCount;

    public Form1()
    {
        InitializeComponent();
    }

    private void btnCount_Click(object sender, EventArgs e)
    {
        string text = txtInput.Text;
        int count = CountWordsStartingWithP(text);
        lblResult.Text = $"Кількість слів, що починаються на 'р': {count}";
    }

    private int CountWordsStartingWithP(string text)
    {
        char[] separators = { ' ', ',', '.', '!', '?', ';', ':', '\n', '\r' };
        return text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Count(word => word.Length > 0 && (word[0] == 'р' || word[0] == 'Р'));
    }
}