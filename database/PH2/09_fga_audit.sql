-- =========================================================
-- PHÂN HỆ 2 - FGA AUDIT
-- Nhóm: 06
-- Schema: QLYTE_06
-- =========================================================


-- =========================================================
-- PHẦN A - CẤP QUYỀN DBMS_FGA
-- Chạy bằng SYS AS SYSDBA
-- =========================================================

GRANT EXECUTE ON SYS.DBMS_FGA TO QLYTE_06;


-- =========================================================
-- PHẦN B - TẠO FGA POLICIES
-- Chạy bằng QLYTE_06
-- =========================================================

-- =========================================================
-- B1. XÓA FGA POLICY CŨ NẾU TỒN TẠI
-- =========================================================

BEGIN 
    DBMS_FGA.DROP_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'DONTHUOC',
        policy_name     => 'FGA_DONTHUOC_UPDATE'
    );
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -28102 THEN 
            NULL;
        END IF;
END;
/


BEGIN 
    DBMS_FGA.DROP_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA',
        policy_name     => 'FGA_HSBA_UPDATE'
    );
EXCEPTION 
    WHEN OTHERS THEN
        IF SQLCODE != 28102 THEN
            NULL;
        END IF;
END;
/

BEGIN 
    DBMS_FGA.DROP_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA_DV',
        policy_name     => 'FGA_HSBA_DV_UPDATE'
    );
EXCEPTION 
    WHEN OTHERS THEN
        IF SQLCODE != 28102 THEN
            NULL;
        END IF;
END;
/
     
-- =========================================================
-- B2. FGA POLICY CHO DONTHUOC
-- Ghi log khi có UPDATE trên các cột: NGAYDT, TENTHUOC, LIEUDUNG
-- =========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'DONTHUOC',
        policy_name     => 'FGA_DONTHUOC_UPDATE',
        audit_condition => NULL,
        audit_column    => 'NGAYDT,TENTHUOC,LIEUDUNG',
        statement_types => 'UPDATE',
        audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );
END;
/

-- =========================================================
-- B3. FGA POLICY CHO HSBA
-- Ghi log khi có bác sĩ cập nhật: CHANDOAN, DIEUTRI, KETLUAN
-- =========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA',
        policy_name     => 'FGA_HSBA_UPDATE',
        audit_condition => NULL,
        audit_column    => 'CHANDOAN,DIEUTRI,KETLUAN',
        statement_types => 'UPDATE',
        audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );
END;
/

-- =========================================================
-- B4. FGA POLICY CHO HSBA_DV
-- Ghi log khi Kỹ thuật viên cập nhật KETQUA
-- =========================================================

BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA_DV',
        policy_name     => 'FGA_HSBA_DV_UPDATE',
        audit_condition => NULL,
        audit_column    => 'KETQUA',
        statement_types => 'UPDATE',
        audit_trail     => DBMS_FGA.DB + DBMS_FGA.EXTENDED
    );
END;
/
-- =========================================================
-- B4. XEM LOG FGA SAU KHI TEST 
-- Chạy bằng SYS
-- =========================================================
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

