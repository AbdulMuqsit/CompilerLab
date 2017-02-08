using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompilerLab.PFN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OperatorPrecendence = Operators.Precedence;
        }
        private Dictionary<char, int> OperatorPrecendence { get; set; }
        public async Task<string> Evaluate(string input)
        {
            return await PFNEngine.ConvertToPNF(input, OperatorPrecendence);
        }

        private async void BtnEvaluate_Click(object sender, RoutedEventArgs e)
        {
            var input = TxtInput.Text;
            TxtOutput.Text = await Evaluate(input);
        }
    }
}
