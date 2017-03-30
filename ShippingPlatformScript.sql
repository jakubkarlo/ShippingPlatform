-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: shippingplatform
-- ------------------------------------------------------
-- Server version	5.7.17-log

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
-- Table structure for table `addresses`
--

DROP TABLE IF EXISTS `addresses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `addresses` (
  `addressID` int(11) NOT NULL AUTO_INCREMENT,
  `country` varchar(45) DEFAULT NULL,
  `city` varchar(45) DEFAULT NULL,
  `zipcode` varchar(45) DEFAULT NULL,
  `street` varchar(45) DEFAULT NULL,
  `housenumber` int(11) DEFAULT NULL,
  PRIMARY KEY (`addressID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `addresses`
--

LOCK TABLES `addresses` WRITE;
/*!40000 ALTER TABLE `addresses` DISABLE KEYS */;
INSERT INTO `addresses` VALUES (1,'Poland','Lodz','93-367','Okregowa',55),(2,'Austria','Dornbirn','6850','Jahngasse',20);
/*!40000 ALTER TABLE `addresses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clients` (
  `clientID` int(11) NOT NULL AUTO_INCREMENT,
  `clientAddressID` int(11) DEFAULT NULL,
  `orderID` int(11) DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `emailAddress` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`clientID`),
  KEY `FK_clientID_orderID_idx` (`orderID`),
  KEY `FK_clients_clientAddressID_addresses_idx` (`clientAddressID`),
  CONSTRAINT `FK_clients_clientAddressID_addresses` FOREIGN KEY (`clientAddressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_clients_orderID_orders` FOREIGN KEY (`orderID`) REFERENCES `orders` (`orderID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clients`
--

LOCK TABLES `clients` WRITE;
/*!40000 ALTER TABLE `clients` DISABLE KEYS */;
INSERT INTO `clients` VALUES (1,1,1,'janusz','mariusz','janusz@siema.pl');
/*!40000 ALTER TABLE `clients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logistic_centers`
--

DROP TABLE IF EXISTS `logistic_centers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logistic_centers` (
  `logisticCenterID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `addressID` int(11) DEFAULT NULL,
  `shippingRouteID` int(11) DEFAULT NULL,
  PRIMARY KEY (`logisticCenterID`),
  KEY `addressID_idx` (`addressID`),
  KEY `FK_logCentre_shipRoute_idx` (`shippingRouteID`),
  CONSTRAINT `FK_logCentre_addressID_addresses` FOREIGN KEY (`addressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_logCentre_shipRouteID_routes` FOREIGN KEY (`shippingRouteID`) REFERENCES `routes` (`routeID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logistic_centers`
--

LOCK TABLES `logistic_centers` WRITE;
/*!40000 ALTER TABLE `logistic_centers` DISABLE KEYS */;
INSERT INTO `logistic_centers` VALUES (1,'Kolpinghaus Center',2,1);
/*!40000 ALTER TABLE `logistic_centers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notifications`
--

DROP TABLE IF EXISTS `notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `notifications` (
  `notificationID` int(11) NOT NULL AUTO_INCREMENT,
  `clientEmail` varchar(45) DEFAULT NULL,
  `recipientEmail` varchar(45) DEFAULT NULL,
  `message` varchar(45) DEFAULT NULL,
  `subject` varchar(45) DEFAULT NULL,
  `timestamp` datetime(6) DEFAULT NULL,
  `orderID` int(11) DEFAULT NULL,
  `attachmentID` int(11) DEFAULT NULL,
  PRIMARY KEY (`notificationID`),
  KEY `FK_notif_orders_idx` (`orderID`),
  CONSTRAINT `FK_notif_orderID_orders` FOREIGN KEY (`orderID`) REFERENCES `orders` (`orderID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notifications`
--

LOCK TABLES `notifications` WRITE;
/*!40000 ALTER TABLE `notifications` DISABLE KEYS */;
INSERT INTO `notifications` VALUES (1,'janusz@siema.pl','entschuldigung@yahu.com','hello','greetin','2012-12-12 12:00:00.000000',1,1);
/*!40000 ALTER TABLE `notifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `orders` (
  `orderID` int(11) NOT NULL AUTO_INCREMENT,
  `recipientAddressID` int(11) DEFAULT NULL,
  `clientAddressID` int(11) DEFAULT NULL,
  `referenceNumber` varchar(45) DEFAULT NULL,
  `createdDate` datetime DEFAULT NULL,
  `pickupDate` datetime DEFAULT NULL,
  `deliveryDate` datetime DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`orderID`),
  KEY `FK_order_clientAddress_addresses_addressID_idx` (`clientAddressID`),
  KEY `FK_orders_recipientAddress_idx` (`recipientAddressID`),
  CONSTRAINT `FK_orders_clientAddressID_addresses` FOREIGN KEY (`clientAddressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_orders_recipientAddressID_addresses` FOREIGN KEY (`recipientAddressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,2,1,'232345','2012-12-11 12:00:00','2012-12-12 12:00:00','2012-12-13 12:00:00','in progress');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `packages`
--

DROP TABLE IF EXISTS `packages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `packages` (
  `packageID` int(11) NOT NULL AUTO_INCREMENT,
  `height` double DEFAULT NULL,
  `width` double DEFAULT NULL,
  `depth` double DEFAULT NULL,
  `weight` double DEFAULT NULL,
  `content` varchar(45) DEFAULT NULL,
  `orderID` int(11) DEFAULT NULL,
  PRIMARY KEY (`packageID`),
  KEY `FK_packages_orderID_orders_idx` (`orderID`),
  CONSTRAINT `FK_packages_orderID_orders` FOREIGN KEY (`orderID`) REFERENCES `orders` (`orderID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `packages`
--

LOCK TABLES `packages` WRITE;
/*!40000 ALTER TABLE `packages` DISABLE KEYS */;
INSERT INTO `packages` VALUES (1,20,30,20,5,'stuff',1);
/*!40000 ALTER TABLE `packages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `routes`
--

DROP TABLE IF EXISTS `routes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `routes` (
  `routeID` int(11) NOT NULL AUTO_INCREMENT,
  `startAddressID` int(11) DEFAULT NULL,
  `endAddressID` int(11) DEFAULT NULL,
  `startTime` datetime DEFAULT NULL,
  `endTime` datetime DEFAULT NULL,
  `orderID` int(11) DEFAULT NULL,
  PRIMARY KEY (`routeID`),
  KEY `FK_startAddr_address_idx` (`startAddressID`),
  KEY `FK_endAddr_address_idx` (`endAddressID`),
  KEY `FK_routes_orderID_orders_idx` (`orderID`),
  CONSTRAINT `FK_routes_endAddressID_address` FOREIGN KEY (`endAddressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_routes_orderID_orders` FOREIGN KEY (`orderID`) REFERENCES `orders` (`orderID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_routes_startAddressID_address` FOREIGN KEY (`startAddressID`) REFERENCES `addresses` (`addressID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `routes`
--

LOCK TABLES `routes` WRITE;
/*!40000 ALTER TABLE `routes` DISABLE KEYS */;
INSERT INTO `routes` VALUES (1,1,2,'2012-12-12 12:00:00','2012-12-13 12:00:00',1);
/*!40000 ALTER TABLE `routes` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-03-30 18:25:15
