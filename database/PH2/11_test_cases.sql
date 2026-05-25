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
-- TEST 6 - BAC SI CAP NHAT DON THUOC
-- Dung de test RBAC + VPD + FGA tren DONTHUOC
-- =========================================================

CONNECT BS001/123@localhost:1521/XEPDB1;

SELECT MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
FROM QLYTE_06.DONTHUOC
ORDER BY MAHSBA;

UPDATE QLYTE_06.DONTHUOC
SET LIEUDUNG = N'Test FGA - cap nhat lieu dung boi BS001'
WHERE MAHSBA = 'HS001'
  AND TENTHUOC = N'Aspirin';

COMMIT;


-- =========================================================
-- TEST 7 - OLS THONGBAO
-- U1 co label cao nhat nen thay nhieu nhat.
-- U8 chi thay thong bao phu hop label cua minh, neu co.
-- U2/U3 co the no rows selected neu khong co dong dung TM:HCM/TK:HN.
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


CONNECT U2/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MATB, NOIDUNG, DIADIEM
FROM QLYTE_06.THONGBAO
ORDER BY MATB;


CONNECT U3/123@localhost:1521/XEPDB1;

SELECT SYS_CONTEXT('USERENV', 'SESSION_USER') AS CURRENT_USER
FROM DUAL;

SELECT MATB, NOIDUNG, DIADIEM
FROM QLYTE_06.THONGBAO
ORDER BY MATB;


-- =========================================================
-- TEST 8 - XEM STANDARD AUDIT LOG
-- Chay bang SYS AS SYSDBA
-- =========================================================

CONNECT SYS/Giatuan27092005@localhost:1521/XEPDB1 AS SYSDBA;

SELECT USERNAME,
       OWNER,
       OBJ_NAME,
       ACTION_NAME,
       TIMESTAMP
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'QLYTE_06'
  AND OBJ_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC', 'THONGBAO')
ORDER BY TIMESTAMP DESC;


-- =========================================================
-- TEST 9 - XEM FGA AUDIT LOG
-- Chay bang SYS AS SYSDBA
-- =========================================================

CONNECT SYS/Giatuan27092005@localhost:1521/XEPDB1 AS SYSDBA;

SELECT DB_USER,
       OBJECT_SCHEMA,
       OBJECT_NAME,
       POLICY_NAME,
       STATEMENT_TYPE,
       SQL_TEXT,
       TIMESTAMP
FROM DBA_FGA_AUDIT_TRAIL
WHERE OBJECT_SCHEMA = 'QLYTE_06'
  AND OBJECT_NAME IN ('DONTHUOC', 'HSBA', 'HSBA_DV')
ORDER BY TIMESTAMP DESC;


-- =========================================================
-- TEST 10 - BACKUP / RESTORE DATA CHECK
-- Neu da import sang QLYTE_06_RESTORE thi chay doan nay.
-- =========================================================

CONNECT QLYTE_06_RESTORE/123@localhost:1521/XEPDB1;

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