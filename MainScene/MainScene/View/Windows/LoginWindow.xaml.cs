﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;
using System.Windows.Data;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MainScene.Util;
using System.Runtime.Serialization.Formatters.Binary;

namespace MainScene.View.Windows
{ 
    /// <summary>
    /// LoginWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoginWindow : Window
    {
        Stopwatch stopWatch;
        public LoginWindow(Stopwatch stopWatch)
        {
            InitializeComponent();
            this.stopWatch = stopWatch;
        }

        private void AccessManager(object sender, RoutedEventArgs e)
        {
            if(idTextBox.Text == "manager" && passwordTextBox.Text == "1234")
            {
                Window win2 = new Adminwindow(stopWatch);
                win2.ShowDialog();
            }
        }
        private void storageSetting()
        {
            FileStream storageStream;
            SaveManager save = new SaveManager(idTextBox.Text);
            storageStream = File.Create(@"C:\saved.localdb");
            BinaryFormatter format = new BinaryFormatter();
            format.Serialize(storageStream, save);
            storageStream.Close();
        }
    }
}
