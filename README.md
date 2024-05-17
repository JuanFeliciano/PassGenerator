# PasswordStore

PasswordStore é um projeto simples em C# para gerenciar senhas, permitindo gerar senhas aleatórias com base em critérios definidos pelo usuário, buscar senhas por nome, editar senhas existentes, remover senhas e listar todas as senhas armazenadas.

## Funcionalidades

- **Gerar Senha:** Crie senhas aleatórias baseadas em comprimento e caracteres definidos pelo usuário (letras maiúsculas, minúsculas, números e caracteres especiais).
- **Buscar Senha:** Busque senhas armazenadas pelo nome.
- **Remover Senha:** Remova senhas armazenadas.
- **Editar Senha:** Edite senhas existentes e, se desejado, altere o nome associado.
- **Listar Todas as Senhas:** Exiba todas as senhas armazenadas no sistema.

## Estrutura do Projeto

O projeto está dividido nas seguintes classes:

- **MainProgram:** Classe principal que gerencia o fluxo do programa.
- **PasswordEntry:** Modelo que representa uma entrada de senha.
- **GeneratePass:** Lida com a geração de novas senhas.
- **GenerateRandomPassword:** Gera a senha aleatória com base nos critérios do usuário.
- **SearchPass:** Realiza a busca de senhas pelo nome.
- **RemovePass:** Remove uma senha específica.
- **EditPass:** Edita uma senha existente.
- **CatchAll:** Lista todas as senhas armazenadas.

## Como Utilizar

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/PasswordStore.git
    cd PasswordStore
    ```

2. Abra o projeto em seu IDE preferido e execute a aplicação.

3. Na execução, você verá o menu principal com as opções:
    ```
    Escolha uma opção:
    1- Gerar uma nova senha
    2- Buscar uma senha (nome)
    3- Remover senha salva
    4- Editar
    5- Buscar todas as senhas
    6- Sair
    ```

### Gerar Senha

Escolha a opção `1` para gerar uma nova senha. O sistema solicitará:
- Comprimento da senha (até 50 caracteres)
- Inclusão de letras maiúsculas, minúsculas, números e caracteres especiais
- Nome para a senha gerada

### Buscar Senha

Escolha a opção `2` para buscar uma senha pelo nome. Digite o nome ou parte do nome da senha que deseja buscar.

### Remover Senha

Escolha a opção `3` para remover uma senha. Digite o nome da senha que deseja remover.

### Editar Senha

Escolha a opção `4` para editar uma senha. O sistema permitirá:
- Alterar o comprimento da senha
- Alterar os tipos de caracteres inclusos
- Alterar o nome da senha

### Listar Todas as Senhas

Escolha a opção `5` para listar todas as senhas armazenadas no sistema.

### Sair

Escolha a opção `6` para sair do programa.

## Exemplo de Uso
  ```
  Escolha uma opção:
  1- Gerar uma nova senha
  2- Buscar uma senha (nome)
  3- Remover senha salva
  4- Editar
  5- Buscar todas as senhas
  6- Sair
  1
  Digite o tamanho desejado para sua senha (Tamanho MAX = 50): 12
  Incluir letras maiúsculas? (s/n): s
  Incluir letras minúsculas? (s/n): s
  Incluir caracteres especiais? (s/n): s
  Incluir números? (s/n): s
  Digite um nome para sua senha: GitHub
  Senha Gerada: A1b2C3d4E5!@
  ```

## Contribuições

Sinta-se à vontade para contribuir com o projeto, seja corrigindo bugs, melhorando a documentação ou adicionando novas funcionalidades.

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/MinhaFeature`)
3. Commit suas alterações (`git commit -m 'Adiciona MinhaFeature'`)
4. Push para a branch (`git push origin feature/MinhaFeature`)
5. Abra um Pull Request

---

