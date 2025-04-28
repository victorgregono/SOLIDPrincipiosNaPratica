using SOLIDPrincipiosNaPratica.repositorio;
using SOLIDPrincipiosNaPratica.Repositorio.Interface;
using SOLIDPrincipiosNaPratica.Services;

namespace SOLIDPrincipiosNaPratica
{
    class Program
    {
        private readonly IServicoUsuario _servicoUsuario;
        public Program(IServicoUsuario servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Exemplos de Princípios SOLID:");
            Console.WriteLine("-------------------------");

            // S - Exemplo do Princípio da Responsabilidade Única
            Console.WriteLine("\n[S] - Single Responsibility Principle (Princípio da Responsabilidade Única)");
            Console.WriteLine("Cada classe deve ter apenas uma única responsabilidade");

            var program = new Program(new ServicoUsuario(new RepositorioUsuarioBancoDados()));
            program._servicoUsuario.RegistrarUsuario("joaosilva", "joao@exemplo.com");

            // O - Exemplo do Princípio Aberto/Fechado
            Console.WriteLine("\n[O] - Open/Closed Principle (Princípio Aberto/Fechado)");
            Console.WriteLine("Entidades devem estar abertas para extensão, mas fechadas para modificação");
            var formas = new List<IForma>
            {
                new Retangulo { Largura = 5, Altura = 3 },
                new Circulo { Raio = 4 }
            };
            var calculadoraArea = new CalculadoraArea();
            Console.WriteLine($"Área total: {calculadoraArea.CalcularAreaTotal(formas)}");

            // L - Exemplo do Princípio da Substituição de Liskov
            Console.WriteLine("\n[L] - Liskov Substitution Principle (Princípio da Substituição de Liskov)");
            Console.WriteLine("Objetos de uma classe derivada devem poder substituir objetos da classe base sem afetar a funcionalidade");
            Passaro passaro = new Pardal();
            passaro.Voar(); // Funciona bem

            passaro = new Avestruz();
            passaro.Andar(); // Funciona bem

            // I - Exemplo do Princípio da Segregação de Interface
            Console.WriteLine("\n[I] - Interface Segregation Principle (Princípio da Segregação de Interface)");
            Console.WriteLine("É melhor ter muitas interfaces específicas do que uma única interface genérica");
            IImpressora impressora = new DispositivoMultifuncional();
            impressora.Imprimir();

            IScanner scanner = new DispositivoMultifuncional();
            scanner.Escanear();

            // D - Exemplo do Princípio da Inversão de Dependência
            Console.WriteLine("\n[D] - Dependency Inversion Principle (Princípio da Inversão de Dependência)");
            Console.WriteLine("Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações");
            var servicoNotificacao = new ServicoNotificacao(
                new List<ICanalNotificacao>
                {
                    new NotificacaoEmail(),
                    new NotificacaoSMS()
                });
            servicoNotificacao.Notificar("Olá mundo SOLID!");

            Console.WriteLine("\n-------------------------");
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }
    }

    #region O - Princípio Aberto/Fechado (OCP - Open/Closed Principle)

    /// <summary>
    /// O - Interface que define uma forma.
    /// 
    /// O QUE É: O princípio O (Aberto/Fechado) diz que você deve poder adicionar novos recursos
    /// sem precisar modificar o código que já existe.
    ///
    /// PARA QUE SERVE: Permite que o sistema cresça com menos riscos de quebrar o que já funciona.
    /// É como se você pudesse adicionar novos brinquedos em um parque sem precisar fechar ou 
    /// modificar os brinquedos que já existem.
    /// 
    /// NESTE EXEMPLO: Podemos adicionar novos tipos de formas geométricas sem precisar mudar
    /// a calculadora que soma as áreas.
    /// </summary>
    public interface IForma
    {
        /// <summary>
        /// Calcula a área da forma.
        /// </summary>
        /// <returns>A área calculada</returns>
        double CalcularArea();
    }

    /// <summary>
    /// O - Implementação de Retângulo da interface IForma.
    /// Aberto/Fechado (OCP): Uma forma de estender o sistema sem modificar o que já existe.
    /// </summary>
    public class Retangulo : IForma
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        /// <summary>
        /// Calcula a área do retângulo.
        /// </summary>
        /// <returns>A área do retângulo</returns>
        public double CalcularArea()
        {
            return Largura * Altura;
        }
    }

    /// <summary>
    /// O - Implementação de Círculo da interface IForma.
    /// Aberto/Fechado (OCP): Outra forma de estender o sistema sem modificar o que já existe.
    /// </summary>
    public class Circulo : IForma
    {
        public double Raio { get; set; }

        /// <summary>
        /// Calcula a área do círculo.
        /// </summary>
        /// <returns>A área do círculo</returns>
        public double CalcularArea()
        {
            return Math.PI * Raio * Raio;
        }
    }

    /// <summary>
    /// O - Calculadora que trabalha com qualquer forma.
    /// Aberto/Fechado (OCP): Esta calculadora funciona com qualquer forma, mesmo com aquelas
    /// que ainda não foram criadas.
    /// </summary>
    public class CalculadoraArea
    {
        /// <summary>
        /// Calcula a área total de múltiplas formas.
        /// </summary>
        /// <param formas="formas">Coleção de formas</param>
        /// <returns>A área total</returns>
        public double CalcularAreaTotal(IEnumerable<IForma> formas)
        {
            double total = 0;
            foreach (var forma in formas)
            {
                total += forma.CalcularArea();
            }
            return total;
        }
    }

    #endregion

    #region L - Princípio da Substituição de Liskov (LSP - Liskov Substitution Principle)

    /// <summary>
    /// L - Classe base Pássaro com capacidades que todos os pássaros devem ter.
    /// 
    /// O QUE É: O princípio L (Substituição de Liskov) diz que, se uma classe B herda de uma classe A,
    /// você deve poder usar B onde quer que A seja esperado, sem causar problemas.
    ///
    /// PARA QUE SERVE: Garante que as classes derivadas não quebrem o funcionamento esperado
    /// das classes base. É como garantir que, se você contratou um pintor, qualquer pintor que
    /// apareça (seja especialista em casas ou carros) deve ser capaz de pintar o que você precisa.
    /// 
    /// NESTE EXEMPLO: Qualquer tipo específico de pássaro (como Pardal ou Avestruz) pode ser usado
    /// onde um Pássaro genérico é esperado, sem causar problemas no código.
    /// </summary>
    public abstract class Passaro
    {
        /// <summary>
        /// Todos os pássaros podem andar.
        /// </summary>
        public virtual void Andar()
        {
            Console.WriteLine("Pássaro está andando");
        }

        /// <summary>
        /// Nem todos os pássaros podem voar, então isso é feito virtual para permitir sobrescrita.
        /// </summary>
        public virtual void Voar()
        {
            Console.WriteLine("Pássaro está voando");
        }
    }

    /// <summary>
    /// L - Pardal é um pássaro que pode voar.
    /// Substituição de Liskov (LSP): Pardal pode ser usado onde Passaro é usado.
    /// </summary>
    public class Pardal : Passaro
    {
        public override void Voar()
        {
            Console.WriteLine("Pardal está voando alto");
        }
    }

    /// <summary>
    /// L - Avestruz é um pássaro que não pode voar.
    /// Substituição de Liskov (LSP): Avestruz ainda pode ser usado como um Passaro, 
    /// mas trata adequadamente o método voar.
    /// </summary>
    public class Avestruz : Passaro
    {
        public override void Voar()
        {
            Console.WriteLine("Avestruz não pode voar");
            // Em vez de lançar uma exceção, tratamos adequadamente este caso
        }

        public override void Andar()
        {
            Console.WriteLine("Avestruz está correndo rápido");
        }
    }

    #endregion

    #region I - Princípio da Segregação de Interface (ISP - Interface Segregation Principle)

    /// <summary>
    /// I - Interface para funcionalidade de impressora.
    /// 
    /// O QUE É: O princípio I (Segregação de Interface) diz que é melhor ter várias interfaces
    /// pequenas e específicas do que uma única interface grande e genérica.
    ///
    /// PARA QUE SERVE: Evita que as classes implementem métodos que não vão usar.
    /// É como quando você vai a um restaurante e recebe um cardápio específico (só bebidas, só sobremesas)
    /// em vez de um enorme catálogo com todas as opções possíveis, o que facilita sua escolha.
    /// 
    /// NESTE EXEMPLO: Em vez de ter uma única interface "DispositivoDeEscritório", temos interfaces
    /// separadas para impressão, digitalização e fax, permitindo que dispositivos simples implementem
    /// apenas o que realmente fazem.
    /// </summary>
    public interface IImpressora
    {
        /// <summary>
        /// Imprime um documento.
        /// </summary>
        void Imprimir();
    }

    /// <summary>
    /// I - Interface para funcionalidade de scanner.
    /// Segregação de Interface (ISP): Interface separada para escaneamento.
    /// </summary>
    public interface IScanner
    {
        /// <summary>
        /// Escaneia um documento.
        /// </summary>
        void Escanear();
    }

    /// <summary>
    /// I - Interface para funcionalidade de fax.
    /// Segregação de Interface (ISP): Interface separada para envio de fax.
    /// </summary>
    public interface IFax
    {
        /// <summary>
        /// Envia um fax.
        /// </summary>
        void EnviarFax();
    }

    /// <summary>
    /// I - Impressora simples que implementa apenas a funcionalidade de impressora.
    /// Segregação de Interface (ISP): Implementa apenas as interfaces necessárias.
    /// </summary>
    public class ImpressoraSimples : IImpressora
    {
        /// <summary>
        /// Imprime um documento.
        /// </summary>
        public void Imprimir()
        {
            Console.WriteLine("Imprimindo documento");
        }
    }

    /// <summary>
    /// I - Dispositivo multifuncional implementando múltiplas interfaces.
    /// Segregação de Interface (ISP): Implementa todas as interfaces que suporta.
    /// </summary>
    public class DispositivoMultifuncional : IImpressora, IScanner, IFax
    {
        /// <summary>
        /// Imprime um documento.
        /// </summary>
        public void Imprimir()
        {
            Console.WriteLine("Multifuncional: Imprimindo documento");
        }

        /// <summary>
        /// Escaneia um documento.
        /// </summary>
        public void Escanear()
        {
            Console.WriteLine("Multifuncional: Escaneando documento");
        }

        /// <summary>
        /// Envia um fax.
        /// </summary>
        public void EnviarFax()
        {
            Console.WriteLine("Multifuncional: Enviando fax");
        }
    }

    #endregion

    #region D - Princípio da Inversão de Dependência (DIP - Dependency Inversion Principle)

    /// <summary>
    /// D - Interface para canais de notificação.
    /// 
    /// O QUE É: O princípio D (Inversão de Dependência) diz que classes de alto nível não devem
    /// depender diretamente de classes de baixo nível, mas sim de abstrações (interfaces).
    ///
    /// PARA QUE SERVE: Torna o sistema mais flexível para mudanças e facilita testes.
    /// É como se em vez de depender de uma marca específica de pilha, seu controle remoto
    /// funcionasse com qualquer pilha que tenha o tamanho e voltagem corretos.
    /// 
    /// NESTE EXEMPLO: O serviço de notificação não depende de tipos específicos de notificação
    /// (email, SMS), mas de uma interface genérica, permitindo adicionar novos tipos
    /// (como WhatsApp, Telegram) sem mudar o serviço.
    /// </summary>
    public interface ICanalNotificacao
    {
        /// <summary>
        /// Envia uma notificação com a mensagem especificada.
        /// </summary>
        /// <param mensagem="mensagem">A mensagem a ser enviada</param>
        void EnviarNotificacao(string mensagem);
    }

    /// <summary>
    /// D - Implementação de notificação por email.
    /// Inversão de Dependência (DIP): Implementação de baixo nível que depende de abstração.
    /// </summary>
    public class NotificacaoEmail : ICanalNotificacao
    {
        /// <summary>
        /// Envia uma notificação por email.
        /// </summary>
        /// <param mensagem="mensagem">A mensagem a ser enviada</param>
        public void EnviarNotificacao(string mensagem)
        {
            Console.WriteLine($"Enviando email: {mensagem}");
        }
    }

    /// <summary>
    /// D - Implementação de notificação por SMS.
    /// Inversão de Dependência (DIP): Outra implementação de baixo nível que depende de abstração.
    /// </summary>
    public class NotificacaoSMS : ICanalNotificacao
    {
        /// <summary>
        /// Envia uma notificação por SMS.
        /// </summary>
        /// <param mensagem="mensagem">A mensagem a ser enviada</param>
        public void EnviarNotificacao(string mensagem)
        {
            Console.WriteLine($"Enviando SMS: {mensagem}");
        }
    }

    /// <summary>
    /// D - Serviço de notificação que depende de abstração, não de implementações concretas.
    /// Inversão de Dependência (DIP): Módulo de alto nível dependendo de abstrações.
    /// </summary>
    public class ServicoNotificacao
    {
        private readonly IEnumerable<ICanalNotificacao> _canais;

        /// <summary>
        /// Inicializa uma nova instância do ServicoNotificacao.
        /// </summary>
        /// <param canais="canais">Coleção de canais de notificação</param>
        public ServicoNotificacao(IEnumerable<ICanalNotificacao> canais)
        {
            _canais = canais;
        }

        /// <summary>
        /// Notifica através de todos os canais disponíveis.
        /// </summary>
        /// <param mensagem="mensagem">A mensagem a ser enviada</param>
        public void Notificar(string mensagem)
        {
            foreach (var canal in _canais)
            {
                canal.EnviarNotificacao(mensagem);
            }
        }
    }

    #endregion
}
