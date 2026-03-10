using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            // newContactWindow.Show(); // 창이 열려 있어도 다른 창에서 작업 가능
            newContactWindow.ShowDialog(); // 해당 창이 닫히기 전까지는 다른 창에서 작업 불가능
            ReadDatabase();
        }

        void ReadDatabase()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                // 💡 쿼리 결과를 명확하게 리스트로 변환합니다.
                var contacts = conn.Table<Contact>().ToList();

                // 디버깅용 메시지 박스: 여기서 개수가 1개 이상 뜨는지 확인하세요!
                if (contacts != null)
                {
                    System.Diagnostics.Debug.WriteLine($"데이터 개수: {contacts.Count}");
                }
            }
        }
    }
}