CREATE DATABASE  IF NOT EXISTS `nhibernate_learning` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `nhibernate_learning`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: nhibernate_learning
-- ------------------------------------------------------
-- Server version	5.5.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Province` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (1,'Buddy','Toups',NULL,NULL,NULL,NULL),(2,'Courtney','Toups',NULL,NULL,NULL,NULL),(3,'Steve','Jobs',NULL,NULL,NULL,NULL),(4,'Bill','Crystal','1234 Some Street','Houston','TX','US'),(5,'Bill','Crystal','1234 Some Street','Houston','TX','US'),(7,'Bill','Crystal','1234 Some Street','Houston','TX','US'),(8,'Bill','Crystal','1234 Some Street','Houston','TX','US');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `Id` char(36) NOT NULL,
  `CustomerId` int(11) DEFAULT NULL,
  `Ordered` datetime DEFAULT NULL,
  `Shipped` datetime DEFAULT NULL,
  `Street` varchar(45) DEFAULT NULL,
  `City` varchar(45) DEFAULT NULL,
  `Province` varchar(45) DEFAULT NULL,
  `Country` varchar(45) DEFAULT NULL,
  `MemberSince` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES ('0dfce56e-25e2-4648-a23b-a285015a9558',8,'2013-11-29 21:01:52',NULL,NULL,NULL,NULL,NULL,NULL),('956ddc87-e6a0-425a-9117-a2850156a0c8',5,'2013-11-28 20:47:28','2013-11-29 20:47:28','1234 Some Street','Houston','TX','US',NULL),('b4518241-cf87-4d3e-bff8-a28501555c50',4,'2013-11-29 20:42:51',NULL,NULL,NULL,NULL,NULL,NULL),('c9270eae-b6c7-49c3-b9e1-a28501555c4e',4,'2013-11-28 20:42:51','2013-11-29 20:42:51','1234 Some Street','Houston','TX','US',NULL),('e1289028-74ee-47f5-bd29-a2850156a0c9',5,'2013-11-29 20:47:28',NULL,NULL,NULL,NULL,NULL,NULL),('f61a68d6-478e-4c5c-a4a8-a285015a9556',8,'2013-11-28 21:01:52','2013-11-29 21:01:52','1234 Some Street','Houston','TX','US',NULL);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-12-04 13:57:25
