namespace SOLIDPrincipiosNaPratica.Domain.Entity;
using System;


/// <summary>
/// S - Modelo de usuário representando um usuário no sistema.
/// 
/// O QUE É: O princípio S (Responsabilidade Única) diz que uma classe deve fazer apenas uma coisa.
/// É como se cada classe tivesse um único trabalho, assim como cada pessoa em uma empresa 
/// tem uma função específica.
///
/// PARA QUE SERVE: Evita classes que fazem muitas coisas ao mesmo tempo, o que torna o código 
/// mais organizado, mais fácil de entender e de modificar. É como se você não pedisse para 
/// o cozinheiro de um restaurante também limpar os banheiros - cada um faz o que sabe melhor.
/// 
/// NESTE EXEMPLO: Esta classe Usuario só tem a responsabilidade de armazenar dados do usuário, 
/// não faz mais nada.
/// </summary>
public class Usuario
{
    public string NomeUsuario { get; set; }
    public string Email { get; set; }
}