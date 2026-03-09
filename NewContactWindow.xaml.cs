using SQLite;
using DesktopContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopContactsApp
{
    /// <summary>
    /// NewContactWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact() { 
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };
            string databaseName = "Contacts.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // 윈도우의 '내 문서' 폴더 경로를 자동으로 찾아준다.
            string databasePath = System.IO.Path.Combine(folderPath, databaseName); // C:\Users\이름\Documents\Contacts.db와 같은 전체 주소를 만든다.

            //SQLiteConnection connection = new SQLiteConnection(databasePath); // 지정한 경로의 DB 파일을 연다.
            //connection.CreateTable<Contact>(); // 이미 있다면 이 구문은 무시된다.
            //connection.Insert(contact); // 저장
            //connection.Close(); // 닫지 않으면 다른 곳에서 이 파일을 열 수 없다.

            using (SQLiteConnection connection = new SQLiteConnection(databasePath)) {
                connection.CreateTable<Contact>(); // 이미 있다면 이 구문은 무시된다.
                connection.Insert(contact); // 저장
            } // using 블록이 끝나면 자동으로 Close 호출

            Close(); // 현재 창 닫기
        }
    }
}
