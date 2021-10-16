-- MySQL Workbench Synchronization
-- Generated: 2021-10-15 16:49
-- Model: New Model
-- Version: 1.0
-- Project: Recolhaki

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

CREATE SCHEMA IF NOT EXISTS `recolhaki` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `recolhaki`.`Coletor` (
  `idColetor` INT(11) NOT NULL AUTO_INCREMENT,
  `Coletorcol` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`idColetor`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `recolhaki`.`Pessoa` (
  `idPessoa` INT(11) NOT NULL AUTO_INCREMENT,
  `cpf` VARCHAR(15) NOT NULL,
  `nome` VARCHAR(150) NOT NULL,
  `email` VARCHAR(30) NOT NULL,
  `rua` VARCHAR(150) NOT NULL,
  `cep` INT(11) NOT NULL,
  `numero` INT(11) NOT NULL,
  `complemento` VARCHAR(100) NOT NULL,
  `cidade` VARCHAR(100) NOT NULL,
  `bairro` VARCHAR(100) NOT NULL,
  `estado` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idPessoa`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `recolhaki`.`Avaliacao` (
  `idAvaliacao` INT(11) NOT NULL AUTO_INCREMENT,
  `descricao` VARCHAR(600) NOT NULL,
  `id_emoje` INT(11) NOT NULL,
  `Pessoa_idPessoa` INT(11) NOT NULL,
  `DoacaoMaterialReciclavel_idDoacaoMaterialReciclavel` INT(11) NOT NULL,
  PRIMARY KEY (`idAvaliacao`),
  INDEX `fk_Avaliacao_Pessoa1_idx` (`Pessoa_idPessoa` ASC) VISIBLE,
  INDEX `fk_Avaliacao_DoacaoMaterialReciclavel1_idx` (`DoacaoMaterialReciclavel_idDoacaoMaterialReciclavel` ASC) VISIBLE,
  CONSTRAINT `fk_Avaliacao_Pessoa1`
    FOREIGN KEY (`Pessoa_idPessoa`)
    REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Avaliacao_DoacaoMaterialReciclavel1`
    FOREIGN KEY (`DoacaoMaterialReciclavel_idDoacaoMaterialReciclavel`)
    REFERENCES `recolhaki`.`DoacaoMaterialReciclavel` (`idDoacaoMaterialReciclavel`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `recolhaki`.`DoacaoMaterialReciclavel` (
  `idDoacaoMaterialReciclavel` INT(11) NOT NULL AUTO_INCREMENT,
  `tipo` INT(11) NOT NULL,
  `nome` VARCHAR(50) NOT NULL,
  `peso` FLOAT(11) NOT NULL,
  `dataManifestacaoInteresse` DATETIME NOT NULL,
  `Pessoa_idPessoa` INT(11) NOT NULL,
  `Notificacao_idNotificacao` INT(11) NOT NULL,
  `Coletor_idColetor` INT(11) NOT NULL,
  PRIMARY KEY (`idDoacaoMaterialReciclavel`),
  INDEX `fk_DoacaoMaterialReciclavel_Pessoa1_idx` (`Pessoa_idPessoa` ASC) VISIBLE,
  INDEX `fk_DoacaoMaterialReciclavel_Notificacao1_idx` (`Notificacao_idNotificacao` ASC) VISIBLE,
  INDEX `fk_DoacaoMaterialReciclavel_Coletor1_idx` (`Coletor_idColetor` ASC) VISIBLE,
  CONSTRAINT `fk_DoacaoMaterialReciclavel_Pessoa1`
    FOREIGN KEY (`Pessoa_idPessoa`)
    REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DoacaoMaterialReciclavel_Notificacao1`
    FOREIGN KEY (`Notificacao_idNotificacao`)
    REFERENCES `recolhaki`.`Notificacao` (`idNotificacao`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DoacaoMaterialReciclavel_Coletor1`
    FOREIGN KEY (`Coletor_idColetor`)
    REFERENCES `recolhaki`.`Coletor` (`idColetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `recolhaki`.`Notificacao` (
  `idNotificacao` INT(11) NOT NULL AUTO_INCREMENT,
  `status` VARCHAR(45) NOT NULL,
  `descricao` VARCHAR(200) NOT NULL,
  `Pessoa_idPessoa` INT(11) NOT NULL,
  PRIMARY KEY (`idNotificacao`),
  INDEX `fk_Notificacao_Pessoa1_idx` (`Pessoa_idPessoa` ASC) VISIBLE,
  CONSTRAINT `fk_Notificacao_Pessoa1`
    FOREIGN KEY (`Pessoa_idPessoa`)
    REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `recolhaki`.`AutorizacaoColetor` (
  `Coletor_idColetor` INT(11) NOT NULL,
  `Pessoa_idPessoa` INT(11) NOT NULL,
  `dataAutorizacao` DATETIME NOT NULL,
  `statusAutorizacao` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Coletor_idColetor`, `Pessoa_idPessoa`),
  INDEX `fk_Coletor_has_Pessoa_Pessoa1_idx` (`Pessoa_idPessoa` ASC) VISIBLE,
  INDEX `fk_Coletor_has_Pessoa_Coletor1_idx` (`Coletor_idColetor` ASC) VISIBLE,
  CONSTRAINT `fk_Coletor_has_Pessoa_Coletor1`
    FOREIGN KEY (`Coletor_idColetor`)
    REFERENCES `recolhaki`.`Coletor` (`idColetor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Coletor_has_Pessoa_Pessoa1`
    FOREIGN KEY (`Pessoa_idPessoa`)
    REFERENCES `recolhaki`.`Pessoa` (`idPessoa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
