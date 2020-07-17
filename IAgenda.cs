using System.Collections.Generic;

namespace Whats_31
{
    public interface IAgenda
    {
         void Cadastrar(Contato cont);
         
         void Excluir(Contato cont);

         List<Contato> Listar();
    }
}