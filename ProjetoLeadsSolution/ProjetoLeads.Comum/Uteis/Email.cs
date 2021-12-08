using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Comum.Uteis
{
    public class Email
    {
        public Email(string emailDestino)
        {
            EmailDestino = emailDestino;
        }

        public string EmailDestino { get; set; }

        public static bool ValidarEmail(string email)
        {
            if (email.Contains("@") && email.Contains("stil") && email.Contains(".com"))
            {
                return true;
            }
            return false;
        }

        public static int EnviarCodigoDeVerificacao(string emailDestinatario, string nomeDestinatario)
        {
            if (ValidarEmail(emailDestinatario))
            {
                //Geramos o código que será enviado no e-mail
                var geradorCodigo = new Random();
                int codigo = geradorCodigo.Next(100000, 999999);

                //Criamos uma nova mensagem
                var message = new MimeMessage();

                //Especificamos o remetente
                message.From.Add(new MailboxAddress("João Vitor", "jovioli.dev@gmail.com"));

                //Especificamos o destinatário
                message.To.Add(new MailboxAddress(nomeDestinatario, emailDestinatario));

                //Assunto do e-mail
                message.Subject = "Código de validação de cadastro - GLEN";

                //Corpo do e-mail
                message.Body = new TextPart("Esse é o TextPart")
                {

                    Text = @"Olá, João Vitor! Tá aí o código" + codigo.ToString()
                };

                using (var client = new SmtpClient())
                {
                    //Abrimos a conexão com o SMTP
                    client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

                    //Autenticamos o nosso e-mail
                    client.Authenticate("jovioli.dev@gmail.com", "joviolidev04");

                    //Enviamos o e-mail
                    client.Send(message);

                    //Fechamos a conexão
                    client.Disconnect(true);
                }

                return codigo;
            }

            return 0;
        }

        public static bool ValidarCodigoDeVerificacao(int codigoGerado, int codigoInformado)
        {
            if (codigoGerado == codigoInformado)
            {
                return true;
            }

            return false;
        }
    }
}
