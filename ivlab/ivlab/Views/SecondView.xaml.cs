using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using ivlab.Core.Models;
using ivlab.Core.ViewModels;
using ivlab.Services;

namespace ivlab.Views
{
    /// <summary>
    /// Interaction logic for SecondView.xaml
    /// </summary>
    public partial class SecondView
    {
        public SecondView()
        {
            InitializeComponent();
        }

        protected DispatcherTimer DispatcherTimer;
        private void SetTimer(int timer)
        {
            DispatcherTimer = new DispatcherTimer();
            DispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //TODO: Change timer later
#if DEBUG
            DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 5);
#else
                DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 10);
#endif

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var vm = ViewModel as SecondViewModel;
            vm?.GetData();


            //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            //Int32 unixTickTimestamp = (Int32)(TickTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            double result = TickTime.Subtract(DateTime.UtcNow).TotalSeconds;
            double percentResult = result / int.Parse(secText.Text);
            pbStatus.Value = 100 - (percentResult * 100);


            if (DateTime.UtcNow >= TickTime)
            {
                DispatcherTimer.Stop();
                timercontrol.IsEnabled = true;
                slValue.IsEnabled = true;
                secText.IsEnabled = true;
                seriesCheck.IsEnabled = true;


              
                ExportToExcel exportToExcel = new ExportToExcel();
                bool outResult;
                exportToExcel.ExportData(vm?.RootRefObjects, seriesChecklist, out outResult);

                if (outResult)
                {
                    StopExport.IsEnabled = false;
                    Export.IsEnabled = true;
                    secText.IsEnabled = true;
                    timercontrol.IsEnabled = true;
                    seriesCheck.IsEnabled = true;
                    progressArea.IsEnabled = false;
                    pbStatus.Value = 0;
                    MessageBox.Show("Success!!! Please check your Drive C");
                }
                else
                {
                    MessageBox.Show("Something went wrong! Please check your Microsoft Office installed?");
                    StopExport.IsEnabled = false;
                    Export.IsEnabled = true;
                    timercontrol.IsEnabled = true;
                    secText.IsEnabled = true;
                    seriesCheck.IsEnabled = true;
                    progressArea.IsEnabled = false;
                    pbStatus.Value = 0;
                }
            }
        }
        public DateTime TickTime { get; set; }

        protected List<bool> seriesChecklist;
        private void Export_Click(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as SecondViewModel;
            TickTime = DateTime.UtcNow.AddSeconds(int.Parse(secText.Text));
            progressArea.IsEnabled = true;
            Export.IsEnabled = false;
            timercontrol.IsEnabled = false;
            secText.IsEnabled = false;
            seriesChecklist = new List<bool>();
           
            if (Regex.IsMatch(secText.Text, @"\d"))
            {
                SetTimer(int.Parse(secText.Text));
                seriesCheck.IsEnabled = false;
                seriesChecklist.Add(t1C.IsChecked != null && t1C.IsChecked.Value);
                seriesChecklist.Add(t2C.IsChecked != null && t2C.IsChecked.Value);
                seriesChecklist.Add(t3C.IsChecked != null && t3C.IsChecked.Value);
                seriesChecklist.Add(p1C.IsChecked != null && p1C.IsChecked.Value);
                seriesChecklist.Add(p2C.IsChecked != null && p2C.IsChecked.Value);
                seriesChecklist.Add(p3C.IsChecked != null && p3C.IsChecked.Value);
                seriesChecklist.Add(a1C.IsChecked != null && a1C.IsChecked.Value);
                seriesChecklist.Add(a2C.IsChecked != null && a2C.IsChecked.Value);
                seriesChecklist.Add(a3C.IsChecked != null && a3C.IsChecked.Value);
                seriesChecklist.Add(g1C.IsChecked != null && g1C.IsChecked.Value);
                seriesChecklist.Add(g2C.IsChecked != null && g2C.IsChecked.Value);

                if (vm?.RootRefObjects.Count > 0)
                {
                    var messageBoxResult =
                        System.Windows.MessageBox.Show("Do you want to create new Data? Existing Data has found!",
                            "Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        vm?.RootRefObjects.Clear();
                        vm?.GetData();
                        DispatcherTimer.Start();
                        StopExport.IsEnabled = true;
                    }
                    else
                    {
                        ExportToExcel exportToExcel = new ExportToExcel();
                        bool outResult;
                        exportToExcel.ExportData(vm?.RootRefObjects, seriesChecklist, out outResult);
                        if (!outResult)
                        {
                            MessageBox.Show("Something went wrong! Please check your Microsoft Office installed?");
                        }
                    }
                }
                else
                {
                    vm?.GetData();
                    StopExport.IsEnabled = true;
                    DispatcherTimer.Start();

                }
            }
            else
            {
                MessageBox.Show("Please input Second Value!");
                Export.IsEnabled = true;
                seriesCheck.IsEnabled = true;
            }
        }



        private void SlValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MinuteText_Copy != null)
            {
                MinuteText_Copy.Text = (slValue.Value / 60).ToString("#.##") + " min";
            }

        }


        private void StopExport_OnClick(object sender, RoutedEventArgs e)
        {
            var vm = ViewModel as SecondViewModel;
            ExportToExcel exportToExcel = new ExportToExcel();
            bool outResult;
            exportToExcel.ExportData(vm?.RootRefObjects, seriesChecklist,out outResult);

            if (outResult)
            {
                StopExport.IsEnabled = false;
                Export.IsEnabled = true;
                secText.IsEnabled = true;
                timercontrol.IsEnabled = true;
                seriesCheck.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Something went wrong! Please check your Microsoft Office installed?");
                StopExport.IsEnabled = false;
                Export.IsEnabled = true;
                timercontrol.IsEnabled = true;
                secText.IsEnabled = true;
                seriesCheck.IsEnabled = true;
            }
        }
    }
}
