-- =========================================================
-- PHÂN HỆ 2 - OLS
-- Nhóm: 06
-- Schema: QLYTE_06
-- =========================================================


-- =========================================================
-- 1. KIỂM TRA AUDIT TRAIL
-- =========================================================

SHOW PARAMETER audit_trail;


-- =========================================================
-- 2. XÓA AUDIT CŨ NẾU CẦN
-- =========================================================

NOAUDIT SELECT ON QLYTE_06.BENHNHAN;
NOAUDIT UPDATE ON QLYTE_06.BENHNHAN;
NOAUDIT SELECT ON QLYTE_06.HSBA;
NOAUDIT UPDATE ON QLYTE_06.HSBA;
NOAUDIT SELECT ON QLYTE_06.HSBA_DV;
NOAUDIT UPDATE ON QLYTE_06.HSBA_DV;
NOAUDIT SELECT ON QLYTE_06.DONTHUOC;
NOAUDIT UPDATE ON QLYTE_06.DONTHUOC;
NOAUDIT SELECT ON QLYTE_06.THONGBAO;


-- =========================================================
-- 3. STANDARD AUDIT - 5 NGỮ CẢNH ĐỀ XUẤT
-- =========================================================

-- Ngữ cảnh 1:
-- Audit truy vấn thông tin bận nhân 
AUDIT SELECT ON QLYTE_06.BENHNHAN BY ACCESS;

-- Ngữ cảnh 2: Audit cập nhật thông tin bận nhân
AUDIT UPDATE ON QLYTE_06.BENHNHAN BY ACCESS;

-- Ngữ cảnh 3: Audit truy vấn hồ sơ bệnh ân
AUDIT SELECT ON QLYTE_06.HSBA BY ACCESS;

-- Ngữ cảnh 4: Audit cập nhật hồ sơ bệnh án
AUDIT UPDATE ON QLYTE_06.HSBA BY ACCESS;

-- Ngữ cảnh 5: Audit truy vấn và cập nhật dịch vụ kỹ thuật 
AUDIT SELECT, UPDATE ON QLYTE_06.HSBA_DV BY ACCESS;

-- Bonus: Audit truy vấn đơn thuốc
AUDIT SELECT, UPDATE ON QLYTE_06.DONTHUOC BY ACCESS;


-- =========================================================
-- 4. KIỂM TRA CÁC AUDIT OPTION ĐÃ BẬT
-- =========================================================

SELECT OWNER,
       OBJECT_NAME,
       OBJECT_TYPE,
       ALT,
       AUD,
       COM,
       DEL,
       GRA,
       IND,
       INS,
       LOC,
       REN,
       SEL,
       UPD
FROM DBA_OBJ_AUDIT_OPTS
WHERE OWNER = 'QLYTE_06'
ORDER BY OBJECT_NAME;


SELECT USERNAME,
       OWNER,
       OBJ_NAME,
       ACTION_NAME,
       TIMESTAMP,
       SQL_TEXT
FROM DBA_AUDIT_TRAIL
WHERE OWNER = 'QLYTE_06'
  AND OBJ_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC', 'THONGBAO')
ORDER BY TIMESTAMP DESC;