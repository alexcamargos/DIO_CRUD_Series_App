# Criando um APP simples de cadastro de séries em .NET :clapper:

Projeto desenvolvido durante a aula **Desafio de Projeto: Criando um APP simples de cadastro de séries em .NET** ministrada pelo instrutor [Eliézer Zarpelão](https://github.com/elizarp) como parte das atividades do bootcamp MRV .NET Developer oferecido pela [MRV](https://www.mrv.com.br) em parceria com a [Digital Innovation One](https://web.digitalinnovation.one).

## Objetivo

Criar um algoritmo simples de cadastro de séries com objetivo de fixar o aprendizado sobre orientação a objetos, o principal paradigma de programação utilizada no mercado. Durante o desenvolvimento fixaremos os pensamentos relacionando a orientado a objetos (modelagem de domínio, utilização de recursos e coleção).

## Conceitos iniciais

#### CRUD

**CRUD** é o acrônimo da expressão do idioma Inglês, **C**reate (Criação), **R**ead (Consulta), **U**pdate (Atualização) e **D**elete (Destruição). Este acrônimo é comumente utilizado para definir as quatro operações básicas usadas em Banco de Dados Relacionais.

#### Classes Abstratas

Uma *classe abstrata* tem o comportamento de uma "super classe" (classe pai), funciona apenas para ser herdada, não permite que se crie instâncias, faz com que as subclasses herdadas (filhas) tenham a mesma hierarquia. Podendo conter métodos completos ou incompletos.

Uma classe abstrata não suporta múltiplas heranças. Assim, uma classe pode implementar várias interfaces, mas apenas herdar de uma classe abstrata. Normalmente seus métodos são abstratos. Esses métodos são implementados nas classes herdadas concretas com o objetivo de definir o comportamento específico. O método abstrato define apenas a assinatura do método, portanto, não contém código. A classe filha será, então, forçada a definir tais métodos, pois, caso contrário, a classe filha também se tornará abstrata.

#### Interfaces

Uma *interface* contém definições para um grupo de funcionalidades relacionadas que uma classe não abstrata ou uma struct deve implementar. Uma interface pode definir static métodos, que devem ter uma implementação. Uma interface não pode declarar dados de instância, como campos, propriedades implementadas automaticamente ou eventos de propriedade.

Usando interfaces, você pode, por exemplo, incluir o comportamento de várias fontes em uma classe. Essa funcionalidade é importante em C# porque a linguagem não dá suporte a várias heranças de classes. Além disso, use uma interface se você deseja simular a herança para structs, pois eles não podem herdar de outro struct ou classe.

## Copyright

**Author**: Alexsander Lopes Camargos
**Author-email**: alcamargos@vivaldi.net


## License
**The MIT License**

-----

*Copyright 2021 - Alexsander Lopes Camargos*

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

-----

