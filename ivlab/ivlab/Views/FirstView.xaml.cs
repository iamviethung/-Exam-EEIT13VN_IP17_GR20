using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using ivlab.Core.Models;
using ivlab.Core.ViewModels;
using Telerik.Windows.Controls.Charting;
using System.IO;
using System.Windows.Media.Imaging;

namespace ivlab.Views
{
    /// <summary>
    /// Interaction logic for First.xaml
    /// </summary>
    public partial class FirstView
    {

        protected DispatcherTimer DispatcherTimer;
        public FirstView()
        {
            InitializeComponent();
        }


        
        private void SetTimer()
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
            var vm = ViewModel as FirstViewModel;
            vm?.GetData();
            LoadDataChart(vm?.RootRefObjects);
            if (DateTime.UtcNow >= TickTime)
            {
                DispatcherTimer.Stop();
                timercontrol.IsEnabled = true;
                slValue.IsEnabled = true;
                secText.IsEnabled = true;
                seriesCheck.IsEnabled = true;
                button.IsEnabled = true;
                button_Copy.IsEnabled = false;
            }
        }

        public DateTime TickTime { get; set; }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            TickTime = new DateTime();
            TickTime = DateTime.UtcNow.AddSeconds(int.Parse(secText.Text));
            var vm = ViewModel as FirstViewModel;
            vm?.GetData();
            LoadDataChart(vm?.RootRefObjects);
            timercontrol.IsEnabled = false;
            slValue.IsEnabled = false;
            secText.IsEnabled = false;
            SetTimer();
            seriesCheck.IsEnabled = false;
            button_Copy.IsEnabled = true;
            button.IsEnabled = false;
            DispatcherTimer.Start();



           
        }

        private void Button_OnClick1(object sender, RoutedEventArgs e)
        {
            timercontrol.IsEnabled = true;
            slValue.IsEnabled = true;
            secText.IsEnabled = true;
            seriesCheck.IsEnabled = true;
            button.IsEnabled = true;
            button_Copy.IsEnabled = false;
            DispatcherTimer.Stop();
        }

        private void Button_OnClick2(object sender, RoutedEventArgs e)
        {
           
            System.Windows.Media.Imaging.PngBitmapEncoder test = new PngBitmapEncoder();
           
            Telerik.Windows.Media.Imaging.ExportExtensions.ExportToImage(rChart, "c:\\ivlab.png", test);

        }

        private void SlValue_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MinuteText_Copy != null)
            {
                MinuteText_Copy.Text = (slValue.Value / 60).ToString("#.##") + " min";
            }
         
        }


        public void LoadDataChart(ObservableCollection<RefTimestamp> refTimestamp)
        {

            rChart.DefaultView.ChartArea.AxisX.DefaultLabelFormat = "HH:mm:ss";
            rChart.DefaultView.ChartArea.AxisX.LabelRotationAngle = 45;


            var Tank1Series = new DataSeries
            {
                LegendLabel = "Tank 1",
                Definition = new LineSeriesDefinition(),
            };

            if (t1C.IsChecked != null && t1C.IsChecked.Value)
            {



                CustomGridLine gridline = new CustomGridLine();
                var tank1Max
                    = refTimestamp[0].RootRefObject.tank1.max;
                if (tank1Max != null)
                    gridline.YIntercept = tank1Max.Value;
                gridline.Stroke = new SolidColorBrush(Colors.DeepSkyBlue);
                gridline.StrokeThickness = 2;
                gridline.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;


                rChart.DefaultView.ChartArea.Annotations.Add(gridline);
                Tank1Series.Definition.Appearance.Stroke =
                    Tank1Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.DeepSkyBlue);


            }

            var Tank2Series = new DataSeries
            {
                LegendLabel = "Tank 2",
                Definition = new LineSeriesDefinition(),
            };

            if (t2C.IsChecked.Value)
            {



                CustomGridLine gridline2 = new CustomGridLine();
                var tank2Max
                    = refTimestamp[0].RootRefObject.tank2.max;
                if (tank2Max != null)
                    gridline2.YIntercept = tank2Max.Value;

                gridline2.Stroke = new SolidColorBrush(Colors.Red);
                gridline2.StrokeThickness = 2;
                gridline2.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridline2);
                Tank2Series.Definition.Appearance.Stroke =
                    Tank2Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.Red);

            }


            var Tank3Series = new DataSeries
            {
                LegendLabel = "Tank 3",
                Definition = new LineSeriesDefinition(),
            };

            if (t3C.IsChecked.Value)
            {




                CustomGridLine gridline3 = new CustomGridLine();
                var tank3Max
                    = refTimestamp[0].RootRefObject.tank3.max;
                if (tank3Max != null)
                    gridline3.YIntercept = tank3Max.Value;

                gridline3.Stroke = new SolidColorBrush(Colors.DarkOrange);
                gridline3.StrokeThickness = 2;
                gridline3.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;

                rChart.DefaultView.ChartArea.Annotations.Add(gridline3);
                Tank3Series.Definition.Appearance.Stroke =
                    Tank3Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.DarkOrange);

            }



            var pumpe1Series = new DataSeries
            {
                LegendLabel = "Pumpe 1",
                Definition = new LineSeriesDefinition(),
            };

            if (p1C.IsChecked.Value)
            {
                CustomGridLine gridlinep1 = new CustomGridLine();
                var pump1Max
                    = refTimestamp[0].RootRefObject.pumpe1.max;
                if (pump1Max != null)
                    gridlinep1.YIntercept = pump1Max.Value;

                gridlinep1.Stroke = new SolidColorBrush(Colors.Chartreuse);
                gridlinep1.StrokeThickness = 2;
                gridlinep1.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinep1);
                pumpe1Series.Definition.Appearance.Stroke =
                    pumpe1Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.Chartreuse);

            }


            var pumpe2Series = new DataSeries
            {
                LegendLabel = "Pumpe 2",
                Definition = new LineSeriesDefinition(),
            };

            if (p2C.IsChecked.Value)
            {
                CustomGridLine gridlinep2 = new CustomGridLine();
                var pump2Max
                    = refTimestamp[0].RootRefObject.pumpe2.max;
                if (pump2Max != null)
                    gridlinep2.YIntercept = pump2Max.Value;

                gridlinep2.Stroke = new SolidColorBrush(Colors.OliveDrab);
                gridlinep2.StrokeThickness = 2;
                gridlinep2.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinep2);
                pumpe2Series.Definition.Appearance.Stroke =
                    pumpe2Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.OliveDrab);

            }

            var pumpe3Series = new DataSeries
            {
                LegendLabel = "Pumpe 3",
                Definition = new LineSeriesDefinition(),
            };

            if (p3C.IsChecked.Value)
            {
                CustomGridLine gridlinep3 = new CustomGridLine();
                var pump3Max
                    = refTimestamp[0].RootRefObject.pumpe3.max;
                if (pump3Max != null)
                    gridlinep3.YIntercept = pump3Max.Value;

                gridlinep3.Stroke = new SolidColorBrush(Colors.Black);
                gridlinep3.StrokeThickness = 2;
                gridlinep3.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinep3);
                pumpe3Series.Definition.Appearance.Stroke =
                    pumpe3Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.Black);

            }


            var adg1Series = new DataSeries
            {
                LegendLabel = "Adg 1",
                Definition = new LineSeriesDefinition(),
            };


            if (a1C.IsChecked.Value)
            {
                CustomGridLine gridlinea1 = new CustomGridLine();
                var adg1Max
                    = refTimestamp[0].RootRefObject.adg1.max;
                if (adg1Max != null)
                    gridlinea1.YIntercept = adg1Max.Value;

                gridlinea1.Stroke = new SolidColorBrush(Colors.Aqua);
                gridlinea1.StrokeThickness = 2;
                gridlinea1.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinea1);
                adg1Series.Definition.Appearance.Stroke =
                    adg1Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.Aqua);

            }

            var adg2Series = new DataSeries
            {
                LegendLabel = "Adg 2",
                Definition = new LineSeriesDefinition(),
            };


            if (a2C.IsChecked.Value)
            {
                CustomGridLine gridlinea2 = new CustomGridLine();
                var adg2Max
                    = refTimestamp[0].RootRefObject.adg2.max;
                if (adg2Max != null)
                    gridlinea2.YIntercept = adg2Max.Value;

                gridlinea2.Stroke = new SolidColorBrush(Colors.Bisque);
                gridlinea2.StrokeThickness = 2;
                gridlinea2.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinea2);
                adg2Series.Definition.Appearance.Stroke =
                    adg2Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.Bisque);


            }

            var adg3Series = new DataSeries
            {
                LegendLabel = "Adg 3",
                Definition = new LineSeriesDefinition(),
            };



            if (a3C.IsChecked.Value)
            {

                CustomGridLine gridlinea3 = new CustomGridLine();
                var adg3Max
                    = refTimestamp[0].RootRefObject.adg3.max;
                if (adg3Max != null)
                    gridlinea3.YIntercept = adg3Max.Value;

                gridlinea3.Stroke = new SolidColorBrush(Colors.CadetBlue);
                gridlinea3.StrokeThickness = 2;
                gridlinea3.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlinea3);
                adg3Series.Definition.Appearance.Stroke =
                    adg3Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.CadetBlue);



            }


            var gas1Series = new DataSeries
            {
                LegendLabel = "Gas 1",
                Definition = new LineSeriesDefinition(),
            };

            if (g1C.IsChecked.Value)
            {

                CustomGridLine gridlineg1 = new CustomGridLine();
                var gas1Max
                    = refTimestamp[0].RootRefObject.gas1.max;
                if (gas1Max != null)
                    gridlineg1.YIntercept = gas1Max.Value;

                gridlineg1.Stroke = new SolidColorBrush(Colors.DarkOrchid);
                gridlineg1.StrokeThickness = 2;
                gridlineg1.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlineg1);
                gas1Series.Definition.Appearance.Stroke =
                    gas1Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.DarkOrchid);
            }



            var gas2Series = new DataSeries
            {
                LegendLabel = "Gas 1",
                Definition = new LineSeriesDefinition(),
            };


            if (g2C.IsChecked.Value)
            {

                CustomGridLine gridlineg2 = new CustomGridLine();
                var gas2Max
                    = refTimestamp[0].RootRefObject.gas2.max;
                if (gas2Max != null)
                    gridlineg2.YIntercept = gas2Max.Value;

                gridlineg2.Stroke = new SolidColorBrush(Colors.DarkRed);
                gridlineg2.StrokeThickness = 2;
                gridlineg2.ElementStyle = this.Resources["CustomGridLineStyle"] as Style;
                rChart.DefaultView.ChartArea.Annotations.Add(gridlineg2);
                gas2Series.Definition.Appearance.Stroke =
                    gas2Series.Definition.Appearance.Fill = new SolidColorBrush(Colors.DarkRed);


            }



            foreach (var reftimestamp in refTimestamp)
            {
                if (t1C.IsChecked.Value)
                {
                    var itemt1 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.tank1.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };
                    Tank1Series.Add(itemt1);
                }


                if (t2C.IsChecked.Value)
                {

                    var itemt2 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.tank2.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    Tank2Series.Add(itemt2);
                }


                if (t3C.IsChecked.Value)
                {

                    var itemt3 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.tank3.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    Tank3Series.Add(itemt3);
                }

                if (p1C.IsChecked.Value)
                {


                    var itemp1 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.pumpe1.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };


                    pumpe1Series.Add(itemp1);
                }


                if (p2C.IsChecked.Value)
                {

                    var itemp2 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.pumpe2.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    pumpe2Series.Add(itemp2);
                }


                if (p3C.IsChecked.Value)
                {

                    var itemp3 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.pumpe3.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    pumpe3Series.Add(itemp3);
                }



                if (a1C.IsChecked.Value)
                {

                    var itema1 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.adg1.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    adg1Series.Add(itema1);
                }

                if (a2C.IsChecked.Value)
                {

                    var itema2 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.adg2.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    adg2Series.Add(itema2);
                }

                if (a3C.IsChecked.Value)
                {

                    var itema3 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.adg3.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    adg3Series.Add(itema3);
                }

                if (g1C.IsChecked.Value)
                {

                    var itemg1 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.gas1.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    gas1Series.Add(itemg1);
                }

                if (g2C.IsChecked.Value)
                {

                    var itemg2 = new DataPoint
                    {
                        YValue = double.Parse(reftimestamp.RootRefObject.gas2.actual),
                        XValue = DateTime.Parse(reftimestamp.Timestamp).ToOADate()
                    };

                    gas2Series.Add(itemg2);
                }
            }

            if (refTimestamp.Count > 1)
            {
                rChart.DefaultView.ChartArea.DataSeries.Clear();
            }

            if (t1C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(Tank1Series);
            if (t2C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(Tank2Series);
            if (t3C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(Tank3Series);
            if (p1C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(pumpe1Series);
            if (p2C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(pumpe2Series);
            if (p3C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(pumpe3Series);
            if (a1C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(adg1Series);
            if (a2C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(adg2Series);
            if (a3C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(adg3Series);
            if (g1C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(gas1Series);
            if (g2C.IsChecked.Value)
                rChart.DefaultView.ChartArea.DataSeries.Add(gas2Series);


        }

    }
}
