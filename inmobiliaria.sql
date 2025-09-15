-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 13, 2025 at 06:20 AM
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
  `monto` decimal(10,2) NOT NULL,
  `fecha_desde` date NOT NULL,
  `fecha_hasta` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `contratos`
--

INSERT INTO `contratos` (`id_contrato`, `id_inquilino`, `id_inmueble`, `monto`, `fecha_desde`, `fecha_hasta`) VALUES
(1, 1, 1, 700.00, '2025-09-13', '2025-12-17'),
(3, 2, 15, 450.00, '2025-09-12', '2026-04-30');

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
(1, 'Lejos al 400.', 'Residencial', 400, 2, 1, 1, 'disponible', 'Casa con puertas y ventanas', 1),
(15, 'Chubut 1090', 'Residencial', 400, 2, 1, 0, 'disponible', 'CASA LINDA', 3),
(16, 'Av Rivadavia 101', 'Departamento', 60, 2, 1, 0, 'disponible', 'Depto chico en zona céntrica', 1),
(17, 'San Martin 202', 'Casa', 120, 4, 2, 1, 'disponible', 'Casa amplia con patio', 3),
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
(65, 'Sarmiento 5032', 'Casa', 195, 6, 3, 1, 'disponible', 'Casa en dos plantas', 3);

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
(1, '123456784', 'Garay', 'Jonathan', '2626262', 'yoni@fff.com', 'micasaotucasa321'),
(2, '789789789789', 'Garay', 'Jonathan G', '156474777', 'yoni@fff.com', 'micasaotucasa'),
(3, '30000001', 'Gomez', 'Juan', '1111111', 'juan.gomez1@mail.com', 'Calle 1'),
(4, '30000002', 'Perez', 'Maria', '1111112', 'maria.perez2@mail.com', 'Calle 2'),
(5, '30000003', 'Lopez', 'Carlos', '1111113', 'carlos.lopez3@mail.com', 'Calle 3'),
(6, '30000004', 'Diaz', 'Ana', '1111114', 'ana.diaz4@mail.com', 'Calle 4'),
(7, '30000005', 'Rodriguez', 'Luis', '1111115', 'luis.rodriguez5@mail.com', 'Calle 5'),
(8, '30000006', 'Fernandez', 'Sofia', '1111116', 'sofia.fernandez6@mail.com', 'Calle 6'),
(9, '30000007', 'Martinez', 'Pedro', '1111117', 'pedro.martinez7@mail.com', 'Calle 7'),
(10, '30000008', 'Sanchez', 'Laura', '1111118', 'laura.sanchez8@mail.com', 'Calle 8'),
(11, '30000009', 'Ruiz', 'Diego', '1111119', 'diego.ruiz9@mail.com', 'Calle 9'),
(12, '30000010', 'Torres', 'Carla', '1111120', 'carla.torres10@mail.com', 'Calle 10'),
(13, '30000011', 'Moreno', 'Hugo', '1111121', 'hugo.moreno11@mail.com', 'Calle 11'),
(14, '30000012', 'Mendez', 'Lucia', '1111122', 'lucia.mendez12@mail.com', 'Calle 12'),
(15, '30000013', 'Garcia', 'Mario', '1111123', 'mario.garcia13@mail.com', 'Calle 13'),
(16, '30000014', 'Navarro', 'Clara', '1111124', 'clara.navarro14@mail.com', 'Calle 14'),
(17, '30000015', 'Juarez', 'Pablo', '1111125', 'pablo.juarez15@mail.com', 'Calle 15'),
(18, '30000016', 'Vega', 'Paula', '1111126', 'paula.vega16@mail.com', 'Calle 16'),
(19, '30000017', 'Silva', 'Andres', '1111127', 'andres.silva17@mail.com', 'Calle 17'),
(20, '30000018', 'Luna', 'Marta', '1111128', 'marta.luna18@mail.com', 'Calle 18'),
(21, '30000019', 'Paz', 'Jorge', '1111129', 'jorge.paz19@mail.com', 'Calle 19'),
(22, '30000020', 'Herrera', 'Camila', '1111130', 'camila.herrera20@mail.com', 'Calle 20'),
(23, '30000021', 'Arias', 'Tomas', '1111131', 'tomas.arias21@mail.com', 'Calle 21'),
(24, '30000022', 'Ortiz', 'Florencia', '1111132', 'florencia.ortiz22@mail.com', 'Calle 22'),
(25, '30000023', 'Ibarra', 'Nicolas', '1111133', 'nicolas.ibarra23@mail.com', 'Calle 23'),
(26, '30000024', 'Acosta', 'Victoria', '1111134', 'victoria.acosta24@mail.com', 'Calle 24'),
(27, '30000025', 'Rojas', 'Matias', '1111135', 'matias.rojas25@mail.com', 'Calle 25'),
(28, '30000026', 'Soto', 'Julieta', '1111136', 'julieta.soto26@mail.com', 'Calle 26'),
(29, '30000027', 'Castro', 'Fernando', '1111137', 'fernando.castro27@mail.com', 'Calle 27'),
(30, '30000028', 'Aguilar', 'Valeria', '1111138', 'valeria.aguilar28@mail.com', 'Calle 28'),
(31, '30000029', 'Rios', 'Santiago', '1111139', 'santiago.rios29@mail.com', 'Calle 29'),
(32, '30000030', 'Molina', 'Gabriela', '1111140', 'gabriela.molina30@mail.com', 'Calle 30'),
(33, '30000031', 'Campos', 'Lucas', '1111141', 'lucas.campos31@mail.com', 'Calle 31'),
(34, '30000032', 'Dominguez', 'Elena', '1111142', 'elena.dominguez32@mail.com', 'Calle 32'),
(35, '30000033', 'Correa', 'Esteban', '1111143', 'esteban.correa33@mail.com', 'Calle 33'),
(36, '30000034', 'Gimenez', 'Romina', '1111144', 'romina.gimenez34@mail.com', 'Calle 34'),
(37, '30000035', 'Peralta', 'Agustin', '1111145', 'agustin.peralta35@mail.com', 'Calle 35'),
(38, '30000036', 'Fuentes', 'Marina', '1111146', 'marina.fuentes36@mail.com', 'Calle 36'),
(39, '30000037', 'Carrizo', 'Daniel', '1111147', 'daniel.carrizo37@mail.com', 'Calle 37'),
(40, '30000038', 'Vargas', 'Rocio', '1111148', 'rocio.vargas38@mail.com', 'Calle 38'),
(41, '30000039', 'Bravo', 'Alberto', '1111149', 'alberto.bravo39@mail.com', 'Calle 39'),
(42, '30000040', 'Nuñez', 'Martina', '1111150', 'martina.nunez40@mail.com', 'Calle 40'),
(43, '30000041', 'Pereyra', 'Sebastian', '1111151', 'sebastian.pereyra41@mail.com', 'Calle 41'),
(44, '30000042', 'Ferreyra', 'Claudia', '1111152', 'claudia.ferreyra42@mail.com', 'Calle 42'),
(45, '30000043', 'Benitez', 'Cristian', '1111153', 'cristian.benitez43@mail.com', 'Calle 43'),
(46, '30000044', 'Medina', 'Noelia', '1111154', 'noelia.medina44@mail.com', 'Calle 44'),
(47, '30000045', 'Suarez', 'Gaston', '1111155', 'gaston.suarez45@mail.com', 'Calle 45'),
(48, '30000046', 'Blanco', 'Alicia', '1111156', 'alicia.blanco46@mail.com', 'Calle 46'),
(49, '30000047', 'Godoy', 'Federico', '1111157', 'federico.godoy47@mail.com', 'Calle 47'),
(50, '30000048', 'Ponce', 'Lorena', '1111158', 'lorena.ponce48@mail.com', 'Calle 48'),
(51, '30000049', 'Ledesma', 'Marcos', '1111159', 'marcos.ledesma49@mail.com', 'Calle 49'),
(52, '30000050', 'Mendoza', 'Natalia', '1111160', 'natalia.mendoza50@mail.com', 'Calle 50');

-- --------------------------------------------------------

--
-- Table structure for table `pagos`
--

CREATE TABLE `pagos` (
  `id_pago` int(11) NOT NULL,
  `id_contrato` int(11) NOT NULL,
  `fecha_pago` date NOT NULL,
  `monto` decimal(10,2) NOT NULL,
  `estado` enum('pendiente','pagado','atrasado') DEFAULT 'pendiente'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pagos`
--

INSERT INTO `pagos` (`id_pago`, `id_contrato`, `fecha_pago`, `monto`, `estado`) VALUES
(1, 3, '2025-08-30', 400.00, 'pagado');

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
(1, '12345678', 'sincnombre123', 'sincnombre123', '1231213', 'jjjj@gmail.com', 'casa mi casa 300'),
(3, '33539441', 'Garay', 'Soledad Malvina', '223344556677', 'yoni@fff.com', 'micasaotucasa123'),
(4, '35115723', 'Moreno', 'Roberto', '321456789', 'moreno.robert@gmail.com', 'Su casa bandera'),
(7, '50122444', 'Moreno', 'Roberta', '223322', 'moreno.roberta@gmail.com', 'micasaotucasa');

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  `contraseña` varchar(255) NOT NULL,
  `rol` enum('administrador','empleado') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  MODIFY `id_contrato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `inmuebles`
--
ALTER TABLE `inmuebles`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `inquilinos`
--
ALTER TABLE `inquilinos`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT for table `pagos`
--
ALTER TABLE `pagos`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

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
