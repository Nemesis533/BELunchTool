CREATE DATABASE  IF NOT EXISTS `be_lunch_tool` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `be_lunch_tool`;
-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: bfgmysql    Database: be_lunch_tool
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `lunch_options`
--

DROP TABLE IF EXISTS `lunch_options`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lunch_options` (
  `lunch_id` int NOT NULL AUTO_INCREMENT,
  `lunch_desc` varchar(255) DEFAULT NULL,
  `lunch_type` int DEFAULT NULL,
  `lunch_stock_qty` int DEFAULT '0',
  `lunch_cost` decimal(10,1) DEFAULT '0.0',
  `lunch_price` decimal(10,1) DEFAULT '0.0',
  `lunch_supplier_code` varchar(100) DEFAULT NULL,
  `lunch_be_code` varchar(100) DEFAULT NULL,
  `lunch_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`lunch_id`),
  UNIQUE KEY `lunch_be-code_UNIQUE` (`lunch_be_code`),
  UNIQUE KEY `lunch_supplier_code_UNIQUE` (`lunch_supplier_code`),
  UNIQUE KEY `lunch_name_UNIQUE` (`lunch_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lunch_options`
--

LOCK TABLES `lunch_options` WRITE;
/*!40000 ALTER TABLE `lunch_options` DISABLE KEYS */;
/*!40000 ALTER TABLE `lunch_options` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lunch_to_lunch_type_match`
--

DROP TABLE IF EXISTS `lunch_to_lunch_type_match`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lunch_to_lunch_type_match` (
  `lunch_match_id` int NOT NULL AUTO_INCREMENT,
  `lunch_id` int DEFAULT NULL,
  `lunch_type_id` int DEFAULT NULL,
  PRIMARY KEY (`lunch_match_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lunch_to_lunch_type_match`
--

LOCK TABLES `lunch_to_lunch_type_match` WRITE;
/*!40000 ALTER TABLE `lunch_to_lunch_type_match` DISABLE KEYS */;
/*!40000 ALTER TABLE `lunch_to_lunch_type_match` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lunch_type_table`
--

DROP TABLE IF EXISTS `lunch_type_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lunch_type_table` (
  `lunch_type_id` int NOT NULL AUTO_INCREMENT,
  `lunch_type_desc` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`lunch_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lunch_type_table`
--

LOCK TABLES `lunch_type_table` WRITE;
/*!40000 ALTER TABLE `lunch_type_table` DISABLE KEYS */;
INSERT INTO `lunch_type_table` VALUES (1,'Antipasto'),(2,'Primo Piatto'),(3,'Secondo Piatto'),(4,'Dessert'),(5,'Bevanda');
/*!40000 ALTER TABLE `lunch_type_table` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_purchases`
--

DROP TABLE IF EXISTS `user_purchases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_purchases` (
  `user_purchase_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int DEFAULT NULL,
  `lunch_id` int DEFAULT NULL,
  `date` date DEFAULT NULL,
  `status` int DEFAULT NULL,
  `changed_date` date DEFAULT NULL,
  `status_changed_by` int DEFAULT NULL,
  PRIMARY KEY (`user_purchase_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_purchases`
--

LOCK TABLES `user_purchases` WRITE;
/*!40000 ALTER TABLE `user_purchases` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_purchases` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `user_purchases_AFTER_INSERT` AFTER INSERT ON `user_purchases` FOR EACH ROW BEGIN
	INSERT INTO user_purchases_log (
			user_purchase_id,
			old_row_data,
			new_row_data,
			dml_type,
			dml_timestamp,
			dml_created_by
		)
		VALUES(
			NEW.user_purchase_id,
			null,
			JSON_OBJECT(
				"user_purchase_id", NEW.user_purchase_id,
				"user_id", NEW.user_id,
				"lunch_id", NEW.lunch_id,
				"date", NEW.date,
				"status", NEW.status,
                "changed_date", NEW.changed_date,
                "status_changed_by", NEW.status_changed_by
			),
			'INSERT',
			CURRENT_TIMESTAMP,
			@logged_user
		);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`%`*/ /*!50003 TRIGGER `user_purchases_AFTER_UPDATE` AFTER UPDATE ON `user_purchases` FOR EACH ROW BEGIN
	INSERT INTO user_purchases_log (
			user_purchase_id,
			old_row_data,
			new_row_data,
			dml_type,
			dml_timestamp,
			dml_created_by
		)
		VALUES(
			NEW.user_purchase_id,
			JSON_OBJECT(
				"old_user_purchase_id", OLD.user_purchase_id,
				"old_user_id",OLD.user_id,
				"old_lunch_id", OLD.lunch_id,
				"old_date", OLD.date,
				"old_status", OLD.status,
                "old_changed_date", OLD.changed_date,
                "old__status_changed_by", OLD.status_changed_by
			),
			JSON_OBJECT(
				"new_user_purchase_id", NEW.user_purchase_id,
				"new_user_id", NEW.user_id,
				"new_lunch_id", NEW.lunch_id,
				"new_date", NEW.date,
				"new_status", NEW.status,
                "new_changed_date", NEW.changed_date,
                "new_status_changed_by", NEW.status_changed_by
			),
			'INSERT',
			CURRENT_TIMESTAMP,
			@logged_user
		);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `user_purchases_log`
--

DROP TABLE IF EXISTS `user_purchases_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_purchases_log` (
  `purchase_log_id` int NOT NULL AUTO_INCREMENT,
  `user_purchase_id` int DEFAULT NULL,
  `old_row_data` longtext,
  `new_row_data` longtext,
  `dml_type` enum('INSERT','UPDATE','DELETE') DEFAULT NULL,
  `dml_timestamp` timestamp NULL DEFAULT NULL,
  `dml_created_by` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`purchase_log_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_purchases_log`
--

LOCK TABLES `user_purchases_log` WRITE;
/*!40000 ALTER TABLE `user_purchases_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_purchases_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'be_lunch_tool'
--

--
-- Dumping routines for database 'be_lunch_tool'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-09 19:25:24
