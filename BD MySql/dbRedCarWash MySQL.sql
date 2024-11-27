DROP TABLE IF EXISTS `color`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `color` (
  `id_color` int NOT NULL AUTO_INCREMENT,
  `nombreColor_color` varchar(45) DEFAULT NULL,
  `id_uc_color` int DEFAULT NULL,
  PRIMARY KEY (`id_color`),
  KEY `id_uc_color_idx` (`id_uc_color`),
  CONSTRAINT `id_uc_color` FOREIGN KEY (`id_uc_color`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `color`
--

LOCK TABLES `color` WRITE;
/*!40000 ALTER TABLE `color` DISABLE KEYS */;
/*!40000 ALTER TABLE `color` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marca`
--

DROP TABLE IF EXISTS `marca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marca` (
  `id_marca` int NOT NULL AUTO_INCREMENT,
  `nombreMarca_marca` varchar(45) DEFAULT NULL,
  `id_uc_marca` int DEFAULT NULL,
  PRIMARY KEY (`id_marca`),
  KEY `id_uc_marca_idx` (`id_uc_marca`),
  CONSTRAINT `id_uc_marca` FOREIGN KEY (`id_uc_marca`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marca`
--

LOCK TABLES `marca` WRITE;
/*!40000 ALTER TABLE `marca` DISABLE KEYS */;
/*!40000 ALTER TABLE `marca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personal`
--

DROP TABLE IF EXISTS `personal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `personal` (
  `id_personal` int NOT NULL AUTO_INCREMENT,
  `fecha_personal` date DEFAULT NULL,
  `id_re_personal` int DEFAULT NULL,
  `id_tdp_personal` int DEFAULT NULL,
  `valor_personal` decimal(10,2) DEFAULT NULL,
  `id_uc_personal` int DEFAULT NULL,
  PRIMARY KEY (`id_personal`),
  KEY `id_re_personal_idx` (`id_re_personal`),
  KEY `id_tdp_personal_idx` (`id_tdp_personal`),
  KEY `id_uc_personal_idx` (`id_uc_personal`),
  CONSTRAINT `id_re_personal` FOREIGN KEY (`id_re_personal`) REFERENCES `registro_de_empleado` (`id_re`),
  CONSTRAINT `id_tdp_personal` FOREIGN KEY (`id_tdp_personal`) REFERENCES `tipo_de_pago` (`id_tdp`),
  CONSTRAINT `id_uc_personal` FOREIGN KEY (`id_uc_personal`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personal`
--

LOCK TABLES `personal` WRITE;
/*!40000 ALTER TABLE `personal` DISABLE KEYS */;
/*!40000 ALTER TABLE `personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registro_de_empleado`
--

DROP TABLE IF EXISTS `registro_de_empleado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registro_de_empleado` (
  `id_re` int NOT NULL AUTO_INCREMENT,
  `fecha_re` date DEFAULT NULL,
  `cedula_re` varchar(45) DEFAULT NULL,
  `nombres_re` varchar(45) DEFAULT NULL,
  `apellidos_re` varchar(45) DEFAULT NULL,
  `sueldoAcordado_re` decimal(10,2) DEFAULT NULL,
  `id_uc_re` int DEFAULT NULL,
  PRIMARY KEY (`id_re`),
  KEY `id_uc_re_idx` (`id_uc_re`),
  CONSTRAINT `id_uc_re` FOREIGN KEY (`id_uc_re`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registro_de_empleado`
--

LOCK TABLES `registro_de_empleado` WRITE;
/*!40000 ALTER TABLE `registro_de_empleado` DISABLE KEYS */;
/*!40000 ALTER TABLE `registro_de_empleado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registro_de_tipo_lavado`
--

DROP TABLE IF EXISTS `registro_de_tipo_lavado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registro_de_tipo_lavado` (
  `id_rtl` int NOT NULL AUTO_INCREMENT,
  `tipoLavado_rtl` varchar(100) DEFAULT NULL,
  `precioPublico_rtl` decimal(10,2) DEFAULT NULL,
  `id_uc_rtl` int DEFAULT NULL,
  PRIMARY KEY (`id_rtl`),
  KEY `id_uc_rtl_idx` (`id_uc_rtl`),
  CONSTRAINT `id_uc_rtl` FOREIGN KEY (`id_uc_rtl`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registro_de_tipo_lavado`
--

LOCK TABLES `registro_de_tipo_lavado` WRITE;
/*!40000 ALTER TABLE `registro_de_tipo_lavado` DISABLE KEYS */;
/*!40000 ALTER TABLE `registro_de_tipo_lavado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `registro_de_vehiculo`
--

DROP TABLE IF EXISTS `registro_de_vehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `registro_de_vehiculo` (
  `id_rv` int NOT NULL AUTO_INCREMENT,
  `placa_rv` varchar(45) DEFAULT NULL,
  `cliente_rv` varchar(45) DEFAULT NULL,
  `id_tdv_rv` int DEFAULT NULL,
  `id_color_rv` int DEFAULT NULL,
  `id_marca_rv` int DEFAULT NULL,
  `id_uc_rv` int DEFAULT NULL,
  PRIMARY KEY (`id_rv`),
  KEY `id_tdv_rv_idx` (`id_tdv_rv`),
  KEY `id_color_rv_idx` (`id_color_rv`),
  KEY `id_marca_rv_idx` (`id_marca_rv`),
  KEY `id_uc_rv_idx` (`id_uc_rv`),
  CONSTRAINT `id_color_rv` FOREIGN KEY (`id_color_rv`) REFERENCES `color` (`id_color`),
  CONSTRAINT `id_marca_rv` FOREIGN KEY (`id_marca_rv`) REFERENCES `marca` (`id_marca`),
  CONSTRAINT `id_tdv_rv` FOREIGN KEY (`id_tdv_rv`) REFERENCES `tipo_de_vehiculo` (`id_tdv`),
  CONSTRAINT `id_uc_rv` FOREIGN KEY (`id_uc_rv`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `registro_de_vehiculo`
--

LOCK TABLES `registro_de_vehiculo` WRITE;
/*!40000 ALTER TABLE `registro_de_vehiculo` DISABLE KEYS */;
/*!40000 ALTER TABLE `registro_de_vehiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicios`
--

DROP TABLE IF EXISTS `servicios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicios` (
  `id_servicios` int NOT NULL AUTO_INCREMENT,
  `fecha_servicios` date DEFAULT NULL,
  `id_rv_servicios` int DEFAULT NULL,
  `id_rtl_servicios` int DEFAULT NULL,
  `precioPagado_servicios` decimal(10,2) DEFAULT NULL,
  `precioPendiente_servicios` decimal(10,2) DEFAULT NULL,
  `id_uc_servicios` int DEFAULT NULL,
  PRIMARY KEY (`id_servicios`),
  KEY `id_rv_servicios_idx` (`id_rv_servicios`),
  KEY `id_rtl_servicios_idx` (`id_rtl_servicios`),
  KEY `id_uc_servicios_idx` (`id_uc_servicios`),
  CONSTRAINT `id_rtl_servicios` FOREIGN KEY (`id_rtl_servicios`) REFERENCES `registro_de_tipo_lavado` (`id_rtl`),
  CONSTRAINT `id_rv_servicios` FOREIGN KEY (`id_rv_servicios`) REFERENCES `registro_de_vehiculo` (`id_rv`),
  CONSTRAINT `id_uc_servicios` FOREIGN KEY (`id_uc_servicios`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicios`
--

LOCK TABLES `servicios` WRITE;
/*!40000 ALTER TABLE `servicios` DISABLE KEYS */;
/*!40000 ALTER TABLE `servicios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_de_pago`
--

DROP TABLE IF EXISTS `tipo_de_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_de_pago` (
  `id_tdp` int NOT NULL AUTO_INCREMENT,
  `tipoDePago_tdp` varchar(45) DEFAULT NULL,
  `id_uc_tdp` int DEFAULT NULL,
  PRIMARY KEY (`id_tdp`),
  KEY `id_uc_tdp_idx` (`id_uc_tdp`),
  CONSTRAINT `id_uc_tdp` FOREIGN KEY (`id_uc_tdp`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_de_pago`
--

LOCK TABLES `tipo_de_pago` WRITE;
/*!40000 ALTER TABLE `tipo_de_pago` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_de_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipo_de_vehiculo`
--

DROP TABLE IF EXISTS `tipo_de_vehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipo_de_vehiculo` (
  `id_tdv` int NOT NULL AUTO_INCREMENT,
  `tipoDeVehiculo_tdv` varchar(45) DEFAULT NULL,
  `id_uc_tdv` int DEFAULT NULL,
  PRIMARY KEY (`id_tdv`),
  KEY `id_uc_tdv_idx` (`id_uc_tdv`),
  CONSTRAINT `id_uc_tdv` FOREIGN KEY (`id_uc_tdv`) REFERENCES `usuarios` (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipo_de_vehiculo`
--

LOCK TABLES `tipo_de_vehiculo` WRITE;
/*!40000 ALTER TABLE `tipo_de_vehiculo` DISABLE KEYS */;
/*!40000 ALTER TABLE `tipo_de_vehiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id_uc` int NOT NULL AUTO_INCREMENT,
  `usuario_uc` varchar(45) DEFAULT NULL,
  `correo_uc` varchar(45) DEFAULT NULL,
  `clave_uc` varchar(100) DEFAULT NULL,
  `tipoCuenta_uc` int DEFAULT NULL,
  `fechaCaducidad_uc` date DEFAULT NULL,
  `idEmpleado_uc` int DEFAULT NULL,
  PRIMARY KEY (`id_uc`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (11,'Yasser','2010guabo@gmail.com','$2b$10$4taz90QKTqzey9P5WmCM9OJZ/BR76gu3rk0f6NbaL/7bU5fEa5sfG',1,'2021-01-01',0);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `uoc4jg4hwutobv32`@`%` 
    SQL SECURITY DEFINER
VIEW `vista_servicios` AS
    SELECT 
        `servicios`.`id_servicios` AS `id_servicios`,
        `servicios`.`fecha_servicios` AS `fecha_servicios`,
        `registro_de_vehiculo`.`placa_rv` AS `placa_rv`,
        `tipo_de_vehiculo`.`tipoDeVehiculo_tdv` AS `tipoDeVehiculo_tdv`,
        `registro_de_tipo_lavado`.`tipoLavado_rtl` AS `tipoLavado_rtl`,
        `registro_de_tipo_lavado`.`precioPublico_rtl` AS `precioPublico_rtl`,
        `servicios`.`precioPagado_servicios` AS `precioPagado_servicios`,
        `servicios`.`precioPendiente_servicios` AS `precioPendiente_servicios`,
        `servicios`.`id_uc_servicios` AS `id_uc_servicios`
    FROM
        ((((`servicios`
        JOIN `registro_de_vehiculo`)
        JOIN `tipo_de_vehiculo`)
        JOIN `registro_de_tipo_lavado`)
        JOIN `usuarios`)
    WHERE
        ((`servicios`.`id_rv_servicios` = `registro_de_vehiculo`.`id_rv`)
            AND (`servicios`.`id_rtl_servicios` = `registro_de_tipo_lavado`.`id_rtl`)
            AND (`servicios`.`id_uc_servicios` = `usuarios`.`id_uc`)
            AND (`registro_de_vehiculo`.`id_tdv_rv` = `tipo_de_vehiculo`.`id_tdv`))

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `uoc4jg4hwutobv32`@`%` 
    SQL SECURITY DEFINER
VIEW `vista_registroDeVehiculo` AS
    SELECT 
        `registro_de_vehiculo`.`id_rv` AS `id_rv`,
        `registro_de_vehiculo`.`placa_rv` AS `placa_rv`,
        `registro_de_vehiculo`.`cliente_rv` AS `cliente_rv`,
        `tipo_de_vehiculo`.`tipoDeVehiculo_tdv` AS `tipoDeVehiculo_tdv`,
        `color`.`nombreColor_color` AS `nombreColor_color`,
        `marca`.`nombreMarca_marca` AS `nombreMarca_marca`,
        `registro_de_vehiculo`.`id_uc_rv` AS `id_uc_rv`
    FROM
        ((((`registro_de_vehiculo`
        JOIN `tipo_de_vehiculo`)
        JOIN `color`)
        JOIN `marca`)
        JOIN `usuarios`)
    WHERE
        ((`registro_de_vehiculo`.`id_tdv_rv` = `tipo_de_vehiculo`.`id_tdv`)
            AND (`registro_de_vehiculo`.`id_color_rv` = `color`.`id_color`)
            AND (`registro_de_vehiculo`.`id_marca_rv` = `marca`.`id_marca`)
            AND (`registro_de_vehiculo`.`id_uc_rv` = `usuarios`.`id_uc`))

CREATE 
    ALGORITHM = UNDEFINED 
    DEFINER = `uoc4jg4hwutobv32`@`%` 
    SQL SECURITY DEFINER
VIEW `vista_personal` AS
    SELECT 
        `personal`.`id_personal` AS `id_personal`,
        `personal`.`fecha_personal` AS `fecha_personal`,
        `registro_de_empleado`.`nombres_re` AS `nombres_re`,
        `registro_de_empleado`.`apellidos_re` AS `apellidos_re`,
        `registro_de_empleado`.`cedula_re` AS `cedula_re`,
        `tipo_de_pago`.`tipoDePago_tdp` AS `tipoDePago_tdp`,
        `personal`.`valor_personal` AS `valor_personal`,
        `personal`.`id_uc_personal` AS `id_uc_personal`
    FROM
        (((`personal`
        JOIN `tipo_de_pago`)
        JOIN `registro_de_empleado`)
        JOIN `usuarios`)
    WHERE
        ((`personal`.`id_re_personal` = `registro_de_empleado`.`id_re`)
            AND (`personal`.`id_tdp_personal` = `tipo_de_pago`.`id_tdp`)
            AND (`personal`.`id_uc_personal` = `usuarios`.`id_uc`))