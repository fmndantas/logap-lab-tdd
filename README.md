# TDD - Logap LAB

## Objetivos

- Praticar TDD com testes unitários
- Praticar testes de integração

## Especificações

Crie um serviço que salve endereços válidos de e-mail. Considere que um e-mail é inicialmente salvo como inativo.

O serviço deve permitir ativar/desativar endereços de e-mail em lote.

### Regras para um e-mail válido

Um endereço de e-mail válido contém somente um caractere `@`. 

O que vem antes do `@` só pode ter caracteres `a-z` ou `0-9`.

O que vem após o `@` (domínio) deve ter um exatamente um ponto (`.`). Cada fragmento do domínio só pode ter
caracteres `a-z`.
