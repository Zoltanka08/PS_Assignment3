USE OnlineClinic;

INSERT INTO [User] ([Username], Password, Firstname, Lastname, Mobile, Mail, RoleId) 
VALUES	('admin123', '1234', 'AdminF', 'AdminL', '0742145623', 'admin_admin@admin.com', 1), 
		('doctor123', '1234', 'DoctorF', 'DoctorL', '07421451353', 'doctor_doctor@doctor.com', 2),
		('secretary123', '1234', 'SecretaryF', 'SecretaryL', '07421451353', 'secretary_sec@secretary.com', 3);