using System.Windows;

namespace KoetjeMelken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeckOfCards deck;
        public MainWindow()
        {
            InitializeComponent();
        }

        void shuffleButton_Click(object sender, RoutedEventArgs e)
        {
            deck = new DeckOfCards();
            deck.shuffle();
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
