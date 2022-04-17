-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 14 Mar 2021, 17:38:41
-- Sunucu sürümü: 10.4.14-MariaDB
-- PHP Sürümü: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `medyalar`
--
CREATE DATABASE IF NOT EXISTS `medyalar` DEFAULT CHARACTER SET utf8 COLLATE utf8_turkish_ci;
USE `medyalar`;

DELIMITER $$
--
-- İşlevler
--
CREATE DEFINER=`root`@`localhost` FUNCTION `DiziIzlendiKontrol` (`diziid` INT, `kisiid` INT) RETURNS TINYINT(1) NO SQL
RETURN (SELECT IF(COUNT(b.id)>0,0,1) FROM (SELECT id FROM bolum WHERE did=diziid) AS b LEFT JOIN (SELECT izle,mid FROM izleme WHERE tip='d' AND kid=kisiid) AS i ON b.id=i.mid WHERE i.izle=0 OR ISNULL(i.izle))$$

CREATE DEFINER=`root`@`localhost` FUNCTION `SezonIzlendiKontrol` (`sezonno` INT, `diziid` INT, `kisiid` INT) RETURNS TINYINT(1) NO SQL
RETURN (SELECT IF(COUNT(b.id)>0,0,1) FROM (SELECT id FROM bolum WHERE did=diziid AND sno=sezonno) AS b LEFT JOIN (SELECT izle,mid FROM izleme WHERE tip='d' AND kid=kisiid) AS i ON b.id=i.mid WHERE i.izle=0 OR ISNULL(i.izle))$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `bolum`
--

CREATE TABLE `bolum` (
  `id` int(11) NOT NULL,
  `did` int(11) NOT NULL,
  `sno` int(11) NOT NULL,
  `bno` int(11) NOT NULL,
  `tip` enum('b','s','f') COLLATE utf8_turkish_ci NOT NULL,
  `video` varchar(100) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `dizi`
--

CREATE TABLE `dizi` (
  `id` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tur` enum('Yerli','Yabancı') COLLATE utf8_turkish_ci NOT NULL,
  `resim` varchar(100) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tetikleyiciler `dizi`
--
DELIMITER $$
CREATE TRIGGER `dizi_sil` AFTER DELETE ON `dizi` FOR EACH ROW BEGIN
            DELETE FROM izleme WHERE izleme.tip='d' AND izleme.mid=OLD.id ;
            DELETE FROM turler WHERE turler.tip='d' AND turler.mid=OLD.id ;
            DELETE FROM oyuncular WHERE oyuncular.tip='d' AND oyuncular.mid=OLD.id ;
            DELETE FROM yonetmenler WHERE yonetmenler.tip='d' AND yonetmenler.mid=OLD.id ;
            DELETE FROM bolum WHERE bolum.did=OLD.id ;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `film`
--

CREATE TABLE `film` (
  `id` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `orjad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tur` enum('Yerli','Yabancı') COLLATE utf8_turkish_ci NOT NULL,
  `dil` enum('Dublaj','Altyazı','Türkçe') COLLATE utf8_turkish_ci NOT NULL,
  `yil` int(11) NOT NULL,
  `imdb` decimal(3,1) NOT NULL,
  `fragman` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `resim` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `cover` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `video` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `ozet` text COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tetikleyiciler `film`
--
DELIMITER $$
CREATE TRIGGER `film_sil` AFTER DELETE ON `film` FOR EACH ROW BEGIN
            DELETE FROM izleme WHERE izleme.tip='f' AND izleme.mid=OLD.id ;
            DELETE FROM turler WHERE turler.tip='f' AND turler.mid=OLD.id ;
            DELETE FROM oyuncular WHERE oyuncular.tip='f' AND oyuncular.mid=OLD.id ;
            DELETE FROM yonetmenler WHERE yonetmenler.tip='f' AND yonetmenler.mid=OLD.id ;
        END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `izleme`
--

CREATE TABLE `izleme` (
  `id` int(11) NOT NULL,
  `kid` int(11) NOT NULL,
  `mid` int(11) NOT NULL,
  `sure` int(11) NOT NULL,
  `uzunluk` int(11) NOT NULL,
  `izle` tinyint(1) NOT NULL,
  `tip` enum('f','d') COLLATE utf8_turkish_ci NOT NULL,
  `tarih` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kanal`
--

CREATE TABLE `kanal` (
  `id` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tur` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `logo` varchar(100) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

CREATE TABLE `kullanici` (
  `id` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`id`, `ad`) VALUES
(1, 'Yasin');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `oyuncular`
--

CREATE TABLE `oyuncular` (
  `id` int(11) NOT NULL,
  `mid` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tip` enum('f','d') COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `turler`
--

CREATE TABLE `turler` (
  `id` int(11) NOT NULL,
  `mid` int(11) NOT NULL,
  `tur` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `tip` enum('f','d') COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yonetmenler`
--

CREATE TABLE `yonetmenler` (
  `id` int(11) NOT NULL,
  `mid` int(11) NOT NULL,
  `ad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `tip` enum('f','d') COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `bolum`
--
ALTER TABLE `bolum`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `dizi`
--
ALTER TABLE `dizi`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `film`
--
ALTER TABLE `film`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `izleme`
--
ALTER TABLE `izleme`
  ADD PRIMARY KEY (`id`),
  ADD KEY `kid` (`kid`);

--
-- Tablo için indeksler `kanal`
--
ALTER TABLE `kanal`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `kullanici`
--
ALTER TABLE `kullanici`
  ADD PRIMARY KEY (`id`);

--
-- Tablo için indeksler `oyuncular`
--
ALTER TABLE `oyuncular`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mid` (`mid`);

--
-- Tablo için indeksler `turler`
--
ALTER TABLE `turler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mid` (`mid`);

--
-- Tablo için indeksler `yonetmenler`
--
ALTER TABLE `yonetmenler`
  ADD PRIMARY KEY (`id`),
  ADD KEY `mid` (`mid`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `bolum`
--
ALTER TABLE `bolum`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=67;

--
-- Tablo için AUTO_INCREMENT değeri `dizi`
--
ALTER TABLE `dizi`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `film`
--
ALTER TABLE `film`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9728;

--
-- Tablo için AUTO_INCREMENT değeri `izleme`
--
ALTER TABLE `izleme`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=294;

--
-- Tablo için AUTO_INCREMENT değeri `kullanici`
--
ALTER TABLE `kullanici`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `oyuncular`
--
ALTER TABLE `oyuncular`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66032;

--
-- Tablo için AUTO_INCREMENT değeri `turler`
--
ALTER TABLE `turler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16875;

--
-- Tablo için AUTO_INCREMENT değeri `yonetmenler`
--
ALTER TABLE `yonetmenler`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7757;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `izleme`
--
ALTER TABLE `izleme`
  ADD CONSTRAINT `izleme_ibfk_1` FOREIGN KEY (`kid`) REFERENCES `kullanici` (`id`);

--
-- Tablo kısıtlamaları `oyuncular`
--
ALTER TABLE `oyuncular`
  ADD CONSTRAINT `oyuncular_ibfk_1` FOREIGN KEY (`mid`) REFERENCES `film` (`id`);

--
-- Tablo kısıtlamaları `turler`
--
ALTER TABLE `turler`
  ADD CONSTRAINT `turler_ibfk_1` FOREIGN KEY (`mid`) REFERENCES `film` (`id`);

--
-- Tablo kısıtlamaları `yonetmenler`
--
ALTER TABLE `yonetmenler`
  ADD CONSTRAINT `yonetmenler_ibfk_1` FOREIGN KEY (`mid`) REFERENCES `film` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
