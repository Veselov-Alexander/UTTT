-- MySQL Script generated by MySQL Workbench
-- Sun Jul 15 13:13:10 2018
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema uttt
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema uttt
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `uttt` DEFAULT CHARACTER SET utf8 ;
-- -----------------------------------------------------
-- Schema uttt
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema uttt
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `uttt` DEFAULT CHARACTER SET utf8 ;
USE `uttt` ;
USE `uttt` ;

-- -----------------------------------------------------
-- Table `uttt`.`achievement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `uttt`.`achievement` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `title` VARCHAR(45) NOT NULL,
  `description` VARCHAR(500) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `title_UNIQUE` (`title` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 9
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `uttt`.`game`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `uttt`.`game` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `moves` VARCHAR(5000) NOT NULL,
  `date` DATETIME NOT NULL,
  `winner` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 23
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `uttt`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `uttt`.`user` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `rank` INT(11) NULL DEFAULT '1000',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `login_UNIQUE` (`login` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 24
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `uttt`.`user_has_an_achievement`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `uttt`.`user_has_an_achievement` (
  `Achievement_id` INT(11) NOT NULL,
  `User_id` INT(11) NOT NULL,
  PRIMARY KEY (`Achievement_id`, `User_id`),
  INDEX `fk_User_has_an_achievement_Achievement_idx` (`Achievement_id` ASC),
  INDEX `fk_User_has_an_achievement_User1_idx` (`User_id` ASC),
  CONSTRAINT `fk_User_has_an_achievement_Achievement`
    FOREIGN KEY (`Achievement_id`)
    REFERENCES `uttt`.`achievement` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_has_an_achievement_User1`
    FOREIGN KEY (`User_id`)
    REFERENCES `uttt`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `uttt`.`user_played_the_game`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `uttt`.`user_played_the_game` (
  `User_id` INT(11) NOT NULL,
  `Game_id` INT(11) NOT NULL,
  PRIMARY KEY (`User_id`, `Game_id`),
  INDEX `fk_User_played_the_game_User1_idx` (`User_id` ASC),
  INDEX `fk_User_played_the_game_Game1_idx` (`Game_id` ASC),
  CONSTRAINT `fk_User_played_the_game_Game1`
    FOREIGN KEY (`Game_id`)
    REFERENCES `uttt`.`game` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_User_played_the_game_User1`
    FOREIGN KEY (`User_id`)
    REFERENCES `uttt`.`user` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;