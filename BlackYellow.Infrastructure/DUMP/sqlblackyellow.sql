-- MySQL Script generated by MySQL Workbench
-- 06/07/17 11:07:36
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema BlackYellow
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema BlackYellow
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `BlackYellow` DEFAULT CHARACTER SET latin1 ;
USE `BlackYellow` ;

-- -----------------------------------------------------
-- Table `BlackYellow`.`Users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Users` (
  `UserId` INT(11) NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(200) NULL DEFAULT NULL,
  `Password` VARCHAR(200) NULL DEFAULT NULL,
  `Profile` INT(11) NOT NULL,
  PRIMARY KEY (`UserId`))
ENGINE = InnoDB
AUTO_INCREMENT = 55
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `BlackYellow`.`Customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Customers` (
  `CustomerId` INT(11) NOT NULL AUTO_INCREMENT,
  `FirstName` VARCHAR(500) NULL DEFAULT NULL,
  `LastName` VARCHAR(500) NULL DEFAULT NULL,
  `Birthday` DATE NOT NULL,
  `Cpf` VARCHAR(20) NULL DEFAULT NULL,
  `UserId` INT(11) NULL DEFAULT NULL,
  `Phone` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`CustomerId`),
  INDEX `UserId` (`UserId` ASC),
  CONSTRAINT `Customers_ibfk_1`
    FOREIGN KEY (`UserId`)
    REFERENCES `BlackYellow`.`Users` (`UserId`))
ENGINE = InnoDB
AUTO_INCREMENT = 35
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `BlackYellow`.`Adresses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Adresses` (
  `AddressId` INT(11) NOT NULL AUTO_INCREMENT,
  `Street` VARCHAR(800) NULL DEFAULT NULL,
  `Number` VARCHAR(200) NULL DEFAULT NULL,
  `ZipCode` VARCHAR(200) NULL DEFAULT NULL,
  `State` VARCHAR(200) NULL DEFAULT NULL,
  `City` VARCHAR(200) NULL DEFAULT NULL,
  `Street2` VARCHAR(500) NULL DEFAULT NULL,
  `CustomerId` INT(11) NOT NULL,
  PRIMARY KEY (`AddressId`),
  INDEX `CustomerId` (`CustomerId` ASC),
  CONSTRAINT `Adresses_ibfk_1`
    FOREIGN KEY (`CustomerId`)
    REFERENCES `BlackYellow`.`Customers` (`CustomerId`))
ENGINE = InnoDB
AUTO_INCREMENT = 25
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `BlackYellow`.`CartsItems`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`CartsItems` (
  `ItemCartId` INT(11) NOT NULL AUTO_INCREMENT,
  `ProductId` BIGINT(20) NOT NULL,
  `OrderId` BIGINT(20) NOT NULL,
  `Quantity` INT(11) NOT NULL,
  `Price` FLOAT NOT NULL,
  PRIMARY KEY (`ItemCartId`))
ENGINE = InnoDB
AUTO_INCREMENT = 64
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `BlackYellow`.`Categories`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Categories` (
  `CategoryId` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(200) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `Description` VARCHAR(8000) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  PRIMARY KEY (`CategoryId`))
ENGINE = InnoDB
AUTO_INCREMENT = 27
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `BlackYellow`.`Products`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Products` (
  `ProductId` INT(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(200) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `Description` VARCHAR(8000) CHARACTER SET 'utf8' NULL DEFAULT NULL,
  `Quantity` INT(11) NOT NULL,
  `Price` FLOAT NOT NULL,
  `DateRegister` DATETIME NOT NULL,
  `CategoryId` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`ProductId`),
  INDEX `fk_category_id` (`CategoryId` ASC),
  CONSTRAINT `fk_category_id`
    FOREIGN KEY (`CategoryId`)
    REFERENCES `BlackYellow`.`Categories` (`CategoryId`))
ENGINE = InnoDB
AUTO_INCREMENT = 55
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_unicode_ci;


-- -----------------------------------------------------
-- Table `BlackYellow`.`GaleryProducts`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`GaleryProducts` (
  `GaleryProdutctId` INT(11) NOT NULL AUTO_INCREMENT,
  `NameImage` VARCHAR(1000) NOT NULL,
  `PathImage` VARCHAR(1000) NOT NULL,
  `IsPrincipal` BIT(1) NOT NULL,
  `ProductId` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`GaleryProdutctId`),
  INDEX `ProductId` (`ProductId` ASC),
  CONSTRAINT `GaleryProducts_ibfk_1`
    FOREIGN KEY (`ProductId`)
    REFERENCES `BlackYellow`.`Products` (`ProductId`))
ENGINE = InnoDB
AUTO_INCREMENT = 124
DEFAULT CHARACTER SET = latin1;


-- -----------------------------------------------------
-- Table `BlackYellow`.`Orders`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `BlackYellow`.`Orders` (
  `OrderId` INT(11) NOT NULL AUTO_INCREMENT,
  `OrderDate` DATETIME NOT NULL,
  `CustomerId` BIGINT(20) NOT NULL,
  `OrderStatus` BIGINT(20) NOT NULL,
  `PaymentMethod` INT(11) NOT NULL,
  `PaymentDate` DATETIME NOT NULL,
  `TicketNumber` BIGINT(20) NULL DEFAULT NULL,
  `TotalOrder` DECIMAL(18,2) NULL DEFAULT NULL,
  PRIMARY KEY (`OrderId`),
  INDEX `CustomerId` (`CustomerId` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 49
DEFAULT CHARACTER SET = latin1;

USE `BlackYellow`;

DELIMITER $$
USE `BlackYellow`$$
CREATE
DEFINER=`root`@`%`
TRIGGER `BlackYellow`.`Orders_insert`
BEFORE INSERT ON `BlackYellow`.`Orders`
FOR EACH ROW
BEGIN
    SET NEW.TicketNumber = NEW.OrderId+1000000;
  END$$

USE `BlackYellow`$$
CREATE
DEFINER=`root`@`%`
TRIGGER `BlackYellow`.`Orders_update`
BEFORE UPDATE ON `BlackYellow`.`Orders`
FOR EACH ROW
BEGIN
    SET NEW.TicketNumber = NEW.OrderId+1000000;
  END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;