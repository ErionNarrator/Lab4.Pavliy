using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Monster<int>[]? Monsters { get; set; } = null;
        private bool isAmmoSort = true;
        private bool isHealthSort = true;
        public MainWindow()
        {
            InitializeComponent();
            mmCopy.IsEnabled = false;
            mmCreate.IsEnabled = false;
            tbCreate.IsEnabled = false;
            tbCopy.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbCount.Text.Length != 0)
            {
                Monsters = null;
                Monsters = new Monster<int>[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + Monsters.Length + " элемента создан");
                Monster<int>.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                monsterList.ItemsSource = null;
                stCount.Content = "Создано " + Monster<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void mmCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }
        void GridViewColumnHeaderClickedHandler(object sender,
                                        RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if(headerClicked!.Content.ToString()=="Здоровье")
            {
                if (isHealthSort)
                {
                    Array.Sort(Monsters!);
                }
                else
                {
                    Monsters=Monsters!.OrderByDescending(p => p.Health).ToArray();
                }
                isHealthSort = !isHealthSort;
            }   
            else if(headerClicked.Content.ToString() == "Патроны")
            {
                if (isAmmoSort)
                {
                    Array.Sort(Monsters!, new AmmoComparator());    
                }
                else
                {
                    Monsters = Monsters!.OrderByDescending(p => p.Ammo).ToArray();
                }
                isAmmoSort = !isAmmoSort;
            }
            monsterList.ItemsSource = null;
            monsterList.ItemsSource = Monsters;
        }

        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Copy()
        {
            if (monsterList.SelectedItems.Count != 0)
            {
                Monster<int>? monster = monsterList.SelectedItem as Monster<int>;
                Monsters![Monster<int>.Count] = (Monster<int>)monster!.Clone();
                monsterList.ItemsSource = null;
                monsterList.ItemsSource = Monsters;
                Monster<int>.Count++;
                stCount.Content = "Создано " + Monster<int>.Count + " из " + tbCount.Text;
            }
        }
        private void Add()
        {
            if (Monsters!.Length > Monster<int>.Count)
            {
                AddMonster add = new AddMonster();
                if (add.ShowDialog() == true)
                {
                    Monsters[Monster<int>.Count] = new Monster<int>();
                    Monsters[Monster<int>.Count].Id = add.ID;
                    Monsters[Monster<int>.Count].Name = add.Name;
                    Monsters[Monster<int>.Count].Health = add.Health;
                    Monsters[Monster<int>.Count].Ammo = add.Ammo;
                    Monster<int>.Count++;
                }
                monsterList.ItemsSource = null;
                monsterList.ItemsSource = Monsters;
                stCount.Content = "Создано " + Monster<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }
}