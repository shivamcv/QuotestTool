using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private string currentQuote;

        public string CurrentQuote
        {
            get { return currentQuote; }
            set {
                currentQuote = value;
                OnPropertyChanged("CurrentQuote");
            }
        }

        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker bgwrk = new BackgroundWorker();

            bgwrk.DoWork += bgwrk_DoWork;
            bgwrk.RunWorkerAsync();
        }

       

        void bgwrk_DoWork(object sender, DoWorkEventArgs e)
        {
            getUpdate();
        }

        private void getUpdate()
        {
            Parser p = new Parser();
            CurrentQuote = p.parse();
            getUpdate();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Drag_click(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
