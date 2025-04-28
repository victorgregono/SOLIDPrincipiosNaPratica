using SOLIDPrincipiosNaPratica.Domain.Entity;

namespace SOLIDPrincipiosNaPratica.Repositorio.Interface;

/// <summary>
/// S - Interface para operações de repositório de usuário.
/// Responsabilidade Única (SRP): Define operações de acesso a dados.
/// </summary>
public interface IRepositorioUsuario
{
    /// <summary>
    /// Salva um usuário no armazenamento de dados.
    /// </summary>
    /// <param name="usuario">O usuário a ser salvo</param>
    void Salvar(Usuario usuario);
}