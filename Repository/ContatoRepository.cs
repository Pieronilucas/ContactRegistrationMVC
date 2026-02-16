using ContactRegistration.Data;
using ContactRegistration.Models;

namespace ContactRegistration.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly BancoContext _context;
    
    public ContatoRepository(BancoContext context)
    {
        _context = context;
    }

    public ContatoModel Adicionar(ContatoModel contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
        
        return contato;
    }

    public List<ContatoModel> Listar()
    {
        return _context.Contatos.ToList();
    }

    public ContatoModel? ListarPorId(int id)
    {
        return _context.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        ContatoModel contatoUpdate = ListarPorId(contato.Id);

        if (contatoUpdate == null)
        {
            throw new SystemException("Houve um erro na atualização. Contato não encontrado");
        }
        contatoUpdate.Nome = contato.Nome;
        contatoUpdate.Email = contato.Email;
        contatoUpdate.Celular = contato.Celular;
        
        _context.Contatos.Update(contatoUpdate);
        _context.SaveChanges();
        return contatoUpdate;
    }
}