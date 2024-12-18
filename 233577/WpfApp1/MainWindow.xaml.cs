using System;
using System.Windows;
using System.Windows.Threading;

namespace _123
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Start the clock
            StartClock();
        }

        // Using a DependencyProperty as the backing store for CurrentTime. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentTimeProperty =
            DependencyProperty.Register("CurrentTime", typeof(DateTime), typeof(MainWindow), new PropertyMetadata(DateTime.Now, OnCurrentTimePropertyChanged));

        public DateTime CurrentTime
        {
            get { return (DateTime)GetValue(CurrentTimeProperty); }
            set { SetValue(CurrentTimeProperty, value); }
        }

        private static void OnCurrentTimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as MainWindow;
            if (window != null)
            {
                // Update the clock control or any other UI element here
                window.UpdateClockDisplay();
            }
        }

        private void StartClock()
        {
            // Update the CurrentTime property every second
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now;
            };
            timer.Start();
        }

        private void UpdateClockDisplay()
        {
            // Assuming you have a TextBlock named ClockTextBlock in your XAML
            ClockTextBlock.Text = CurrentTime.ToString("hh:mm:ss tt");
        }
    }
}