# Microsserviço Gateway
    Responsável por fazer a autenticação e gestão de contas de usuários.

### Endpoints:
    - create-account
        realiza criação de conta para um usuário, utiliza BCrypt para criptografar a senha com um salt de 10.
    - login
        realiza login da conta do usuário
