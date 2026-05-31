-- =========================================================
-- PHÂN HỆ 2 - OLS
-- Nhóm: 06
-- Schema: QLYTE_06
-- =========================================================


-- =========================================================
-- B1. XÓA POLICY CŨ NẾU TỒN TẠI
-- =========================================================

BEGIN
    LBACSYS.SA_SYSDBA.DROP_POLICY(
        policy_name => 'THONGBAO_OLS',
        drop_column => TRUE
    );
EXCEPTION
    WHEN OTHERS THEN
        NULL;
END;
/

-- =========================================================
-- B2. TẠO POLICY
-- Cột THONGBAO_LABEL sẽ được thêm vào bảng THONGBAO khi apply policy
-- =========================================================

BEGIN
    LBACSYS.SA_SYSDBA.CREATE_POLICY(
        policy_name     => 'THONGBAO_OLS',
        column_name     => 'THONGBAO_LABEL',
        default_options => 'READ_CONTROL,WRITE_CONTROL'
    );
END;
/

-- =========================================================
-- B3. TẠO LEVEL
-- Cấp bậc
-- BGD: Ban giám đốc
-- LDK: Lãnh đạo khoa
-- NV: Nhân viên
-- Level cao hơn đọc được level thấp hơn nếu compartment/group phù hợp
-- =========================================================

BEGIN 
    LBACSYS.SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num  => 1000,
        short_name => 'NV',
        long_name  => 'Nhân viên'
    );
    
    LBACSYS.SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num => 2000, 
        short_name => 'LDK',
        long_name => 'Lãnh đạo khoa'
    );
    
    LBACSYS.SA_COMPONENTS.CREATE_LEVEL(
        policy_name => 'THONGBAO_OLS',
        level_num => 3000,
        short_name => 'BGD',
        long_name => 'Ban giám đốc'
    );
END;
/

-- =========================================================
-- B4. TẠO COMPARTMENTS
-- TH: Khoa Tiêu Hóa
-- TK: Khoa Thần Kinh
-- TM: Khoa Tim Mạch
-- =========================================================

BEGIN
    LBACSYS.SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 10,
        short_name  => 'TH',
        long_name   => 'Khoa tieu hoa'
    );

    LBACSYS.SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 20,
        short_name  => 'TK',
        long_name   => 'Khoa than kinh'
    );

    LBACSYS.SA_COMPONENTS.CREATE_COMPARTMENT(
        policy_name => 'THONGBAO_OLS',
        comp_num    => 30,
        short_name  => 'TM',
        long_name   => 'Khoa tim mach'
    );
END;
/


-- =========================================================
-- B5. TẠO GROUPS
-- HCM: Hồ Chí Minh
-- HP: Hải Phòng
-- HN: Hà Nội
-- =========================================================
BEGIN
    LBACSYS.SA_COMPONENTS.CREATE_GROUP(
            policy_name => 'THONGBAO_OLS',
            group_num  => 100,
            short_name => 'HCM',
            parent_name => NULL,
            long_name  => 'Hồ Chí Minh'
        );
        
    LBACSYS.SA_COMPONENTS.CREATE_GROUP(
            policy_name => 'THONGBAO_OLS',
            group_num  => 200,
            short_name => 'HP',
            parent_name => NULL,
            long_name  => 'Hải Phòng'
        );
        
    LBACSYS.SA_COMPONENTS.CREATE_GROUP(
            policy_name => 'THONGBAO_OLS',
            group_num  => 300,
            short_name => 'HN',
            parent_name => NULL,
            long_name  => 'Hà Nội'
        );
END;
/


 -- =========================================================
 -- B6. TẠO DATA LABELS
 -- t1: Gửi đến toàn bộ nhân viên
 -- t2: Gửi đến toàn bộ Ban Giám Đốc
 -- t3: Gửi đến các Lãnh đạo khoa
 -- t4: Gửi đến lãnh đạo Khoa tiêu hóa
 -- t5: Gửi đến nhân viên Khoa tiêu hóa ở HCM
 -- t6: Gửi đến nhân viên Khoa tiêu hóa ở HN
 -- t7: Gửi đến lãnh đạo Khoa tiêu hóa và Khoa thần kinh tại HP
-- =========================================================

BEGIN
    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1001,
        label_value => 'NV:TH,TK,TM:HCM,HP,HN'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1002,
        label_value => 'BGD:TH,TK,TM:HCM,HP,HN'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1003,
        label_value => 'LDK:TH,TK,TM:HCM,HP,HN'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1004,
        label_value => 'LDK:TH:HCM,HP,HN'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1005,
        label_value => 'NV:TH:HCM'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1006,
        label_value => 'NV:TH:HN'
    );

    LBACSYS.SA_LABEL_ADMIN.CREATE_LABEL(
        policy_name => 'THONGBAO_OLS',
        label_tag   => 1007,
        label_value => 'LDK:TH,TK:HP'
    );
END;
/
    
 -- =========================================================
 -- B7. APPLY POLICY VÀO BẢNG THONGBAO
 -- =========================================================
 
BEGIN
    LBACSYS.LBAC_POLICY_ADMIN.APPLY_TABLE_POLICY(
        policy_name    => 'THONGBAO_OLS',
        schema_name    => 'QLYTE_06',
        table_name     => 'THONGBAO',
        table_options  => 'READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL'
    );
END;
/

 -- =========================================================
 -- B8. DISABLE POLICY BẰNG SYS
 -- =========================================================
 
BEGIN
    LBACSYS.SA_SYSDBA.DISABLE_POLICY('THONGBAO_OLS');
END;
/


 -- =========================================================
 -- B9. GẮN LABEL CHO QLYTE_06
 -- Vẫn chạy bằng SYS
 -- =========================================================
 
 BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'QLYTE_06',
        max_read_label  => 'BGD:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        max_write_label => 'BGD:TH,TK,TM:HCM,HP,HN',
        def_label       => 'BGD:TH,TK,TM:HCM,HP,HN',
        row_label       => 'BGD:TH,TK,TM:HCM,HP,HN'
    );
END;
/
 
 
 -- =========================================================
 -- B10. GẮN LABEL CHO CÁC DÒNG DỮ LIỆU THONGBAO
 -- Lưu ý: sau khi apply policy, bảng THONGBAO có thêm cột THONGBAO_LABEL
 
UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'NV:TH,TK,TM:HCM,HP,HN')
WHERE MATB = 'T1';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'BGD:TH,TK,TM:HCM,HP,HN')
WHERE MATB = 'T2';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'LDK:TH,TK,TM:HCM,HP,HN')
WHERE MATB = 'T3';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'LDK:TH:HCM,HP,HN')
WHERE MATB = 'T4';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'NV:TH:HCM')
WHERE MATB = 'T5';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'NV:TH:HN')
WHERE MATB = 'T6';

UPDATE THONGBAO
SET THONGBAO_LABEL = CHAR_TO_LABEL('THONGBAO_OLS', 'LDK:TH,TK:HP')
WHERE MATB = 'T7';

COMMIT;


 -- =========================================================
 -- B11. GẮN USER LABELS CHO U1 ĐẾN U9
 -- u1: Giám đốc đọc toàn bộ thông báo
 -- u2: Lãnh đạo Khoa tim mạch tại HCM
 -- u3: Lãnh đạo Khoa thần kinh tại HN
 -- u4: Nhân viên Khoa thân kinh tại HCM
 -- u5: Nhân viên Khoa tim mạch tại HCM
 -- u6: Lãnh đạo phòng đọc thông báo Khoa tim mạch tại HCM
 -- u7: Lãnh đạo phòng đọc toàn bộ thông báo phù hợp với cấp lãnh đạo phòng 
-- =========================================================

 -- u1: Giám đốc
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U1',
        max_read_label  => 'BGD:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        max_write_label => 'BGD:TH,TK,TM:HCM,HP,HN',
        def_label       => 'BGD:TH,TK,TM:HCM,HP,HN',
        row_label       => 'BGD:TH,TK,TM:HCM,HP,HN'
    );
END;
/

-- u2: Lãnh đạo Khoa tim mạch tại HCM
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U2',
        max_read_label  => 'LDK:TM:HCM',
        min_write_label => 'NV',
        max_write_label => 'LDK:TM:HCM',
        def_label       => 'LDK:TM:HCM',
        row_label       => 'LDK:TM:HCM'
    );
END;
/

-- u3:Lãnh đạo Khoa thần kinh tại HN
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U3',
        max_read_label  => 'LDK:TK:HN',
        min_write_label => 'NV',
        max_write_label => 'LDK:TK:HN',
        def_label       => 'LDK:TK:HN',
        row_label       => 'LDK:TK:HN'
    );
END;
/

-- u4: Nhân viên Khoa thần kinh tại HCM
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U4',
        max_read_label  => 'NV:TK:HCM',
        min_write_label => 'NV',
        max_write_label => 'NV:TK:HCM',
        def_label       => 'NV:TK:HCM',
        row_label       => 'NV:TK:HCM'
    );
END;
/

-- u5: Nhân viên Khoa tim mạch tại HCM
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U5',
        max_read_label  => 'NV:TM:HCM',
        min_write_label => 'NV',
        max_write_label => 'NV:TM:HCM',
        def_label       => 'NV:TM:HCM',
        row_label       => 'NV:TM:HCM'
    );
END;
/

-- u6: Lãnh đạo phòng đọc thông báo Khoa tim mạch tại HCM
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U6',
        max_read_label  => 'LDK:TM:HCM',
        min_write_label => 'NV',
        max_write_label => 'LDK:TM:HCM',
        def_label       => 'LDK:TM:HCM',
        row_label       => 'LDK:TM:HCM'
    );
END;
/

-- u7: Lãnh đạo phfong đọc toàn bộ thông báo cấp lãnh đạo phòng
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U7',
        max_read_label  => 'LDK:TH,TK,TM:HCM,HP,HN',
        min_write_label => 'NV',
        max_write_label => 'LDK:TH,TK,TM:HCM,HP,HN',
        def_label       => 'LDK:TH,TK,TM:HCM,HP,HN',
        row_label       => 'LDK:TH,TK,TM:HCM,HP,HN'
    );
END;
/

-- u8: Nhân viên Khoa tiêu hóa tại HN
BEGIN
    LBACSYS.SA_USER_ADMIN.SET_USER_LABELS(
        policy_name     => 'THONGBAO_OLS',
        user_name       => 'U8',
        max_read_label  => 'NV:TH:HN',
        min_write_label => 'NV',
        max_write_label => 'NV:TH:HN',
        def_label       => 'NV:TH:HN',
        row_label       => 'NV:TH:HN'
    );
END;
/


-- =========================================================
-- B12. CẤP QUYỀN SELECT BẢNG THONGBAO CHO CÁC USER OLS
-- =========================================================

GRANT SELECT ON THONGBAO TO U1;
GRANT SELECT ON THONGBAO TO U2;
GRANT SELECT ON THONGBAO TO U3;
GRANT SELECT ON THONGBAO TO U4;
GRANT SELECT ON THONGBAO TO U5;
GRANT SELECT ON THONGBAO TO U6;
GRANT SELECT ON THONGBAO TO U7;
GRANT SELECT ON THONGBAO TO U8;

-- =========================================================
-- B13. ENABLE LẠI POLICY BẰNG SYS
-- =========================================================
BEGIN
    LBACSYS.SA_SYSDBA.ENABLE_POLICY('THONGBAO_OLS');
END;
/

-- =========================================================
-- B14. KIẾM TRA CẤU HÌNH
-- =========================================================

-- Kiểm tra dữ liệu thông báo bảng shema owner
SELECT MATB, NOIDUNG, DIADIEM, THONGBAO_LABEL
FROM THONGBAO
ORDER BY MATB;

