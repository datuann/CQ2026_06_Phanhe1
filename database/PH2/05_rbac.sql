-- =========================================================
-- PHÂN HỆ 2 - CREATE TABLES
-- Nhóm: 06
-- Schema: QLYTE_06
-- Chạy bằng User QLYTE_06
-- =========================================================


ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

-- =========================================================
-- DROP ROLES NEU DA TON TAI
-- =========================================================

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_DIEUPHOIVIEN';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -1919 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_BACSI';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -1919 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_KYTHUATVIEN';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -1919 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP ROLE ROLE_BENHNHAN';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -1919 THEN RAISE; END IF;
END;
/

-- =========================================================
-- CREATE ROLES
-- =========================================================

CREATE ROLE ROLE_DIEUPHOIVIEN;
CREATE ROLE ROLE_BACSI;
CREATE ROLE ROLE_KYTHUATVIEN;
CREATE ROLE ROLE_BENHNHAN;

-- =========================================================
-- GRANT QUYỀN CHO ROLE_DIEUPHOIVIEN
--
-- TC#2
-- Điều phối viên có thể:
-- Xem, thêm, sửa BENHNHAN
-- Tạo mới HSBA
-- Cập nhật MAKHOA, MABS trong HSBA
-- Điều phối KTV: cập nhật MAKT trong HSBA_DV
-- =========================================================

GRANT SELECT, INSERT ON QLYTE_06.BENHNHAN TO ROLE_DIEUPHOIVIEN;
GRANT UPDATE (SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH,TIENSUBENHGD, DIUNGTHUOC) 
ON QLYTE_06.BENHNHAN TO ROLE_DIEUPHOIVIEN;

GRANT SELECT, INSERT ON QLYTE_06.HSBA TO ROLE_DIEUPHOIVIEN;
GRANT UPDATE (MAKHOA, MABS) ON QLYTE_06.HSBA TO ROLE_DIEUPHOIVIEN;

GRANT SELECT ON QLYTE_06.HSBA_DV TO ROLE_DIEUPHOIVIEN;
GRANT UPDATE (MAKT) ON QLYTE_06.HSBA_DV TO ROLE_DIEUPHOIVIEN;


-- =========================================================
-- GRANT QUYEN CHO ROLE_BACSI
--
-- TC#3:
-- Bác sĩ/Y sĩ:
-- Xem HSBA mình điều trị: sẽ giới hạn bằng VPD
-- Thêm, xóa HSBA_DV liên quan đến HSBA mình phụ trách
-- Cập nhật CHANDOAN, DIEUTRI, KETLUAN
-- Xem bệnh nhân liên quan đến HSBA mình điều trị: sẽ giới hạn bằng VPD/view
-- Cập nhật TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
-- Thêm, xóa, cập nhật DONTHUOC liên quan đến HSBA mình điều trị: TENTHUOC, LIEUDUNG
-- =========================================================

GRANT SELECT ON QLYTE_06.HSBA TO ROLE_BACSI;
GRANT UPDATE (CHANDOAN, DIEUTRI, KETLUAN) ON QLYTE_06.HSBA TO ROLE_BACSI;

GRANT SELECT ON QLYTE_06.BENHNHAN TO ROLE_BACSI;
GRANT UPDATE (TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC) ON QLYTE_06.BENHNHAN TO ROLE_BACSI;

GRANT SELECT, INSERT, DELETE ON QLYTE_06.HSBA_DV TO ROLE_BACSI;

GRANT SELECT, INSERT, DELETE ON QLYTE_06.DONTHUOC TO ROLE_BACSI;
GRANT UPDATE (NGAYDT, TENTHUOC, LIEUDUNG) ON QLYTE_06.DONTHUOC TO ROLE_BACSI;

-- =========================================================
-- GRANT QUYỀN CHO ROLE_KYTHUATVIEN
--
-- TC#4:
-- Kỹ thuật viên:
-- Chỉ xem dòng HSBA_DV được điều phối: VPD
-- Cập nhật KETQUA
-- =========================================================

GRANT SELECT ON QLYTE_06.HSBA_DV TO ROLE_KYTHUATVIEN;
GRANT UPDATE (KETQUA) ON QLYTE_06.HSBA_DV TO ROLE_KYTHUATVIEN;


-- =========================================================
-- GRANT QUYỀN CHO ROLE_BENHNHAN
--
-- TC#5:
-- Bệnh nhân:
-- Chỉ sửa thông tin của mình: VPD
-- Sửa trừ các trường MA, HOTEN, PHAI, NGAYSINH, CCCD
-- =========================================================

GRANT SELECT ON QLYTE_06.BENHNHAN TO ROLE_BENHNHAN;
GRANT UPDATE (SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC) ON QLYTE_06.BENHNHAN TO ROLE_BENHNHAN;


-- =========================================================
-- GRANT ROLE CHO USERS
-- =========================================================

GRANT ROLE_DIEUPHOIVIEN TO DP001,DP002;
GRANT ROLE_BACSI TO BS001, BS002, BS003;
GRANT ROLE_KYTHUATVIEN TO KT001, KT002;
GRANT ROLE_BENHNHAN TO BN001, BN002, BN003, BN004

-- =========================================================
-- SET DEFAULT ROLE
-- =========================================================

ALTER USER DP001 DEFAULT ROLE ROLE_DIEUPHOIVIEN;
ALTER USER DP002 DEFAULT ROLE ROLE_DIEUPHOIVIEN;

ALTER USER BS001 DEFAULT ROLE ROLE_BACSI;
ALTER USER BS002 DEFAULT ROLE ROLE_BACSI;
ALTER USER BS003 DEFAULT ROLE ROLE_BACSI;

ALTER USER KT001 DEFAULT ROLE ROLE_KYTHUATVIEN;
ALTER USER KT002 DEFAULT ROLE ROLE_KYTHUATVIEN;

ALTER USER BN001 DEFAULT ROLE ROLE_BENHNHAN;
ALTER USER BN002 DEFAULT ROLE ROLE_BENHNHAN;
ALTER USER BN003 DEFAULT ROLE ROLE_BENHNHAN;
ALTER USER BN004 DEFAULT ROLE ROLE_BENHNHAN;

-- =========================================================
-- KIEM TRA ROLE DA CAP
-- =========================================================

SELECT GRANTEE, GRANTED_ROLE, DEFAULT_ROLE
FROM DBA_ROLE_PRIVS
WHERE GRANTEE IN (
    'DP001', 'DP002',
    'BS001', 'BS002', 'BS003',
    'KT001', 'KT002',
    'BN001', 'BN002', 'BN003', 'BN004'
)
ORDER BY GRANTEE, GRANTED_ROLE;

-- =========================================================
-- KIEM TRA QUYEN OBJECT CUA ROLE
-- =========================================================

SELECT GRANTEE, OWNER, TABLE_NAME, PRIVILEGE, GRANTABLE
FROM DBA_TAB_PRIVS
WHERE GRANTEE IN (
    'ROLE_DIEUPHOIVIEN',
    'ROLE_BACSI',
    'ROLE_KYTHUATVIEN',
    'ROLE_BENHNHAN'
)
ORDER BY GRANTEE, OWNER, TABLE_NAME, PRIVILEGE;

-- =========================================================
-- KIEM TRA QUYEN THEO COT
-- =========================================================

SELECT GRANTEE, OWNER, TABLE_NAME, COLUMN_NAME, PRIVILEGE
FROM DBA_COL_PRIVS
WHERE GRANTEE IN (
    'ROLE_DIEUPHOIVIEN',
    'ROLE_BACSI',
    'ROLE_KYTHUATVIEN',
    'ROLE_BENHNHAN'
)
ORDER BY GRANTEE, TABLE_NAME, COLUMN_NAME;