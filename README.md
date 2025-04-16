# Princípios SOLID na Prática

Este projeto demonstra os cinco princípios SOLID de programação orientada a objetos com exemplos práticos em C#.

## O que são os Princípios SOLID?

SOLID é um acrônimo para cinco princípios de design em programação orientada a objetos que, quando aplicados corretamente, tornam o código mais fácil de manter, entender e estender:

### S - Single Responsibility Principle (Princípio da Responsabilidade Única)
- **O que é:** Uma classe deve ter apenas uma razão para mudar, ou seja, deve ter apenas uma responsabilidade.
- **Por que é importante:** Reduz a complexidade, facilita a manutenção e testes.
- **Exemplo no projeto:** Classes `Usuario`, `RepositorioUsuarioBancoDados` e `ServicoUsuario` têm responsabilidades claramente separadas.

### O - Open/Closed Principle (Princípio Aberto/Fechado)
- **O que é:** Entidades de software devem estar abertas para extensão, mas fechadas para modificação.
- **Por que é importante:** Permite adicionar novos recursos sem alterar código existente.
- **Exemplo no projeto:** Interface `IForma` e classes `Retangulo` e `Circulo` demonstram como adicionar novas formas sem modificar a `CalculadoraArea`.

### L - Liskov Substitution Principle (Princípio da Substituição de Liskov)
- **O que é:** Objetos de uma classe derivada devem poder substituir objetos da classe base sem afetar a correção do programa.
- **Por que é importante:** Garante que herança seja usada corretamente.
- **Exemplo no projeto:** Classes `Pardal` e `Avestruz` que herdam de `Passaro` implementam seus comportamentos sem quebrar o contrato.

### I - Interface Segregation Principle (Princípio da Segregação de Interface)
- **O que é:** É melhor ter muitas interfaces específicas do que uma única interface genérica.
- **Por que é importante:** Evita que classes implementem métodos que não vão usar.
- **Exemplo no projeto:** Interfaces separadas `IImpressora`, `IScanner` e `IFax` permitem implementações específicas para cada dispositivo.

### D - Dependency Inversion Principle (Princípio da Inversão de Dependência)
- **O que é:** Módulos de alto nível não devem depender de módulos de baixo nível. Ambos devem depender de abstrações.
- **Por que é importante:** Reduz o acoplamento e aumenta a flexibilidade e testabilidade.
- **Exemplo no projeto:** `ServicoNotificacao` depende da abstração `ICanalNotificacao`, não de implementações concretas.

## Como Executar o Projeto

1. Certifique-se de ter o .NET SDK instalado (este projeto usa .NET 9.0)
2. Clone o repositório
3. Navegue até a pasta do projeto
4. Execute o projeto com o comando:
   ```
   dotnet run
   ```

## Estrutura do Projeto

- `Program.cs` - Contém o ponto de entrada da aplicação e exemplos de todos os princípios SOLID
- Cada região do código (#region) representa um princípio SOLID com exemplos práticos
- Cada classe e interface possui comentários explicativos que detalham como ela exemplifica um princípio SOLID

## Por que Estudar SOLID?

Aplicar os princípios SOLID traz diversos benefícios:

- **Código mais legível e manutenível**
- **Facilidade para testar**
- **Redução de acoplamento**
- **Facilidade para estender funcionalidades**
- **Reutilização de código**

Este projeto serve como um guia prático para entender como aplicar estes princípios em situações reais de desenvolvimento de software.