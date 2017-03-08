using CompilerLab.DesktopApplication.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompilerLab.DesktopApplication.ViewModels
{
    public class RegexExamplesViewModel : ViewModelBase
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                if (_text == value)
                {
                    return;
                }
                OnPropertyChanged();
            }
        }
        private string _parsedText;

        public string ParsedText
        {
            get { return _parsedText; }
            set
            {
                if (_parsedText == value)
                {
                    return;
                }
                _parsedText = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RemoveWhitespaceCommand { get; set; }
        public RegexExamplesViewModel()
        {
            RemoveWhitespaceCommand = new RelayCommand(ExecuteRemoveWhitespaceCommand, (obj) => !String.IsNullOrWhiteSpace(Text));
        }

        private async void ExecuteRemoveWhitespaceCommand(object obj)
        {
            await Task.Run(() =>
            {

                StringBuilder builder = new StringBuilder();
                int previousIndex = 0;
                var matches = Regex.Matches(Text, @"\s{2,}");
                foreach (Match match in matches)
                {
                    builder.Append(Text.Substring(previousIndex, match.Index - previousIndex));
                    builder.Append(" ");
                    previousIndex = match.Index + match.Length;
                }
                builder.Append(Text.Substring(previousIndex, Text.Length - previousIndex));
                ParsedText = builder.ToString();
            });

        }
    }
}
