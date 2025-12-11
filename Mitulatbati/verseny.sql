-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Dec 11. 12:18
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `szelesbalas`
--
CREATE DATABASE IF NOT EXISTS `szelesbalas` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `szelesbalas`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `versenyzok`
--

CREATE TABLE IF NOT EXISTS `versenyzok` (
  `sorszam` int(11) NOT NULL AUTO_INCREMENT,
  `nev` varchar(30) DEFAULT NULL,
  `elso_leng` decimal(4,2) DEFAULT NULL,
  `masodik_leng` decimal(4,2) DEFAULT NULL,
  `harmadik_leng` decimal(4,2) DEFAULT NULL,
  `legjobb_leng` decimal(4,2) GENERATED ALWAYS AS (least(`elso_leng`,`masodik_leng`,`harmadik_leng`)) STORED,
  PRIMARY KEY (`sorszam`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `versenyzok`
--

INSERT INTO `versenyzok` (`sorszam`, `nev`, `elso_leng`, `masodik_leng`, `harmadik_leng`) VALUES
(1, 'Példa Versenyző', 1.13, 1.25, 1.09),
(2, 'Kovács Bence', 1.05, 1.15, 1.01),
(3, 'Nagy Emese', 1.22, 1.30, 1.19),
(4, 'Tóth Ádám', 0.99, 1.10, 0.95),
(5, 'Kiss Virág', 5.20, 5.10, 0.50),
(6, 'Lakatos Máté', 3.14, 2.71, 1.61),
(7, 'Horváth Zalán', 1.10, 1.20, 1.00),
(8, 'Varga Hanna', 1.50, 1.40, 1.60),
(9, 'Fekete Noel', 2.10, 2.20, 2.00),
(10, 'Mészáros Lili', 0.80, 0.90, 0.70),
(11, 'Molnár Áron', 1.30, 1.30, 1.30);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;