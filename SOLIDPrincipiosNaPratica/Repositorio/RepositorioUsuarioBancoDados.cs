using SOLIDPrincipiosNaPratica.Domain.Entity;
using SOLIDPrincipiosNaPratica.Repositorio.Interface;

namespace SOLIDPrincipiosNaPratica.repositorio;

/// <summary>
/// S - Implementação de banco de dados do repositório de usuário.
/// Responsabilidade Única (SRP): Lida apenas com operações de banco de dados para usuários.
/// </summary>
public class RepositorioUsuarioBancoDados : IRepositorioUsuario
{
    /// <summary>
    /// Salva um usuário no banco de dados.
    /// </summary>
    /// <param name="usuario">O usuário a ser salvo</param>
    public void Salvar(Usuario usuario)
    {
        Console.WriteLine($"Salvando usuário {usuario.NomeUsuario} no banco de dados");
        // Lógica de salvamento no banco de dados aqui
    }
}