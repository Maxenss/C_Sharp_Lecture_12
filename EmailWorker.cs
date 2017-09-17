using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Lecture_12
{
    class EmailWorker
    {
        #region Поля класса
        // Данные отправителя
        private string fromLogin;
        private string fromPassword;
        // Данные получателя
        private string toLogin;

        // Объекты типа E-mail
        private MailAddress fromAddress;
        private MailAddress toAddress;

        // Беб-клиент для посылки сообщений
        private SmtpClient smtp;
        #endregion

        // Конструктор класса, пользовательский
        public EmailWorker(string fromLogin, string fromPassword)
        {
            this.fromLogin = fromLogin;
            this.fromPassword = fromPassword;

            this.fromAddress = new MailAddress(this.fromLogin, "Отправитель");
        }

        public bool SendMessage(string toLogin,
            string title, string body)
        {
            // Создаем подключение для отправки сообщений
            // Авторизация в сервисе для отправки сообщений Google
            smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                // Указываете данные о E-mail аккаунте отправителя
                Credentials = new NetworkCredential(
                    fromAddress.Address, fromPassword)
            };

            // Создаём E-mail адрес отправителя
            this.toAddress = new MailAddress(toLogin, "Получатель");

            // Создаем Объект типа E-mail-сообщение, и указываем, что 
            // сообщение отсылается с адреса fromAddress 
            // к адресу toAdress
            MailMessage message = new MailMessage(fromAddress, toAddress);
            // Указываем тему сообщения
            message.Subject = title;
            // Указываем тело сообшения
            message.Body = body;

            // В этот блок помещаем программный код, 
            // который может сгенерировать ошибку (исключение - Exception)
            // Блок try может "кидать" исключения 
            try
            {
                Console.WriteLine("Пытаемся отправить сообщение");
                smtp.Send(message);
            }
            // В случае, если в блоке try, возникает исключение
            // То выполняется блок catch.
            // Если в блоке try не возникает исключение
            // То блок catch не выполняется
            // Блок catch может "ловить" исключения
            catch
            {
                Console.WriteLine("Произошла ошибка при отправке сообщения");
                return false;
            }
            // Блок finnaly, выполняется в любом случае
            // Независимо от того, было сгенерировано исключение, или нет
            finally {
                Console.WriteLine("По крайней мере, мы пытались :)");
            }

            return true;
        }

        #region Методы доступа set-, get-

        public string FromLogin { get => fromLogin; set => fromLogin = value; }
        public string FromPassword { get => fromPassword; set => fromPassword = value; }
        public string ToLogin { get => toLogin; set => toLogin = value; }
        public MailAddress FromAddress { get => fromAddress; set => fromAddress = value; }
        public MailAddress ToAddress { get => toAddress; set => toAddress = value; }

        #endregion
    }
}