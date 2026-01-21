SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* ===============================
   CLINIC
================================ */
CREATE TABLE Clinic (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    address VARCHAR(200),
    phone VARCHAR(20),
    email VARCHAR(100),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME2,
    updated_at DATETIME2
);
GO

/* ===============================
   DOCTOR
================================ */
CREATE TABLE Doctor (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NULL,
    full_name VARCHAR(100),
    specialty VARCHAR(100),
    professional_license VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME2,
    updated_at DATETIME2
);
GO

/* ===============================
   CLINIC_DOCTOR
================================ */
CREATE TABLE ClinicDoctor (
    id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_id INT NOT NULL,
    clinic_id INT NOT NULL,
    is_active BIT NOT NULL DEFAULT 1
);
GO

/* ===============================
   PATIENT
================================ */
CREATE TABLE Patient (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NULL,
    full_name VARCHAR(100),
    birth_date DATE,
    gender CHAR(1),
    phone VARCHAR(20),
    email VARCHAR(100),
    address VARCHAR(200),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME2,
    updated_at DATETIME2
);
GO

/* ===============================
   APPOINTMENT STATUS
================================ */
CREATE TABLE AppointmentStatus (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50),
    description VARCHAR(100),
    is_active BIT NOT NULL DEFAULT 1
);
GO

/* ===============================
   APPOINTMENT
================================ */
CREATE TABLE Appointment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    doctor_id INT NOT NULL,
    clinic_id INT NOT NULL,
    patient_id INT NOT NULL,
    status_id INT NOT NULL,
    appointment_date DATETIME2,
    created_at DATETIME2
);
GO

/* ===============================
   CONSULTATION
   (includes weight & height)
================================ */
CREATE TABLE Consultation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT NOT NULL,
    reason VARCHAR(MAX),
    diagnosis VARCHAR(MAX),
    consultation_date DATETIME2,
    weight_kg DECIMAL(5,2),
    height_cm DECIMAL(5,2)
);
GO

/* ===============================
   MEDICAL HISTORY
================================ */
CREATE TABLE MedicalHistory (
    id INT IDENTITY(1,1) PRIMARY KEY,
    consultation_id INT NOT NULL,
    notes VARCHAR(500),
    created_at DATETIME2
);
GO

/* ===============================
   PRESCRIPTION
================================ */
CREATE TABLE Prescription (
    id INT IDENTITY(1,1) PRIMARY KEY,
    general_instructions VARCHAR(500),
    medical_history_id INT NOT NULL,
    created_at DATETIME2
);
GO

/* ===============================
   MEDICINE
================================ */
CREATE TABLE Medicine (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100),
    description VARCHAR(200),
    presentation VARCHAR(50),
    is_active BIT NOT NULL DEFAULT 1
);
GO

/* ===============================
   PRESCRIPTION_MEDICINE
================================ */
CREATE TABLE PrescriptionMedicine (
    id INT IDENTITY(1,1) PRIMARY KEY,
    prescription_id INT NOT NULL,
    medicine_id INT NOT NULL,
    dosage VARCHAR(100),
    frequency VARCHAR(100),
    duration VARCHAR(50)
);
GO

/* ===============================
   MEDICATION SCHEDULE
================================ */
CREATE TABLE MedicationSchedule (
    id INT IDENTITY(1,1) PRIMARY KEY,
    prescription_id INT NOT NULL,
    medicine_id INT NOT NULL,
    scheduled_date DATE,
    scheduled_time TIME,
    taken BIT
);
GO

/* ===============================
   NOTIFICATION
================================ */
CREATE TABLE Notification (
    id INT IDENTITY(1,1) PRIMARY KEY,
    medication_schedule_id INT NOT NULL,
    sent_at DATETIME2,
    is_sent BIT NOT NULL DEFAULT 1
);
GO

/* ===============================
   FOREIGN KEYS
================================ */

ALTER TABLE ClinicDoctor
ADD CONSTRAINT FK_ClinicDoctor_Clinic
FOREIGN KEY (clinic_id) REFERENCES Clinic(id);

ALTER TABLE ClinicDoctor
ADD CONSTRAINT FK_ClinicDoctor_Doctor
FOREIGN KEY (doctor_id) REFERENCES Doctor(id);

ALTER TABLE Appointment
ADD CONSTRAINT FK_Appointment_Doctor
FOREIGN KEY (doctor_id) REFERENCES Doctor(id);

ALTER TABLE Appointment
ADD CONSTRAINT FK_Appointment_Clinic
FOREIGN KEY (clinic_id) REFERENCES Clinic(id);

ALTER TABLE Appointment
ADD CONSTRAINT FK_Appointment_Patient
FOREIGN KEY (patient_id) REFERENCES Patient(id);

ALTER TABLE Appointment
ADD CONSTRAINT FK_Appointment_Status
FOREIGN KEY (status_id) REFERENCES AppointmentStatus(id);

ALTER TABLE Consultation
ADD CONSTRAINT FK_Consultation_Appointment
FOREIGN KEY (appointment_id) REFERENCES Appointment(id);

ALTER TABLE MedicalHistory
ADD CONSTRAINT FK_MedicalHistory_Consultation
FOREIGN KEY (consultation_id) REFERENCES Consultation(id);

ALTER TABLE Prescription
ADD CONSTRAINT FK_Prescription_MedicalHistory
FOREIGN KEY (medical_history_id) REFERENCES MedicalHistory(id);

ALTER TABLE PrescriptionMedicine
ADD CONSTRAINT FK_PM_Prescription
FOREIGN KEY (prescription_id) REFERENCES Prescription(id);

ALTER TABLE PrescriptionMedicine
ADD CONSTRAINT FK_PM_Medicine
FOREIGN KEY (medicine_id) REFERENCES Medicine(id);

ALTER TABLE MedicationSchedule
ADD CONSTRAINT FK_MS_Prescription
FOREIGN KEY (prescription_id) REFERENCES Prescription(id);

ALTER TABLE MedicationSchedule
ADD CONSTRAINT FK_MS_Medicine
FOREIGN KEY (medicine_id) REFERENCES Medicine(id);

ALTER TABLE Notification
ADD CONSTRAINT FK_Notification_MedicationSchedule
FOREIGN KEY (medication_schedule_id) REFERENCES MedicationSchedule(id);
GO