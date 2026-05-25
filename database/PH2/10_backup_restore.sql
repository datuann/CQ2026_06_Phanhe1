-- =========================================================
-- PHÂN HỆ 2 - BACKUP/RESTORE
-- Nhóm: 06
-- Schema: QLYTE_06

-- Mục tiêu:
-- Sao lưu Schema QLYTE_06 bằng Oracle Data Pump Export
-- Phục hồi schema bằng Oracle Data Pump Import
-- Kiểm tra dữ liệu sau khi restore

-- Lưu ý:
-- Các lệnh expdp/impdp chạy trong CMD/PowerShell, không chạy trong SQL Developer
-- Các lệnh CREATE DIRECTORY chạy bằng SYS hoặc SYSTEM
-- =========================================================


-- =========================================================
-- PHẦN A - TẠO ORACLE DIRECTORY CHO BACKUP
-- Chạy bằng SYS AS SYSDBA
-- =========================================================

-- Tạo thư mục trên Windows: D:\oracle_backup

CREATE OR REPLACE DIRECTORY PH2_BACKUP_DIR AS 'D:\oracle_backup';

GRANT READ, WRITE ON DIRECTORY PH2_BACKUP_DIR TO SYSTEM;
GRANT READ, WRITE ON DIRECTORY PH2_BACKUP_DIR TO QLYTE_06;

-- Kiểm tra DIRECTORY
SELECT DIRECTORY_NAME, DIRECTORY_PATH
FROM DBA_DIRECTORIES
WHERE DIRECTORY_NAME = 'PH2_BACKUP_DIR';

BEGIN
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'BENHNHAN', 'POL_BENHNHAN_VPD', FALSE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'HSBA', 'POL_HSBA_VPD', FALSE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'HSBA_DV', 'POL_HSBA_DV_VPD', FALSE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'DONTHUOC', 'POL_DONTHUOC_VPD', FALSE);
END;
/

BEGIN
    LBACSYS.SA_SYSDBA.DISABLE_POLICY('THONGBAO_OLS');
END;
/

BEGIN
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'BENHNHAN', 'POL_BENHNHAN_VPD', TRUE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'HSBA', 'POL_HSBA_VPD', TRUE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'HSBA_DV', 'POL_HSBA_DV_VPD', TRUE);
    DBMS_RLS.ENABLE_POLICY('QLYTE_06', 'DONTHUOC', 'POL_DONTHUOC_VPD', TRUE);
END;
/

BEGIN
    LBACSYS.SA_SYSDBA.ENABLE_POLICY('THONGBAO_OLS');
END;
/

-- Backup:
-- expdp system/Giatuan27092005@localhost:1521/XEPDB1 schemas=QLYTE_06 directory=PH2_BACKUP_DIR dumpfile=qlyte06_backup.dmp logfile=qlyte06_backup.log

-- Backup thành công, D\oracle_backup:
-- qlyte06_backup.dmp
-- qlyte06_backup.log


-- =========================================================
-- PHẦN C - KIỂM TRA BACKUP LOG
-- Chay trong CMD/PowerShell
-- =========================================================

-- D:\oracle_backup\qlyte06_backup.log

-- =========================================================
-- PHẦN D - RESTORE SANG SCHEMA QLYTE_06_RESTORE
-- CHẠY BẰNG SYS AS SYSDBA:
-- =========================================================

-- CONNECT SYS/123@localhost:1521/XEPDB1 AS SYSDBA;
-- Xóa schema cũ nếu đã tồn tại
BEGIN
    EXECUTE IMMEDIATE 'DROP USER QLYTE_06_RESTORE CASCADE';
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- Tạo schema restore:
CREATE USER QLYTE_06_RESTORE IDENTIFIED BY 123;

GRANT CREATE SESSION TO QLYTE_06_RESTORE;
GRANT CREATE TABLE TO QLYTE_06_RESTORE;
GRANT CREATE VIEW TO QLYTE_06_RESTORE;
GRANT CREATE PROCEDURE TO QLYTE_06_RESTORE;
GRANT CREATE TRIGGER TO QLYTE_06_RESTORE;
GRANT CREATE SEQUENCE TO QLYTE_06_RESTORE;

ALTER USER QLYTE_06_RESTORE QUOTA UNLIMITED ON USERS;

-- Chạy trong CMD/PowerShell:
-- impdp system/Giatuan27092005@localhost:1521/XEPDB1 schemas=QLYTE_06 remap_schema=QLYTE_06:QLYTE_06_RESTORE directory=PH2_BACKUP_DIR dumpfile=qlyte06_backup.dmp logfile=qlyte06_restore_remap.log

-- =========================================================
-- PHẦN F - KIỂM TRA SAU KHI RESTORE
-- =========================================================

-- Restore sang schema QLYTE_06_RESTORE: chạy bằng QLYTE_06_RESTORE
-- CONNECT QLYTE_06_RESTORE/123@localhost:1521/XEPDB1;

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
-- PHẦN G - MÔ TẢ QUY TRÌNH SAU KHI XẢY RA SỰ CỐ
-- =========================================================

-- 1. Phát hiện sự cố thông qua DBA_AUDIT_TRAIL hoặc DBA_FGA_AUDIT_TRAIL.
-- 2. Xác định thời điểm và object bị tác động.
-- 3. Dùng bản backup gần nhất để restore
-- 4. Đối chiếu log audit/FGA để xác định thao tác cần kiểm tra lại.
-- 5. Kiểm tra số lượng dòng và dữ liệu quan trọng sau restore.

