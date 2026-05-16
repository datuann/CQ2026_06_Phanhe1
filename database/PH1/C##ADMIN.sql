-- Script to create database schema for Hospital Management System
-- Using Oracle SQL

-- Drop tables if they exist (for re-creation)
DROP TABLE Hos_Medication CASCADE CONSTRAINTS;
DROP TABLE Hos_Medical_Record CASCADE CONSTRAINTS;
DROP TABLE Hos_Appointment CASCADE CONSTRAINTS;
DROP TABLE Hos_Doctor CASCADE CONSTRAINTS;
DROP TABLE Hos_Patient CASCADE CONSTRAINTS;

-- Create Patient table
CREATE TABLE Hos_Patient (
    ID VARCHAR2(10) PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    DOB DATE,
    Address VARCHAR2(200),
    Medical_History CLOB,
    Sensitivity_Level VARCHAR2(20) CHECK (Sensitivity_Level IN ('Public', 'Confidential', 'Secret'))
);

-- Create Doctor table
CREATE TABLE Hos_Doctor (
    ID VARCHAR2(10) PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Specialty VARCHAR2(100),
    Department VARCHAR2(100)
);

-- Create Appointment table
CREATE TABLE Hos_Appointment (
    ID VARCHAR2(10) PRIMARY KEY,
    Patient_ID VARCHAR2(10) REFERENCES Hos_Patient(ID),
    Doctor_ID VARCHAR2(10) REFERENCES Hos_Doctor(ID),
    DateApp DATE NOT NULL,
    Status VARCHAR2(20) CHECK (Status IN ('Pending', 'Completed', 'Cancelled')),
    Notes CLOB
);

-- Create Medical_Record table
CREATE TABLE Hos_Medical_Record (
    ID VARCHAR2(10) PRIMARY KEY,
    Patient_ID VARCHAR2(10) REFERENCES Hos_PATIENT(ID),
    Doctor_ID VARCHAR2(10) REFERENCES Hos_DOCTOR(ID),
    Diagnosis VARCHAR2(200),
    Treatment CLOB,
    DateRec DATE NOT NULL
);

-- Create Medication table
CREATE TABLE Hos_Medication (
    ID VARCHAR2(10) PRIMARY KEY,
    Name VARCHAR2(100) NOT NULL,
    Dosage VARCHAR2(50),
    Patient_ID VARCHAR2(10) REFERENCES Hos_Patient(ID),
    Prescribed_By VARCHAR2(10) REFERENCES Hos_Doctor(ID)
);

-- Insert detailed sample data

-- Patients
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P001', 'Nguyen Van A', TO_DATE('1990-01-15', 'YYYY-MM-DD'), '123 Duong Nguyen Thai Hoc, Quan 1, TPHCM', 'Cao huyet ap, tieu duong loai 2', 'Confidential');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P002', 'Tran Thi B', TO_DATE('1985-05-20', 'YYYY-MM-DD'), '456 Duong Binh Hung, Quan 2, TPHCM', 'Di ung thuoc, benh tim mach', 'Secret');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P003', 'Le Van C', TO_DATE('2000-03-10', 'YYYY-MM-DD'), '789 Duong Cao Thang, Quan 3, TPHCM', 'Khong co benh man tinh', 'Public');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P004', 'Pham Thi D', TO_DATE('1975-07-25', 'YYYY-MM-DD'), '101 Duong Hoang Dieu, Quan 4, TPHCM', 'Ung thu vu, dang dieu tri', 'Secret');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P005', 'Ho Van E', TO_DATE('1995-11-30', 'YYYY-MM-DD'), '202 Duong Tran Hung Dao, Quan 5, TPHCM', 'Hen suyen, di ung phan hoa', 'Confidential');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P006', 'Vo Thi F', TO_DATE('1988-02-14', 'YYYY-MM-DD'), '303 Duong Binh Phu, Quan 6, TPHCM', 'Thieu mau, benh than', 'Confidential');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P007', 'Bui Van G', TO_DATE('1992-06-18', 'YYYY-MM-DD'), '404 Duong Nguyen Van Linh, Quan 7, TPHCM', 'Viêm da, di ung', 'Public');
INSERT INTO Hos_Patient (ID, Name, DOB, Address, Medical_History, Sensitivity_Level) 
VALUES ('P008', 'Dang Thi H', TO_DATE('1970-09-05', 'YYYY-MM-DD'), '505 Duong Pham The Hien, Quan 8, TPHCM', 'Benh gan, tieu duong', 'Secret');

-- Doctors
INSERT INTO Hos_Doctor (ID, Name, Specialty, Department) 
VALUES ('D001', 'Vu Thi F', 'Noi khoa', 'Khoa Noi');
INSERT INTO Hos_Doctor (ID, Name, Specialty, Department) 
VALUES ('D002', 'Dang Van G', 'Ngoai khoa', 'Khoa Ngoai');
INSERT INTO Hos_Doctor (ID, Name, Specialty, Department) 
VALUES ('D003', 'Bui Thi H', 'Nhi khoa', 'Khoa Nhi');
INSERT INTO Hos_Doctor (ID, Name, Specialty, Department) 
VALUES ('D004', 'Ngo Van I', 'San khoa', 'Khoa San');
INSERT INTO Hos_Doctor (ID, Name, Specialty, Department) 
VALUES ('D005', 'Ly Thi K', 'Tim mach', 'Khoa Tim mach');

-- Appointments (adding more to make doctors treat multiple patients, eg, D001 treats P001, P003, P006, P008; D002 treats P002, P004, P007, etc)
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A001', 'P001', 'D001', TO_DATE('2025-09-01', 'YYYY-MM-DD'), 'Completed', 'Kham dinh ky, kiem tra huyet ap');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A002', 'P002', 'D002', TO_DATE('2025-09-05', 'YYYY-MM-DD'), 'Pending', 'Phau thuat ngoai khoa');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A003', 'P003', 'D001', TO_DATE('2025-09-10', 'YYYY-MM-DD'), 'Cancelled', 'Tre em bi sot, huy do benh nang');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A004', 'P004', 'D002', TO_DATE('2025-09-15', 'YYYY-MM-DD'), 'Completed', 'Kham san khoa dinh ky');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A005', 'P005', 'D005', TO_DATE('2025-09-20', 'YYYY-MM-DD'), 'Pending', 'Kiem tra tim mach');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A006', 'P006', 'D001', TO_DATE('2025-09-25', 'YYYY-MM-DD'), 'Completed', 'Kham than va truyen dich');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A007', 'P007', 'D002', TO_DATE('2025-09-30', 'YYYY-MM-DD'), 'Pending', 'Dieu tri viêm da');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A008', 'P008', 'D001', TO_DATE('2025-10-05', 'YYYY-MM-DD'), 'Completed', 'Kiem tra gan va dieu tri tieu duong');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A009', 'P003', 'D001', TO_DATE('2025-10-10', 'YYYY-MM-DD'), 'Pending', 'Tai kham sau huy lich truoc');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A010', 'P006', 'D001', TO_DATE('2025-10-15', 'YYYY-MM-DD'), 'Completed', 'Theo doi thieu mau');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A011', 'P004', 'D002', TO_DATE('2025-10-20', 'YYYY-MM-DD'), 'Pending', 'Tai kham sau phau thuat');
INSERT INTO Hos_Appointment (ID, Patient_ID, Doctor_ID, DateApp, Status, Notes) 
VALUES ('A012', 'P007', 'D002', TO_DATE('2025-10-25', 'YYYY-MM-DD'), 'Completed', 'Kiem tra da lieu');

-- Medical_Records (corresponding to appointments, with doctors having multiple records)
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR001', 'P001', 'D001', 'Cao huyet ap', 'Ke don thuoc ha huyet ap, khuyen cao che do an uong', TO_DATE('2025-09-01', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR002', 'P002', 'D002', 'Gay xuong', 'Phau thuat noi xuong, nghi ngoi 6 tuan', TO_DATE('2025-09-05', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR003', 'P003', 'D001', 'Cam cum', 'Thuoc ha sot, nghi ngoi tai nha', TO_DATE('2025-09-10', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR004', 'P004', 'D002', 'Ung thu giai doan 2', 'Hoa tri, theo doi dinh ky', TO_DATE('2025-09-15', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR005', 'P005', 'D005', 'Roi loan nhip tim', 'Thuoc dieu tri, kiem tra lai sau 1 thang', TO_DATE('2025-09-20', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR006', 'P006', 'D001', 'Thieu mau man tinh', 'Truyen mau, bo sung sat', TO_DATE('2025-09-25', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR007', 'P007', 'D002', 'Viêm da di ung', 'Kem boi, tranh tiep xuc chat kich thich', TO_DATE('2025-09-30', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR008', 'P008', 'D001', 'Viêm gan B', 'Thuoc khang virus, che do an uong', TO_DATE('2025-10-05', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR009', 'P003', 'D001', 'Sot sieu vi', 'Nghi ngoi, uong nhieu nuoc', TO_DATE('2025-10-10', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR010', 'P006', 'D001', 'Benh than man tinh', 'Loc mau, dieu chinh che do an', TO_DATE('2025-10-15', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR011', 'P004', 'D002', 'Sau phau thuat', 'Thuoc giam dau, tai kham', TO_DATE('2025-10-20', 'YYYY-MM-DD'));
INSERT INTO Hos_Medical_Record (ID, Patient_ID, Doctor_ID, Diagnosis, Treatment, DateRec) 
VALUES ('MR012', 'P007', 'D002', 'Da lieu man tinh', 'Dieu tri dai han, theo doi', TO_DATE('2025-10-25', 'YYYY-MM-DD'));

-- Medications (adding more, with doctors prescribing to multiple patients)
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED001', 'Paracetamol', '500mg, 3 lan/ngay', 'P001', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED002', 'Amoxicillin', '250mg, 2 lan/ngay', 'P002', 'D002');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED003', 'Ibuprofen', '400mg, khi dau', 'P003', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED004', 'Tamoxifen', '20mg, 1 lan/ngay', 'P004', 'D002');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED005', 'Aspirin', '81mg, 1 lan/ngay', 'P005', 'D005');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED006', 'Metformin', '500mg, 2 lan/ngay', 'P001', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED008', 'Ferrous Sulfate', '325mg, 1 lan/ngay', 'P006', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED009', 'Hydrocortisone Cream', '1%, boi 2 lan/ngay', 'P007', 'D002');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED010', 'Entecavir', '05mg, 1 lan/ngay', 'P008', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED011', 'Cefixime', '200mg, 2 lan/ngay', 'P003', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED012', 'Furosemide', '40mg, 1 lan/ngay', 'P006', 'D001');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED013', 'Oxycodone', '5mg, khi dau', 'P004', 'D002');
INSERT INTO Hos_Medication (ID, Name, Dosage, Patient_ID, Prescribed_By) 
VALUES ('MED014', 'Prednisone', '10mg, 1 lan/ngay', 'P007', 'D002');

-- Commit changes
COMMIT;

select * from Hos_Doctor;
select * from Hos_Patient;
select * from Hos_Medication;
select * from Hos_medical_record;
select * from Hos_appointment;

-- Tạo User
CREATE USER P001 IDENTIFIED BY 123;
GRANT CONNECT TO P001;
GRANT CREATE SESSION TO P001;

CREATE USER D001 IDENTIFIED BY 123;
GRANT CONNECT TO D001;
GRANT CREATE SESSION TO D001;

CREATE USER N001 IDENTIFIED BY 123;
GRANT CREATE SESSION TO N001;

CREATE USER N_TEMP IDENTIFIED BY 123;
GRANT CREATE SESSION TO N_TEMP;

CREATE USER INTERN1 IDENTIFIED BY 123;
GRANT CREATE SESSION TO INTERN1;

CREATE USER M001 IDENTIFIED BY 123;
GRANT CREATE SESSION TO M001;

-- DAC
-- Triển khai DAC để cho phép Admin grant quyền SELECT trên bảng Patient cho một Doctor cụ thể. Giải thích rủi ro nếu Doctor grant tiếp cho người khác
GRANT SELECT ON HOS_PATIENT TO D001;

-- Sử dụng DAC để doctor revoke quyền UPDATE trên Medical_Record từ Nurse trên hồ sơ của mình.
GRANT CREATE VIEW TO D001;

GRANT SELECT, UPDATE ON HOS_MEDICAL_RECORD TO D001 WITH GRANT OPTION;

-- Patient grant quyền SELECT trên Appointment cho một Nurse tạm thời. Giải thích cách DAC hỗ trợ chia sẻ dữ liệu linh hoạt nhưng có thể dẫn đến rò rỉ thông tin.
GRANT CREATE VIEW TO P001;

GRANT SELECT ON HOS_APPOINTMENT TO P001 WITH GRANT OPTION;

-- Triển khai DAC với WITH GRANT OPTION để Doctor có thể grant quyền cho
GRANT SELECT ON HOS_MEDICATION TO D001 WITH GRANT OPTION;

-- RBAC
-- Tạo role Doctor_Role với quyền SELECT/UPDATE trên Medical_Record và Appointment. Thêm user vào role và test.
CREATE ROLE DOCTOR_ROLE;

GRANT SELECT, UPDATE ON HOS_MEDICAL_RECORD TO DOCTOR_ROLE;

GRANT SELECT, UPDATE ON HOS_APPOINTMENT TO DOCTOR_ROLE;

GRANT DOCTOR_ROLE TO D001;

-- Tạo role Nurse_Role với quyền hạn chế hơn (chỉ SELECT trên Patient)
CREATE ROLE NURSE_ROLE;

GRANT SELECT ON HOS_PATIENT TO NURSE_ROLE;

GRANT NURSE_ROLE TO N001;

-- Tạo role Manager_Role chỉ cho phép SELECT trên báo cáo tổng hợp (sử dụng VIEW). Tạo view và grant role.
CREATE ROLE MANAGER_ROLE;

CREATE OR REPLACE VIEW V_DOCTOR_REPORT AS
SELECT 
    D.ID           AS DOCTOR_ID,
    D.NAME         AS DOCTOR_NAME,
    COUNT(A.ID)    AS TOTAL_APPOINTMENTS
FROM HOS_DOCTOR D
LEFT JOIN HOS_APPOINTMENT A 
    ON D.ID = A.DOCTOR_ID
GROUP BY D.ID, D.NAME;

GRANT SELECT ON V_DOCTOR_REPORT TO MANAGER_ROLE;

GRANT MANAGER_ROLE TO M001;

-- Triển khai session roles để một doctor có thể switch sang Nurse_Role tạm thời. Viết câu lệnh SET ROLE và nhận xét về việc sử dụng dynamic RBAC

GRANT SELECT ON HOS_MEDICAL_RECORD TO NURSE_ROLE;

GRANT SELECT ON HOS_APPOINTMENT TO NURSE_ROLE;

GRANT DOCTOR_ROLE TO D001;

GRANT NURSE_ROLE TO D001;

ALTER USER D001 DEFAULT ROLE DOCTOR_ROLE;

-- VPD
-- Tạo VPD policy để Patient chỉ thấy dòng của mình trong bảng Medical_Record

CREATE ROLE PATIENT_ROLE;

GRANT PATIENT_ROLE TO P001;

GRANT SELECT ON HOS_MEDICAL_RECORD TO PATIENT_ROLE;

CREATE OR REPLACE FUNCTION F_VPD_PATIENT_RECORD
(
    P_SCHEMA VARCHAR2,
    P_OBJ    VARCHAR2
)
RETURN VARCHAR2
AS
BEGIN
    RETURN 'PATIENT_ID = SYS_CONTEXT(''USERENV'',''SESSION_USER'')';
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'C##ADMIN',
        object_name   => 'HOS_MEDICAL_RECORD',
        policy_name   => 'POL_PATIENT_RECORD'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'C##ADMIN',
        object_name     => 'HOS_MEDICAL_RECORD',
        policy_name     => 'POL_PATIENT_RECORD',
        policy_function => 'F_VPD_PATIENT_RECORD',
        statement_types => 'SELECT'
    );
END;
/

-- Áp dụng VPD cho Doctor chỉ xem Appointment trong department của mình. Viết policy và mô tả cách nó bảo vệ privacy mà không thay đổi query.
GRANT SELECT ON HOS_APPOINTMENT TO DOCTOR_ROLE;

CREATE OR REPLACE FUNCTION F_VPD_DOCTOR_APPOINTMENT_DEPT
(
    P_SCHEMA VARCHAR2,
    P_OBJ    VARCHAR2
)
RETURN VARCHAR2
AS
    V_USER VARCHAR2(30);
BEGIN
    V_USER := SYS_CONTEXT('USERENV', 'SESSION_USER');

    RETURN 'DOCTOR_ID IN (
                SELECT D2.ID
                FROM C##ADMIN.HOS_DOCTOR D1
                JOIN C##ADMIN.HOS_DOCTOR D2
                  ON D1.DEPARTMENT = D2.DEPARTMENT
                WHERE D1.ID = ''' || V_USER || '''
            )';
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'C##ADMIN',
        object_name   => 'HOS_APPOINTMENT',
        policy_name   => 'POL_DOCTOR_APPT_DEPT'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'C##ADMIN',
        object_name     => 'HOS_APPOINTMENT',
        policy_name     => 'POL_DOCTOR_APPT_DEPT',
        policy_function => 'F_VPD_DOCTOR_APPOINTMENT_DEPT',
        statement_types => 'SELECT'
    );
END;
/

-- Triển khai VPD column-masking để Nurse không thấy Medical_History trong Patient nếu Sensitivity_Level = 'Secret'. Viết policy với column masking và giải thích ứng dụng trong dữ liệu nhạy cảm.
CREATE OR REPLACE FUNCTION F_VPD_NURSE_PATIENT_MASK
(
    P_SCHEMA VARCHAR2,
    P_OBJ    VARCHAR2
)
RETURN VARCHAR2
AS
    V_USER VARCHAR2(30);
BEGIN
    V_USER := SYS_CONTEXT('USERENV', 'SESSION_USER');

    IF V_USER IN ('N001', 'N_TEMP') THEN
        RETURN 'SENSITIVITY_LEVEL <> ''Secret''';
    ELSE
        RETURN '1=1';
    END IF;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'C##ADMIN',
        object_name   => 'HOS_PATIENT',
        policy_name   => 'POL_NURSE_PATIENT_MASK'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema         => 'C##ADMIN',
        object_name           => 'HOS_PATIENT',
        policy_name           => 'POL_NURSE_PATIENT_MASK',
        policy_function       => 'F_VPD_NURSE_PATIENT_MASK',
        statement_types       => 'SELECT',
        sec_relevant_cols     => 'MEDICAL_HISTORY',
        sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS
    );
END;
/

-- Tạo VPD policy cho Manager chỉ thấy dữ liệu tổng hợp trên Medication mà không thấy chi tiết Patient_ID.
CREATE OR REPLACE VIEW V_MEDICATION_SUMMARY AS
SELECT
    PRESCRIBED_BY,
    NAME AS MEDICATION_NAME,
    COUNT(*) AS TOTAL_PRESCRIPTIONS
FROM HOS_MEDICATION
GROUP BY PRESCRIBED_BY, NAME;

GRANT SELECT ON V_MEDICATION_SUMMARY TO MANAGER_ROLE;

GRANT SELECT ON HOS_MEDICATION TO MANAGER_ROLE;

CREATE OR REPLACE FUNCTION F_VPD_MANAGER_MED_MASK
(
    P_SCHEMA VARCHAR2,
    P_OBJ    VARCHAR2
)
RETURN VARCHAR2
AS
    V_USER VARCHAR2(30);
BEGIN
    V_USER := SYS_CONTEXT('USERENV', 'SESSION_USER');

    IF V_USER = 'M001' THEN
        RETURN '1=2';
    ELSE
        RETURN '1=1';
    END IF;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema => 'C##ADMIN',
        object_name   => 'HOS_MEDICATION',
        policy_name   => 'POL_MANAGER_MED_MASK'
    );
EXCEPTION
    WHEN OTHERS THEN NULL;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema         => 'C##ADMIN',
        object_name           => 'HOS_MEDICATION',
        policy_name           => 'POL_MANAGER_MED_MASK',
        policy_function       => 'F_VPD_MANAGER_MED_MASK',
        statement_types       => 'SELECT',
        sec_relevant_cols     => 'PATIENT_ID',
        sec_relevant_cols_opt => DBMS_RLS.ALL_ROWS
    );
END;
/

SELECT GRANTEE, GRANTED_ROLE, ADMIN_OPTION
FROM DBA_ROLE_PRIVS
WHERE GRANTEE = 'U_TEST';

SELECT GRANTEE, GRANTED_ROLE
FROM DBA_ROLE_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND GRANTED_ROLE = 'R_TEST';

SELECT GRANTEE, OWNER, TABLE_NAME, PRIVILEGE
FROM DBA_TAB_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND TABLE_NAME = 'HOS_PATIENT';

SELECT GRANTEE, TABLE_NAME, PRIVILEGE
FROM DBA_TAB_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND TABLE_NAME = 'HOS_PATIENT'
  AND PRIVILEGE = 'SELECT';
  
SELECT GRANTEE, TABLE_NAME, COLUMN_NAME, PRIVILEGE
FROM DBA_COL_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND TABLE_NAME = 'HOS_PATIENT';


SELECT GRANTEE, TABLE_NAME, PRIVILEGE
FROM DBA_TAB_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND TABLE_NAME = 'V_DOCTOR_REPORT';
  
SELECT GRANTEE, GRANTED_ROLE, ADMIN_OPTION
FROM DBA_ROLE_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND GRANTED_ROLE = 'R_TEST';
  
SELECT GRANTEE, TABLE_NAME, PRIVILEGE, GRANTABLE
FROM DBA_TAB_PRIVS
WHERE GRANTEE = 'U_TEST'
  AND TABLE_NAME = 'HOS_PATIENT'
  AND PRIVILEGE = 'SELECT';