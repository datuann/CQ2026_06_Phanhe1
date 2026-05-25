-- =========================================================
-- PHÂN HỆ 2 - CREATE ORACLE USERS
-- Nhóm: 06
-- Schema: QLYTE_06
-- Chạy bằng User QLYTE_06
-- =========================================================

ALTER SESSION SET "_ORACKE_SCRIPT" = TRUE;

-- =========================================================
-- PROCEDURE HỖ TRỢ DROP USER NẾU ĐÃ TỒN TẠI
-- =========================================================

CREATE OR REPLACE PROCEDURE SYS.DROP_USER_IF_EXISTS_PH2(p_username IN VARCHAR2)
AS
BEGIN
    EXECUTE IMMEDIATE 'DROP USER' || p_username || 'CASCADE';
EXCEPTION
    WHEN OTHERS THEN
        IF SQLCODE != -1918 THEN RAISE;
        END IF;
END;
/

-- =========================================================
-- XÓA USERS CŨ
-- =========================================================

BEGIN
    DROP_USER_IF_EXISTS_PH2('DP001');
    DROP_USER_IF_EXISTS_PH2('DP002');

    DROP_USER_IF_EXISTS_PH2('BS001');
    DROP_USER_IF_EXISTS_PH2('BS002');
    DROP_USER_IF_EXISTS_PH2('BS003');

    DROP_USER_IF_EXISTS_PH2('KT001');
    DROP_USER_IF_EXISTS_PH2('KT002');

    DROP_USER_IF_EXISTS_PH2('BN001');
    DROP_USER_IF_EXISTS_PH2('BN002');
    DROP_USER_IF_EXISTS_PH2('BN003');
    DROP_USER_IF_EXISTS_PH2('BN004');

    DROP_USER_IF_EXISTS_PH2('U1');
    DROP_USER_IF_EXISTS_PH2('U2');
    DROP_USER_IF_EXISTS_PH2('U3');
    DROP_USER_IF_EXISTS_PH2('U4');
    DROP_USER_IF_EXISTS_PH2('U5');
    DROP_USER_IF_EXISTS_PH2('U6');
    DROP_USER_IF_EXISTS_PH2('U7');
    DROP_USER_IF_EXISTS_PH2('U8');
END;
/

-- =========================================================
-- TẠO USER NHÂN VIÊN
-- Password demo: 123
-- =========================================================


CREATE USER DP001 IDENTIFIED BY 123;
CREATE USER DP002 IDENTIFIED BY 123;

CREATE USER BS001 IDENTIFIED BY 123;
CREATE USER BS002 IDENTIFIED BY 123;
CREATE USER BS003 IDENTIFIED BY 123;

CREATE USER KT001 IDENTIFIED BY 123;
CREATE USER KT002 IDENTIFIED BY 123;

-- =========================================================
-- TẠO USER BỆNH NHÂN
-- =========================================================

CREATE USER BN001 IDENTIFIED BY 123;
CREATE USER BN002 IDENTIFIED BY 123;
CREATE USER BN003 IDENTIFIED BY 123;
CREATE USER BN004 IDENTIFIED BY 123;

-- =========================================================
-- TẠO OUSERS OLS
-- =========================================================

CREATE USER U1 IDENTIFIED BY 123;
CREATE USER U2 IDENTIFIED BY 123;
CREATE USER U3 IDENTIFIED BY 123;
CREATE USER U4 IDENTIFIED BY 123;
CREATE USER U5 IDENTIFIED BY 123;
CREATE USER U6 IDENTIFIED BY 123;
CREATE USER U7 IDENTIFIED BY 123;
CREATE USER U8 IDENTIFIED BY 123;

-- =========================================================
-- CẤP QUYỀN ĐĂNG NHẬP
-- =========================================================

GRANT CREATE SESSION TO
    DP001, DP002,
    BS001, BS002, BS003,
    KT001, KT002,
    BN001, BN002, BN003, BN004,
    U1, U2, U3, U4, U5, U6, U7, U8;

-- =========================================================
-- KIỂM TRA USER ĐÃ TẠO
-- =========================================================

SELECT USERNAME, ACCOUNT_STATUS, CREATED
FROM DBA_USERS
WHERE USERNAME IN (
    'DP001', 'DP002',
    'BS001', 'BS002', 'BS003',
    'KT001', 'KT002',
    'BN001', 'BN002', 'BN003', 'BN004',
    'U1', 'U2', 'U3', 'U4', 'U5', 'U6', 'U7', 'U8'
)
ORDER BY USERNAME;
