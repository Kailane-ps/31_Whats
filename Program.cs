using System;

namespace Whats_31
{
    class Program
    {
        static void Main(string[] args)
        {
           Agenda agenda = new Agenda();
           
           Contato c1 = new Contato("Kailane", "(11) 11111-1111");
           Contato c2 = new Contato("Pereira", "(12) 22222-2222");
           Contato c3 = new Contato("Sousa",   "(13) 33333-3333");

            agenda.Cadastrar(c1);
            agenda.Cadastrar(c2);
            agenda.Cadastrar(c3);

            agenda.Excluir(c2);

           foreach ( Contato c in agenda.Listar())
           {
               Console.WriteLine($"Nome: {c.Nome} \t Tel: {c.Telefone}");

           }

           Mensagem msg = new Mensagem();

           msg.Destinatario = c3;

           Console.ForegroundColor = ConsoleColor.DarkBlue;
           msg.Texto = " Boa Noite! " + msg.Destinatario.Nome;
           Console.WriteLine(msg.Enviar());
           Console.ResetColor();

        }
    }
}
