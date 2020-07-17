using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Whats_31
{
    public class Agenda : IAgenda
    {
        List<Contato> contatos = new List<Contato>();

        private const string PATH = "Database/contato.csv";

        
        public Agenda()
        {
             
            string pasta = PATH.Split('/')[0];

            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }


            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        
        }

        public void Cadastrar(Contato cont)
        {
            string[] linhas = {PrepararLinhaCSV(cont)};
            File.AppendAllLines(PATH, linhas);
        }
        private string PrepararLinhaCSV(Contato c)
        {
           return $"{c.Nome};{c.Telefone}"; 
        }


        public void Excluir(Contato cont)
        {
            List<string> linhas = new List<string>();

           
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(x => x.Contains(cont.Nome));
            ReescreverCSV(linhas);
        }

        public List<Contato> Listar()
        {
            string [] lista = File.ReadAllLines(PATH);

            
            foreach(var linha in lista){

                
                string[] dados = linha.Split(';');   

                 Contato c = new Contato( dados[0] , dados[1] );

                contatos.Add(c);

            }

            contatos = contatos.OrderBy(y => y.Nome).ToList();
            return contatos;

        }
        private void ReescreverCSV(List<string> lines){

            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (string In in lines)
                {
                    output.Write(In + "\n");
                }
            }
        }


    }
}