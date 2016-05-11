USE OnlineClinic;

CREATE TABLE [User] 
(
Id int IDENTITY PRIMARY KEY,
Username varchar(30),
Password varchar(30),
Firstname varchar(30),
Lastname varchar(30),
Mobile varchar(30),
Mail varchar(30),
RoleId int,
FOREIGN KEY (RoleId) REFERENCES [Role](Id)
);