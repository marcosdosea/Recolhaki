-- MySQL Workbench Synchronization
-- Generated: 2021-12-02 20:18
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: marco

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

ALTER TABLE `recolhaki`.`avaliacao` 
DROP FOREIGN KEY `fk_Avaliacao_Pessoa1`,
DROP FOREIGN KEY `fk_Avaliacao_DoacaoMaterialReciclavel1`;

ALTER TABLE `recolhaki`.`doacaomaterialreciclavel` 
DROP FOREIGN KEY `fk_DoacaoMaterialReciclavel_Pessoa1`,
DROP FOREIGN KEY `fk_DoacaoMaterialReciclavel_Notificacao1`,
DROP FOREIGN KEY `fk_DoacaoMaterialReciclavel_Coletor1`;

ALTER TABLE `recolhaki`.`avaliacao` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
DROP COLUMN `DoacaoMaterialReciclavel_idDoacaoMaterialReciclavel`,
DROP COLUMN `Pessoa_idPessoa`,
ADD COLUMN `numeroEstrelas` INT(11) NOT NULL DEFAULT 0 AFTER `data`,
ADD COLUMN `idPessoa` INT(11) NOT NULL AFTER `numeroEstrelas`,
ADD COLUMN `idMaterialReciclavel` INT(11) NOT NULL AFTER `idPessoa`,
ADD COLUMN `tipo` ENUM('COMENTARIO', 'PROBLEMA') NOT NULL DEFAULT 'COMENTARIO' AFTER `idMaterialReciclavel`,
CHANGE COLUMN `descricao` `descricao` VARCHAR(200) NOT NULL ,
CHANGE COLUMN `id_emoje` `data` DATE NOT NULL ,
ADD INDEX `fk_Avaliacao_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
ADD INDEX `fk_Avaliacao_MaterialReciclavel1_idx` (`idMaterialReciclavel` ASC) VISIBLE,
DROP INDEX `fk_Avaliacao_DoacaoMaterialReciclavel1_idx` ,
DROP INDEX `fk_Avaliacao_Pessoa1_idx` ;
;

ALTER TABLE `recolhaki`.`doacaomaterialreciclavel` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ,
DROP COLUMN `Coletor_idColetor`,
DROP COLUMN `Notificacao_idNotificacao`,
DROP COLUMN `Pessoa_idPessoa`,
ADD COLUMN `statusColeta` ENUM('DISPONIVEL', 'SOLICITADO', 'ENTREGUE') NOT NULL DEFAULT 'DISPONIVEL' AFTER `dataSolicitacao`,
ADD COLUMN `statusNotificacao` ENUM('NENHUMA', 'NOTIFICADO', 'CONFIRMADO') NOT NULL DEFAULT 'NENHUMA' AFTER `statusColeta`,
ADD COLUMN `dataColeta` DATETIME NULL DEFAULT NULL AFTER `statusNotificacao`,
ADD COLUMN `dataNotificacao` DATETIME NULL DEFAULT NULL AFTER `dataColeta`,
ADD COLUMN `idPessoaColetor` INT(11) NULL DEFAULT NULL AFTER `dataNotificacao`,
ADD COLUMN `idEmpresa` INT(11) NULL DEFAULT NULL AFTER `idPessoaColetor`,
CHANGE COLUMN `idDoacaoMaterialReciclavel` `idMaterialReciclavel` INT(11) NOT NULL ,
CHANGE COLUMN `tipo` `tipo` ENUM('PAPEL', 'PLASTICO', 'VIDRO', 'ORGANICO', 'ELETRONICO', 'METAL') NOT NULL DEFAULT 'PAPEL' ,
CHANGE COLUMN `nome` `descricao` VARCHAR(100) NOT NULL ,
CHANGE COLUMN `peso` `pesoAproximado` FLOAT(11) NOT NULL ,
CHANGE COLUMN `dataManifestacaoInteresse` `dataSolicitacao` DATETIME NULL DEFAULT NULL ,
ADD INDEX `fk_MaterialReciclavel_Pessoa1_idx` (`idPessoaColetor` ASC) VISIBLE,
ADD INDEX `fk_MaterialReciclavel_Pessoa2_idx` (`idPessoaDoador` ASC) VISIBLE,
ADD INDEX `fk_MaterialReciclavel_Empresa1_idx` (`idEmpresa` ASC) VISIBLE,
DROP INDEX `fk_DoacaoMaterialReciclavel_Coletor1_idx` ,
DROP INDEX `fk_DoacaoMaterialReciclavel_Notificacao1_idx` ,
DROP INDEX `fk_DoacaoMaterialReciclavel_Pessoa1_idx` ;
, RENAME TO  `recolhaki`.`MaterialReciclavel` ;

ALTER TABLE `recolhaki`.`pessoa` 
CHARACTER SET = utf8 , COLLATE = utf8_general_ci ;

CREATE TABLE IF NOT EXISTS `recolhaki`.`Empresa` (
  `idEmpresa` INT(11) NOT NULL AUTO_INCREMENT,
  `cnpj` VARCHAR(11) NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `rua` VARCHAR(150) NOT NULL,
  `cep` INT(11) NOT NULL,
  `numero` INT(11) NOT NULL,
  `complemento` VARCHAR(100) NOT NULL,
  `cidade` VARCHAR(100) NOT NULL,
  `bairro` VARCHAR(100) NOT NULL,
  `estado` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idEmpresa`),
  UNIQUE INDEX `cnpj_UNIQUE` (`cnpj` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

CREATE TABLE IF NOT EXISTS `recolhaki`.`EmpresaColetor` (
  `idEmpresa` INT(11) NOT NULL,
  `idPessoa` INT(11) NOT NULL,
  `dataAutorizacao` DATETIME NOT NULL,
  `status` ENUM('ATIVO', 'INATIVO') NOT NULL DEFAULT 'INATIVO',
  `prazoColetaHoras` INT(11) NOT NULL DEFAULT 48,
  PRIMARY KEY (`idEmpresa`, `idPessoa`),
  INDEX `fk_EmpresaPessoa_Pessoa1_idx` (`idPessoa` ASC) VISIBLE,
  INDEX `fk_EmpresaPessoa_Empresa1_idx` (`idEmpresa` ASC) VISIBLE,
  CONSTRAINT `fk_EmpresaPessoa_Empresa1`
    FOREIGN KEY (`idEmpresa`)
    REFERENCES `recolhaki`.`Empresa` (`idEmpresa`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_EmpresaPessoa_Pessoa1`
    FOREIGN KEY (`idPessoa`)
    REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = latin1;

DROP TABLE IF EXISTS `recolhaki`.`notificacao` ;

DROP TABLE IF EXISTS `recolhaki`.`coletor` ;

DROP TABLE IF EXISTS `recolhaki`.`autorizacaocoletor` ;

ALTER TABLE `recolhaki`.`avaliacao` 
ADD CONSTRAINT `fk_Avaliacao_Pessoa1`
  FOREIGN KEY (`idPessoa`)
  REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
  ON DELETE CASCADE
  ON UPDATE CASCADE,
ADD CONSTRAINT `fk_Avaliacao_MaterialReciclavel1`
  FOREIGN KEY (`idMaterialReciclavel`)
  REFERENCES `recolhaki`.`MaterialReciclavel` (`idMaterialReciclavel`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;

ALTER TABLE `recolhaki`.`doacaomaterialreciclavel` 
ADD CONSTRAINT `fk_MaterialReciclavel_Pessoa1`
  FOREIGN KEY (`idPessoaColetor`)
  REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
  ON DELETE CASCADE
  ON UPDATE CASCADE,
ADD CONSTRAINT `fk_MaterialReciclavel_Pessoa2`
  FOREIGN KEY (`idPessoaDoador`)
  REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
  ON DELETE CASCADE
  ON UPDATE CASCADE,
ADD CONSTRAINT `fk_MaterialReciclavel_Empresa1`
  FOREIGN KEY (`idEmpresa`)
  REFERENCES `recolhaki`.`Empresa` (`idEmpresa`)
  ON DELETE CASCADE
  ON UPDATE CASCADE;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
