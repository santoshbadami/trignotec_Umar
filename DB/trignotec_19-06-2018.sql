# Host: localhost  (Version: 5.1.73-community)
# Date: 2018-06-19 18:17:23
# Generator: MySQL-Front 5.3  (Build 4.89)

/*!40101 SET NAMES utf8 */;

#
# Structure for table "customermaster"
#

CREATE TABLE `customermaster` (
  `custId` int(11) NOT NULL AUTO_INCREMENT,
  `custName` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `mobile` varchar(255) DEFAULT NULL,
  `emailId` varchar(255) DEFAULT NULL,
  `vatNo` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `type` varchar(255) DEFAULT NULL,
  `dateCreated` datetime DEFAULT NULL,
  `dateModified` datetime DEFAULT NULL,
  PRIMARY KEY (`custId`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;

#
# Data for table "customermaster"
#

INSERT INTO `customermaster` VALUES (1,'Mypol','Mysore','123','9731565322','umarshariff86@gmail.com','vat123',1,'Manual','2018-05-05 11:23:04','2018-05-05 11:23:04'),(2,'Mypol','Mysore','123','9731565322','umarshariff86@gmail.com','123',1,'Manual','2018-05-05 11:23:58','2018-06-04 15:39:05'),(3,'Mypol','Mysore','123','9731565322','umarshariff86@gmail.com','vatno',1,'Manual','2018-05-05 11:31:36','2018-06-02 15:04:05'),(4,'Shariff1','Mysore133','456798','0000000000','123u@u.com','gf',1,'Manual','2018-05-05 11:35:46','2018-06-04 14:20:32'),(5,'JK Tyres1','Mysore1','9731565322','1234567891','u@u.com','7946',1,'Excel','2018-05-06 15:49:41','2018-05-06 15:49:41'),(6,'JK Tyres2','Mysore2','9731565322','1234567891','u@u.com','7946',1,'Excel','2018-05-06 15:49:41','2018-05-06 15:49:41'),(7,'JK Tyres3','Mysore3','9731565322','1234567891','u@u.com','7946',1,'Excel','2018-05-06 15:49:41','2018-05-06 15:49:41'),(8,'JK Tyres4','Mysore4','9731565322','1234567891','u@u.com','7946',0,'Excel','2018-05-06 15:49:41','2018-05-06 16:12:48'),(9,'Dammam Company','Dammam','1234567890','0254789645','umarshariff86@gmail.com','1234567890',1,'Manual','2018-05-14 16:07:35','2018-05-14 16:07:35'),(10,'Company 1','Dammam 1','12345678912','123456789','u@u.com','123456789',1,'Excel','2018-05-14 16:09:07','2018-05-14 16:09:07'),(11,'Company 2','Dammam 2','12345678912','123456789','u@u.com','123456790',1,'Excel','2018-05-14 16:09:07','2018-05-14 16:09:07'),(12,'Company 3','Dammam 3','12345678912','123456789','u@u.com','123456791',1,'Excel','2018-05-14 16:09:07','2018-05-14 16:09:07'),(13,'Company 4','Dammam 4','12345678912','123456789','u@u.com','123456792',1,'Excel','2018-05-14 16:09:07','2018-05-14 16:09:07'),(14,'Company 5','Dammam 5','12345678912','123456789','u@u.com','123456793',1,'Excel','2018-05-14 16:09:07','2018-05-14 16:09:07'),(15,'Zia Bhaiya','Mysore','98745321111','454545','U@u.com','1365',1,'Excel','2018-05-19 11:12:36','2018-05-19 11:12:36'),(16,'GNS','Dammam','9731565322','0932049230','shajee.khan@trignotec.com','09238482309480923480',1,'Manual','2018-05-19 16:03:29','2018-05-19 16:03:29');

#
# Structure for table "invoicedetails"
#

CREATE TABLE `invoicedetails` (
  `invdId` int(11) NOT NULL AUTO_INCREMENT,
  `invId` int(11) DEFAULT NULL,
  `prodId` int(11) DEFAULT NULL,
  `prodDescription` text,
  `qty` varchar(255) DEFAULT NULL,
  `prodPrice` decimal(11,2) DEFAULT NULL,
  `totalPrice` decimal(11,2) DEFAULT NULL,
  PRIMARY KEY (`invdId`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8;

#
# Data for table "invoicedetails"
#

INSERT INTO `invoicedetails` VALUES (51,22,2,'Screew','10',800.00,8000.00),(52,22,2,'Screew','20',100.00,2000.00),(53,23,3,'Hammer','10',300.00,3000.00),(56,25,2,'Screew','10',800.00,8000.00),(57,25,2,'Screew','201',100.00,20100.00),(58,26,2,'Screew','10',800.00,8000.00),(59,26,2,'Screew','201',100.00,20100.00),(60,27,3,'Hammer','10',89.00,890.00),(81,28,2,'Screew','1',100.00,100.00),(82,28,3,'Hammer','2',89.00,178.00),(83,29,2,'Screew','1',100.00,100.00),(84,29,3,'Hammer','2',89.00,178.00),(85,30,2,'Screew','1',100.00,100.00),(86,30,3,'Hammer','2',89.00,178.00),(93,21,4,'Knife','5',50.00,250.00),(94,21,3,'Hammer','10',89.00,890.00),(95,21,45,'789','6',6.00,36.00);

#
# Structure for table "invoicemaster"
#

CREATE TABLE `invoicemaster` (
  `invId` int(11) NOT NULL AUTO_INCREMENT,
  `invUniqueNo` int(11) DEFAULT NULL,
  `invoiceNo` int(11) DEFAULT NULL,
  `invoiceDate` date DEFAULT NULL,
  `custId` int(11) DEFAULT NULL,
  `custName` varchar(255) DEFAULT NULL,
  `custVat` varchar(255) DEFAULT NULL,
  `quotId` int(11) DEFAULT NULL,
  `amount` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `dateCreated` datetime DEFAULT NULL,
  `dateModified` datetime DEFAULT NULL,
  PRIMARY KEY (`invId`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

#
# Data for table "invoicemaster"
#

INSERT INTO `invoicemaster` VALUES (21,3,3,'2018-06-19',5,'JK Tyres1','',4,'Open',1,'2018-06-04 15:17:42','2018-06-19 18:08:07'),(22,3,4,'2018-06-04',2,'Mypol','',3,'Open',1,'2018-06-04 15:20:48','2018-06-19 18:08:07'),(23,5,5,'2018-06-04',2,'Mypol','123',0,'Closed',1,'2018-06-04 15:39:05','2018-06-04 15:39:05'),(25,3,6,'2018-06-19',2,'Mypol','',0,'Open',1,'2018-06-19 11:14:46','2018-06-19 18:08:07'),(26,3,7,'2018-06-19',2,'Mypol','',0,'Open',1,'2018-06-19 11:15:27','2018-06-19 18:08:07'),(27,6,8,'2018-06-19',15,'Zia Bhaiya','',5,'Closed',1,'2018-06-19 11:17:23','2018-06-19 11:17:23'),(28,7,9,'2018-06-19',1,'Mypol','',0,'Open',1,'2018-06-19 17:43:00','2018-06-19 17:43:00'),(29,7,10,'2018-06-19',1,'Mypol','',0,'Open',1,'2018-06-19 17:43:40','2018-06-19 17:43:40'),(30,7,11,'2018-06-19',1,'Mypol','',0,'Open',1,'2018-06-19 17:44:24','2018-06-19 17:44:24');

#
# Structure for table "invoicepaymentdetails"
#

CREATE TABLE `invoicepaymentdetails` (
  `invPId` int(11) NOT NULL AUTO_INCREMENT,
  `invId` int(11) DEFAULT NULL,
  `totalExVat` decimal(11,2) DEFAULT NULL,
  `vatPer` int(11) DEFAULT NULL,
  `vatAmt` decimal(11,2) DEFAULT NULL,
  `totalInTax` decimal(11,2) DEFAULT NULL,
  `termsAndContions` text,
  PRIMARY KEY (`invPId`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;

#
# Data for table "invoicepaymentdetails"
#

INSERT INTO `invoicepaymentdetails` VALUES (21,21,1176.00,5,58.80,1234.80,'123\nUmar'),(22,22,10000.00,5,500.00,10500.00,''),(23,23,3000.00,5,150.00,3150.00,''),(25,25,28100.00,5,1405.00,29505.00,''),(26,26,28100.00,5,1405.00,29505.00,''),(27,27,890.00,5,44.50,934.50,''),(28,28,278.00,5,13.90,291.90,''),(29,29,278.00,5,13.90,291.90,''),(30,30,278.00,5,13.90,291.90,'hello');

#
# Structure for table "productmaster"
#

CREATE TABLE `productmaster` (
  `prodId` int(11) NOT NULL AUTO_INCREMENT,
  `description` text,
  `unitPrice` decimal(11,2) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `type` varchar(255) DEFAULT NULL,
  `dateCreated` datetime DEFAULT NULL,
  `dateModified` datetime DEFAULT NULL,
  PRIMARY KEY (`prodId`)
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;

#
# Data for table "productmaster"
#

INSERT INTO `productmaster` VALUES (1,'Bolt',10.00,0,'Excel','2018-05-06 16:57:30','2018-05-19 16:25:41'),(2,'Screew89',100.00,1,'Quotation','2018-05-06 16:57:30','2018-06-19 18:01:13'),(3,'Hammer',89.00,1,'Invoice','2018-05-06 16:57:30','2018-06-19 18:08:08'),(4,'Knife',50.00,1,'Invoice','2018-05-06 16:57:30','2018-06-19 18:08:07'),(5,'Nail',50.00,0,'Excel','2018-05-06 16:57:30','2018-05-06 17:09:17'),(6,'Hat',60.00,1,'Quotation','2018-05-06 17:09:32','2018-06-11 10:45:31'),(7,'Web Site Development45',89.00,1,'Quotation','2018-05-14 16:09:51','2018-06-11 11:03:49'),(8,'Dammam Web Site 1',2000.00,1,'Invoice','2018-05-14 16:10:38','2018-06-04 15:14:41'),(9,'Dammam Web Site 2',2001.00,1,'Invoice','2018-05-14 16:10:38','2018-06-04 15:14:41'),(10,'Dammam Web Site 3',2002.00,1,'Invoice','2018-05-14 16:10:38','2018-06-04 15:14:41'),(11,'Dammam Web Site 4',2003.00,1,'Invoice','2018-05-14 16:10:38','2018-06-04 15:14:41'),(12,'Dammam Web Site 5',2004.00,1,'Invoice','2018-05-14 16:10:38','2018-06-04 15:14:41'),(13,'Dammam Web Site 6',2005.00,1,'Excel','2018-05-14 16:10:38','2018-05-14 16:10:38'),(14,'Dammam Web Site 7',2006.00,1,'Excel','2018-05-14 16:10:38','2018-05-14 16:10:38'),(15,'Gun',16.00,1,'Quotation','2018-05-16 17:03:54','2018-05-16 17:03:54'),(16,'45',45.00,1,'Quotation','2018-05-16 17:06:41','2018-05-16 17:06:41'),(17,'78',12.00,1,'Quotation','2018-05-16 17:08:30','2018-05-16 17:08:30'),(18,'78',12.00,1,'Quotation','2018-05-16 17:10:19','2018-05-16 17:10:19'),(19,'12',23.00,1,'Quotation','2018-05-16 17:11:44','2018-05-16 17:11:44'),(20,'12',23.00,1,'Quotation','2018-05-16 17:34:25','2018-05-16 17:34:25'),(21,'12',12.00,1,'Quotation','2018-05-16 17:37:19','2018-05-16 17:37:19'),(22,'Add new',100.00,1,'Quotation','2018-05-16 17:40:53','2018-05-16 17:40:53'),(23,'point value',2500.50,1,'Quotation','2018-05-16 17:42:31','2018-05-16 17:42:31'),(24,'12',12.00,1,'Quotation','2018-05-16 18:03:59','2018-05-16 18:03:59'),(25,'89',23.00,1,'Quotation','2018-05-16 18:04:13','2018-05-16 18:04:13'),(26,'12312',12.00,1,'Quotation','2018-05-16 18:12:38','2018-05-16 18:12:38'),(27,'12\n',12.00,1,'Quotation','2018-05-16 18:14:18','2018-05-16 18:14:18'),(28,'12',12.00,1,'Quotation','2018-05-16 18:19:27','2018-05-16 18:19:27'),(29,'45',45.00,1,'Quotation','2018-05-16 18:26:55','2018-05-16 18:26:55'),(30,'Pen drive',12.00,1,'Quotation','2018-05-16 18:27:27','2018-05-16 18:27:27'),(31,'Kit',1000.00,1,'Quotation','2018-05-16 18:29:00','2018-05-16 18:29:00'),(32,'Ipen',500.00,1,'Quotation','2018-05-16 18:29:58','2018-05-16 18:29:58'),(33,'hello',20.00,1,'Quotation','2018-05-17 20:45:41','2018-05-17 20:45:41'),(34,'Welcome',30.00,1,'Quotation','2018-05-17 20:46:04','2018-05-17 20:46:04'),(35,'Jug',100.00,1,'Quotation','2018-05-17 21:01:32','2018-05-17 21:01:32'),(36,'12',0.00,1,'Quotation','2018-05-17 21:06:47','2018-05-17 21:06:47'),(37,'89',89.00,1,'Quotation','2018-05-17 21:06:47','2018-05-17 21:06:47'),(38,'jub',12.00,1,'Quotation','2018-05-18 18:16:37','2018-05-18 18:16:37'),(39,'Hikvision',380.00,1,'Quotation','2018-05-19 16:06:57','2018-05-19 16:06:57'),(40,'Website Design 1st Payment',5000.00,1,'Quotation','2018-05-19 16:22:16','2018-05-19 16:22:16'),(41,'Installation & Configuration',5000.00,1,'Quotation','2018-05-19 16:29:59','2018-05-19 16:29:59'),(42,'56',50.00,1,'Invoice','2018-05-31 13:09:40','2018-06-04 15:14:41'),(43,'89',89.00,1,'Invoice','2018-05-31 13:09:43','2018-06-04 15:14:41'),(44,'ds',0.00,1,'Invoice','2018-06-04 14:30:03','2018-06-04 14:30:03'),(45,'789',6.00,1,'Invoice','2018-06-19 17:32:23','2018-06-19 18:08:08');

#
# Structure for table "quotationdetails"
#

CREATE TABLE `quotationdetails` (
  `qdId` int(11) NOT NULL AUTO_INCREMENT,
  `quotId` int(11) DEFAULT NULL,
  `prodId` int(11) DEFAULT NULL,
  `prodDescription` text,
  `qty` varchar(255) DEFAULT NULL,
  `prodPrice` decimal(11,2) DEFAULT NULL,
  `totalPrice` decimal(11,2) DEFAULT NULL,
  PRIMARY KEY (`qdId`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;

#
# Data for table "quotationdetails"
#

INSERT INTO `quotationdetails` VALUES (6,1,8,'Dammam Web Site 1','1',2000.00,2000.00),(7,1,9,'Dammam Web Site 2','2',2001.00,4002.00),(8,1,10,'Dammam Web Site 3','3',2002.00,6006.00),(9,1,11,'Dammam Web Site 4','4',2003.00,8012.00),(10,1,12,'Dammam Web Site 5','5',2004.00,10020.00),(11,1,42,'56','5',50.00,250.00),(12,1,4,'Knife','89',89.00,7921.00),(13,1,43,'89','89',89.00,7921.00),(14,2,3,'Hammer','50',300.00,15000.00),(15,2,2,'Screew','50',50.00,2500.00),(18,4,4,'Knife','5',50.00,250.00),(20,3,2,'Screew','10',800.00,8000.00),(21,6,2,'Screew','10',100.00,1000.00),(22,6,6,'Hat','30',60.00,1800.00),(23,7,2,'Screew89','78',89.00,6942.00),(24,7,4,'Knife','8',50.00,400.00),(25,7,7,'Web Site Development45','898',89.00,79922.00),(28,5,3,'Hammer','10',89.00,890.00),(33,8,2,'Screew89','5',100.00,500.00),(34,8,3,'Hammer','5',300.00,1500.00);

#
# Structure for table "quotationmaster"
#

CREATE TABLE `quotationmaster` (
  `quotId` int(11) NOT NULL AUTO_INCREMENT,
  `quotNo` int(11) DEFAULT NULL,
  `quotDate` date DEFAULT NULL,
  `custId` int(11) DEFAULT NULL,
  `custName` varchar(255) DEFAULT NULL,
  `status` int(11) DEFAULT '1',
  `dateCreated` datetime DEFAULT NULL,
  `dateModified` datetime DEFAULT NULL,
  PRIMARY KEY (`quotId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

#
# Data for table "quotationmaster"
#

INSERT INTO `quotationmaster` VALUES (1,1,'2018-05-01',15,'Zia Bhaiya',1,'2018-05-31 10:02:01','2018-05-31 13:05:15'),(2,2,'2018-05-31',3,'Mypol',1,'2018-05-31 13:11:49','2018-05-31 13:11:49'),(3,3,'2018-05-31',2,'Mypol',1,'2018-05-31 13:12:28','2018-06-02 10:19:07'),(4,4,'2018-06-01',4,'Shariff1',1,'2018-06-01 12:59:24','2018-06-01 12:59:24'),(5,5,'2018-06-01',5,'JK Tyres1',1,'2018-06-01 13:01:14','2018-06-19 15:11:23'),(6,6,'2018-06-12',16,'GNS',1,'2018-06-11 10:45:30','2018-06-11 10:45:30'),(7,7,'2018-06-11',1,'Mypol',1,'2018-06-11 11:03:49','2018-06-11 11:03:49'),(8,8,'2018-06-11',15,'Zia Bhaiya',1,'2018-06-11 11:40:34','2018-06-19 18:01:13');

#
# Structure for table "quotationpaymentdetails"
#

CREATE TABLE `quotationpaymentdetails` (
  `qpdId` int(11) NOT NULL AUTO_INCREMENT,
  `quotId` int(11) DEFAULT NULL,
  `totalExVat` decimal(11,2) DEFAULT NULL,
  `vatPer` int(11) DEFAULT NULL,
  `vatAmt` decimal(10,2) DEFAULT NULL,
  `totalInTax` decimal(11,2) DEFAULT NULL,
  `termsAndContions` text,
  PRIMARY KEY (`qpdId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

#
# Data for table "quotationpaymentdetails"
#

INSERT INTO `quotationpaymentdetails` VALUES (1,1,46132.00,10,4613.20,50745.20,NULL),(2,2,17500.00,5,875.00,18375.00,NULL),(3,3,8000.00,5,400.00,8400.00,''),(4,5,890.00,5,44.50,934.50,'A\nB\nC\nD'),(5,6,2800.00,5,140.00,2940.00,''),(6,7,87264.00,5,4363.20,91627.20,''),(7,8,2000.00,5,100.00,2100.00,'Terms and Conditions\nHello 123\nites delivered');

#
# Function "fn_GetNextInvoiceNo"
#

CREATE FUNCTION `fn_GetNextInvoiceNo`() RETURNS int(11)
BEGIN
     DECLARE _invoiceNo INT(11);
     DECLARE cnt INT(11);
     
     SELECT COUNT(1) FROM invoicemaster INTO cnt;
     
     IF cnt != 0 THEN
        SELECT MAX(invoiceNo) + 1 FROM invoicemaster INTO _invoiceNo;
     ELSE
         SELECT 1 INTO _invoiceNo;
     END IF;
     
     RETURN _invoiceNo;
END;

#
# Function "fn_GetNextQuotationNo"
#

CREATE FUNCTION `fn_GetNextQuotationNo`() RETURNS int(11)
BEGIN
     DECLARE _quotNo INT(11);
     DECLARE cnt INT(11);
     
     SELECT COUNT(1) FROM quotationmaster INTO cnt;
     
     IF cnt != 0 THEN
        SELECT MAX(quotNo) + 1 FROM quotationmaster INTO _quotNo;
     ELSE
         SELECT 1 INTO _quotNo;
     END IF;
     
     RETURN _quotNo;
END;

#
# Function "fn_GetUniqueInvoiceNo"
#

CREATE FUNCTION `fn_GetUniqueInvoiceNo`() RETURNS int(11)
BEGIN
     DECLARE _uniqueInvoiceNo INT(11);
     DECLARE _cnt INT(11);
     
     SELECT COUNT(1) FROM invoicemaster INTO _cnt;
     IF _cnt = 0 THEN
        SELECT 1 INTO _uniqueInvoiceNo;
     ELSE
        SELECT MAX(invUniqueNo) + 1 FROM invoicemaster INTO _uniqueInvoiceNo;
     END IF;
     
     RETURN _uniqueInvoiceNo;
END;

#
# Procedure "deleteCustomerMasterByCustId"
#

CREATE PROCEDURE `deleteCustomerMasterByCustId`(
_custId VARCHAR(255)
)
BEGIN
     UPDATE customermaster SET 
     status = 0,
     dateModified = NOW()
     WHERE custId LIKE _custId;
END;

#
# Procedure "deleteInvoiceByInvId"
#

CREATE PROCEDURE `deleteInvoiceByInvId`(
_invId INT
)
BEGIN
     DELETE FROM invoicemaster WHERE invId = _invId;

     DELETE FROM invoicedetails WHERE invId = _invId;

     DELETE FROM invoicepaymentdetails WHERE invId = _invId;
END;

#
# Procedure "deleteProductMasterByProdId"
#

CREATE PROCEDURE `deleteProductMasterByProdId`(
_prodId INT(11)
)
BEGIN
     UPDATE productmaster SET
     status = 0,
     dateModified = NOW()
     WHERE prodId = _prodId;
END;

#
# Procedure "getAllInvoiceDetails"
#

CREATE PROCEDURE `getAllInvoiceDetails`()
BEGIN
     SELECT im.invId, invoiceNo, invoiceDate, custName, totalExVat, vatPer, vatAmt, totalInTax
     FROM invoicemaster im, invoicepaymentdetails ipd 
     WHERE im.invId = ipd.invId AND status = 1 ORDER BY im.invId DESC;
END;

#
# Procedure "getAllQuotationDetails"
#

CREATE PROCEDURE `getAllQuotationDetails`()
BEGIN
     SELECT qm.quotId, quotNo, quotDate, custName, totalExVat, vatPer, vatAmt, totalInTax
     FROM quotationmaster qm,quotationpaymentdetails qpd
     WHERE qm.quotId = qpd.quotId AND qm.status = 1 ORDER BY quotId DESC;
END;

#
# Procedure "GetCustomerMasterByCustId"
#

CREATE PROCEDURE `GetCustomerMasterByCustId`(
_custId VARCHAR(255)
)
BEGIN
     SELECT *,CAST(CONCAT_WS(' | ',custId,vatNo) AS CHAR) custIdWithVatNo FROM customermaster WHERE status = 1 AND custId LIKE _custId;
END;

#
# Procedure "getInvoiceDetailsByInvId"
#

CREATE PROCEDURE `getInvoiceDetailsByInvId`(
_invId INT(11)
)
BEGIN
     SELECT * FROM invoicemaster WHERE status = 1 AND invId = _invId;
     
     SELECT * FROM invoicedetails WHERE invId = _invId;
     
     SELECT * FROM invoicepaymentdetails WHERE invId = _invId;
END;

#
# Procedure "GetOpenInvoiceNos"
#

CREATE PROCEDURE `GetOpenInvoiceNos`()
BEGIN
     SELECT CAST(CONCAT(MAX(invId), '|', invUniqueNo) AS CHAR) invIdUniqueNo,
     CAST(GROUP_CONCAT(invoiceNo) AS CHAR) invoiceNo FROM invoicemaster WHERE status = 1 AND amount = 'Open'
     GROUP BY invUniqueNo;
END;

#
# Procedure "getproductDetailsForQuoAndIn"
#

CREATE PROCEDURE `getproductDetailsForQuoAndIn`()
BEGIN
     SELECT CAST(CONCAT_WS('|',prodId,unitPrice) AS CHAR) prodId ,description FROM productmaster WHERE status = 1;
END;

#
# Procedure "getProductMasterByProdId"
#

CREATE PROCEDURE `getProductMasterByProdId`(
_prodId VARCHAR(255)
)
BEGIN
     SELECT * FROM productmaster WHERE status = 1 AND prodId LIKE _prodId;
END;

#
# Procedure "getQuotationDetailsByQuotId"
#

CREATE PROCEDURE `getQuotationDetailsByQuotId`(
_quotID INT(11)
)
BEGIN
     SELECT * FROM quotationmaster WHERE status = 1 AND quotId = _quotID;

     SELECT * FROM quotationdetails WHERE quotId = _quotID;

     SELECT * FROM quotationpaymentdetails WHERE quotId = _quotID;
END;

#
# Procedure "getQuotationNoForInvoice"
#

CREATE PROCEDURE `getQuotationNoForInvoice`()
BEGIN
     SELECT quotId, CAST(CONCAT('Q',quotNo) AS CHAR) QquotNo, quotNo FROM quotationmaster WHERE status = 1 ORDER BY quotId DESC;
END;

#
# Procedure "invoiceDetailsDeleteByInvId"
#

CREATE PROCEDURE `invoiceDetailsDeleteByInvId`(
_invId INT
)
BEGIN
     DELETE FROM invoicedetails WHERE invId = _invId;
END;

#
# Procedure "quotationDetailsDeleteByQuotId"
#

CREATE PROCEDURE `quotationDetailsDeleteByQuotId`(
_quotId INT
)
BEGIN
     DELETE FROM quotationdetails WHERE quotId = _quotId;
END;

#
# Procedure "saveCustomerMaster"
#

CREATE PROCEDURE `saveCustomerMaster`(
_custName VARCHAR(500),
_address TEXT,
_phone VARCHAR(255),
_mobile VARCHAR(255),
_emailId VARCHAR(255),
_vatNo VARCHAR(255),
_type VARCHAR(255)
)
BEGIN
     INSERT INTO customermaster (custName, address, phone, mobile, emailId, vatNo, type, dateCreated, dateModified)
     VALUES (_custName, _address, _phone, _mobile, _emailId, _vatNo, _type, NOW(), NOW());
END;

#
# Procedure "saveInvoiceDetails"
#

CREATE PROCEDURE `saveInvoiceDetails`(
_invId INT(11),
_prodId INT(11),
_prodDescription TEXT,
_prodPrice NUMERIC(11,2),
_qty VARCHAR(255),
_totalPrice NUMERIC(11,2)
)
BEGIN     
     DECLARE _productId INT;
     
     IF _prodId = 0 THEN
        CALL saveProductMaster(_prodDescription, _prodPrice, 'Invoice');
        SELECT LAST_INSERT_ID() INTO _productId;
     ELSE
         SET _productId = _prodId;
         CALL updateProductMaster(_productId, _prodDescription, _prodPrice, 'Invoice');
     END IF;

     INSERT INTO invoicedetails (invId, prodId, prodDescription, qty, prodPrice, totalPrice)
     VALUES (_invId, _productId, _prodDescription, _qty, _prodPrice, _totalPrice);
END;

#
# Procedure "saveInvoiceMaster"
#

CREATE PROCEDURE `saveInvoiceMaster`(
_quotId INT,
_invoiceNo INT,
_invoiceDate DATE,
_custId INT,
_custName VARCHAR(255),
_custVat VARCHAR(255),
_amount VARCHAR(255),
_invUniqueNo INT
)
BEGIN
     DECLARE _uniqueNo INT;
     
     IF _invUniqueNo = 0 THEN
        SELECT fn_GetUniqueInvoiceNo() INTO _uniqueNo;
     ELSE
        SET _uniqueNo = _invUniqueNo;
     END IF;

     -- IF _custVat != '' THEN
       -- UPDATE customermaster SET vatNo = _custVat, dateModified = NOW() WHERE custId = _custId;
     -- END IF;
     
     IF _amount = 'Closed' THEN
        UPDATE invoicemaster SET amount = 'Closed', dateModified = NOW() WHERE invUniqueNo = _uniqueNo;
     END IF;
     
     INSERT INTO invoicemaster (invUniqueNo, invoiceNo, invoiceDate, custId, custName, custVat, quotId, amount, dateCreated, dateModified)
     VALUES (_uniqueNo, _invoiceNo, _invoiceDate, _custId, _custName, _custVat, _quotId, _amount, NOW(), NOW());
     
     SELECT LAST_INSERT_ID();
END;

#
# Procedure "saveInvoicePaymentDetails"
#

CREATE PROCEDURE `saveInvoicePaymentDetails`(
_invId INT(11),
_totalExVat NUMERIC(11,2),
_vatPer INT(11),
_vatAmt NUMERIC(11,2),
_totalInTax NUMERIC(11,2),
_termsAndContions TEXT
)
BEGIN
     INSERT INTO invoicepaymentdetails (invId, totalExVat, vatPer, vatAmt, totalInTax, termsAndContions)
     VALUES (_invId, _totalExVat, _vatPer, _vatAmt, _totalInTax, _termsAndContions);
END;

#
# Procedure "saveProductMaster"
#

CREATE PROCEDURE `saveProductMaster`(
_description TEXT,
_unitPrice NUMERIC(11,2),
_type VARCHAR(255)
)
BEGIN
     INSERT INTO productmaster (description, unitPrice, type, dateCreated, dateModified)
     VALUES (_description, _unitPrice, _type, NOW(), NOW());
END;

#
# Procedure "saveProductWhileAddingQuoAndIn"
#

CREATE PROCEDURE `saveProductWhileAddingQuoAndIn`(
_description TEXT,
_unitPrice NUMERIC(11,2),
_type VARCHAR(255)
)
BEGIN
     INSERT INTO productmaster (description, unitPrice, type, dateCreated, dateModified)
     VALUES (_description, _unitPrice, _type, NOW(), NOW());
     
     SELECT LAST_INSERT_ID();
END;

#
# Procedure "saveQuotationDetails"
#

CREATE PROCEDURE `saveQuotationDetails`(
_quotId INT(11),
_prodId INT(11),
_prodDescription TEXT,
_prodPrice NUMERIC(11,2),
_qty VARCHAR(255),
_totalPrice NUMERIC(11,2)
)
BEGIN     
     DECLARE _productId INT;
     
     IF _prodId = 0 THEN
        CALL saveProductMaster(_prodDescription, _prodPrice, 'Quotation');
        SELECT LAST_INSERT_ID() INTO _productId;
     ELSE
         SET _productId = _prodId;
         CALL updateProductMaster(_productId, _prodDescription, _prodPrice, 'Quotation');
     END IF;

     INSERT INTO quotationdetails (quotId, prodId, prodDescription, qty, prodPrice, totalPrice)
     VALUES (_quotId, _productId, _prodDescription, _qty, _prodPrice, _totalPrice);
END;

#
# Procedure "saveQuotationMaster"
#

CREATE PROCEDURE `saveQuotationMaster`(
_quotNo INT(11),
_quotDate DATE,
_custId INT(11),
_custName VARCHAR(255)
)
BEGIN
     INSERT INTO quotationmaster (quotNo, quotDate, custId, custName, dateCreated, dateModified)
     VALUES (_quotNo, _quotDate, _custId, _custName, NOW(), NOW());
     
     SELECT LAST_INSERT_ID();
END;

#
# Procedure "savequotationPaymentDetails"
#

CREATE PROCEDURE `savequotationPaymentDetails`(
_quotId INT(11),
_totalExVat NUMERIC(11,2),
_vatPer INT(11),
_vatAmt NUMERIC(11,2),
_totalInTax NUMERIC(11,2),
_termsAndContions TEXT
)
BEGIN
     INSERT INTO quotationpaymentdetails (quotId, totalExVat, vatPer, vatAmt, totalInTax, termsAndContions)
     VALUES (_quotId, _totalExVat, _vatPer, _vatAmt, _totalInTax, _termsAndContions);
END;

#
# Procedure "updateCustomerMaster"
#

CREATE PROCEDURE `updateCustomerMaster`(
_custId INT,
_custName VARCHAR(500),
_address TEXT,
_phone VARCHAR(255),
_mobile VARCHAR(255),
_emailId VARCHAR(255),
_vatNo VARCHAR(255)
)
BEGIN
     UPDATE customermaster SET
     custName = _custName,
     address = _address,
     phone = _phone,
     mobile = _mobile,
     emailId = _emailId,
     vatNo = _vatNo,
     dateModified = NOW()
     WHERE custId = _custId;
END;

#
# Procedure "updateInvoiceMaster"
#

CREATE PROCEDURE `updateInvoiceMaster`(
_invId INT,
_invoiceNo INT,
_invoiceDate DATE,
_custId INT,
_custName VARCHAR(255),
_amount VARCHAR(255),
_uniqueNo INT
)
BEGIN
     UPDATE invoicemaster SET
     invoiceNo = _invoiceNo,
     invoiceDate = _invoiceDate,
     custId = _custId,
     custName = _custName,
     amount = _amount,
     dateModified = NOW()
     WHERE invId = _invId;
     
     IF _amount = 'Closed' THEN
        UPDATE invoicemaster SET amount = 'Closed', dateModified = NOW() WHERE invUniqueNo = _uniqueNo;
     ELSEIF _amount = 'Open' THEN
        UPDATE invoicemaster SET amount = 'Open', dateModified = NOW() WHERE invUniqueNo = _uniqueNo;  
     END IF;
END;

#
# Procedure "updateinvoicePaymentDetails"
#

CREATE PROCEDURE `updateinvoicePaymentDetails`(
_invId INT,
_totalExVat NUMERIC(11,2),
_vatPer INT(11),
_vatAmt NUMERIC(11,2),
_totalInTax NUMERIC(11,2),
_termsAndContions TEXT
)
BEGIN
     UPDATE invoicepaymentdetails SET
     totalExVat = _totalExVat,
     vatPer = _vatPer,
     vatAmt = _vatAmt,
     totalInTax = _totalInTax,
     termsAndContions = _termsAndContions
     WHERE invId = _invId;
END;

#
# Procedure "updateProductMaster"
#

CREATE PROCEDURE `updateProductMaster`(
_prodId INT,
_description TEXT,
_unitPrice NUMERIC(11,2),
_type VARCHAR(255)
)
BEGIN
     UPDATE productmaster SET
     description = _description,
     unitPrice = _unitPrice,
     type = _type,
     dateModified = NOW()
     WHERE prodId = _prodId;
END;

#
# Procedure "updateQuotationMaster"
#

CREATE PROCEDURE `updateQuotationMaster`(
_quotId INT,
_quotNo INT(11),
_quotDate DATE,
_custId INT(11),
_custName VARCHAR(255)
)
BEGIN
     UPDATE quotationmaster SET
     quotNo = _quotNo,
     quotDate = _quotDate,
     custId = _custId,
     custName = _custName,
     dateModified = NOW()
     WHERE quotId = _quotId;
END;

#
# Procedure "updatequotationPaymentDetails"
#

CREATE PROCEDURE `updatequotationPaymentDetails`(
_quotId INT(11),
_totalExVat NUMERIC(11,2),
_vatPer INT(11),
_vatAmt NUMERIC(11,2),
_totalInTax NUMERIC(11,2),
_termsAndContions TEXT
)
BEGIN
     UPDATE quotationpaymentdetails SET
     totalExVat = _totalExVat,
     vatPer = _vatPer,
     vatAmt = _vatAmt,
     totalInTax = _totalInTax,
     termsAndContions = _termsAndContions
     WHERE quotId = _quotId;
END;

#
# Procedure "validateInvoiceNo"
#

CREATE PROCEDURE `validateInvoiceNo`(
_invoiceNo INT,
_invId INT
)
BEGIN

     IF _invId = 0 THEN
        SELECT * FROM invoicemaster WHERE status = 1 AND invoiceNo = _invoiceNo;
     ELSE
         SELECT * FROM invoicemaster WHERE status = 1 AND invoiceNo = _invoiceNo AND invId != _invId;
     END IF;
     
END;

#
# Procedure "validateQuotationNo"
#

CREATE PROCEDURE `validateQuotationNo`(
_quotNo INT,
_quotId INT
)
BEGIN

     IF _quotId = 0 THEN
        SELECT * FROM quotationmaster WHERE status = 1 AND quotNo = _quotNo;
     ELSE
         SELECT * FROM quotationmaster WHERE status = 1 AND quotNo = _quotNo AND quotId != _quotId;
     END IF;
     
END;
