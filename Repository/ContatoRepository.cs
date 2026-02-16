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
}