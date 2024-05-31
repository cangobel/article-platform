--USE SQLDersDb;


---- Örnek veritabanı için, “Urunler” tablosunu kullanarak “Notebook” ürününün satış miktarı 
----4 adetten fazla ise satış miktarını yazıp tebrik eden, 3-4 arası ise “satışlara dikkat edelim”, 3 
----adetten az ise yetersiz satış yazan T-SQL komutlarını yazınız. 

--DECLARE @Urun_Sayisi VARCHAR(10)
-- SELECT @Urun_Sayisi=COUNT(*) FROM Urunler WHERE (Urun_Fiyati<200)
-- IF (@Urun_Sayisi>0) 
--PRINT 'Fiyati 200TL den az '+@Urun_Sayisi+'  ürün vardır'
-- ELSE
-- PRINT 'Fiyati 200TL den az ürün yoktur'

--DECLARE @urunId int;
--DECLARE @urunSayisi int;

--SELECT @urunId = Urunler.Urun_No  FROM Urunler where Urun_Adi='Notebook'; 
--SELECT @urunSayisi = SUM(Satislar.Miktar) FROM Satislar WHERE Urun_No=@urunId

--IF(@urunSayisi > 4)
--	PRINT 'tebrikler'
--ELSE IF(@urunSayisi > 3)
--	PRINT 'dikkat edelim'
--ELSE
--	PRINT 'yetersiz satis'



----cursor tanımlama ve kullanma
----Okunacak değişkenler tanımlanır.
--DECLARE @AD nvarchar(100);DECLARE @CINS nvarchar(5);DECLARE @METIN nvarchar(max)--İmleç veri kümesi için tanımlanır.
--DECLARE Calısan_cursor CURSOR FOR SELECT Adi, Cinsiyet From Calisanlar Order By Adi--İmleç açılır
--Open Calısan_cursor

--SET @METIN= 'Firmamızda ' 
--FETCH NEXT FROM Calısan_cursor INTO @AD, @CINS
--SET @METIN= @METIN + @AD + +'('+ @CINS+')'

--WHILE @@FETCH_STATUS = 0
--Begin
-- FETCH NEXT FROM Calısan_cursor INTO @AD, @CINS --Soraki kayda ilerlenir.
-- SET @METIN=@METIN +', '+  @AD +'('+ @CINS+')' -- Her bir veri metne eklenir. 
-- END
--SET @METIN= @METIN +' adlı çalışanlar bulunmaktadır.' 
--Select @METIN--İmleç kapanarak silinir.
--Close Calısan_cursor
--deallocate Calısan_cursor



----Error fonskiyonları
-- BEGIN TRY
-- SELECT 4/0
-- END TRY
-- BEGIN CATCH
--    SELECT
-- ERROR_NUMBER() AS Hata_Numarasi,
-- ERROR_SEVERITY() AS Hata_Duzeyi,
-- ERROR_STATE() AS Hata_Durum_No,
-- ERROR_LINE() AS Hata_Satir_No,
-- ERROR_MESSAGE() AS Hata_Mesaj
-- END CATCH


 --CREATE PROCEDURE sp_CalisanBolum
 --AS
 --BEGIN
 --SELECT Bolumler.Bolum_Adi, Calisanlar.Adi
 --FROM Bolumler INNER JOIN
 --      Calisanlar ON Bolumler.Bolum_No = Calisanlar.Bolum_No
 --END

 --EXEC sp_CalisanBolum