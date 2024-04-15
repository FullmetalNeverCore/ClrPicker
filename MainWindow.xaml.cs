using System.Drawing;
using System.Runtime.InteropServices;
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
using System.Windows.Threading;

namespace ClrPickerWPF
{




    public partial class MainWindow : Window
    {

        private DispatcherTimer ttimer = new DispatcherTimer();
        private back.ColorPicker clrpckr = new back.ColorPicker();


        public MainWindow()
        {
            InitializeComponent();
            SetTimer();


        }

        public void SetTimer()
        {
            ttimer.Interval = TimeSpan.FromMilliseconds(100);
            ttimer.Tick += ClrUpdate;
            ttimer.Start();
        }


        private void ClrUpdate(object sender,EventArgs e)
        {
            System.Windows.Media.Color color = clrpckr.getColor();
            CLR.Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R,color.G,color.B));
            HW.Text = $"RGB:{color.R},{color.G},{color.B}";
        }

    }
}