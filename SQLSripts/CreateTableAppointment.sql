USE OnlineClinic;

CREATE TABLE [Appointment] 
(
Id int IDENTITY PRIMARY KEY,
PatientId int,
UserId int,
StartDate Datetime,
EndDate Datetime,
FOREIGN KEY (PatientId) REFERENCES [Patient](Id),
FOREIGN KEY (UserId) REFERENCES [User](Id)
);