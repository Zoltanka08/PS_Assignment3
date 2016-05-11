USE OnlineClinic;

CREATE TABLE [Treatment] 
(
Id int IDENTITY PRIMARY KEY,
Description varchar(200),
PatientId int,
MedicineId int,
FOREIGN KEY (PatientId) REFERENCES [Patient](Id),
FOREIGN KEY (MedicineId) REFERENCES [Medicine](Id)
);