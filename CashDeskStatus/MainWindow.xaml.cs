using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Newtonsoft.Json;

namespace CashDeskStatus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<CashDeskDto> CashDesk { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            
            
            CashDesk = new ObservableCollection<CashDeskDto>();

            CashDesk.Add(new CashDeskDto(){Id = 1,IsOpened = true, Name = "Cash Desk 1",NumberOfPeople = 2, State = CashState.Yellow});
            CashDesk.Add(new CashDeskDto() { Id = 2, IsOpened = true, Name = "Cash Desk 2", NumberOfPeople = 4, State = CashState.Yellow});
            CashDesk.Add(new CashDeskDto() { Id = 3, IsOpened = false, Name = "Cash Desk 3", NumberOfPeople = 0, State = CashState.Green });
            CashDesk.Add(new CashDeskDto() { Id = 4, IsOpened = false, Name = "Cash Desk 4", NumberOfPeople = 0, State = CashState.Green });
            CashDesk.Add(new CashDeskDto() { Id = 5, IsOpened = false, Name = "Cash Desk 5", NumberOfPeople = 0, State = CashState.Green });
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, EventArgs e)
        {

        }

        private void btn_Helper(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;
            if (cmd.DataContext is CashDeskDto)
            {
                CashDeskDto cashDesk = (CashDeskDto)cmd.DataContext;
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
            if (cmd.DataContext is CashDeskDto)
            {
                CashDeskDto cashDesk = (CashDeskDto)cmd.DataContext;
                cashDesk.IsOpened = true;
                
            }
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Button cmd = (Button)sender;

            if (cmd.DataContext is CashDeskDto)
            {
                CashDeskDto cashDesk = (CashDeskDto)cmd.DataContext;
                cashDesk.IsOpened = false;
            }
            
        }
        
    }
}
