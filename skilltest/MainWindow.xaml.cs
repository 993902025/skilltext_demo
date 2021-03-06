﻿using System;
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
        int dmg_val = 0;
        string skill_str;
        int skill_num;
        string key_name = "start";
        Border[] bdr = new Border[30];
        Random r = new Random();
        DispatcherTimer dt1 = new DispatcherTimer();
        DispatcherTimer dt2 = new DispatcherTimer();
        //double deltdt_mil;
        //double deltdt_sec;
        DateTime nowdt;
        Player player1 = new Player();
        Skill skill_1 = new Skill();


        public MainWindow()
        {
            InitializeComponent();


            nowdt = DateTime.Now;
            //detdt = DateTime.Now - DateTime.Now;
            dt1.Interval = TimeSpan.FromMilliseconds(dt_val_1);
            dt1.Tick += new EventHandler(update_play);
            //dt1.Tick += new EventHandler(update_skill);
            dt1.Start();
            this.KeyDown += new KeyEventHandler(keyevent);

            player1.Re_Event += new Action<float>(Play_Re_Event);
            skill_1.Re_Event += new Action<float>(Play_Re_Event);
        }

        private void btn_skill_1_Click(object sender, RoutedEventArgs e)
        {           
                //skill_num = 1;
                do_skill();

        }
        private void do_skill()
        {
            skill_1.skill_1(ref skill_str);
            output_1.Text += skill_str + "\r\n";
        }


        private void output_1_TextChanged(object sender, TextChangedEventArgs e)
        {
            output_1.ScrollToEnd();
        }

        void keyevent(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D1)
            {
                btn_skill_1_Click(this, null);
            }
            if (e.Key == Key.S)
            {
                ifrun = false;
            }
        }
        void update_play(object sender, EventArgs e)
        {
            double deltdt_mil;
            double deltdt_sec;
            TimeSpan dt_up = DateTime.Now - nowdt;

            deltdt_mil = dt_up.Milliseconds;
            //Console.WriteLine(deltdt_mil);
            player1.RestoreMana(deltdt_mil);
            
            
            deltdt_sec = dt_up.TotalSeconds;
            float dt_to_cd = (float)deltdt_sec;
            float re_temp = skill_1.RestoreCD(dt_to_cd);

            nowdt = DateTime.Now;
        }
        

        void Play_Re_Event(float obj)
        {            
            lab_mana.Content = string.Format("{0:N2}", obj);
        }
        void Skill_Re_Event(float obj)
        {
            lab_mana.Content = string.Format("{0:N2}",obj);
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            output_1.Text = null;
        }

        private void btn_skill_2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
