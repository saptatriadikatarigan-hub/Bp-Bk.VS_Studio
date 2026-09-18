-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Sep 18, 2026 at 09:25 AM
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
-- Database: `db_bp_bk`
--

-- --------------------------------------------------------

--
-- Table structure for table `bimbingan_konseling`
--

CREATE TABLE `bimbingan_konseling` (
  `id_konseling` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `tanggal_konseling` datetime NOT NULL,
  `permasalahan` text NOT NULL,
  `solusi_hasil` text NOT NULL,
  `status_konseling` enum('mengajukan','proses','selesai') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `buku`
--

CREATE TABLE `buku` (
  `nomor_buku` int(11) NOT NULL,
  `judul_buku` varchar(100) NOT NULL,
  `jenis_buku` varchar(100) NOT NULL,
  `tahun_terbit` year(4) NOT NULL,
  `penerbit` varchar(100) NOT NULL,
  `pengarang` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `guru`
--

CREATE TABLE `guru` (
  `id_guru` int(11) NOT NULL,
  `nama_guru` varchar(100) NOT NULL,
  `nip` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guru`
--

INSERT INTO `guru` (`id_guru`, `nama_guru`, `nip`) VALUES
(1, 'Pak Budi', '198001'),
(2, 'Bu Siti', '198002'),
(3, 'Pak Andi', '198003');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal_guru`
--

CREATE TABLE `jadwal_guru` (
  `id_jadwal_guru` int(11) NOT NULL,
  `id_guru` int(11) NOT NULL,
  `hari` enum('Senin','Selasa','Rabu','Kamis','Jumat','Sabtu') NOT NULL,
  `jam_mulai` time NOT NULL,
  `jam_selesai` time NOT NULL,
  `status` enum('Tersedia','Tidak Tersedia') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jadwal_guru`
--

INSERT INTO `jadwal_guru` (`id_jadwal_guru`, `id_guru`, `hari`, `jam_mulai`, `jam_selesai`, `status`) VALUES
(1, 3, 'Selasa', '08:00:00', '10:00:00', 'Tidak Tersedia'),
(2, 1, 'Rabu', '04:00:00', '10:00:00', 'Tidak Tersedia');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal_konseling`
--

CREATE TABLE `jadwal_konseling` (
  `id_jadwal` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `id_guru` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `jam` time NOT NULL,
  `keperluan` text NOT NULL,
  `status` enum('Menunggu','Disetujui','Ditolak','Selesai') NOT NULL DEFAULT 'Menunggu',
  `alasan_penolakan` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jadwal_konseling`
--

INSERT INTO `jadwal_konseling` (`id_jadwal`, `id_siswa`, `id_guru`, `tanggal`, `jam`, `keperluan`, `status`, `alasan_penolakan`) VALUES
(1, 5, 2, '2026-08-25', '09:00:00', 'Masalah belajar', 'Ditolak', NULL),
(2, 6, 2, '0000-00-00', '00:00:10', 'Kritis identiias', 'Disetujui', NULL),
(3, 7, 3, '2026-04-21', '10:00:00', 'Pembelajaran', 'Menunggu', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `kategori_pelanggaran`
--

CREATE TABLE `kategori_pelanggaran` (
  `id_kategori` int(11) NOT NULL,
  `nama_pelanggaran` varchar(150) NOT NULL,
  `poin` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `konseling`
--

CREATE TABLE `konseling` (
  `id_konseling` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `id_guru` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `jenis_konseling` varchar(150) NOT NULL,
  `masalah` text NOT NULL,
  `hasil` text NOT NULL,
  `tindak_lanjut` text NOT NULL,
  `status` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `id_user` int(11) NOT NULL,
  `role` enum('admin','anggota') NOT NULL,
  `user` varchar(100) NOT NULL,
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`id_user`, `role`, `user`, `password`) VALUES
(1, 'admin', 'sapta', 'admin123'),
(2, 'admin', 'w', 'w');

-- --------------------------------------------------------

--
-- Table structure for table `pelanggaran_siswa`
--

CREATE TABLE `pelanggaran_siswa` (
  `id_pelanggaran` int(11) NOT NULL,
  `id_siswa` int(11) NOT NULL,
  `id_kategori` int(11) NOT NULL,
  `tanggal` date NOT NULL,
  `catatan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `perpus`
--

CREATE TABLE `perpus` (
  `id` int(11) NOT NULL,
  `buku` varchar(100) NOT NULL,
  `penulis` varchar(100) NOT NULL,
  `hasil` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `siswa`
--

CREATE TABLE `siswa` (
  `id_siswa` int(11) NOT NULL,
  `nisn` varchar(20) NOT NULL,
  `nama_siswa` varchar(100) NOT NULL,
  `kelas` varchar(20) NOT NULL,
  `point_pelanggaran` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `siswa`
--

INSERT INTO `siswa` (`id_siswa`, `nisn`, `nama_siswa`, `kelas`, `point_pelanggaran`) VALUES
(5, '1234567', 'sapta', 'XII-RPL-A', 1),
(6, '123456', 'kanya', 'XII-RPL-A', 1),
(7, '9876543', 'siapa', '12', 1),
(8, '87654567', 'bilal', '12', 20),
(10, '134578900', 'dawd', 'XI', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bimbingan_konseling`
--
ALTER TABLE `bimbingan_konseling`
  ADD PRIMARY KEY (`id_konseling`),
  ADD KEY `fk_bk_siswa` (`id_siswa`);

--
-- Indexes for table `buku`
--
ALTER TABLE `buku`
  ADD PRIMARY KEY (`nomor_buku`);

--
-- Indexes for table `guru`
--
ALTER TABLE `guru`
  ADD PRIMARY KEY (`id_guru`);

--
-- Indexes for table `jadwal_guru`
--
ALTER TABLE `jadwal_guru`
  ADD PRIMARY KEY (`id_jadwal_guru`),
  ADD KEY `fk_jadwal_guru_ref` (`id_guru`);

--
-- Indexes for table `jadwal_konseling`
--
ALTER TABLE `jadwal_konseling`
  ADD PRIMARY KEY (`id_jadwal`),
  ADD KEY `fk_jadwal_siswa` (`id_siswa`),
  ADD KEY `fk_jadwal_guru` (`id_guru`);

--
-- Indexes for table `kategori_pelanggaran`
--
ALTER TABLE `kategori_pelanggaran`
  ADD PRIMARY KEY (`id_kategori`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id_user`);

--
-- Indexes for table `pelanggaran_siswa`
--
ALTER TABLE `pelanggaran_siswa`
  ADD PRIMARY KEY (`id_pelanggaran`),
  ADD KEY `fk_pelanggaran_siswa` (`id_kategori`),
  ADD KEY `id_siswa` (`id_siswa`),
  ADD KEY `id_siswa_2` (`id_siswa`),
  ADD KEY `id_siswa_3` (`id_siswa`);

--
-- Indexes for table `perpus`
--
ALTER TABLE `perpus`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `siswa`
--
ALTER TABLE `siswa`
  ADD PRIMARY KEY (`id_siswa`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bimbingan_konseling`
--
ALTER TABLE `bimbingan_konseling`
  MODIFY `id_konseling` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `buku`
--
ALTER TABLE `buku`
  MODIFY `nomor_buku` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guru`
--
ALTER TABLE `guru`
  MODIFY `id_guru` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `jadwal_guru`
--
ALTER TABLE `jadwal_guru`
  MODIFY `id_jadwal_guru` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `jadwal_konseling`
--
ALTER TABLE `jadwal_konseling`
  MODIFY `id_jadwal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `kategori_pelanggaran`
--
ALTER TABLE `kategori_pelanggaran`
  MODIFY `id_kategori` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `pelanggaran_siswa`
--
ALTER TABLE `pelanggaran_siswa`
  MODIFY `id_pelanggaran` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `perpus`
--
ALTER TABLE `perpus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `siswa`
--
ALTER TABLE `siswa`
  MODIFY `id_siswa` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `bimbingan_konseling`
--
ALTER TABLE `bimbingan_konseling`
  ADD CONSTRAINT `fk_bk_siswa` FOREIGN KEY (`id_siswa`) REFERENCES `siswa` (`id_siswa`);

--
-- Constraints for table `jadwal_guru`
--
ALTER TABLE `jadwal_guru`
  ADD CONSTRAINT `fk_jadwal_guru_ref` FOREIGN KEY (`id_guru`) REFERENCES `guru` (`id_guru`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jadwal_konseling`
--
ALTER TABLE `jadwal_konseling`
  ADD CONSTRAINT `fk_jadwal_guru` FOREIGN KEY (`id_guru`) REFERENCES `guru` (`id_guru`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_jadwal_siswa` FOREIGN KEY (`id_siswa`) REFERENCES `siswa` (`id_siswa`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `pelanggaran_siswa`
--
ALTER TABLE `pelanggaran_siswa`
  ADD CONSTRAINT `fk_pelanggaran_siswa` FOREIGN KEY (`id_kategori`) REFERENCES `kategori_pelanggaran` (`id_kategori`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_ps_siswa` FOREIGN KEY (`id_siswa`) REFERENCES `siswa` (`id_siswa`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
