using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lecture_12
{
    class Program
    {
        static void Main(string[] args)
        {
            // Данные отправителя
            string fromLogin = "";     // = "maxensit@gmail.com";
            string fromPassword = "";  // = "maxens0402";
            // Данные получателя
            string toLogin = "";       // = "maxenssss@gmail.com";

            // Тема сообщения
            string title = "";
            // Тело сообщения
            string body = "";

            Console.Write("Введите логин отправителя : ");
            fromLogin = Console.ReadLine();
            Console.Write("Введите пароль отправителя : ");
            fromPassword = Console.ReadLine();
            Console.Write("Введите логин получателя : ");
            toLogin = Console.ReadLine();
            Console.Write("Введите тему сообщения : ");
            title = Console.ReadLine();
            Console.Write("Введите тело сообщения : ");
            body = Console.ReadLine();


            EmailWorker emailWorker1 =
                new EmailWorker(fromLogin, fromPassword);

            bool flag =
                emailWorker1.SendMessage(
                    toLogin, title, body);

            if (flag == true)
            {
                Console.WriteLine("Сообщение отправилось");
            }
            else
            {
                Console.WriteLine("Сообщение не отправилось");
            }

            Console.ReadKey();
        }
    }
}
