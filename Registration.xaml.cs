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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void buttonReg_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxRegLogin.Text.Length >= 4 & passBox.Password.Length >= 6 & passBox.Password.Length <=18 
                & (passBox.Password.Contains("*") || passBox.Password.Contains("&") || passBox.Password.Contains("{")
                || passBox.Password.Contains("}") || passBox.Password.Contains("|") || passBox.Password.Contains("+")))
            {
                if(passBox.Password==passBox2.Password)
                {
                    if(textBoxRegCaptca==textBoxCaptcha)
                    {
                        MessageBox.Show("Вы успешно зарегистрировались!");

                        MainWindow avtorizacia = new MainWindow();
                        avtorizacia.Show();
                        this.Hide();

                        SqlConnection sc = new SqlConnection();
                        SqlCommand com = new SqlCommand();

                        sc.ConnectionString = ("Data Source=KXRSTI;Initial Catalog=Kontrolnaya;" +
                            "Integrated Security=True");
                        sc.Open();
                        com.Connection = sc;
                        com.CommandText = ("INSERT INTO Zakazchik (Login, Password)" +
                            " VALUES ('" + textBoxRegLogin.Text + "','" + passBox.Password + "');");
                        com.ExecuteNonQuery();
                        sc.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверно введена капча!");
                    }
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Введённые данные не соответсвуют правилам");
            }
        }

        private void buttonCaptcha_Click(object sender, RoutedEventArgs e)
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = " ";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            textBoxRegCaptca.Text = pwd;
        }
    }
}
