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
using MaterialDesignThemes.Wpf;
using AdminPanel.Data.Server.Performance;

namespace AdminPanel.Content.Views.Frames.PerformanceTools
{
    /// <summary>
    /// Interaction logic for MainPerfomanceTool.xaml
    /// </summary>
    public partial class MainPerfomanceTool : Page
    {
        private List<Card> meters;
        private PerformanceTracker tracker;

        public MainPerfomanceTool()
        {
            InitializeComponent();
            
            // Initialize list of meters.
            meters = new List<Card>(new Card[] { meter0_0, meter1_0, meter2_0, meter0_1, meter1_1, meter2_1 });

            tracker = new PerformanceTracker();

            tracker.StartPing(pingCounter);
            meter0_0.Content = new StackPanel
            {
                Background = Brushes.Aqua
            };

        }

        private void onClose(object sender, RoutedEventArgs e)
        {
            tracker.StopAll();
        }
    }
}
