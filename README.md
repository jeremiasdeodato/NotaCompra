# NotaCompra

Sistema para pesquisa e aprovação de notas de compra.

## Tecnologias Utilizadas

- Api em .NET 6
- Banco de Dados MySQL.

## Configuração para montar o ambiente

Será necessária criar o banco de dados e as tabelas, para poder rodar a aplicação em seguida criar um usuário e começar a utilizar.

```bash
- Criação do Banco de Dados:

  CREATE DATABASE `microuniverso` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

- Criação das Tabelas:

CREATE TABLE `faixa_valor_aprovacao` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ValorMinimo` decimal(10,2) NOT NULL,
  `ValorMaximo` decimal(10,2) NOT NULL,
  `VistosNecessarios` smallint NOT NULL,
  `AprovacoesNecessarias` smallint NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `historico_aprovacao` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UsuarioId` varchar(100) NOT NULL,
  `Data` datetime NOT NULL,
  `Operacao` smallint NOT NULL,
  `NotaCompraId` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Usuario_HistoricoAprovacao` (`UsuarioId`),
  KEY `FK_Nota_Compra_Historico_Aprovacao` (`NotaCompraId`),
  CONSTRAINT `FK_Nota_Compra_Historico_Aprovacao` FOREIGN KEY (`NotaCompraId`) REFERENCES `nota_compra` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Usuario_HistoricoAprovacao` FOREIGN KEY (`UsuarioId`) REFERENCES `usuario` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `nota_compra` (
  `Id` varchar(100) NOT NULL,
  `ValorMercadorias` decimal(10,0) NOT NULL,
  `ValorDesconto` decimal(10,0) NOT NULL,
  `ValorFrete` decimal(10,0) NOT NULL,
  `ValorTotal` decimal(10,0) NOT NULL,
  `DataDeEmissao` datetime NOT NULL,
  `Status` smallint NOT NULL,
  `Ativo` bit(1) NOT NULL,
  `DataCriacao` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `usuario` (
  `Id` varchar(100) NOT NULL,
  `Login` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Senha` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Papel` smallint NOT NULL,
  `ValorMinimo` decimal(10,0) NOT NULL,
  `ValorMaximo` decimal(10,0) NOT NULL,
  `DataCriacao` datetime DEFAULT NULL,
  `Ativo` bit(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
