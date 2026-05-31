-- =========================================================
-- PHAN HE 2 - TEST CASES TONG HOP
-- Nhom: 06
--
-- Muc tieu:
-- - Test RBAC
-- - Test VPD
-- - Test OLS
-- - Test Standard Audit
-- - Test FGA
-- - Test Backup/Restore
-- =========================================================


-- =========================================================
-- TEST 0 - KIEM TRA DU LIEU GOC
-- Chay bang QLYTE_06
-- =========================================================

CONNECT QLYTE_06/123@localhost:1521/XEPDB1;

SELECT 'BENHNHAN' AS TABLE_NAME, COUNT(*) AS SO_DONG FROM BENHNHAN
UNION ALL
SELECT 'NHANVIEN', COUNT(*) FROM NHANVIEN
UNION ALL
SELECT 'HSBA', COUNT(*) FROM HSBA
UNION ALL
SELECT 'HSBA_DV', COUNT(*) FROM HSBA_DV
UNION ALL
SELECT 'DONTHUOC', COUNT(*) FROM DONTHUOC
UNION ALL
SELECT 'THONGBAO', COUNT(*) FROM THONGBAO;


-- =========================================================
-- TEST DP001 - DIEU PHOI VIEN
-- DP001 xem/them/sua BENHNHAN, tao HSBA, phan cong BS/KHOA/KTV
-- =========================================================

CONNECT DP001/123@localhost:1521/XEPDB1;

-- DP xem toan bo BENHNHAN
SELECT MABN, TENBN, PHAI, CCCD
FROM QLYTE_06.BENHNHAN
ORDER BY MABN;

-- DP sua thong tin benh nhan
UPDATE QLYTE_06.BENHNHAN
SET TENBN = TENBN
WHERE MABN = 'BN001';

COMMIT;

-- DP tao HSBA moi
INSERT INTO QLYTE_06.HSBA(MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN)
VALUES ('HS_TEST_DP', 'BN001', DATE '2026-05-27', NULL, NULL, 'BS001', 'K01', NULL);

COMMIT;

-- DP phan cong bac si/khoa
UPDATE QLYTE_06.HSBA
SET MABS = 'BS001',
    MAKHOA = 'K01'
WHERE MAHSBA = 'HS_TEST_DP';

COMMIT;


-- =========================================================
-- TEST 1 - RBAC + VPD BENH NHAN
-- User BN001 chi thay thong tin cua chinh minh.
-- Duoc update dia chi / tien su benh.
-- Khong duoc update TENBN.
-- =========================================================

CONNECT BN001/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MABN, TENBN, PHAI, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, USERNAME
FROM QLYTE_06.BENHNHAN;

-- Hop le: update cot duoc phep
UPDATE QLYTE_06.BENHNHAN
SET SONHA = N'99'
WHERE MABN = 'BN001';

COMMIT;

-- Khong hop le: BN khong duoc sua ho ten
-- Ky vong: ORA-01031 insufficient privileges
UPDATE QLYTE_06.BENHNHAN
SET TENBN = N'Ten bi sua sai'
WHERE MABN = 'BN001';


-- =========================================================
-- TEST 2 - VPD BENH NHAN KHONG SUA DUOC DONG NGUOI KHAC
-- Ky vong: 0 rows updated
-- =========================================================

CONNECT BN001/123@localhost:1521/XEPDB1;

UPDATE QLYTE_06.BENHNHAN
SET SONHA = N'88'
WHERE MABN = 'BN002';

COMMIT;


-- =========================================================
-- TEST 3 - RBAC + VPD BAC SI
-- BS001 chi thay HSBA minh phu trach.
-- Du lieu mau: BS001 phu trach HS001, HS004.
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MAHSBA, MABN, MABS, CHANDOAN, DIEUTRI, KETLUAN
FROM QLYTE_06.HSBA
ORDER BY MAHSBA;

-- Hop le: update HSBA minh phu trach
UPDATE QLYTE_06.HSBA
SET CHANDOAN = N'Test VPD/FGA - cap nhat boi BS001'
WHERE MAHSBA = 'HS001';

COMMIT;

-- Khong tac dong: HS002 thuoc BS002, BS001 khong thay do VPD
-- Ky vong: 0 rows updated
UPDATE QLYTE_06.HSBA
SET CHANDOAN = N'Cap nhat sai quyen'
WHERE MAHSBA = 'HS002';

COMMIT;


-- =========================================================
-- TEST 4 - BAC SI XEM BENH NHAN LIEN QUAN
-- BS001 chi thay BN co HSBA do minh phu trach.
-- Ky vong: BN001, BN004.
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT MABN, TENBN, USERNAME
FROM QLYTE_06.BENHNHAN
ORDER BY MABN;


-- =========================================================
-- TEST 5 - RBAC + VPD KY THUAT VIEN
-- KT001 chi thay HSBA_DV duoc phan cong.
-- Du lieu mau: KT001 co HS001, HS003.
-- =========================================================

CONNECT KT001/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MAHSBA, LOAIDV, MAKT, KETQUA
FROM QLYTE_06.HSBA_DV
ORDER BY MAHSBA;

-- Hop le: KT001 cap nhat ket qua dong cua minh
UPDATE QLYTE_06.HSBA_DV
SET KETQUA = N'Test VPD/FGA - ket qua cap nhat boi KT001'
WHERE MAHSBA = 'HS001';

COMMIT;

-- Khong tac dong: HS002 thuoc KT002
-- Ky vong: 0 rows updated
UPDATE QLYTE_06.HSBA_DV
SET KETQUA = N'Cap nhat sai quyen'
WHERE MAHSBA = 'HS002';

COMMIT;

-- Khong hop le: KT khong duoc update MAKT
-- Ky vong: ORA-01031
UPDATE QLYTE_06.HSBA_DV
SET MAKT = 'KT002'
WHERE MAHSBA = 'HS001';


-- =========================================================
-- TEST 5B - BAC SI THEM / XOA HSBA_DV
-- BS001 duoc them/xoa dich vu lien quan HSBA minh phu trach
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT MAHSBA, LOAIDV, NGAYDV, MAKT, KETQUA
FROM QLYTE_06.HSBA_DV
ORDER BY MAHSBA, NGAYDV;

-- Hop le: them dich vu cho HSBA minh phu trach
INSERT INTO QLYTE_06.HSBA_DV(MAHSBA, LOAIDV, NGAYDV, MAKT, KETQUA)
VALUES ('HS001', N'Dich vu test BS001', DATE '2026-05-27', NULL, NULL);

COMMIT;

-- Hop le: xoa dich vu vua them
DELETE FROM QLYTE_06.HSBA_DV
WHERE MAHSBA = 'HS001'
  AND LOAIDV = N'Dich vu test BS001'
  AND NGAYDV = DATE '2026-05-27';

COMMIT;

-- Khong hop le hoac bi chan boi VPD: them dich vu tren HSBA khong phu trach
INSERT INTO QLYTE_06.HSBA_DV(MAHSBA, LOAIDV, NGAYDV, MAKT, KETQUA)
VALUES ('HS002', N'Dich vu sai quyen BS001', DATE '2026-05-27', NULL, NULL);


-- =========================================================
-- TEST 6 - BAC SI CAP NHAT DON THUOC
-- Dung de test RBAC + VPD + FGA tren DONTHUOC
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
FROM QLYTE_06.DONTHUOC
ORDER BY MAHSBA, NGAYDT, TENTHUOC;

-- Hop le: BS001 them don thuoc tren HSBA minh phu trach
INSERT INTO QLYTE_06.DONTHUOC(MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG)
VALUES ('HS001', DATE '2026-05-27', N'Thuoc test BS001', N'1 vien/ngay');

COMMIT;

-- Hop le: cap nhat TENTHUOC, LIEUDUNG de kich hoat FGA
UPDATE QLYTE_06.DONTHUOC
SET TENTHUOC = N'Thuoc test BS001 500mg',
    LIEUDUNG = N'2 vien/ngay'
WHERE MAHSBA = 'HS001'
  AND NGAYDT = DATE '2026-05-27'
  AND TENTHUOC = N'Thuoc test BS001';

COMMIT;

-- Hop le: xoa don thuoc vua them
DELETE FROM QLYTE_06.DONTHUOC
WHERE MAHSBA = 'HS001'
  AND NGAYDT = DATE '2026-05-27'
  AND TENTHUOC = N'Thuoc test BS001 500mg';

COMMIT;

-- Khong hop le hoac 0 rows: BS001 thao tac tren HSBA khong phu trach
INSERT INTO QLYTE_06.DONTHUOC(MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG)
VALUES ('HS002', DATE '2026-05-27', N'Thuoc sai quyen', N'1 vien/ngay');


-- =========================================================
-- TEST 7 - OLS THONGBAO
-- U1 có label cao nhất nên thấy nhiều nhất
-- U8 chỉ thấy thông báo phù hợp với label của mình, nếu có
-- =========================================================

CONNECT U1/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MATB, NOIDUNG, DIADIEM
FROM QLYTE_06.THONGBAO
ORDER BY MATB;


CONNECT U8/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MATB, NOIDUNG, DIADIEM
FROM QLYTE_06.THONGBAO
ORDER BY MATB;



-- =========================================================
-- TEST NHANVIEN CÁ NHÂN - TC#5
-- Nhân viên chỉ xem dòng của mình và chỉ sửa QUEQUAN, SODT
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, USERNAME
FROM QLYTE_06.NHANVIEN;

-- Hợp lệ: update QUEQUAN, SODT
UPDATE QLYTE_06.NHANVIEN
SET QUEQUAN = N'TP. Ho Chi Minh',
    SODT = '0900000001'
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER');

COMMIT;

-- Không hợp lệ: không được sửa HOTEN
-- Kỳ vọng: ORA-01031
UPDATE QLYTE_06.NHANVIEN
SET HOTEN = N'Ten khong duoc sua'
WHERE USERNAME = SYS_CONTEXT('USERENV', 'SESSION_USER');


-- =========================================================
-- TEST 8 - XEM STANDARD AUDIT LOG
-- Chạy bằng SYS AS SYSDBA
-- =========================================================

CONNECT SYS/<your_password>@localhost:1521/XEPDB1 AS SYSDBA;

SELECT USERNAME,
       OWNER,
       OBJ_NAME,
       ACTION_NAME,
       RETURNCODE,
       TIMESTAMP
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'QLYTE_06'
  AND OBJ_NAME IN (
      'BENHNHAN',
      'NHANVIEN',
      'HSBA',
      'HSBA_DV',
      'DONTHUOC',
      'THONGBAO',
      'VW_AUDIT_HSBA_BACSI',
      'PROC_AUDIT_TEST',
      'FN_AUDIT_TEST'
  )
ORDER BY TIMESTAMP DESC;


-- =========================================================
-- TEST 9 - XEM FGA AUDIT LOG
-- Chay bang SYS AS SYSDBA
-- =========================================================

CONNECT SYS/<your_password>@localhost:1521/XEPDB1 AS SYSDBA;

-- FGA DONTHUOC
SELECT DB_USER, OBJECT_NAME, POLICY_NAME, STATEMENT_TYPE, SQL_TEXT, TIMESTAMP
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'QLYTE_06'
  AND OBJECT_NAME = 'DONTHUOC'
ORDER BY TIMESTAMP DESC;

-- FGA HSBA
SELECT DB_USER, OBJECT_NAME, POLICY_NAME, STATEMENT_TYPE, SQL_TEXT, TIMESTAMP
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'QLYTE_06'
  AND OBJECT_NAME = 'HSBA'
ORDER BY TIMESTAMP DESC;

-- FGA HSBA_DV
SELECT DB_USER, OBJECT_NAME, POLICY_NAME, STATEMENT_TYPE, SQL_TEXT, TIMESTAMP
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'QLYTE_06'
  AND OBJECT_NAME = 'HSBA_DV'
ORDER BY TIMESTAMP DESC;


-- =========================================================
-- TEST 10 - BACKUP / RESTORE DATA CHECK
-- Neu da import sang QLYTE_06_RESTORE thi chay doan nay.
-- =========================================================

CONNECT SYS/<your_password>@localhost:1521/XEPDB1 AS SYSDBA;

SELECT 'BENHNHAN' AS TABLE_NAME, COUNT(*) AS SO_DONG FROM QLYTE_06_RESTORE.BENHNHAN
UNION ALL
SELECT 'NHANVIEN', COUNT(*) FROM QLYTE_06_RESTORE.NHANVIEN
UNION ALL
SELECT 'HSBA', COUNT(*) FROM QLYTE_06_RESTORE.HSBA
UNION ALL
SELECT 'HSBA_DV', COUNT(*) FROM QLYTE_06_RESTORE.HSBA_DV
UNION ALL
SELECT 'DONTHUOC', COUNT(*) FROM QLYTE_06_RESTORE.DONTHUOC
UNION ALL
SELECT 'THONGBAO', COUNT(*) FROM QLYTE_06_RESTORE.THONGBAO;