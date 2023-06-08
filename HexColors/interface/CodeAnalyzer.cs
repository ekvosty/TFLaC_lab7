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
        private char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        private AnalyzerState AnalyzerState = AnalyzerState.FIRST_SYMBOL;
        private int ColumnCount = 0;
        private int errorCounter = 0;
        private bool hasEndLiteral = false;
        RichTextBox richTextBox;
        bool firstDigit = false;
        private List<char> lexems = new List<char>();


        public CodeAnalyzer(string text, RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            text = text.ToLowerInvariant();
            foreach (char match in text)
            {
                lexems.Add(match);
                ColumnCount++;

                if (AnalyzerState == AnalyzerState.FIRST_SYMBOL) 
                { 
                    if (match != '#')
                    {
                        AppendError("Цвет должен начинаться с #");
                        errorCounter++;
                    }
                    AnalyzerState = AnalyzerState.HEX;
                }
                else
                {
                    if (allowedChars.Contains(match)) 
                    {

                    }
                    else
                    {
                        AppendError("Недопустимый символ");
                        errorCounter++;
                    }
                }
            }
            if (errorCounter == 0)
            {
                if (ColumnCount == 4 || ColumnCount == 7 || ColumnCount == 9)
                {
                    AppendInfo("Цвет написан без ошибок");
                }
                else
                {
                    AppendError("Цвет задан неверно - неверное количество hex-символов");
                    errorCounter++;
                }
            }
            else 
            {
                AppendInfo("Цвет записан с ошибками!");
            }
        }

        private void AppendError(string error = "")
        {
            richTextBox.AppendText($"{error}{", ошибка в позиции "}{ColumnCount}{Environment.NewLine}");
        }

        private void AppendInfo(string info = "")
        {
            richTextBox.AppendText($"{info}{Environment.NewLine}");
        }
    }
}
