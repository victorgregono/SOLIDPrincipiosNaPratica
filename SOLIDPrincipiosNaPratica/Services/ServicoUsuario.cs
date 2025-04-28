
using SOLIDPrincipiosNaPratica.Domain.Entity;
using SOLIDPrincipiosNaPratica.Repositorio.Interface;

namespace SOLIDPrincipiosNaPratica.Services;

/// <summary>
/// S - Serviço que gerencia a lógica de negócios relacionada a usuários.
/// Responsabilidade Única (SRP): Encapsula apenas operações de negócios relacionadas ao usuário.
/// </summary>
public class ServicoUsuario : IServicoUsuario
{
    private readonly IRepositorioUsuario _repositorioUsuario;

    /// <summary>
    /// Inicializa uma nova instância do ServicoUsuario.
    /// </summary>
    /// <param name="repositorioUsuario">A implementação do repositório de usuário</param>
    public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    /// <summary>
    /// Registra um novo usuário no sistema.
    /// </summary>
    /// <param nomeUsuario="nomeUsuario">O nome de usuário</param>
    /// <param email="email">O email do usuário</param>
    public void RegistrarUsuario(string nomeUsuario, string email)
    {
        // Validar entrada
        if (string.IsNullOrEmpty(nomeUsuario) || string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("Nome de usuário e email são obrigatórios");
        }

        // Criar usuário
        var usuario = new Usuario { NomeUsuario = nomeUsuario, Email = email };

        // Salvar usuário
        _repositorioUsuario.Salvar(usuario);

        Console.WriteLine($"Usuário {nomeUsuario} registrado com sucesso!");
    }
}
