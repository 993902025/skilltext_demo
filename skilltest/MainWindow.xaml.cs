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
using System.Windows.Threading;

//需要一个角色类，技能类，技能类又不能每个技能建一个类，则需要派生，因此要有个基类，然后每个技能的方法还不同，于是还要考虑重载施放技能的方法；

namespace skilltest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ifrun = true;
        int dt_val_1 = 1;
        Player player1 = new Player();
        
        int dmg_val = 0;
        int skill_num;
        string key_name = "start";
        Border[] bdr = new Border[30];
        Random r = new Random();
        DispatcherTimer dt1 = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();
        double deltdt;
        DateTime nowdt;
        public MainWindow()
        {
            InitializeComponent();
            nowdt = DateTime.Now;
            //detdt = DateTime.Now - DateTime.Now;
            dt1.Interval = TimeSpan.FromMilliseconds(dt_val_1);
            dt1.Tick += new EventHandler(update);
            this.KeyDown += new KeyEventHandler(keyevent);
            dt1.Start();
        }

        private void btn_skill_1_Click(object sender, RoutedEventArgs e)
        {           
                //skill_num = 1;
                do_skill();

        }
        private void do_skill()
        {
            if (0 == player1.skill_1(ref dmg_val))
            {
                output_1.Text += dmg_val.ToString() + "\r\n";
                player1.mana -= player1.mana - player1.skill_1_mana;
            }
            else if (-1 == player1.skill_1(ref dmg_val))
            {
                output_1.Text += string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "技能CD中！" + "\r\n";
            }
            else if (-2 == player1.skill_1(ref dmg_val))
            {
                output_1.Text += string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "魔法不足！" + "\r\n";
            }
            else if (-3 == player1.skill_1(ref dmg_val))
            {
                output_1.Text += string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + "当前状态无法施法！" + "\r\n";
            }
        }


        private void output_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            output_1.ScrollToEnd();
        }

        void keyevent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                btn_skill_1_Click(this, null);
            }
            if (e.Key == Key.S)
            {
                ifrun = false;
            }
        }
        void update(object sender, EventArgs e)
        {
            if (ifrun == true)
            {
                deltdt = (DateTime.Now - nowdt).TotalMilliseconds;
                if (deltdt >= 500)
                {
                    if (player1.mana < 100)
                    {
                        player1.mana +=  1;
                    }
                    nowdt = DateTime.Now;
                    output_1.Text += string.Format("[{0:HH:MM:ss.fff}]: ", DateTime.Now) + deltdt + "\r\n";
                }
            }

            lab_mana.Content = player1.mana.ToString();

        }


    }
}
