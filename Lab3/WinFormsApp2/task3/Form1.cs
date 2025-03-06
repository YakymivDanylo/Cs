using System.Text.RegularExpressions;

namespace task3;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private TextBox txtInput;  
    private Button btnFind;    
    private Label lblResult;  
    private void BtnFind_Click(object sender, EventArgs e)
    {
        string text = txtInput.Text;
        var result = FindWordsWithMoreThanThreeA(text);
        lblResult.Text = result;
    }

    private string FindWordsWithMoreThanThreeA(string text)
    {
        
        var words = Regex.Split(text, @"\W+");
        var wordsWithMoreThanThreeA = words.Where(word => CountLetterA(word) > 3).ToList();

        
        if (wordsWithMoreThanThreeA.Count > 0)
        {
            return string.Join(", ", wordsWithMoreThanThreeA);
        }
        else
        {
            return "Немає слів, у яких буква 'А' зустрічається більше трьох разів.";
        }
    }

    
    private int CountLetterA(string word)
    {
        return word.Count(c => c == 'а' || c == 'А');
    }
}