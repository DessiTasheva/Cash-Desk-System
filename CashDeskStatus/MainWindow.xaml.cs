using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CashDeskStatus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            
        }

        /*private void btn_Helper(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            if (cmd.DataContext is CashDesks)
            {
                CashDesks cashDesk = (CashDesks)cmd.DataContext;
                cashDesk.NumberOfPeople += 1;
                if (cashDesk.NumberOfPeople >= 0 && cashDesk.NumberOfPeople < 2)
                {
                    cashDesk.State = CashState.Green;
                }
                else if (cashDesk.NumberOfPeople >= 2 && cashDesk.NumberOfPeople < 5)
                {
                    cashDesk.State = CashState.Yellow;
                }
                else
                {
                    cashDesk.State = CashState.Red;
                }
            }
        }

        
        private void OpenButton_Click(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            if (cmd.DataContext is CashDesks)
            {
                CashDesks cashDesk = (CashDesks)cmd.DataContext;
                cashDesk.IsOpened = true;
                
            }
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;

            if (cmd.DataContext is CashDesks)
            {
                CashDesks cashDesk = (CashDesks)cmd.DataContext;
                cashDesk.IsOpened = false;
            }
            
        }*/
        
    }
}
