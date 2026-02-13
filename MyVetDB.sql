-- Created by GitHub Copilot in SSMS - review carefully before executing

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
    created_at DATETIME,
    updated_at DATETIME
);

/* ===============================
   VETERINARIAN
================================ */
CREATE TABLE Veterinarian (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    full_name VARCHAR(100),
    specialty VARCHAR(100),
    professional_license VARCHAR(50),
    phone VARCHAR(20),
    email VARCHAR(100),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME,
    updated_at DATETIME
);

/* ===============================
   CLINIC_VETERINARIAN
================================ */
CREATE TABLE ClinicVeterinarian (
    id INT IDENTITY(1,1) PRIMARY KEY,
    veterinarian_id INT NOT NULL,
    clinic_id INT NOT NULL,
    is_active BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_CV_Veterinarian
        FOREIGN KEY (veterinarian_id) REFERENCES Veterinarian(id),
    CONSTRAINT FK_CV_Clinic
        FOREIGN KEY (clinic_id) REFERENCES Clinic(id)
);

/* ===============================
   OWNER
================================ */
CREATE TABLE Owner (
    id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    full_name VARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    address VARCHAR(200),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME,
    updated_at DATETIME
);

/* ===============================
   PET
================================ */
CREATE TABLE Pet (
    id INT IDENTITY(1,1) PRIMARY KEY,
    owner_id INT NOT NULL,
    name VARCHAR(100),
    species VARCHAR(50),
    breed VARCHAR(50),
    gender CHAR(1),
    birth_date DATE,
    color VARCHAR(50),
    is_active BIT NOT NULL DEFAULT 1,
    created_at DATETIME,
    updated_at DATETIME,
    CONSTRAINT FK_Pet_Owner
        FOREIGN KEY (owner_id) REFERENCES Owner(id)
);

/* ===============================
   APPOINTMENT STATUS
================================ */
CREATE TABLE AppointmentStatus (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(50),
    description VARCHAR(100),
    is_active BIT NOT NULL DEFAULT 1
);

/* ===============================
   APPOINTMENT
================================ */
CREATE TABLE Appointment (
    id INT IDENTITY(1,1) PRIMARY KEY,
    veterinarian_id INT NOT NULL,
    clinic_id INT NOT NULL,
    pet_id INT NOT NULL,
    status_id INT NOT NULL,
    appointment_date DATETIME,
    created_at DATETIME,
    CONSTRAINT FK_Appointment_Veterinarian
        FOREIGN KEY (veterinarian_id) REFERENCES Veterinarian(id),
    CONSTRAINT FK_Appointment_Clinic
        FOREIGN KEY (clinic_id) REFERENCES Clinic(id),
    CONSTRAINT FK_Appointment_Pet
        FOREIGN KEY (pet_id) REFERENCES Pet(id),
    CONSTRAINT FK_Appointment_Status
        FOREIGN KEY (status_id) REFERENCES AppointmentStatus(id)
);

/* ===============================
   CONSULTATION
================================ */
CREATE TABLE Consultation (
    id INT IDENTITY(1,1) PRIMARY KEY,
    appointment_id INT NOT NULL,
    reason NVARCHAR(MAX),
    diagnosis NVARCHAR(MAX),
    consultation_date DATETIME,
    weight_kg DECIMAL(5,2),
    height_cm DECIMAL(5,2),
    CONSTRAINT FK_Consultation_Appointment
        FOREIGN KEY (appointment_id) REFERENCES Appointment(id)
);

/* ===============================
   MEDICAL HISTORY
================================ */
CREATE TABLE MedicalHistory (
    id INT IDENTITY(1,1) PRIMARY KEY,
    consultation_id INT NOT NULL,
    notes NVARCHAR(MAX),
    created_at DATETIME,
    CONSTRAINT FK_MedicalHistory_Consultation
        FOREIGN KEY (consultation_id) REFERENCES Consultation(id)
);

/* ===============================
   PRESCRIPTION
================================ */
CREATE TABLE Prescription (
    id INT IDENTITY(1,1) PRIMARY KEY,
    general_instructions NVARCHAR(MAX),
    medical_history_id INT NOT NULL,
    created_at DATETIME,
    CONSTRAINT FK_Prescription_MedicalHistory
        FOREIGN KEY (medical_history_id) REFERENCES MedicalHistory(id)
);

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

/* ===============================
   PRESCRIPTION_MEDICINE
================================ */
CREATE TABLE PrescriptionMedicine (
    id INT IDENTITY(1,1) PRIMARY KEY,
    prescription_id INT NOT NULL,
    medicine_id INT NOT NULL,
    dosage VARCHAR(100),
    frequency VARCHAR(100),
    duration VARCHAR(50),
    CONSTRAINT FK_PM_Prescription
        FOREIGN KEY (prescription_id) REFERENCES Prescription(id),
    CONSTRAINT FK_PM_Medicine
        FOREIGN KEY (medicine_id) REFERENCES Medicine(id)
);

/* ===============================
   MEDICATION SCHEDULE
================================ */
CREATE TABLE MedicationSchedule (
    id INT IDENTITY(1,1) PRIMARY KEY,
    prescription_id INT NOT NULL,
    medicine_id INT NOT NULL,
    scheduled_date DATE,
    scheduled_time TIME,
    taken BIT,
    CONSTRAINT FK_MS_Prescription
        FOREIGN KEY (prescription_id) REFERENCES Prescription(id),
    CONSTRAINT FK_MS_Medicine
        FOREIGN KEY (medicine_id) REFERENCES Medicine(id)
);

/* ===============================
   NOTIFICATION
================================ */
CREATE TABLE Notification (
    id INT IDENTITY(1,1) PRIMARY KEY,
    medication_schedule_id INT NOT NULL,
    sent_at DATETIME,
    is_sent BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_Notification_MedicationSchedule
        FOREIGN KEY (medication_schedule_id) REFERENCES MedicationSchedule(id)
);