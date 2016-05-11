USE OnlineClinic;

CREATE TABLE [Patient] 
(
Id int IDENTITY PRIMARY KEY,
Firstname varchar(30),
Lastname varchar(30),
Age int,
Mobile varchar(30),
Mail varchar(30),
Address varchar(60)
);