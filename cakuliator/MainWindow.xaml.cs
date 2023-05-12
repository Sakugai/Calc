using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace cakuliator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Desc;
        public double pera;
        public double perb;
        public double perc;
        public double x1;
        public double x2;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }



        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9] ");
            return reg.IsMatch(str);

        }

        private void Answer_btn_Click(object sender, RoutedEventArgs e)
        {
            Okna.AnswerWin answerWin= new Okna.AnswerWin();
            answerWin.Show();
            Close();
        }

        private void History_btn_Click(object sender, RoutedEventArgs e)
        {
            Okna.HistoryWin historyWin= new Okna.HistoryWin();
            historyWin.Show();
            Close();
        }

        private void TapeDan_btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы находитесь в данном окне");
        }

        private void Result_btn_Click(object sender, RoutedEventArgs e)
        {

            if (PerA_tb != null & PerB_tb != null & PerC_tb != null)
            {
                pera = Convert.ToInt32(PerA_tb.Text);
                perb = Convert.ToInt32(PerB_tb.Text);
                perc = Convert.ToInt32(PerC_tb.Text);

                PermA_txbl.Text = Convert.ToString(PerA_tb.Text);
                PermB_txbl.Text = Convert.ToString(PerB_tb.Text);
                PermC_txbl.Text = Convert.ToString(PerC_tb.Text);

                if (perc > 0)
                {
                    Desc = (perb * perb - 4 * pera * perc);
                }
                else
                {
                    Desc = (perb * perb + 4 * pera * perc);
                }
                if (Desc > 0)
                {
                    x1 = (-perb - Convert.ToInt32(Math.Sqrt(Desc)))/(2*pera);
                    x2 = (-perb + Convert.ToInt32(Math.Sqrt(Desc)))/(2*pera);
                } 
                else if (Desc == 0)
                {
                    x1 = -perb/(2*pera);
                }
                
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
