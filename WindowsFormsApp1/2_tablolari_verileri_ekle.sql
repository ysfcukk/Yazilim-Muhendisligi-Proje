-- Tablolarý ve verileri veri tabanýna ekle

use SelfServisKasa;

CREATE TABLE marka (
    marka_adi VARCHAR(100) NOT NULL,
    marka_ID INT PRIMARY KEY,
    marka_indirimi INT NOT NULL,-- yüzde kaç indirim
    CHECK (marka.marka_indirimi < 50) -- inidirm %50 den fazla olamaz
);
CREATE TABLE Urunler (
    UrunID INT PRIMARY KEY,
    UrunAdi VARCHAR(20) NOT NULL,
    BirimFiyat DECIMAL(10, 2) NOT NULL,
    StokMiktari INT NOT NULL,
    Agýrlýk INT NOT NULL, -- Gram cinsinden
    ürün_Ýndirimi INT NOT NULL ,-- yüzde kaç indirim
    urun_marka_id INT NOT NULL,
    CHECK (Urunler.ürün_Ýndirimi < 50),-- inidirm %50 den fazla olamaz

    FOREIGN KEY (urun_marka_id) REFERENCES marka(marka_ID)
);

CREATE TABLE musteri (
    musteri_adi VARCHAR(20) NOT NULL,
    musteri_tel_no VARCHAR(20),
    musteri_dogum_yili INT NOT NULL,
    kayýtlanma_yýlý INT NOT NULL,
    toplam_harcama INT NOT NULL,
    musteri_indirimi INT NOT NULL,-- yüzde kaç indirim
    CHECK (musteri.musteri_indirimi < 50)-- inidirm %50 den fazla olamaz
);
----------------------------------------------------------------------------------------------------------------
-- marka tablosuna veri ekleme
INSERT INTO marka (marka_adi, marka_ID, marka_indirimi) VALUES
('Marka1', 1, 0),
('Marka2', 2, 0),
('Marka3', 3, 0),
('Marka4', 4, 15),
('Marka5', 5, 0),
('Marka6', 6, 0),
('Marka7', 7, 0),
('Marka8', 8, 0),
('Marka9', 9, 0),
('Marka10', 10, 0);

-- Urunler tablosuna veri ekleme
INSERT INTO Urunler (UrunID, UrunAdi, BirimFiyat, StokMiktari, Agýrlýk, ürün_Ýndirimi, urun_marka_id) VALUES
(1, 'Ürün1', 15.99, 100, 200, 10, 1),
(2, 'Ürün2', 25.49, 150, 300, 0, 2),
(3, 'Ürün3', 8.99, 75, 150, 0, 3),
(4, 'Ürün4', 19.99, 120, 250, 5, 4),
(5, 'Ürün5', 12.79, 90, 180, 15, 5),
(6, 'Ürün6', 32.99, 80, 220, 25, 6),
(7, 'Ürün7', 7.49, 200, 400, 0, 7),
(8, 'Ürün8', 14.99, 60, 120, 8, 8),
(9, 'Ürün9', 45.00, 50, 100, 0, 9),
(10, 'Ürün10', 55.99, 30, 60, 0, 10);


-- musteri tablosuna  veri ekleme
INSERT INTO musteri (musteri_adi, musteri_tel_no, musteri_dogum_yili, kayýtlanma_yýlý, toplam_harcama, musteri_indirimi) VALUES
('Müþteri1', '5551234567', 1980, 2015, 500, 0),
('Müþteri2', '5559876543', 1995, 2018, 0, 0),
('Müþteri3', '5551112233', 2000, 2020, 800, 0),
('Müþteri4', '5555555555', 1975, 2010, 0, 0),
('Müþteri5', '5556667777', 1988, 2012, 300, 15),
('Müþteri6', '5558889999', 1990, 2017, 700, 0),
('Müþteri7', '5554443333', 2005, 2019, 1500, 0),
('Müþteri8', '5552221111', 1992, 2016, 0, 8),
('Müþteri9', '5559990000', 1983, 2013, 10, 0),
('Müþteri10', '5557778888', 1970, 2011, 200, 0);