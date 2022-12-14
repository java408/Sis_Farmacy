-- --------------------------------------------------------
-- Host:                         localhost
-- Versión del servidor:         5.7.24 - MySQL Community Server (GPL)
-- SO del servidor:              Win64
-- HeidiSQL Versión:             9.5.0.5332
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Volcando estructura de base de datos para farmamysql
CREATE DATABASE IF NOT EXISTS `farmamysql` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `farmamysql`;

-- Volcando estructura para tabla farmamysql.clientes
CREATE TABLE IF NOT EXISTS `clientes` (
  `idclientes` int(11) NOT NULL AUTO_INCREMENT,
  `nombres` varchar(45) DEFAULT NULL,
  `Direccion` varchar(45) DEFAULT NULL,
  `dni` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idclientes`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.clientes: ~8 rows (aproximadamente)
DELETE FROM `clientes`;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` (`idclientes`, `nombres`, `Direccion`, `dni`) VALUES
	(1, 'cristian ppp', 'lima', '1'),
	(2, 'Ekiseo silva', 'dre', '2'),
	(3, 'dana sanchez', 'lima', '1234567'),
	(4, 'dana sanchez', 'lima', '1234567'),
	(5, 'dana sanchez', 'lima', '1234567'),
	(6, 'cristian ppp', 'lima', '1'),
	(7, 'Ekiseo silva', 'dre', '2'),
	(8, 'dana sanchez', 'lima', '1234567');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;

-- Volcando estructura para tabla farmamysql.detalle_venta
CREATE TABLE IF NOT EXISTS `detalle_venta` (
  `nro_venta` int(11) NOT NULL AUTO_INCREMENT,
  `id_venta` int(11) DEFAULT NULL,
  `id_producto` int(11) DEFAULT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `precio_venta` decimal(11,2) DEFAULT NULL,
  `sub_total` decimal(11,2) DEFAULT NULL,
  `total` decimal(11,2) DEFAULT NULL,
  PRIMARY KEY (`nro_venta`),
  KEY `detalle_venta_idx` (`id_venta`),
  CONSTRAINT `detalle_venta` FOREIGN KEY (`id_venta`) REFERENCES `venta` (`nro_venta`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.detalle_venta: ~0 rows (aproximadamente)
DELETE FROM `detalle_venta`;
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
INSERT INTO `detalle_venta` (`nro_venta`, `id_venta`, `id_producto`, `cantidad`, `precio_venta`, `sub_total`, `total`) VALUES
	(1, 1, 1, 1, 5.00, 5.00, 5.00);
/*!40000 ALTER TABLE `detalle_venta` ENABLE KEYS */;

-- Volcando estructura para procedimiento farmamysql.InsertarDetalle
DELIMITER //
CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertarDetalle`(
IN nro_venta INT,
IN id_venta INT,
IN id_producto INT,
IN cantidad INT,
IN precio_venta DECIMAL(11,2),
IN sub_total DECIMAL(11,2),
IN total DECIMAL(11,2)
)
BEGIN
insert INTO detalle_venta(nro_venta,id_venta,id_producto,cantidad,precio_venta,sub_total,total) VALUES(nro_venta,id_venta,id_producto,cantidad,precio_venta,sub_total,total);
END//
DELIMITER ;

-- Volcando estructura para tabla farmamysql.producto
CREATE TABLE IF NOT EXISTS `producto` (
  `idproducto` int(11) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(45) DEFAULT NULL,
  `precio_venta` decimal(11,2) DEFAULT NULL,
  `precio_compra` decimal(11,2) DEFAULT NULL,
  `stock` varchar(45) DEFAULT NULL,
  `proveedor` int(11) DEFAULT NULL,
  `Fecha_vencimiento` datetime DEFAULT NULL,
  PRIMARY KEY (`idproducto`),
  KEY `proveedor_idx` (`proveedor`),
  CONSTRAINT `proveedor` FOREIGN KEY (`proveedor`) REFERENCES `proveedor` (`id_proveedor`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.producto: ~7 rows (aproximadamente)
DELETE FROM `producto`;
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` (`idproducto`, `Nombre`, `precio_venta`, `precio_compra`, `stock`, `proveedor`, `Fecha_vencimiento`) VALUES
	(00000000001, 'cc', 5.00, 2.00, '10', 1, '2019-07-25 00:00:00'),
	(00000000002, 'dfg', 12.00, 14.00, '10', 2, '2019-07-25 00:00:00'),
	(00000000003, 'dfgfd', 12.00, 15.00, '12', 2, '2019-07-25 00:00:00'),
	(00000000004, 'dsfs', 24.00, 12.00, '4', 2, '2019-07-25 00:00:00'),
	(00000000005, 'dsfs', 12.00, 24.00, '4', 2, '2019-07-25 00:00:00'),
	(00000000006, 'fdgd', 3.00, 4.00, '12', 2, '2019-07-16 00:00:00'),
	(00000000007, 'fdd', 14.00, 12.00, '14', 2, '2019-07-18 00:00:00'),
	(00000000008, 'dfg', 3.00, 5.00, '4', 2, '2019-07-23 00:00:00');
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;

-- Volcando estructura para tabla farmamysql.proveedor
CREATE TABLE IF NOT EXISTS `proveedor` (
  `id_proveedor` int(11) NOT NULL AUTO_INCREMENT,
  `nombres` varchar(45) DEFAULT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_proveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.proveedor: ~2 rows (aproximadamente)
DELETE FROM `proveedor`;
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` (`id_proveedor`, `nombres`, `direccion`, `telefono`) VALUES
	(1, 'cristin', 'lima', '1233'),
	(2, 'dfgfd', 'gdg', '1321');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;

-- Volcando estructura para tabla farmamysql.usuario
CREATE TABLE IF NOT EXISTS `usuario` (
  `idusuario` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.usuario: ~2 rows (aproximadamente)
DELETE FROM `usuario`;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` (`idusuario`, `usuario`, `password`) VALUES
	(1, 'admin', 'admin'),
	(2, 'root', 'root');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;

-- Volcando estructura para tabla farmamysql.venta
CREATE TABLE IF NOT EXISTS `venta` (
  `nro_venta` int(11) NOT NULL,
  `fecha` datetime DEFAULT NULL,
  `usuario` int(11) DEFAULT NULL,
  `id_cliente` int(11) DEFAULT NULL,
  `total` decimal(11,2) DEFAULT NULL,
  PRIMARY KEY (`nro_venta`),
  KEY `cliente_idx` (`id_cliente`),
  KEY `usuario_idx` (`usuario`),
  CONSTRAINT `cliente` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`idclientes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `usuario` FOREIGN KEY (`usuario`) REFERENCES `usuario` (`idusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Volcando datos para la tabla farmamysql.venta: ~1 rows (aproximadamente)
DELETE FROM `venta`;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` (`nro_venta`, `fecha`, `usuario`, `id_cliente`, `total`) VALUES
	(1, '2019-07-26 00:00:00', 1, 1, 5.00);
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
