CREATE DATABASE  IF NOT EXISTS `e_learning` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `e_learning`;
-- MySQL dump 10.13  Distrib 5.6.26, for Win64 (x86_64)
--
-- Host: localhost    Database: e_learning
-- ------------------------------------------------------
-- Server version	5.6.26-log

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
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `courses`
--

LOCK TABLES `courses` WRITE;
/*!40000 ALTER TABLE `courses` DISABLE KEYS */;
INSERT INTO `courses` VALUES ('627dacc6-64e0-4beb-959e-3f3ddc0741cb','Python','Python Programming (Batch 1)','2022-01-01 00:00:00','2022-04-01 00:00:00',50000,'python.png','2023-01-05 14:52:03','2024-02-21 01:49:18',0),('8d565454-ad9b-46cc-934a-ace3aadbc0fb','Java','Java Programming','0001-01-01 00:00:00','0001-01-01 00:00:00',50000,'java.png','2023-01-05 14:52:56','2024-02-21 01:22:54',0),('97fbfbd0-8c6e-11ed-9349-2fa6b599df91','C#','C Sharp Programming Course','2023-01-01 00:00:00','2022-04-01 00:00:00',4000,'Csharp.jpg','2023-01-05 02:59:58','2024-02-21 01:26:41',0),('a77769cb-dffd-4280-b9c2-58b3c416036b','HTML','Hyper Text Markup Language','2020-01-01 00:00:00','2021-01-01 00:00:00',30000,'html.png','2023-01-09 16:57:46','2024-02-21 01:27:47',0),('a7b51492-8c6e-11ed-9349-2fa6b599df91','PHP','PHP Programming Course','2023-01-01 00:00:00','2022-04-01 00:00:00',3000,'php.png','2023-01-05 03:00:24','2024-02-21 01:28:19',0),('f14924fa-f18f-4fb1-9795-86bfec068351','Android Basic','Android Basic Bath 1','2024-03-01 00:00:00','2024-04-30 00:00:00',300000,'android.png','2024-02-21 01:29:34',NULL,0);
/*!40000 ALTER TABLE `courses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,'Class',NULL,1,NULL,NULL,NULL,NULL,NULL),(2,'Course',NULL,2,NULL,NULL,NULL,NULL,NULL),(3,'Menu',NULL,3,NULL,NULL,NULL,NULL,NULL),(4,'Student',NULL,4,NULL,NULL,NULL,NULL,NULL),(5,'Teacher',NULL,5,NULL,NULL,NULL,NULL,NULL),(6,'User',NULL,6,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `menu_permission`
--

LOCK TABLES `menu_permission` WRITE;
/*!40000 ALTER TABLE `menu_permission` DISABLE KEYS */;
INSERT INTO `menu_permission` VALUES ('mp_47278999-dacd-11ee-946e-e8fb1cd7d252',1,'caa7ae64-956c-11ed-9838-3b1dde067e67','create,export,update,'),('mp_472790ae-dacd-11ee-946e-e8fb1cd7d252',2,'caa7ae64-956c-11ed-9838-3b1dde067e67','create,update,delete,'),('mp_472791c3-dacd-11ee-946e-e8fb1cd7d252',3,'caa7ae64-956c-11ed-9838-3b1dde067e67','create,delete,export,view,'),('mp_47279256-dacd-11ee-946e-e8fb1cd7d252',4,'caa7ae64-956c-11ed-9838-3b1dde067e67','create,delete,update,view,export'),('mp_47279301-dacd-11ee-946e-e8fb1cd7d252',5,'caa7ae64-956c-11ed-9838-3b1dde067e67','create,delete,update,view,export'),('mp_47279398-dacd-11ee-946e-e8fb1cd7d252',6,'caa7ae64-956c-11ed-9838-3b1dde067e67','delete,export,update,view,'),('mp_47279430-dacd-11ee-946e-e8fb1cd7d252',1,'caa7fd32-956c-11ed-9838-3b1dde067e67','view'),('mp_47279542-dacd-11ee-946e-e8fb1cd7d252',2,'caa7fd32-956c-11ed-9838-3b1dde067e67','view'),('mp_47279626-dacd-11ee-946e-e8fb1cd7d252',3,'caa7fd32-956c-11ed-9838-3b1dde067e67','view'),('mp_472796b4-dacd-11ee-946e-e8fb1cd7d252',4,'caa7fd32-956c-11ed-9838-3b1dde067e67','view'),('mp_47279726-dacd-11ee-946e-e8fb1cd7d252',5,'caa7fd32-956c-11ed-9838-3b1dde067e67','view'),('mp_472797a3-dacd-11ee-946e-e8fb1cd7d252',6,'caa7fd32-956c-11ed-9838-3b1dde067e67','create,export,view,');
/*!40000 ALTER TABLE `menu_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES ('caa7ae64-956c-11ed-9838-3b1dde067e67','admin','2023-01-16 07:09:42',NULL,0),('caa7fd32-956c-11ed-9838-3b1dde067e67','user','2023-01-16 07:09:42',NULL,0);
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES ('06ac2b6e-784a-4a92-a63f-2749620970b2','hla hla','2023-01-02 00:00:00','3432422342','Mandalay','9/mayaka(N)232432','hlahla@gmail.com','Screenshot_20230103_013935.png','2023-01-09 17:06:41','2023-01-09 17:41:56',0),('082f80a2-f2b0-43cb-aa27-2d5b6b7b4362','Allien','2024-04-01 00:00:00','3432422342','dsfdsfs','dfsdafdsfa','allien@gmail.com','cat5.jpg','2024-04-30 15:49:16',NULL,0),('343b81ab-d349-4a9f-a393-0be80ca5f89b','kyaw kyaw','2023-01-01 00:00:00','3432422342','Yangon','12/mayaka(N)232432','kyaw@gmail.com','Screenshot_20221215_113723.png','2023-01-09 16:59:11',NULL,0),('3b2dff5e-4d94-4c8e-a0e0-d5ca98c427e1','ko ko','2024-04-01 00:00:00','3432422342','dfdsfsdfe','dfjddslkfjdf','koko@gmail.com',NULL,'2024-04-30 15:50:12',NULL,0),('5900fcb2-c489-466d-9a36-b294d9ea080a','zaw zaw','2023-01-04 00:00:00','3432422342','Yangon','12/mayaka(N)232432','zaw@gmail.com','Screenshot_20221229_032752.png','2023-01-09 17:08:39',NULL,0),('6bb01ba6-5302-4ff8-afff-ce7d17b46f10','kaung kyaw moe','2023-01-01 00:00:00','3432422342','Yangon','12/mayaka(N)232432','kaungkyawmoe@gmail.com','Screenshot_20221229_032752.png','2023-01-09 16:51:32',NULL,0),('a03e117d-aba1-42dc-b762-e5b5a4c8b82d','aung aung','2022-01-01 00:00:00','3432422342','Yangon','12/mayaka(N)232432','aung@gmail.com','es.png','2023-01-09 17:01:11','2024-02-21 01:51:20',0),('c8e07dcb-6028-4d28-bd43-a2d1f6681bfa','John','2024-01-03 00:00:00','3432422342','fsdafas','432423432','john@gmail.com','dog.jpg','2024-04-30 15:49:44',NULL,0),('ccfbae0f-9a74-47eb-b1ca-9b134c10d740','mg mg','2023-01-03 00:00:00','3432422342','Yangon','11/datana(n)','mgmg@gmail.com','Screenshot_20221229_032752.png','2023-01-09 17:39:46',NULL,0),('e39b0b1c-bf35-4760-9ec0-0f02c4dc911f','ei mon theint','1997-12-28 00:00:00','3432422342','Yangon','12/mayaka(N)232432','emt@gmail.com','Screenshot_20221122_094351.png','2023-01-09 16:54:48',NULL,0),('e8a7303a-f75c-4f32-a708-6ab339867af2','tun tun','2023-01-01 00:00:00','3432422342','Yangon','12/mayaka(N)232432','tuntun@gmail.com','Screenshot_20221213_062035.png','2023-01-09 17:03:42',NULL,0),('eab62388-5ccd-4c1d-bf85-384a986be0f8','Smith','2024-02-27 00:00:00','3432422342','fsfsdfadsf','gdgdfgfd','smith@gmail.com',NULL,'2024-04-30 15:50:41',NULL,0);
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `teachers`
--

LOCK TABLES `teachers` WRITE;
/*!40000 ALTER TABLE `teachers` DISABLE KEYS */;
/*!40000 ALTER TABLE `teachers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('44879b54-3555-4feb-8b58-c4add6c9f678','johndoe','johndoe@gmail.com','zYsHMpLYIKIa4yY1z4wBRUgmAkzHCMqIizyftHKRjfg=','caa7fd32-956c-11ed-9838-3b1dde067e67','2023-02-14 01:32:18',NULL,0),('a1c8b922-8712-434c-815d-a7c00a6344e6','admin','admin@gmail.com','zYsHMpLYIKIa4yY1z4wBRUgmAkzHCMqIizyftHKRjfg=','caa7ae64-956c-11ed-9838-3b1dde067e67','2023-02-14 01:26:16',NULL,0);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'e_learning'
--
/*!50003 DROP PROCEDURE IF EXISTS `GetList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`%` PROCEDURE `GetList`(
in _select varchar(200),
in _table varchar(200),
in _joinTable varchar(200),
in _where varchar(200),
in _skip int,
in _take int
)
BEGIN

set @db_query = concat(_select,_table,_jointable,_where);

if(_skip > 0 || _take > 0)
then 
set @take = concat(' limit ',_take);
set @skip = concat(' offset ',_skip);
set @db_query = concat(@db_query,@take,@skip);
end if;

prepare _stmt from @db_query;

execute _stmt;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-17 10:47:01
