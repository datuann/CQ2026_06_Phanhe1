-- =========================================================
-- PHÂN HỆ 2 - CREATE TABLES
-- Nhóm: 06
-- Schema: QLYTE_06
-- Chạy bằng User QLYTE_06
-- =========================================================

CONNECT QLYTE_06/123@localhost:1521/XEPDB1;

-- =========================================================
-- DROP TABLES neu da ton tai
-- =========================================================

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE DONTHUOC CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE;
        END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE HSBA_DV CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE HSBA CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE BENHNHAN CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE NHANVIEN CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE; END IF;
END;
/

BEGIN
    EXECUTE IMMEDIATE 'DROP TABLE THONGBAO CASCADE CONSTRAINTS';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -942 THEN RAISE; END IF;
END;
/

-- =========================================================
-- TABLE: BENHNHAN
-- =========================================================

CREATE TABLE BENHNHAN (
    MABN    VARCHAR2(20),
    TENBN   NVARCHAR2(100) NOT NULL,
    PHAI    NVARCHAR2(10),
    NGAYSINH    DATE,
    CCCD    VARCHAR2(20),
    SONHA   NVARCHAR2(50),
    TENDUONG    NVARCHAR2(100),
    QUANHUYEN   NVARCHAR2(100),
    TINHTP  NVARCHAR2(100),
    TIENSUBENH  NVARCHAR2(1000),
    TIENSUBENHGD    NVARCHAR2(1000),
    DIUNGTHUOC  NVARCHAR2(1000),
    USERNAME    VARCHAR2(30),
    
    CONSTRAINT PK_BENHNHAN PRIMARY KEY (MABN),
    CONSTRAINT UQ_BENHNHANH_CCCD UNIQUE (CCCD),
    CONSTRAINT UQ_BENHNHAN_USERNAME UNIQUE (USERNAME)
    
);

-- =========================================================
-- TABLE: NHANVIEN
-- =========================================================

CREATE TABLE NHANVIEN (
    MANV    VARCHAR2(20),
    HOTEN   NVARCHAR2(100) NOT NULL,
    PHAI    NVARCHAR2(10),
    NGAYSINH    DATE,
    CMND    VARCHAR2(20),
    QUEQUAN NVARCHAR2(100),
    SODT    VARCHAR2(20),
    VAITRO  NVARCHAR2(50),
    CHUYENKHOA  NVARCHAR2(100),
    USERNAME    VARCHAR2(30),
    
    CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV),
    CONSTRAINT UQ_NHANVIEN_CMND UNIQUE (CMND),
    CONSTRAINT UQ_NHANVIEN_USERNAME UNIQUE (USERNAME),
    CONSTRAINT CK_NHANVIEN_VAITRO CHECK (
        VAITRO IN (
            N'Điều phối viên',
            N'Bác sĩ/Y sĩ',
            N'Kỹ thuật viên'
        )
    )
);


-- =========================================================
-- TABLE: HSBA
-- =========================================================

CREATE TABLE HSBA (
    MAHSBA  VARCHAR2(20),
    MABN    VARCHAR2(20) NOT NULL,
    NGAY    DATE,
    CHANDOAN    NVARCHAR2(1000),
    DIEUTRI     NVARCHAR2(1000),
    MABS    VARCHAR2(20),
    MAKHOA  VARCHAR2(20),
    KETLUAN NVARCHAR2(1000),
    
    CONSTRAINT PK_HSBA PRIMARY KEY (MAHSBA),
    CONSTRAINT FK_HSBA_BENHNHAN FOREIGN KEY (MABN) REFERENCES BENHNHAN(MABN),
    CONSTRAINT FK_HSBA_BACSI FOREIGN KEY (MABS) REFERENCES NHANVIEN(MANV)
);

-- =========================================================
-- TABLE: HSBA_DV
-- =========================================================

CREATE TABLE HSBA_DV (
    MAHSBA  VARCHAR2(20),
    LOAIDV  NVARCHAR2(100),
    NGAYDV  DATE,
    MAKT    VARCHAR2(20),
    KETQUA  NVARCHAR2(1000),
    
    CONSTRAINT PK_HSBA_DC PRIMARY KEY (MAHSBA, LOAIDV, NGAYDV),
    CONSTRAINT FK_HSBA_DV_HSBA FOREIGN KEY (MAHSBA) REFERENCES HSBA(MAHSBA),
    CONSTRAINT FK_HSBS_DV_KTV FOREIGN KEY (MAKT) REFERENCES NHANVIEN (MANV)
);

-- =========================================================
-- TABLE: DONTHUOC
-- =========================================================

CREATE TABLE DONTHUOC (
    MAHSBA  VARCHAR2(20),
    NGAYDT  DATE,
    TENTHUOC    NVARCHAR2(100),
    LIEUDUNG    NVARCHAR2(200),
    
    CONSTRAINT PK_DONTHUOC PRIMARY KEY (MAHSBA, NGAYDT, TENTHUOC),
    CONSTRAINT FK_DONTHUOC_HSBA FOREIGN KEY (MAHSBA) REFERENCES HSBA(MAHSBA)
);


-- =========================================================
-- TABLE: THONGBAO
-- Dùng cho OLS ở Yêu cầu 2
-- Cột OLS label sẽ được thêm sau bảng SA_POLICY_ADMIN/APPLY_TABLE_POLICY
-- =========================================================

CREATE TABLE THONGBAO (
    MATB    VARCHAR2(20),
    NOIDUNG NVARCHAR2(1000),
    NGAYGIO TIMESTAMP,
    DIADIEM NVARCHAR2(200),
    
    CONSTRAINT PK_THONGBAO PRIMARY KEY (MATB)
);

-- =========================================================
-- INDEX phu tro
-- =========================================================

CREATE INDEX IDX_HSBA_MABN ON HSBA(MABN);
CREATE INDEX IDX_HSBA_MABS ON HSBA(MABS);
CREATE INDEX IDX_HSBA_DV_MAKT ON HSBA_DV(MAKT);


-- =========================================================
-- KIEM TRA
-- =========================================================

SELECT TABLE_NAME
FROM USER_TABLES
WHERE TABLE_NAME IN (
    'BENHNHAN', 
    'NHANVIEN',
    'HSBA',
    'HSBA_DV',
    'DONTHUOC',
    'THONGBAO'
)
ORDER BY TABLE_NAME;