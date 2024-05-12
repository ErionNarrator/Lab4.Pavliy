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
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для AddMonster.xaml
    /// </summary>
    public partial class AddMonster : Window
    {
        public AddMonster()
        {
            InitializeComponent();
        }
        public int ID
        {
            get
            {
                return int.Parse(tbID.Text);
            }
            set
            {
                tbID.Text = value.ToString();
            }
        }
        public string? Name
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }
        public int Health
        {
            get
            {
                return int.Parse(tbHealth.Text);
            }
            set
            {
                tbHealth.Text = value.ToString();
            }
        }
        public int Ammo
        {
            get
            {
                return int.Parse(tbAmmo.Text);
            }
            set
            {
                tbAmmo.Text = value.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
