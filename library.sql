-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 22 Eki 2023, 20:50:23
-- Sunucu sürümü: 10.4.28-MariaDB
-- PHP Sürümü: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `library`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `admin`
--

CREATE TABLE `admin` (
  `id` int(11) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `admin`
--

INSERT INTO `admin` (`id`, `password`) VALUES
(1, '1234');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `writer` varchar(255) NOT NULL,
  `pageCount` int(11) NOT NULL,
  `year` int(11) NOT NULL,
  `genre` varchar(255) NOT NULL,
  `shelfCode` varchar(255) NOT NULL,
  `barcodeNo` varchar(255) NOT NULL,
  `count` int(11) NOT NULL,
  `availableCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `books`
--

INSERT INTO `books` (`id`, `name`, `writer`, `pageCount`, `year`, `genre`, `shelfCode`, `barcodeNo`, `count`, `availableCount`) VALUES
(5, 'Book A', 'Author A', 300, 2020, 'Fiction', 'S001', 'B0001', 5, 4),
(6, 'Book B', 'Author B', 250, 2019, 'Mystery', 'S002', 'B0002', 3, 3),
(7, 'Book C', 'Author C', 400, 2021, 'Fantasy', 'S003', 'B0003', 8, 8),
(8, 'Book D', 'Author D', 350, 2018, 'Sci-Fi', 'S004', 'B0004', 6, 6),
(9, 'Book E', 'Author E', 280, 2022, 'Romance', 'S005', 'B0005', 4, 2);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `lendbooks`
--

CREATE TABLE `lendbooks` (
  `id` int(11) NOT NULL,
  `barcodeNo` varchar(255) NOT NULL,
  `studentID` varchar(255) NOT NULL,
  `lendingDate` date NOT NULL,
  `dueDate` date NOT NULL,
  `librarianName` varchar(255) NOT NULL,
  `isReturned` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `lendbooks`
--

INSERT INTO `lendbooks` (`id`, `barcodeNo`, `studentID`, `lendingDate`, `dueDate`, `librarianName`, `isReturned`) VALUES
(13, 'B0001', '1234', '2023-10-22', '2023-11-05', 'Test Öğrenci', 1),
(14, 'B0001', '4321', '2023-10-22', '2023-11-05', 'Test Öğrenci', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `librarians`
--

CREATE TABLE `librarians` (
  `id` int(11) NOT NULL,
  `nameSurname` varchar(255) NOT NULL,
  `studentID` int(11) NOT NULL,
  `className` varchar(255) NOT NULL,
  `dutyDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `librarians`
--

INSERT INTO `librarians` (`id`, `nameSurname`, `studentID`, `className`, `dutyDate`) VALUES
(11, 'Test Öğrenci', 1111, '10-A', '2023-10-22');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `students`
--

CREATE TABLE `students` (
  `id` int(11) NOT NULL,
  `nameSurname` varchar(255) NOT NULL,
  `className` varchar(255) NOT NULL,
  `studentID` varchar(255) NOT NULL,
  `readBooksCount` int(11) NOT NULL,
  `checkOutBooksCount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Tablo döküm verisi `students`
--

INSERT INTO `students` (`id`, `nameSurname`, `className`, `studentID`, `readBooksCount`, `checkOutBooksCount`) VALUES
(8, 'Alice Johnson', '11-A', '1234', 7, 0),
(9, 'Bob Smith', '11-B', '5678', 4, 0),
(10, 'Charlie Brown', '11-A', '9876', 7, 0),
(11, 'David Wilson', '11-C', '4321', 2, 1),
(12, 'Emily Davis', '11-B', '8765', 4, 0),
(13, 'Frank Miller', '11-A', '3456', 6, 0),
(14, 'Grace Taylor', '11-C', '7890', 5, 0),
(15, 'Henry Harris', '11-B', '2345', 3, 0),
(16, 'Isabella Martinez', '11-A', '6789', 4, 0),
(17, 'Jack Thompson', '11-A', '6543', 8, 0);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `lendbooks`
--
ALTER TABLE `lendbooks`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `librarians`
--
ALTER TABLE `librarians`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `admin`
--
ALTER TABLE `admin`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `lendbooks`
--
ALTER TABLE `lendbooks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- Tablo için AUTO_INCREMENT değeri `librarians`
--
ALTER TABLE `librarians`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `students`
--
ALTER TABLE `students`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
