-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: extensometer
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `user_score`
--

DROP TABLE IF EXISTS `user_score`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_score` (
  `user_name` varchar(15) NOT NULL,
  `height` float NOT NULL,
  `shoulder_length` float NOT NULL,
  `shoulder_angle` float NOT NULL,
  `head` float NOT NULL,
  `score` int(11) NOT NULL,
  `idx` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`idx`),
  KEY `user_name` (`user_name`),
  CONSTRAINT `user_score_ibfk_1` FOREIGN KEY (`user_name`) REFERENCES `user` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_score`
--

LOCK TABLES `user_score` WRITE;
/*!40000 ALTER TABLE `user_score` DISABLE KEYS */;
INSERT INTO `user_score` VALUES ('유경찬',158,35,0,6,51,5),('유경찬',158,35,0,6,51,6),('유경찬',158,35,0,6,51,7),('유경찬',158,35,0,6,51,8),('유경찬',158,35,0,6,51,9),('유경찬',158,35,0,6,51,10),('유경찬',158,35,0,6,51,11),('8등신한석민',177,0,1,8,65,12),('9등신하늘썜',173,0,1,9,60,13),('상호 등신',180,0,1,6,65,14),('신상호',179,0,1,7,65,15),('신상호',179,0,1,7,65,16),('신상호',179,0,1,7,65,17),('신현삼선생님',221,5,1,3,70,18),('신현삼선생님',179,10,-1,6,65,19),('박주희선생님',161,42,1,5,60,20);
/*!40000 ALTER TABLE `user_score` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-06-13 11:35:01
