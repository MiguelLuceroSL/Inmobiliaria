-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 27, 2025 at 03:43 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `inmobiliaria`
--

-- --------------------------------------------------------

--
-- Table structure for table `contratos`
--

CREATE TABLE `contratos` (
  `id_contrato` int(11) NOT NULL,
  `id_inquilino` int(11) NOT NULL,
  `id_inmueble` int(11) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL,
  `cuota_mensual` decimal(10,2) NOT NULL,
  `estado_contrato` enum('Vigente','Finalizado','Cancelado','') DEFAULT 'Vigente',
  `fecha_rescision` date DEFAULT NULL,
  `cancelado_por` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `contratos`
--

INSERT INTO `contratos` (`id_contrato`, `id_inquilino`, `id_inmueble`, `fecha_desde`, `fecha_hasta`, `cuota_mensual`, `estado_contrato`, `fecha_rescision`, `cancelado_por`) VALUES
(1, 1, 1, '2025-09-13', '2025-12-17', 70.00, 'Cancelado', '2025-09-26', 'Admin Principal'),
(3, 2, 15, '2025-09-12', '2026-04-30', 205.00, NULL, NULL, NULL),
(4, 64, 35, '2025-07-30', '2026-01-30', 80.00, 'Vigente', NULL, '');

-- --------------------------------------------------------

--
-- Table structure for table `inmuebles`
--

CREATE TABLE `inmuebles` (
  `id_inmueble` int(11) NOT NULL,
  `direccion` varchar(255) NOT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `superficie` int(11) DEFAULT NULL,
  `ambientes` int(11) DEFAULT NULL,
  `baños` int(11) DEFAULT NULL,
  `cochera` tinyint(1) DEFAULT 0,
  `estado` enum('disponible','alquilado','mantenimiento') DEFAULT 'disponible',
  `descripcion` text DEFAULT NULL,
  `id_propietario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inmuebles`
--

INSERT INTO `inmuebles` (`id_inmueble`, `direccion`, `tipo`, `superficie`, `ambientes`, `baños`, `cochera`, `estado`, `descripcion`, `id_propietario`) VALUES
(1, 'Lejos al 4056', 'Residencial', 400, 2, 1, 1, 'disponible', 'Casa con puertas y ventanas', 4),
(15, 'Chubut 1090', 'Residencial', 400, 2, 1, 0, 'disponible', 'CASA LINDA', 3),
(16, 'Av Rivadavia 101', 'Departamento', 60, 2, 1, 0, 'disponible', 'Depto chico en zona céntrica', 1),
(18, 'Belgrano 303', 'Departamento', 45, 1, 1, 0, 'disponible', 'Monoambiente económico', 4),
(19, 'Mitre 404', 'Local', 80, 2, 1, 0, 'disponible', 'Local comercial en esquina', 7),
(20, 'Lavalle 505', 'Casa', 150, 5, 3, 2, 'disponible', 'Casa familiar grande', 1),
(21, 'Corrientes 606', 'Departamento', 70, 3, 1, 1, 'disponible', 'Depto con balcón', 3),
(22, 'Entre Rios 707', 'Oficina', 55, 2, 1, 0, 'disponible', 'Oficina céntrica luminosa', 4),
(23, 'Catamarca 808', 'Casa', 200, 6, 3, 2, 'disponible', 'Casa con quincho y pileta', 7),
(24, 'Chacabuco 909', 'Departamento', 50, 2, 1, 0, 'disponible', 'Depto en zona sur', 1),
(25, 'Sarmiento 1001', 'Casa', 180, 5, 2, 1, 'disponible', 'Casa de dos plantas', 3),
(26, 'Av Rivadavia 1102', 'Departamento', 65, 2, 1, 1, 'disponible', 'Depto con cochera', 4),
(27, 'San Martin 1203', 'Casa', 130, 4, 2, 1, 'disponible', 'Casa con jardín', 7),
(28, 'Belgrano 1304', 'Departamento', 55, 2, 1, 0, 'disponible', 'Depto cómodo y luminoso', 1),
(29, 'Mitre 1405', 'Local', 90, 3, 1, 0, 'disponible', 'Local con depósito', 3),
(30, 'Lavalle 1506', 'Casa', 160, 5, 2, 2, 'disponible', 'Casa con garaje doble', 4),
(31, 'Corrientes 1607', 'Departamento', 75, 3, 1, 1, 'disponible', 'Depto frente a plaza', 7),
(32, 'Entre Rios 1708', 'Oficina', 50, 2, 1, 0, 'disponible', 'Oficina pequeña', 1),
(33, 'Catamarca 1809', 'Casa', 210, 7, 3, 2, 'disponible', 'Casa quinta', 3),
(34, 'Chacabuco 1901', 'Departamento', 48, 2, 1, 0, 'disponible', 'Depto económico', 4),
(35, 'Sarmiento 2002', 'Casa', 175, 6, 2, 1, 'disponible', 'Casa familiar de lujo', 7),
(36, 'Av Rivadavia 2103', 'Departamento', 62, 2, 1, 0, 'disponible', 'Depto céntrico', 1),
(37, 'San Martin 2204', 'Casa', 140, 5, 2, 1, 'disponible', 'Casa remodelada', 3),
(38, 'Belgrano 2305', 'Departamento', 47, 1, 1, 0, 'disponible', 'Monoambiente moderno', 4),
(39, 'Mitre 2406', 'Local', 100, 3, 1, 0, 'disponible', 'Local sobre avenida', 7),
(40, 'Lavalle 2507', 'Casa', 155, 5, 2, 1, 'disponible', 'Casa con terraza', 1),
(41, 'Corrientes 2608', 'Departamento', 68, 3, 1, 1, 'disponible', 'Depto con vista', 3),
(42, 'Entre Rios 2709', 'Oficina', 53, 2, 1, 0, 'disponible', 'Oficina equipada', 4),
(43, 'Catamarca 2810', 'Casa', 220, 7, 4, 2, 'disponible', 'Casa con parque', 7),
(44, 'Chacabuco 2911', 'Departamento', 52, 2, 1, 0, 'disponible', 'Depto económico', 1),
(45, 'Sarmiento 3012', 'Casa', 190, 6, 3, 1, 'disponible', 'Casa en esquina', 3),
(46, 'Av Rivadavia 3113', 'Departamento', 67, 2, 1, 1, 'disponible', 'Depto reciclado', 4),
(47, 'San Martin 3214', 'Casa', 145, 5, 2, 1, 'disponible', 'Casa amplia', 7),
(48, 'Belgrano 3315', 'Departamento', 54, 2, 1, 0, 'disponible', 'Depto en PB', 1),
(49, 'Mitre 3416', 'Local', 95, 3, 1, 0, 'disponible', 'Local con depósito grande', 3),
(50, 'Lavalle 3517', 'Casa', 165, 5, 3, 2, 'disponible', 'Casa con parrilla', 4),
(51, 'Corrientes 3618', 'Departamento', 72, 3, 1, 1, 'disponible', 'Depto céntrico', 7),
(52, 'Entre Rios 3719', 'Oficina', 57, 2, 1, 0, 'disponible', 'Oficina coworking', 1),
(53, 'Catamarca 3820', 'Casa', 230, 7, 4, 2, 'disponible', 'Casa quinta amplia', 3),
(54, 'Chacabuco 3921', 'Departamento', 49, 2, 1, 0, 'disponible', 'Depto económico', 4),
(55, 'Sarmiento 4022', 'Casa', 185, 6, 2, 1, 'disponible', 'Casa grande', 7),
(56, 'Av Rivadavia 4123', 'Departamento', 63, 2, 1, 0, 'disponible', 'Depto con patio', 1),
(57, 'San Martin 4224', 'Casa', 150, 5, 2, 1, 'disponible', 'Casa moderna', 3),
(58, 'Belgrano 4325', 'Departamento', 46, 1, 1, 0, 'disponible', 'Monoambiente barato', 4),
(59, 'Mitre 4426', 'Local', 85, 2, 1, 0, 'disponible', 'Local céntrico', 7),
(60, 'Lavalle 4527', 'Casa', 170, 5, 2, 2, 'disponible', 'Casa con pileta', 1),
(61, 'Corrientes 4628', 'Departamento', 74, 3, 1, 1, 'disponible', 'Depto reciclado', 3),
(62, 'Entre Rios 4729', 'Oficina', 56, 2, 1, 0, 'disponible', 'Oficina moderna', 4),
(63, 'Catamarca 4830', 'Casa', 240, 8, 4, 3, 'disponible', 'Casa quinta grande', 7),
(64, 'Chacabuco 4931', 'Departamento', 51, 2, 1, 0, 'disponible', 'Depto económico', 1),
(65, 'Sarmiento 5032', 'Casa', 195, 6, 3, 1, 'disponible', 'Casa en dos plantas', 3),
(66, 'Belgrano 583', 'Local', 220, 4, 2, 2, 'disponible', 'Casa quinta', 1),
(67, 'San Juan 2234', 'Casa', 70, 1, 1, 0, 'disponible', 'Oficina coworking', 7),
(68, 'Catamarca 3704', 'Residencial', 400, 4, 2, 0, 'disponible', 'Casa en esquina', 4),
(69, 'Sarmiento 2080', 'Oficina', 70, 2, 2, 1, 'disponible', 'Departamento con balcón', 1),
(70, 'Sarmiento 4621', 'Residencial', 350, 6, 4, 1, 'disponible', 'Casa en dos plantas', 7),
(71, 'Belgrano 2234', 'Departamento', 350, 3, 1, 2, 'disponible', 'Departamento moderno', 7),
(72, 'Maipu 3206', 'Casa', 120, 5, 3, 0, 'disponible', 'Departamento con balcón', 3),
(73, 'Alsina 942', 'Departamento', 75, 4, 4, 2, 'disponible', 'Casa con quincho y pileta', 3),
(74, 'Belgrano 319', 'Local', 160, 5, 3, 1, 'disponible', 'Depto con patio', 4),
(75, 'Alsina 3184', 'Casa', 60, 2, 3, 0, 'disponible', 'Departamento con balcón', 4),
(76, 'Corrientes 312', 'Departamento', 55, 2, 1, 0, 'disponible', 'Monoambiente luminoso', 1),
(77, 'Palermo 2993', 'Local', 95, 3, 2, 1, 'disponible', 'Local comercial en esquina', 7),
(78, 'Lavalle 4040', 'Casa', 140, 4, 2, 1, 'disponible', 'Casa con jardín', 3),
(79, 'Mitre 211', 'Departamento', 48, 1, 1, 0, 'disponible', 'Depto económico', 4),
(80, 'Belgrano 2509', 'Oficina', 50, 2, 1, 0, 'disponible', 'Oficina pequeña', 1),
(81, 'Entre Rios 355', 'Casa', 200, 6, 3, 2, 'disponible', 'Casa con quincho y pileta', 3),
(82, 'Chacabuco 1210', 'Departamento', 52, 2, 1, 0, 'disponible', 'Depto económico', 4),
(83, 'Av Rivadavia 189', 'Residencial', 300, 5, 3, 2, 'disponible', 'Residencial con parque', 1),
(84, 'Corrientes 1580', 'Local', 110, 3, 1, 1, 'disponible', 'Local sobre avenida', 7),
(85, 'Mitre 1780', 'Casa', 180, 5, 2, 1, 'disponible', 'Casa con garage', 3),
(86, 'Sarmiento 4215', 'Departamento', 65, 2, 1, 0, 'disponible', 'Depto cómodo y luminoso', 4),
(87, 'Belgrano 78', 'Oficina', 60, 2, 1, 0, 'disponible', 'Oficina equipada', 1),
(88, 'Maipu 147', 'Casa', 95, 3, 2, 1, 'disponible', 'Casa con terraza', 7),
(89, 'Palermo 2110', 'Departamento', 72, 3, 2, 1, 'disponible', 'Depto con vista', 3),
(90, 'Alsina 88', 'Residencial', 240, 6, 3, 2, 'disponible', 'Residencial amplio', 4),
(91, 'Catamarca 900', 'Casa', 130, 4, 2, 1, 'disponible', 'Casa familiar grande', 1),
(92, 'Lavalle 273', 'Departamento', 58, 2, 1, 0, 'disponible', 'Departamento céntrico', 3),
(93, 'Mitre 333', 'Local', 85, 3, 1, 0, 'disponible', 'Local con depósito', 4),
(94, 'San Martin 412', 'Departamento', 55, 2, 1, 0, 'disponible', 'Depto con balcón', 7),
(95, 'Belgrano 2105', 'Casa', 155, 5, 2, 1, 'disponible', 'Casa con parque', 1),
(96, 'Corrientes 2400', 'Oficina', 57, 2, 1, 0, 'disponible', 'Oficina coworking', 3),
(97, 'Sarmiento 911', 'Departamento', 50, 2, 1, 0, 'disponible', 'Depto económico', 4),
(98, 'Av Rivadavia 1500', 'Casa', 170, 5, 2, 1, 'disponible', 'Casa con pileta', 7),
(99, 'Palermo 110', 'Local', 100, 3, 1, 0, 'disponible', 'Local céntrico', 1),
(100, 'Maipu 780', 'Departamento', 48, 1, 1, 0, 'disponible', 'Monoambiente luminoso', 3),
(101, 'Belgrano 402', 'Casa', 210, 6, 3, 2, 'disponible', 'Casa quinta amplia', 4),
(102, 'Corrientes 520', 'Departamento', 62, 2, 1, 1, 'disponible', 'Depto con cochera', 7),
(103, 'Mitre 1650', 'Oficina', 75, 3, 1, 0, 'disponible', 'Oficina con buena luz', 1),
(104, 'Lavalle 900', 'Residencial', 260, 5, 3, 2, 'disponible', 'Residencial moderno', 3),
(105, 'Catamarca 110', 'Casa', 95, 3, 2, 1, 'disponible', 'Casa en dos plantas', 4),
(106, 'Belgrano 1999', 'Departamento', 54, 2, 1, 0, 'disponible', 'Depto con patio', 7),
(107, 'San Martin 78', 'Local', 92, 3, 2, 1, 'disponible', 'Local con depósito grande', 1),
(108, 'Alsina 1234', 'Casa', 145, 5, 2, 1, 'disponible', 'Casa con jardín', 3),
(109, 'Palermo 452', 'Departamento', 67, 3, 1, 1, 'disponible', 'Depto reciclado', 4),
(110, 'Maipu 3040', 'Oficina', 53, 2, 1, 0, 'disponible', 'Oficina pequeña', 7),
(111, 'Corrientes 990', 'Casa', 190, 6, 3, 1, 'disponible', 'Casa en esquina', 1),
(112, 'Belgrano 315', 'Departamento', 49, 1, 1, 0, 'disponible', 'Depto económico', 3),
(113, 'Mitre 421', 'Local', 120, 4, 2, 1, 'disponible', 'Local con deposito', 4),
(114, 'Sarmiento 210', 'Casa', 160, 5, 2, 2, 'disponible', 'Casa con garage doble', 7),
(115, 'Av Rivadavia 600', 'Departamento', 74, 3, 2, 1, 'disponible', 'Depto frente a plaza', 1),
(116, 'Catamarca 255', 'Residencial', 320, 6, 3, 2, 'disponible', 'Residencial con parque', 3),
(117, 'Belgrano 188', 'Departamento', 56, 2, 1, 0, 'disponible', 'Depto con vista', 4),
(118, 'Corrientes 3610', 'Casa', 135, 4, 2, 1, 'disponible', 'Casa remodelada', 7),
(119, 'Mitre 2406', 'Local', 100, 3, 1, 0, 'disponible', 'Local sobre avenida', 1),
(120, 'San Martin 2204', 'Residencial', 300, 5, 3, 2, 'disponible', 'Residencial amplio', 3),
(121, 'Alsina 76', 'Casa', 80, 3, 2, 0, 'disponible', 'Casa con patio', 4),
(122, 'Palermo 2121', 'Departamento', 61, 2, 1, 0, 'disponible', 'Depto céntrico', 7),
(123, 'Belgrano 3315', 'Departamento', 54, 2, 1, 0, 'disponible', 'Depto en PB', 1),
(124, 'Lavalle 1506', 'Casa', 160, 5, 2, 2, 'disponible', 'Casa con garaje doble', 3),
(125, 'Catamarca 3820', 'Casa', 230, 7, 4, 2, 'disponible', 'Casa quinta grande', 4),
(126, 'Corrientes 606', 'Departamento', 70, 3, 1, 1, 'disponible', 'Depto con balcón', 7),
(127, 'Mitre 1405', 'Local', 90, 3, 1, 0, 'disponible', 'Local con depósito', 1),
(128, 'Sarmiento 503', 'Casa', 120, 4, 2, 1, 'disponible', 'Casa con patio', 3),
(129, 'Av Rivadavia 3113', 'Departamento', 67, 2, 1, 1, 'disponible', 'Depto reciclado', 4),
(130, 'Palermo 505', 'Oficina', 56, 2, 1, 0, 'disponible', 'Oficina moderna', 7),
(131, 'Belgrano 1304', 'Departamento', 55, 2, 1, 0, 'disponible', 'Depto cómodo y luminoso', 1),
(132, 'Maipu 820', 'Casa', 175, 6, 3, 2, 'disponible', 'Casa familiar de lujo', 3),
(133, 'Corrientes 4628', 'Departamento', 74, 3, 1, 1, 'disponible', 'Depto reciclado', 4),
(134, 'Mitre 3416', 'Local', 95, 3, 1, 0, 'disponible', 'Local con depósito grande', 7),
(135, 'Belgrano 2305', 'Departamento', 47, 1, 1, 0, 'disponible', 'Monoambiente moderno', 1),
(136, 'Lavalle 2507', 'Casa', 155, 5, 2, 1, 'disponible', 'Casa con terraza', 3),
(137, 'San Martin 202', 'Casa', 120, 4, 2, 3, 'disponible', 'Casa amplia con patio', 4),
(138, 'Alsina 220', 'Departamento', 52, 2, 1, 0, 'disponible', 'Depto económico', 7),
(139, 'Catamarca 2810', 'Casa', 220, 7, 4, 2, 'disponible', 'Casa con parque', 1),
(140, 'Corrientes 3618', 'Departamento', 72, 3, 1, 1, 'disponible', 'Depto céntrico', 3),
(141, 'Mitre 404', 'Local', 80, 2, 1, 0, 'disponible', 'Local comercial en esquina', 4),
(142, 'Belgrano 331', 'Casa', 145, 5, 2, 1, 'disponible', 'Casa amplia', 7),
(143, 'Sarmiento 1001', 'Casa', 180, 5, 2, 1, 'disponible', 'Casa de dos plantas', 1),
(144, 'Lavalle 505', 'Casa', 150, 5, 3, 2, 'disponible', 'Casa familiar grande', 3),
(145, 'Palermo 311', 'Departamento', 68, 3, 1, 1, 'disponible', 'Depto con vista', 4),
(146, 'Maipu 95', 'Oficina', 53, 2, 1, 0, 'disponible', 'Oficina equipada', 7),
(147, 'Belgrano 5832', 'Residencial', 300, 5, 3, 2, 'disponible', 'Residencial con amenities', 1),
(148, 'Corrientes 1708', 'Oficina', 50, 2, 1, 0, 'disponible', 'Oficina pequeña', 3),
(149, 'Mitre 2406B', 'Local', 100, 3, 1, 0, 'disponible', 'Local sobre avenida', 4),
(150, 'Chacabuco 909', 'Departamento', 50, 2, 1, 0, 'disponible', 'Depto en zona sur', 7),
(151, 'Catamarca 808', 'Casa', 200, 6, 3, 2, 'disponible', 'Casa con quincho y pileta', 1),
(152, 'Belgrano 3315A', 'Departamento', 54, 2, 1, 0, 'disponible', 'Depto en PB', 3),
(153, 'Sarmiento 2002', 'Casa', 175, 6, 2, 1, 'disponible', 'Casa familiar de lujo', 4),
(154, 'Av Rivadavia 1102', 'Departamento', 65, 2, 1, 1, 'disponible', 'Depto con cochera', 7),
(155, 'Lavalle 4527', 'Casa', 170, 5, 2, 2, 'disponible', 'Casa con pileta', 1),
(156, 'Corrientes 2608', 'Departamento', 68, 3, 1, 1, 'disponible', 'Depto con vista', 3),
(157, 'Mitre 246', 'Local', 85, 2, 1, 0, 'disponible', 'Local céntrico', 4),
(158, 'Belgrano 1304B', 'Departamento', 55, 2, 1, 0, 'disponible', 'Depto cómodo y luminoso', 7),
(159, 'Catamarca 1809', 'Casa', 210, 7, 3, 2, 'disponible', 'Casa quinta', 1),
(160, 'Chacabuco 3921', 'Departamento', 49, 2, 1, 0, 'disponible', 'Depto económico', 3),
(161, 'San Martin 1203', 'Casa', 130, 4, 2, 1, 'disponible', 'Casa con jardín', 4),
(162, 'Lavalle 1506B', 'Casa', 160, 5, 2, 2, 'disponible', 'Casa con garaje doble', 7),
(163, 'Corrientes 462', 'Departamento', 75, 3, 1, 1, 'disponible', 'Depto frente a plaza', 1),
(164, 'Belgrano 3319', 'Oficina', 57, 2, 1, 0, 'disponible', 'Oficina pequeña', 3),
(165, 'Mitre 404A', 'Local', 95, 3, 1, 0, 'disponible', 'Local con deposito', 4),
(166, 'Sarmiento 3012', 'Casa', 190, 6, 3, 1, 'disponible', 'Casa en esquina', 7),
(167, 'Catamarca 4931', 'Departamento', 51, 2, 1, 0, 'disponible', 'Depto económico', 1),
(168, 'San Martin 202B', 'Casa', 120, 4, 2, 1, 'disponible', 'Casa amplia con patio', 3),
(169, 'Av Rivadavia 2103', 'Departamento', 62, 2, 1, 0, 'disponible', 'Depto céntrico', 4),
(170, 'Corrientes 1607', 'Departamento', 75, 3, 1, 1, 'disponible', 'Depto frente a plaza', 7),
(171, 'Belgrano 2405', 'Casa', 145, 5, 2, 1, 'disponible', 'Casa amplia', 1),
(172, 'Lavalle 3517', 'Casa', 165, 5, 3, 2, 'disponible', 'Casa con parrilla', 3),
(173, 'Mitre 2406C', 'Local', 100, 3, 1, 0, 'disponible', 'Local sobre avenida', 4),
(174, 'Catamarca 3821', 'Casa', 230, 7, 4, 2, 'disponible', 'Casa quinta amplia', 7);

-- --------------------------------------------------------

--
-- Table structure for table `inquilinos`
--

CREATE TABLE `inquilinos` (
  `id_inquilino` int(11) NOT NULL,
  `dni_inquilino` varchar(20) NOT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `domicilio_personal` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inquilinos`
--

INSERT INTO `inquilinos` (`id_inquilino`, `dni_inquilino`, `apellido`, `nombre`, `telefono`, `email`, `domicilio_personal`) VALUES
(1, '123456784', 'Garay', 'Jonathan', '2626262', 'yoni@fff.com', 'micasaotucasa3210'),
(2, '789789789789', 'Garay', 'Jonathan G', '156474777', 'yoni@fff.com', 'micasaotucasa'),
(53, '40283213', 'Garay', 'Jonathan', '2664153721', 'jonathan.garay213@mail.com', 'Av. Belgrano 1423'),
(54, '35328483', 'García', 'María', '2664890112', 'maria.garcia483@mail.com', 'Rivadavia 2789 piso 2'),
(55, '27104912', 'Gómez', 'Juan', '2664129087', 'juan.gomez912@mail.com', 'Córdoba 456 depto B'),
(56, '38210007', 'Pérez', 'María', '2664770055', 'maria.perez007@mail.com', 'Santa Fe 78'),
(58, '31450004', 'Díaz', 'Ana', '2664982234', 'ana.diaz004@mail.com', 'Urquiza 2915'),
(59, '39002005', 'Rodríguez', 'Luis', '2664667790', 'luis.rodriguez005@mail.com', 'Italia 430'),
(60, '36111006', 'Fernández', 'Sofía', '2664413233', 'sofia.fernandez006@mail.com', 'Salta 212'),
(61, '32000007', 'Martínez', 'Pedro', '2664567845', 'pedro.martinez007@mail.com', 'San Juan 980'),
(62, '34320008', 'Sánchez', 'Laura', '2664801123', 'laura.sanchez008@mail.com', 'Pueyrredón 112'),
(63, '38101009', 'Ruiz', 'Diego', '2664029987', 'diego.ruiz009@mail.com', 'Alsina 77'),
(64, '37300010', 'Torres', 'Carla', '2664741110', 'carla.torres010@mail.com', 'Mitre 1545'),
(65, '41213011', 'Moreno', 'Hugo', '2664556678', 'hugo.moreno011@mail.com', 'Laprida 98'),
(66, '36987012', 'Méndez', 'Lucía', '2664230099', 'lucia.mendez012@mail.com', 'Río Negro 301'),
(67, '35102013', 'García', 'Mario', '2664912345', 'mario.garcia013@mail.com', 'Perón 4023'),
(68, '30112014', 'Navarro', 'Clara', '2664345567', 'clara.navarro014@mail.com', 'Dorrego 66'),
(69, '39501015', 'Juárez', 'Pablo', '2664789001', 'pablo.juarez015@mail.com', 'Alvear 209'),
(70, '28400016', 'Vega', 'Paula', '2664127766', 'paula.vega016@mail.com', 'Santa María 123'),
(71, '42003017', 'Silva', 'Andrés', '2664650091', 'andres.silva017@mail.com', 'Chile 3450'),
(72, '31222018', 'Luna', 'Marta', '2664398877', 'marta.luna018@mail.com', 'Belgrano 904 piso 3'),
(73, '33999019', 'Paz', 'Jorge', '2664013344', 'jorge.paz019@mail.com', 'Obligado 142'),
(74, '34210020', 'Herrera', 'Camila', '2664546671', 'camila.herrera020@mail.com', 'Rawson 56'),
(75, '40500021', 'Arias', 'Tomás', '2664200456', 'tomas.arias021@mail.com', 'Rufino 188'),
(76, '37880022', 'Ortiz', 'Florencia', '2664873322', 'florencia.ortiz022@mail.com', 'Lavalle 2170'),
(77, '36740023', 'Ibarra', 'Nicolás', '2664167890', 'nicolas.ibarra023@mail.com', 'Francia 21'),
(78, '38220024', 'Acosta', 'Victoria', '2664015566', 'victoria.acosta024@mail.com', 'Pellegrini 398'),
(79, '35775025', 'Rojas', 'Matías', '2664790023', 'matias.rojas025@mail.com', 'Catamarca 53'),
(80, '32990026', 'Soto', 'Julieta', '2664321455', 'julieta.soto026@mail.com', 'Independencia 1100'),
(81, '39101027', 'Castro', 'Fernando', '2664678899', 'fernando.castro027@mail.com', 'Alem 290'),
(82, '31405028', 'Aguilar', 'Valeria', '2664945560', 'valeria.aguilar028@mail.com', 'Entre Ríos 760'),
(83, '40220029', 'Ríos', 'Santiago', '2664132239', 'santiago.rios029@mail.com', 'Güemes 44'),
(84, '35990030', 'Molina', 'Gabriela', '2664760098', 'gabriela.molina030@mail.com', 'Jujuy 201'),
(85, '36001031', 'Campos', 'Lucas', '2664219876', 'lucas.campos031@mail.com', 'Pringles 77'),
(86, '37450032', 'Domínguez', 'Elena', '2664955512', 'elena.dominguez032@mail.com', 'Avenida 9 de Julio 12'),
(87, '33700033', 'Correa', 'Esteban', '2664883344', 'esteban.correa033@mail.com', 'Av. del Sol 179'),
(88, '34050034', 'Giménez', 'Romina', '2664027765', 'romina.gimenez034@mail.com', 'San Lorenzo 56'),
(89, '39870035', 'Peralta', 'Agustín', '2664340097', 'agustin.peralta035@mail.com', 'Pasanau 321'),
(90, '31980036', 'Fuentes', 'Marina', '2664774400', 'marina.fuentes036@mail.com', 'Córdoba 1589'),
(91, '32440037', 'Carrizo', 'Daniel', '2664103344', 'daniel.carrizo037@mail.com', 'Castelli 88'),
(92, '38600038', 'Vargas', 'Rocío', '2664652123', 'rocio.vargas038@mail.com', 'Gallo 14'),
(93, '36250039', 'Bravo', 'Alberto', '2664983007', 'alberto.bravo039@mail.com', 'Pasaje Moreno 5'),
(94, '35410040', 'Nuñez', 'Martina', '2664239902', 'martina.nunez040@mail.com', 'Rivadavia 2100 depto 4'),
(95, '37333041', 'Pereyra', 'Sebastián', '2664581122', 'sebastian.pereyra041@mail.com', 'Esmeralda 92'),
(96, '34770042', 'Ferreyra', 'Claudia', '2664900083', 'claudia.ferreyra042@mail.com', 'Belgrano 433'),
(97, '33215043', 'Benítez', 'Cristián', '2664177761', 'cristian.benitez043@mail.com', 'Luro 120'),
(98, '36999044', 'Medina', 'Noelia', '2664540096', 'noelia.medina044@mail.com', 'Roca 1567'),
(99, '38420045', 'Suárez', 'Gastón', '2664827764', 'gaston.suarez045@mail.com', 'Mitre 210'),
(100, '35120046', 'Blanco', 'Alicia', '2664933345', 'alicia.blanco046@mail.com', 'Pueyrredón 503'),
(101, '37001047', 'Godoy', 'Federico', '2664078890', 'federico.godoy047@mail.com', 'Av. San Martín 142'),
(102, '32700048', 'Ponce', 'Lorena', '2664690011', 'lorena.ponce048@mail.com', '9 de Julio 800'),
(103, '39330049', 'Ledesma', 'Marcos', '2664365519', 'marcos.ledesma049@mail.com', 'Monseñor de Andrea 23'),
(104, '34890050', 'Mendoza', 'Natalia', '2664210094', 'natalia.mendoza050@mail.com', 'Av. Roca 119'),
(105, '36580051', 'Sánchez', 'Hernán', '2664156672', 'hernan.sanchez051@mail.com', 'Sarmiento 908'),
(106, '33440052', 'Roldán', 'Luciana', '2664789911', 'luciana.roldan052@mail.com', 'Sanatorio 14'),
(107, '38101053', 'González', 'Martín', '2664043320', 'martin.gonzalez053@mail.com', 'Paso 44'),
(108, '35215054', 'Varela', 'Román', '2664456733', 'roman.varela054@mail.com', 'Boulevard 9'),
(109, '31777055', 'Contreras', 'Silvia', '2664896612', 'silvia.contreras055@mail.com', 'Canal 7 205'),
(110, '37402056', 'Cortés', 'Federico', '2664571239', 'federico.cortes056@mail.com', 'Rincón 333'),
(111, '34009057', 'Álvarez', 'Mariana', '2664700044', 'mariana.alvarez057@mail.com', 'Belgrano 2100'),
(112, '33601058', 'Pazos', 'Hernán', '2664038876', 'hernan.pazos058@mail.com', 'General Paz 45'),
(113, '36887059', 'Sosa', 'Carolina', '2664972230', 'carolina.sosa059@mail.com', 'Zeballos 907'),
(114, '35540060', 'Gallardo', 'Nicolás', '2664128899', 'nicolas.gallardo060@mail.com', 'Dr. Vera 16'),
(115, '37200061', 'Ibáñez', 'Tamara', '2664290077', 'tamara.ibanez061@mail.com', 'Güiraldes 12'),
(116, '32150062', 'Beltrán', 'Ramiro', '2664682234', 'ramiro.beltran062@mail.com', 'España 77'),
(117, '39005063', 'Luna', 'Verónica', '2664815566', 'veronica.luna063@mail.com', 'Venezuela 402'),
(118, '31601064', 'Cárdenas', 'Bruno', '2664160033', 'bruno.cardenas064@mail.com', 'Bv. Roca 999'),
(119, '34808065', 'Malfatti', 'Lucero', '2664537788', 'lucero.malfatti065@mail.com', 'Pellegrini 220A'),
(120, '36303066', 'Núñez', 'Fabián', '2664723312', 'fabian.nunez066@mail.com', 'Mendoza 58'),
(121, '35009067', 'Rico', 'Adriana', '2664074455', 'adriana.rico067@mail.com', 'Alberdi 430'),
(122, '38900068', 'Ferrer', 'Estela', '2664906677', 'estela.ferrer068@mail.com', 'Las Heras 210'),
(123, '33820069', 'Peréz', 'Rodrigo', '2664379922', 'rodrigo.perez069@mail.com', 'Cnel. Suárez 12'),
(124, '37111070', 'Serrano', 'Natalia', '2664203311', 'natalia.serrano070@mail.com', '9 de Julio 55'),
(125, '34640071', 'Villar', 'Gonzalo', '2664930090', 'gonzalo.villar071@mail.com', 'Av. Francia 8'),
(126, '36120072', 'Rey', 'Mónica', '2664256673', 'monica.rey072@mail.com', 'Libertad 188'),
(127, '35770073', 'Aguirre', 'Santiago', '2664189907', 'santiago.aguirre073@mail.com', 'Avenida Roca 120'),
(128, '33410074', 'Areco', 'Lorena', '2664560018', 'lorena.areco074@mail.com', 'Pasaje Italia 3'),
(129, '39990075', 'Chávez', 'Emiliano', '2664683345', 'emiliano.chavez075@mail.com', 'Pje. Belgrano 67'),
(130, '31400076', 'Molina', 'Jimena', '2664027788', 'jimena.molina076@mail.com', 'Río Cuarto 241'),
(131, '34201077', 'Escobar', 'Brenda', '2664792236', 'brenda.escobar077@mail.com', 'Avenida Ocampo 2'),
(132, '36880078', 'Zapata', 'Félix', '2664350095', 'felix.zapata078@mail.com', 'Cnel. Brandan 17'),
(133, '35660079', 'Oliva', 'Marcos', '2664411102', 'marcos.oliva079@mail.com', '33 Orientales 900'),
(134, '37890080', 'Carrera', 'Paula', '2664732217', 'paula.carrera080@mail.com', 'Montevideo 45'),
(135, '33210081', 'Márquez', 'Gustavo', '2664094453', 'gustavo.marquez081@mail.com', 'La Rioja 703'),
(136, '36005082', 'Barrios', 'Marcela', '2664978820', 'marcela.barrios082@mail.com', 'Sarmiento 2000'),
(137, '35345083', 'Figueroa', 'Diego', '2664207781', 'diego.figueroa083@mail.com', 'Av. Mitre 321'),
(138, '32909084', 'Cardozo', 'Neyla', '2664890034', 'neyla.cardozo084@mail.com', 'Pringles 444'),
(139, '38321085', 'Alonso', 'Hugo', '2664249905', 'hugo.alonso085@mail.com', 'Balcarce 190'),
(140, '34111086', 'Nadal', 'Cecilia', '2664760012', 'cecilia.nadal086@mail.com', 'Av. Libertador 101'),
(141, '36707087', 'Perini', 'Hernán', '2664087768', 'hernan.perini087@mail.com', 'España 56'),
(142, '33808088', 'Molina', 'Rebeca', '2664703355', 'rebeca.molina088@mail.com', 'San Luis 9'),
(143, '37301089', 'Quiroga', 'Irene', '2664552219', 'irene.quiroga089@mail.com', 'Belgrano 601'),
(144, '35220090', 'Vega', 'Javier', '2664991122', 'javier.vega090@mail.com', 'Pje. López 8'),
(145, '31555091', 'Salazar', 'César', '2664123340', 'cesar.salazar091@mail.com', 'Rivadavia 1003'),
(146, '34998092', 'López', 'Ana María', '2664750099', 'ana.lopez092@mail.com', 'Av. Belgrano 220'),
(147, '36412093', 'Ramos', 'Gisela', '2664208897', 'gisela.ramos093@mail.com', 'Avellaneda 77'),
(148, '33777094', 'Miranda', 'Pablo', '2664895563', 'pablo.miranda094@mail.com', 'San Martín 301'),
(149, '38005095', 'Ochoa', 'Sergio', '2664327760', 'sergio.ochoa095@mail.com', 'Boulogne 12'),
(150, '35601096', 'Valle', 'Noemí', '2664461114', 'noemi.valle096@mail.com', 'Castro Barros 9'),
(151, '37444097', 'Mena', 'Renata', '2664589906', 'renata.mena097@mail.com', '9 de Julio 1001'),
(152, '33990098', 'Castaño', 'Pedro', '2664902213', 'pedro.castano098@mail.com', 'Belgrano 171'),
(153, '36250099', 'Trujillo', 'Silvina', '2664130098', 'silvina.trujillo099@mail.com', 'Las Heras 3'),
(154, '34550100', 'Pineda', 'Rogelio', '2664798893', 'rogelio.pineda100@mail.com', 'Sarmiento 11'),
(155, '987654321', 'Godoy', 'Jonathan Gabriel', '0266154585470', 'yonikcc@gmail.com', 'Chacabuco'),
(156, '987654321555', 'Godoy', 'Javito', '0266154585470', 'yonikcc@gmail.com', 'Chacabuco 2500');

-- --------------------------------------------------------

--
-- Table structure for table `pagos`
--

CREATE TABLE `pagos` (
  `id_pago` int(11) NOT NULL,
  `id_contrato` int(11) NOT NULL,
  `numero_pago` int(11) NOT NULL,
  `fecha_pago` date NOT NULL,
  `importe` decimal(10,2) NOT NULL,
  `detalle` varchar(255) DEFAULT NULL,
  `anulado` tinyint(1) NOT NULL DEFAULT 0,
  `anulado_por` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pagos`
--

INSERT INTO `pagos` (`id_pago`, `id_contrato`, `numero_pago`, `fecha_pago`, `importe`, `detalle`, `anulado`, `anulado_por`) VALUES
(2, 1, 1, '2025-09-26', 70.00, '1er pago', 1, 'Admin Principal');

-- --------------------------------------------------------

--
-- Table structure for table `propietarios`
--

CREATE TABLE `propietarios` (
  `id_propietario` int(11) NOT NULL,
  `dni_propietario` varchar(20) NOT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `telefono` varchar(30) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `domicilio_personal` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `propietarios`
--

INSERT INTO `propietarios` (`id_propietario`, `dni_propietario`, `apellido`, `nombre`, `telefono`, `email`, `domicilio_personal`) VALUES
(1, '44920912', 'Rodriguezz', 'Juan', '2665449302', 'jjjj@gmail.com', 'casa mi casa 300'),
(3, '33539441', 'Garay', 'Soledad Malvina', '2664872310', 'yoni@fff.com', 'micasaotucasa123'),
(4, '35115723', 'Moreno', 'Roberto', '2664912312', 'moreno.robert@gmail.com', 'Su casa bandera'),
(7, '50122444', 'Miranda', 'Carla', '2665732380', 'miranda.carla@gmail.com', 'micasaotucasa'),
(8, '44920912555', 'Rodriguez', 'Juan', '2665449302', 'jjjj@gmail.com', 'casa mi casa5500');

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `avatar` varchar(255) DEFAULT NULL,
  `email` varchar(100) NOT NULL,
  `clave` varchar(255) NOT NULL,
  `rol` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`id`, `nombre`, `apellido`, `avatar`, `email`, `clave`, `rol`) VALUES
(1, 'Admin', 'Principal', '', 'admin@admin.com', '$2a$11$x8/fubXLlMg7ngNOoIkvLO914d7Tsy5pUL77BNsuglN0XEnNAjFRW', 'Admin'),
(2, 'Miguel', 'Lucero', '', 'miguellucero@gmail.com', '$2a$11$FX5HJgkPBxKz13aqG/qQOOxz0Flo2hjNqpQ2tpItoY4tAD.N36Dke', 'Empleado'),
(3, 'Roque', 'Fernandez', '', 'rfernandez08@gmail.com', '$2a$11$66G38R20W2AOAHkF7k7lieiWG2hg2XNCT/fYbEFOUolzRGBB4Dvm6', 'Empleado');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `contratos`
--
ALTER TABLE `contratos`
  ADD PRIMARY KEY (`id_contrato`),
  ADD KEY `id_inquilino` (`id_inquilino`),
  ADD KEY `contratos_ibfk_2` (`id_inmueble`);

--
-- Indexes for table `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD PRIMARY KEY (`id_inmueble`),
  ADD KEY `id_propietario` (`id_propietario`);

--
-- Indexes for table `inquilinos`
--
ALTER TABLE `inquilinos`
  ADD PRIMARY KEY (`id_inquilino`);

--
-- Indexes for table `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`id_pago`),
  ADD KEY `id_contrato` (`id_contrato`);

--
-- Indexes for table `propietarios`
--
ALTER TABLE `propietarios`
  ADD PRIMARY KEY (`id_propietario`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `contratos`
--
ALTER TABLE `contratos`
  MODIFY `id_contrato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `inmuebles`
--
ALTER TABLE `inmuebles`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=175;

--
-- AUTO_INCREMENT for table `inquilinos`
--
ALTER TABLE `inquilinos`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=158;

--
-- AUTO_INCREMENT for table `pagos`
--
ALTER TABLE `pagos`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `contratos`
--
ALTER TABLE `contratos`
  ADD CONSTRAINT `contratos_ibfk_1` FOREIGN KEY (`id_inquilino`) REFERENCES `inquilinos` (`id_inquilino`),
  ADD CONSTRAINT `contratos_ibfk_2` FOREIGN KEY (`id_inmueble`) REFERENCES `inmuebles` (`id_inmueble`);

--
-- Constraints for table `inmuebles`
--
ALTER TABLE `inmuebles`
  ADD CONSTRAINT `inmuebles_ibfk_1` FOREIGN KEY (`id_propietario`) REFERENCES `propietarios` (`id_propietario`);

--
-- Constraints for table `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `contratos` (`id_contrato`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
