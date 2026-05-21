-- =========================================================
-- PHÂN HỆ 2 - CREATE TABLES
-- Nhóm: 06
-- Schema: QLYTE_06
-- Chạy bằng User QLYTE_06
-- =========================================================


-- =========================================================
-- XÓA POLICY CŨ NẾU TỒN TẠI
-- =========================================================

BEGIN
    DBMS_RLS.DROP_POLICY('QLYTE_06', 'BENHNHAN', 'POL_BENHNHAN_VPD');
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY('QLYTE_06', 'HSBA', 'POL_HSBA_VPD');
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY('QLYTE_06', 'HSBA_DV', 'POL_HSBA_DV_VPD');
EXCEPTION WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY('QLYTE_06', 'DONTHUOC', 'POL_DONTHUOC_VPD');
EXCEPTION WHEN OTHERS THEN NULL;
END;
/
BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'BENHNHAN',
        policy_name   => 'POL_BENHNHAN_SELF'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'BENHNHAN',
        policy_name   => 'POL_BENHNHAN_BACSI'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'HSBA',
        policy_name   => 'POL_HSBA_BACSI'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'HSBA_DV',
        policy_name   => 'POL_HSBA_DV_KTV'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'HSBA_DV',
        policy_name   => 'POL_HSBA_DV_BACSI'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'QLYTE_06',
        object_name   => 'DONTHUOC',
        policy_name   => 'POL_DONTHUOC_BACSI'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

-- =========================================================
-- FUNCTION: LẤY ROLE USER HIỆN TẠI TRONG NHANVIEN
-- =========================================================
CREATE OR REPLACE FUNCTION FN_CURRENT_USER_ROLE
RETURN VARCHAR2
AS
    v_role NVARCHAR2(50);
BEGIN 
    SELECT VAITRO
    INTO v_role
    FROM QLYTE_06.NHANVIEN
    WHERE USERNAME = SYS_CONTEXT('USERNV', 'SESSION_USER');
    
    RETURN v_role;
EXCEPTION 
    WHEN NO_DATA_FOUND THEN
        RETURN NULL;
END;
/


-- =========================================================
-- FUNCTION VPD: BENHNHAN
--
-- Logic
-- QLYTE_06, SYS: thấy tất cả
-- ROLE_DIEUPHOIVIEN: thấy tất cả BENHNHAN
-- ROLE_BACSI: thấy bệnh nhân có HSBA do mình phụ trách
-- ROLE_BENHNHAN: chỉ thấy dòng của chính mình

CREATE OR REPLACE FUNCTION FN_VPD_BENHNHAN (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS 
    v_user NVARCHAR2(30);
    v_role NVARCHAR2(50);
BEGIN
    v_user := SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF v_user IN ('SYS', 'SYSTEM', 'QLYTE_06') THEN
        RETURN '1=1';
    END IF;
    
    BEGIN 
        SELECT VAITRO
        INTO v_role
        FROM QLYTE_06.NHANVIEN
        WHERE USERNAME = v_user;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            v_role := NULL;
    END;

    IF v_role = N'Điều phối viên' THEN
        RETURN '1=1';
    ELSIF v_role = N'Bác sĩ/Y sĩ' THEN
        RETURN 'MABN IN (
                    SELECT H.MABN
                    FROM QLYTE_06.HSBA H
                    JOIN QLYTE_06.NHANVIEN NV ON H.MABS = NV.MANV
                    WHERE NV.USERNAME = SYS_CONTEXT (''USERENV'', ''SESSION_USER'')
                    )';
    ELSE
        RETURN 'USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
        
    END IF;
END;
/   

-- =========================================================
-- FUNCTION VPD: HSBA
--
-- Logic:
-- QLYTE_06, SYS: thấy tất cả
-- ROLE_DIEUPHOIVIEN: thấy tất cả vì cần tạo/phân công HSBA
-- ROLE_BACSI: chỉ thấy HSBA mình phụ trách
-- ROLE_BENHNHAn:: chỉ thấy HSBA của chính mình
-- =========================================================

CREATE OR REPLACE FUNCTION FN_VPD_HSBA (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS 
    v_user NVARCHAR2(30);
    v_role NVARCHAR2(50);
BEGIN
    v_user := SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF v_user IN ('SYS', 'SYSTEM', 'QLYTE_06') THEN
        RETURN '1=1';
    END IF;
    
    BEGIN 
        SELECT VAITRO
        INTO v_role
        FROM QLYTE_06.NHANVIEN
        WHERE USERNAME = v_user;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            v_role := NULL;
    END;
    
    IF v_role = N'Diều phối viên' THEN
        RETURN '1=1';
    ELSIF v_role = N'Bác sĩ/Y sĩ' THEN
        RETURN 'MABS = (
                    SELECT MANV
                    FROM QLYTE_06.NHANVIEN 
                    WHERE USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
    ELSE
        RETURN 'MABN = (
                    SELECT MABN
                    FROM QLYTE_06.BENHNHAN
                    WHERE USERNAME = SYS_CONTETX(''USERENV'', ''SESSION_USER'')
                    )';
    END IF;
END;
/


-- =========================================================
-- FUNCTION VPD: HSBA_DV
--
-- Logic:
-- QLYTE_06, SYS: thấy tất cả
-- ROLE_DIEUPHOIVIEN: thấy tất cả đề điều phối KTV
-- ROLE_BACSI: thấy dịch HSBA thuộc mình phụ trách
-- ROLE_KYTHUATVIEN: chỉ thấy dịch vụ mình được phân công
-- =========================================================

CREATE OR REPLACE FUNCTION FN_VPD_HSBA_DV (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS
    v_user VARCHAR2(30);
    v_role NVARCHAR2(50);
BEGIN
    v_user := SYS_CONTEXT('USERENV', 'SESSION_USER');

    IF v_user IN ('SYS', 'SYSTEM', 'QLYTE_06') THEN
        RETURN '1=1';
    END IF;
    
    BEGIN 
        SELECT VAITRO
        INTO v_role
        FROM QLYTE_06.NHANVIEN
        WHERE USERNAME = v_user;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            v_role := NULL;
    END;
    
    IF v_role = N'Điều phối viên' THEN
        RETURN '1=1';
    ELSIF v_role = N'Bác sĩ/Y sĩ' THEN
        RETURN 'MAHSBA IN (
                        SELECT H.MAHSBA
                        FROM QLYTE_06.HSBA H
                        JOIN QLYTE_05.NHANVIEN NV ON H.MABS = NV.MANV
                        WHERE NV.USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
    ELSIF v_role = N'Kỹ thuật viên' THEN
        RETURN 'MAKT = (
                    SELECT MANV
                    FROM QLYTE_06.NHANVIEN
                    WHERE USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                )';
    ELSE 
        RETURN '1=0';
    END IF;
END;
/

-- =========================================================
-- FUNCTION VPD: DONTHUOC
--
-- Logic:
-- QLYTE_06, SYS: thấy tất cả
-- ROLE_BACSI: chỉ thao tác trên đơn thuốc của HSBA mình phụ trách
-- ROLE_BENHNHAN: có thể xem đơn thuốc của mình nếu sau này cấp SELECT

CREATE OR REPLACE FUNCTION FN_VPD_DONTHUOC (
    schema_name VARCHAR2,
    object_name VARCHAR2
)
RETURN VARCHAR2
AS
    v_user VARCHAR2(30);
    v_role NVARCHAR2(50);
BEGIN
    v_user := SYS_CONTEXT('USERENV', 'SESSION_USER');
    
    IF v_user IN ('SYS', 'SYSTEM', 'QLYTE_06') THEN
        RETURN '1=1';
    END IF;
    
    BEGIN 
        SELECT VAITRO
        INTO v_role
        FROM QLYTE_06.NHANVIEN
        WHERE USERNAME = v_user;
    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            v_role := NULL;
    END;
    
    IF v_role = N'Bác sĩ/Y sĩ' THEN 
        RETURN 'MAHSBA IN (
                        SELECT H.MAHSBA
                        FROM QLYTE_06.HSBA H
                        JOIN QLYTE_06.NHANVIEN NV ON H.MABS = NV.MANV
                        WHERE NV.USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
    ELSE
        RETURN 'MAHSBA IN (
                        SELECT H.MAHSBA
                        FROM QLYTE_06.HSBA H 
                        JOIN QLYTE_06.BENHNHAN BN ON H.MABN = BN.MABN
                        WHERE BN.USERNAME = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')
                    )';
    END IF;
END;
/

-- =========================================================
-- ADD POLICIES
-- =========================================================

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'BENHNHAN',
        policy_name     => 'POL_BENHNHAN_VPD',
        function_schema => 'QLYTE_06',
        policy_function => 'FN_VPD_BENHNHAN',
        statement_types => 'SELECT, UPDATE, DELETE',
        update_check    => TRUE
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA',
        policy_name     => 'POL_HSBA_VPD',
        function_schema => 'QLYTE_06',
        policy_function => 'FN_VPD_HSBA',
        statement_types => 'SELECT, UPDATE, DELETE',
        update_check    => TRUE
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'HSBA_DV',
        policy_name     => 'POL_HSBA_DV_VPD',
        function_schema => 'QLYTE_06',
        policy_function => 'FN_VPD_HSBA_DV',
        statement_types => 'SELECT, UPDATE, DELETE',
        update_check    => TRUE
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'QLYTE_06',
        object_name     => 'DONTHUOC',
        policy_name     => 'POL_DONTHUOC_VPD',
        function_schema => 'QLYTE_06',
        policy_function => 'FN_VPD_DONTHUOC',
        statement_types => 'SELECT, UPDATE, DELETE',
        update_check    => TRUE
    );
END;
/

-- =========================================================
-- KIỂM TRA CÁC POLICY ĐÃ GẮN
-- =========================================================

SELECT OBJECT_NAME,
       POLICY_NAME,
       FUNCTION,
       SEL,
       INS,
       UPD,
       DEL,
       ENABLE
FROM USER_POLICIES
WHERE OBJECT_NAME IN ('BENHNHAN', 'HSBA', 'HSBA_DV', 'DONTHUOC')
ORDER BY OBJECT_NAME, POLICY_NAME;


SELECT MABN, TENBN, USERNAME
FROM BENHNHAN;


SELECT 'NHANVIEN' AS TABLE_NAME, COUNT(*) AS SO_DONG FROM NHANVIEN
UNION ALL
SELECT 'BENHNHAN', COUNT(*) FROM BENHNHAN
UNION ALL
SELECT 'HSBA', COUNT(*) FROM HSBA
UNION ALL
SELECT 'HSBA_DV', COUNT(*) FROM HSBA_DV
UNION ALL
SELECT 'DONTHUOC', COUNT(*) FROM DONTHUOC
UNION ALL
SELECT 'THONGBAO', COUNT(*) FROM THONGBAO;