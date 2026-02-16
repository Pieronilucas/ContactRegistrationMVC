using ContactRegistration.Models;

namespace ContactRegistration.Repository;

public interface IContatoRepository
{
    List<ContatoModel> ListAll();
    ContatoModel AddContact(ContatoModel contato);
    ContatoModel? GetById(int id);
    ContatoModel Update(ContatoModel contato);
    bool? DeleteContact(int id);
}