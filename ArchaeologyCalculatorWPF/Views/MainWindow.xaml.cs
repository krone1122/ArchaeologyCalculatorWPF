using ArchaeologyCalculatorWPF.Models;
using ArchaeologyCalculatorWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ArchaeologyCalculatorWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal MainWindowViewModel _mainWindowViewModel;
        private int currentNumericValue = 26;


        public MainWindow()
        {
            InitializeComponent();
            _mainWindowViewModel = new();

            DataContext = _mainWindowViewModel;
            SetNumericText();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgMaterials.ItemsSource = _mainWindowViewModel.Artifact?.Materials;
        }

        private void Compute_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ComputeResults(GetNumericValue());
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ClearScreen();

            currentNumericValue = 26;
            SetNumericText();
        }

        private void NumDownButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumericValue--;
            SetNumericText();
        }

        private void NumUpButton_Click(object sender, RoutedEventArgs e)
        {
            currentNumericValue++;
            SetNumericText();
        }

        private void SetNumericText()
        {
            txtNumeric.Text = currentNumericValue.ToString();
        }

        private int GetNumericValue()
        {
            return int.Parse(txtNumeric.Text);
        }
    }
}
