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
using CompilerLab.PFN;
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
            OperatorProperties = new OperatorProperties();

        }
        private PFNEngine PFNEngine { get; } = new PFNEngine();
        private OperatorProperties OperatorProperties { get; }
        //public async Task<string> Evaluate(string input)
        //{
        //    return await PFNEngine.ConvertToPFNString(input, OperatorProperties.Precedence);
        //}

        //private async void BtnEvaluate_Click(object sender, RoutedEventArgs e)
        //{
        //    var input = TxtBoxInput.Text;
        //    TxtBlkOutput.Text = await Evaluate(input);
        //}

        //private void TxtInput_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    TxtBlkError.Visibility = Visibility.Collapsed;
        //    //arrow keys, backspace and enter
        //    if (e.Key == Key.Enter || e.Key == Key.Delete || e.Key == Key.Back || e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
        //    {
        //        return;
        //    }
        //    //a new expression starting with a digit
        //    else if (String.IsNullOrEmpty(TxtBoxInput.Text) && e.Key >= Key.D0 && e.Key <= Key.D9)
        //    {
        //        return;
        //    }
        //    //
        //    else if (!String.IsNullOrEmpty(TxtBoxInput.Text))
        //    {
        //        if (OperatorProperties.OperatorsList.Contains(TxtBoxInput.Text.Last()) && ((e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)))
        //        {
        //            return;
        //        }
        //        else if (OperatorProperties.OperatorsList.Contains(TxtBoxInput.Text.Last()) && (e.Key == Key.Add || e.Key == Key.Divide || e.Key == Key.Multiply || e.Key == Key.Subtract))
        //        {
        //            TxtBlkError.Visibility = Visibility.Visible;
        //            TxtBlkError.Text = "Two consecutive operators are not valid. Please insert a digit.";
        //        }
        //        else if ((TxtBoxInput.Text != string.Empty && char.IsDigit(TxtBoxInput.Text.Last())) && (e.Key >= Key.D0 && e.Key <= Key.D9))
        //        {
        //            TxtBlkError.Visibility = Visibility.Visible;
        //            TxtBlkError.Text = "Only single digit integers are allowed, Please insert an operator now.";
        //        }
        //        else if (TxtBoxInput.Text != string.Empty && OperatorProperties.OperatorsList.Contains(TxtBoxInput.Text.Last()) && (e.Key == Key.Add || e.Key == Key.Divide || e.Key == Key.Multiply || e.Key == Key.Subtract))
        //        {
        //            TxtBlkError.Visibility = Visibility.Visible;
        //            TxtBlkError.Text = "Two consecutive operators are not valid. Please insert a digit.";
        //        }
        //        else if (TxtBoxInput.Text == string.Empty && (e.Key == Key.Add || e.Key == Key.Divide || e.Key == Key.Multiply || e.Key == Key.Subtract))
        //        {
        //            TxtBlkError.Visibility = Visibility.Visible;
        //            TxtBlkError.Text = "Expression can not start with an operator, please enter a digit.";
        //        }

        //    }
        //    else
        //    {
        //        TxtBlkError.Visibility = Visibility.Visible;
        //        TxtBlkError.Text = "Alphabets and special characters are not allowed.";
        //    }
        //    e.Handled = true;
        //}
    }
}
