-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 22, 2025 at 07:45 PM
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
-- Indexes for dumped tables
--

--
-- Indexes for table `inquilinos`
--
ALTER TABLE `inquilinos`
  ADD PRIMARY KEY (`id_inquilino`);

--
-- Indexes for table `propietarios`
--
ALTER TABLE `propietarios`
  ADD PRIMARY KEY (`id_propietario`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `inquilinos`
--
ALTER TABLE `inquilinos`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `propietarios`
--
ALTER TABLE `propietarios`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
