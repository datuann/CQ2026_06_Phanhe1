-- =========================================================
-- PHÂN HỆ 2 - INSERT SAMPLE DATA
-- Nhóm: 06
-- Schema: QLYTE_06
-- Chạy bằng User QLYTE_06
-- =========================================================

-- =========================================================
-- XOA DU LIEU CU
-- =========================================================

DELETE FROM DONTHUOC;
DELETE FROM HSBA_DV;
DELETE FROM HSBA;
DELETE FROM THONGBAO;
DELETE FROM BENHNHAN;
DELETE FROM NHANVIEN;

COMMIT;

-- =========================================================
-- NHANVIEN
-- Vai tro:
-- 1. Dieu phoi vien
-- 2. Bac si/Y si
-- 3. Ky thuat vien
-- =========================================================

INSERT INTO NHANVIEN (
    MANV, HOTEN, PHAI, NGAYSINH, CMND, QUEQUAN, SODT, VAITRO, CHUYENKHOA, USERNAME
) VALUES (
    'DP001', N'Nguyễn Điều Phối 1', N'Nam', DATE '1990-01-01',
    '100000001', N'TP. Hồ Chí Minh', '0900000001',
    N'Điều phối viên', N'Tim mạch', 'DP001'
);

INSERT INTO NHANVIEN VALUES (
    'DP002', N'Trần Điều Phối 2', N'Nữ', DATE '1992-02-02',
    '100000002', N'Hà Nội', '0900000002',
    N'Điều phối viên', N'Thần kinh', 'DP002'
);

INSERT INTO NHANVIEN VALUES (
    'BS001', N'Nguyễn Bác Sĩ 1', N'Nam', DATE '1985-03-01',
    '200000001', N'TP. Hồ Chí Minh', '0910000001',
    N'Bác sĩ/Y sĩ', N'Tim mạch', 'BS001'
);

INSERT INTO NHANVIEN VALUES (
    'BS002', N'Lê Bác Sĩ 2', N'Nữ', DATE '1986-04-02',
    '200000002', N'Hà Nội', '0910000002',
    N'Bác sĩ/Y sĩ', N'Thần kinh', 'BS002'
);

INSERT INTO NHANVIEN VALUES (
    'BS003', N'Phạm Y Sĩ 3', N'Nam', DATE '1988-05-03',
    '200000003', N'Hải Phòng', '0910000003',
    N'Bác sĩ/Y sĩ', N'Tiêu hóa', 'BS003'
);

INSERT INTO NHANVIEN VALUES (
    'KT001', N'Nguyễn Kỹ Thuật 1', N'Nam', DATE '1995-06-01',
    '300000001', N'TP. Hồ Chí Minh', '0920000001',
    N'Kỹ thuật viên', N'Xét nghiệm', 'KT001'
);

INSERT INTO NHANVIEN VALUES (
    'KT002', N'Trần Kỹ Thuật 2', N'Nữ', DATE '1996-07-02',
    '300000002', N'Hà Nội', '0920000002',
    N'Kỹ thuật viên', N'Chẩn đoán hình ảnh', 'KT002'
);

-- =========================================================
-- BENHNHAN
-- USERNAME dung de anh xa voi Oracle user
-- =========================================================

INSERT INTO BENHNHAN VALUES (
    'BN001', N'Nguyễn Văn An', N'Nam', DATE '2000-01-10',
    '400000001', N'12', N'Lê Lợi', N'Quận 1', N'TP. Hồ Chí Minh',
    N'Tiểu đường', N'Cao huyết áp', N'Penicillin', 'BN001'
);

INSERT INTO BENHNHAN VALUES (
    'BN002', N'Trần Thị Bình', N'Nữ', DATE '1999-02-15',
    '400000002', N'34', N'Nguyễn Huệ', N'Quận 3', N'TP. Hồ Chí Minh',
    N'Không', N'Không', N'Không', 'BN002'
);

INSERT INTO BENHNHAN VALUES (
    'BN003', N'Lê Văn Cường', N'Nam', DATE '1998-03-20',
    '400000003', N'56', N'Trần Phú', N'Ba Đình', N'Hà Nội',
    N'Hen suyễn', N'Tim mạch', N'Hải sản', 'BN003'
);

INSERT INTO BENHNHAN VALUES (
    'BN004', N'Phạm Thị Dung', N'Nữ', DATE '2001-04-25',
    '400000004', N'78', N'Lạch Tray', N'Ngô Quyền', N'Hải Phòng',
    N'Không', N'Tiểu đường', N'Không', 'BN004'
);

-- =========================================================
-- HSBA
-- MABS quy dinh bac si phu trach ho so
-- MAKHOA demo khoa
-- =========================================================

INSERT INTO HSBA VALUES (
    'HS001', 'BN001', DATE '2026-05-01',
    N'Đau ngực', N'Theo dõi tim mạch', 'BS001', 'TIMMACH',
    N'Đang theo dõi'
);

INSERT INTO HSBA VALUES (
    'HS002', 'BN002', DATE '2026-05-02',
    N'Đau đầu kéo dài', N'Chụp MRI', 'BS002', 'THANKINH',
    N'Chờ kết quả'
);

INSERT INTO HSBA VALUES (
    'HS003', 'BN003', DATE '2026-05-03',
    N'Đau bụng', N'Nội soi tiêu hóa', 'BS003', 'TIEUHOA',
    N'Chờ xét nghiệm'
);

INSERT INTO HSBA VALUES (
    'HS004', 'BN004', DATE '2026-05-04',
    N'Khó thở', N'Xét nghiệm máu', 'BS001', 'TIMMACH',
    N'Đang điều trị'
);

-- =========================================================
-- HSBA_DV
-- MAKT quy dinh ky thuat vien duoc dieu phoi
-- =========================================================

INSERT INTO HSBA_DV VALUES (
    'HS001', N'Xét nghiệm máu', DATE '2026-05-01',
    'KT001', N'Chưa có kết quả'
);

INSERT INTO HSBA_DV VALUES (
    'HS002', N'Chụp MRI', DATE '2026-05-02',
    'KT002', N'Chưa có kết quả'
);

INSERT INTO HSBA_DV VALUES (
    'HS003', N'Nội soi', DATE '2026-05-03',
    'KT001', N'Chưa có kết quả'
);

INSERT INTO HSBA_DV VALUES (
    'HS004', N'Điện tâm đồ', DATE '2026-05-04',
    'KT002', N'Chưa có kết quả'
);

-- =========================================================
-- DONTHUOC
-- Dung de test bac si va audit
-- =========================================================

INSERT INTO DONTHUOC VALUES (
    'HS001', DATE '2026-05-01',
    N'Aspirin', N'1 viên/ngày'
);

INSERT INTO DONTHUOC VALUES (
    'HS002', DATE '2026-05-02',
    N'Paracetamol', N'2 viên/ngày'
);

INSERT INTO DONTHUOC VALUES (
    'HS003', DATE '2026-05-03',
    N'Omeprazole', N'1 viên trước ăn sáng'
);

INSERT INTO DONTHUOC VALUES (
    'HS004', DATE '2026-05-04',
    N'Salbutamol', N'Xịt khi khó thở'
);

-- =========================================================
-- THONGBAO
-- Sau nay OLS se gan label cho tung dong
-- =========================================================

INSERT INTO THONGBAO VALUES (
    'T1',
    N'Gửi đến toàn bộ nhân viên',
    SYSTIMESTAMP,
    N'Toàn bệnh viện'
);

INSERT INTO THONGBAO VALUES (
    'T2',
    N'Gửi đến toàn bộ Ban giám đốc',
    SYSTIMESTAMP,
    N'Phòng họp trung tâm'
);

INSERT INTO THONGBAO VALUES (
    'T3',
    N'Gửi đến các lãnh đạo khoa',
    SYSTIMESTAMP,
    N'Phòng họp khoa'
);

INSERT INTO THONGBAO VALUES (
    'T4',
    N'Gửi đến lãnh đạo Khoa tiêu hóa',
    SYSTIMESTAMP,
    N'Khoa tiêu hóa'
);

INSERT INTO THONGBAO VALUES (
    'T5',
    N'Gửi đến nhân viên Khoa tiêu hóa ở Hồ Chí Minh',
    SYSTIMESTAMP,
    N'Cơ sở Hồ Chí Minh'
);

INSERT INTO THONGBAO VALUES (
    'T6',
    N'Gửi đến nhân viên Khoa tiêu hóa ở Hà Nội',
    SYSTIMESTAMP,
    N'Cơ sở Hà Nội'
);

INSERT INTO THONGBAO VALUES (
    'T7',
    N'Gửi đến lãnh đạo Khoa tiêu hóa và Khoa thần kinh tại Hải Phòng',
    SYSTIMESTAMP,
    N'Cơ sở Hải Phòng'
);

COMMIT;

-- =========================================================
-- KIEM TRA SO LUONG DU LIEU
-- =========================================================

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


SELECT * FROM NHANVIEN;
SELECT * FROM BENHNHAN;
SELECT * FROM HSBA;
SELECT * FROM HSBA_DV;
SELECT * FROM DONTHUOC;
SELECT * FROM THONGBAO;