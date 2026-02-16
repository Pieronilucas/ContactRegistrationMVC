using ContactRegistration.Models;

namespace ContactRegistration.Repository;

public interface IContatoRepository
{
    List<ContatoModel> Listar();
    ContatoModel Adicionar(ContatoModel contato);
    
    
}