using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Kontolnaya
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, RoutedEventArgs e)
        {
            MainWindow avtorizacia = new MainWindow();
            director director = new director();
            master master = new master();
            meneger meneger = new meneger();
            zakazchik zakazchik = new zakazchik();
            zamestitel zamestitel = new zamestitel();

            if (textBoxLogin.Text.Length > 0)
            {
                if (passBox.Password.Length > 0)
                {
                    DataTable dt_user = avtorizacia.Select("SELECT * FROM [dbo].[Director] WHERE [Login] = " +
                        "'" + textBoxLogin.Text + "' AND [Password] = '" + passBox.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует
                    {
                        this.Hide();
                        director.Show();
                    }
                    else
                    {
                        DataTable dt_user2 = avtorizacia.Select("SELECT * FROM [dbo].[Master] WHERE [Login] = " +
                        "'" + textBoxLogin.Text + "' AND [Password] = '" + passBox.Password + "'");
                        if (dt_user.Rows.Count > 0) // если такая запись существует
                        {
                            this.Hide();
                            master.Show();
                        }
                        else
                        {
                             DataTable dt_user3 = avtorizacia.Select("SELECT * FROM [dbo].[Meneger] WHERE [Login] = " +
                            "'" + textBoxLogin.Text + "' AND [Password] = '" + passBox.Password + "'");
                            if (dt_user.Rows.Count > 0) // если такая запись существует
                            {
                                this.Hide();
                                meneger.Show();
                            }
                            else
                            {
                                DataTable dt_user4 = avtorizacia.Select("SELECT * FROM [dbo].[Zakazchik] WHERE [Login] = " +
                                "'" + textBoxLogin.Text + "' AND [Password] = '" + passBox.Password + "'");
                                if (dt_user.Rows.Count > 0) // если такая запись существует
                                {
                                    this.Hide();
                                    zakazchik.Show();
                                }
                                else
                                {
                                    DataTable dt_user5 = avtorizacia.Select("SELECT * FROM [dbo].[Zamestitel_directora] WHERE [Login] = " +
                                    "'" + textBoxLogin.Text + "' AND [Password] = '" + passBox.Password + "'");
                                    if (dt_user.Rows.Count > 0) // если такая запись существует
                                    {
                                        this.Hide();
                                        zamestitel.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Такого пользователя не существует!");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении
                                                                            // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=KXRSTI;Trusted_Connection=Yes;" +
                "DataBase=Kontrolnaya;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
            return dataTable;
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            this.Hide();
        }
    }
}
