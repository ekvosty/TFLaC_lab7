using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace @interface
{
    internal class CodeAnalyzer
    {
        string pattern = @"0(0|1)*0";
        private int ColumnCount = 0;
        RichTextBox richTextBox;


        public CodeAnalyzer(string text, RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            richTextBox.ResetText();
            if (Regex.IsMatch(text, pattern))
            {
                AppendInfo("Введенные данные подходят под регулярное выражение");
            }
            else 
            {
                AppendInfo("Введенные данные не подходят под регулярное выражение");
            }
        }

        private void AppendInfo(string info = "")
        {
            richTextBox.AppendText($"{info}{Environment.NewLine}");
        }
    }
}
