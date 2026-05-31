-- =========================================================
-- PHÂN HỆ 2 - STANDARD AUDIT
-- Nhóm: 06
-- Schema: QLYTE_06
-- =========================================================


-- =========================================================
-- 1. KIỂM TRA AUDIT TRAIL
-- Chạy bằng SYS
-- =========================================================

SHOW PARAMETER audit_trail;

-- =========================================================
-- 3. TẠO VIEW / PROCEDURE / FUNCTION PHỤC VỤ STANDARD AUDIT
-- Chạy bằng QLYTE_06
-- =========================================================

CREATE OR REPLACE VIEW VW_AUDIT_HSBA_BACSI AS
SELECT MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
FROM HSBA;
/

CREATE OR REPLACE PROCEDURE PROC_AUDIT_TEST
AS
BEGIN
    NULL;
END;
/

CREATE OR REPLACE FUNCTION FN_AUDIT_TEST
RETURN VARCHAR2
AS
BEGIN
    RETURN SYS_CONTEXT('USERENV', 'SESSION_USER');
END;
/

-- Cấp quyền để user nghiệp vụ có thể tạo Log audit 
GRANT SELECT ON VW_AUDIT_HSBA_BACSI TO ROLE_BACSI;
GRANT EXECUTE ON PROC_AUDIT_TEST TO ROLE_BACSI;
GRANT EXECUTE ON FN_AUDIT_TEST TO ROLE_BACSI;

-- =========================================================
-- 3. XÓA AUDIT CŨ NẾU CẦN
-- Chạy bằng SYS
-- =========================================================

NOAUDIT SELECT ON QLYTE_06.BENHNHAN;
NOAUDIT UPDATE ON QLYTE_06.BENHNHAN;

NOAUDIT SELECT ON QLYTE_06.HSBA;
NOAUDIT UPDATE ON QLYTE_06.HSBA;

NOAUDIT SELECT ON QLYTE_06.HSBA_DV;
NOAUDIT UPDATE ON QLYTE_06.HSBA_DV;
NOAUDIT INSERT ON QLYTE_06.HSBA_DV;
NOAUDIT DELETE ON QLYTE_06.HSBA_DV;

NOAUDIT SELECT ON QLYTE_06.DONTHUOC;
NOAUDIT UPDATE ON QLYTE_06.DONTHUOC;

NOAUDIT SELECT ON QLYTE_06.THONGBAO;

NOAUDIT SELECT ON QLYTE_06.VW_AUDIT_HSBA_BACSI;
NOAUDIT EXECUTE ON QLYTE_06.PROC_AUDIT_TEST;
NOAUDIT EXECUTE ON QLYTE_06.FN_AUDIT_TEST;


-- =========================================================
-- 4. STANDARD AUDIT - 5 NGỮ CẢNH ĐỀ XUẤT
-- =========================================================

-- Ngữ cảnh 1: TABLE
-- Audit thành công khi user truy vấn thông tin bệnh nhân
AUDIT SELECT ON QLYTE_06.BENHNHAN BY ACCESS WHENEVER SUCCESSFUL;

-- Ngữ cảnh 2 - TABLE:
-- Audit thành công khi user cập nhật thông tin bệnh nhân
AUDIT UPDATE ON QLYTE_06.BENHNHAN BY ACCESS WHENEVER SUCCESSFUL;

-- Ngữ cảnh 3 - VIEW
-- Audit thành công khi bác sĩ truy vấn view hồ sơ bệnh án
AUDIT SELECT ON QLYTE_06.VW_AUDIT_HSBA_BACSI BY ACCESS WHENEVER SUCCESSFUL;

-- Ngữ cảnh 4 - STORED PROCEDURE
-- Audit thành công khi user execute procedure
AUDIT EXECUTE ON QLYTE_06.PROC_AUDIT_TEST BY ACCESS WHENEVER SUCCESSFUL;

-- Ngữ cảnh 5 - FUNCTION
-- Audit thành công khi user execute function
AUDIT EXECUTE ON QLYTE_06.FN_AUDIT_TEST BY ACCESS WHENEVER SUCCESSFUL;

-- Bonus: Audit truy vấn đơn thuốc
AUDIT SELECT, UPDATE ON QLYTE_06.DONTHUOC BY ACCESS;

-- =========================================================
-- 5. STANDARD AUDIT - HÀNH VI KHÔNG THÀNH CÔNG
-- =========================================================

-- Cập nhật bất hợp pháp HSBA
AUDIT UPDATE ON QLYTE_06.HSBA BY ACCESS WHENEVER NOT SUCCESSFUL;

-- Thêm/Xóa/Sửa bất hợp pháp HSBA_DV
AUDIT INSERT, UPDATE, DELETE ON QLYTE_06.HSBA_DV BY ACCESS WHENEVER NOT SUCCESSFUL;

-- Cập nhật bất hợp pháp DONTHUOC
AUDIT UPDATE ON QLYTE_06.DONTHUOC BY ACCESS WHENEVER NOT SUCCESSFUL;


-- =========================================================
-- 6. KIỂM TRA CÁC AUDIT OPTION ĐÃ BẬT
-- =========================================================

COLUMN USERNAME FORMAT A15
COLUMN OWNER FORMAT A12
COLUMN OBJ_NAME FORMAT A25
COLUMN ACTION_NAME FORMAT A15
COLUMN RETURNCODE FORMAT 999999
COLUMN TIMESTAMP FORMAT A20

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
        'HSBA',
        'HSBA_DV',
        'DONTHUOC',
        'THONGBAO',
        'VW_AUDIT_HSBA_BACSI',
        'PROC_AUDIT_TEST',
        'FN_AUDIT_TEST'
  )
ORDER BY TIMESTAMP DESC;


SELECT USERNAME, OWNER, OBJ_NAME, ACTION_NAME, RETURNCODE, TIMESTAMP
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'QLYTE_06'
  AND OBJ_NAME = 'HSBA_DV'
ORDER BY TIMESTAMP DESC;

