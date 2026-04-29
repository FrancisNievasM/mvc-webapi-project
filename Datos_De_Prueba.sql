Use Obligatorio2P3
GO
/*Insercion de usuarios*/
INSERT INTO Usuarios (Mail_Value, Nombre_Value, Apellido_Value, Password, PasswordEncrypted, Tipo_Value)
VALUES
('john.doe@example.com', 'John', 'Doe', 'Password1;', '8037807009f98c71f5e6caba9201e03bfe9deb877e538595d265dd3f62b90916', 'Encargado'),
('jane.smith@example.com', 'Jane', 'Smith', 'Example1!', '5131bc8da61f187b1eec37145972cfd9604177791872c4d1c9bb3730c166e0e1', 'Encargado'),
('michael.johnson@example.com', 'Michael', 'Johnson', 'MySecure2,', '93582bf60340aa60a57c1b2b9d712f5aed10a301501915a37b64d6a3652f2bc4', 'Encargado'),
('emily.davis@example.com', 'Emily', 'Davis', 'Davis2023;', '06436a42213333964ee47a47ec2f759b2df2f87797083e9abebca87cd77f5100', 'Encargado'),
('william.brown@example.com', 'William', 'Brown', 'Brownie3!', '1f1fc46f9efbcf5c0cfed3a61762e580c1dad4cc49df4483252b9646af1e8c33', 'Encargado'),
('linda.miller@example.com', 'Linda', 'Miller', 'Secure!4;', '0c02c800e8270a08546a82519751447f850780b19c1d1c9c071addfc0d0802cd', 'Encargado'),
('robert.wilson@example.com', 'Robert', 'Wilson', 'Wilson5,', 'ea2581e43b8c3f0000dad355419bb7a6b6bdb7a1f687e7ea64b2e831010d2100', 'Encargado'),
('patricia.moore@example.com', 'Patricia', 'Moore', 'Tricia6.', '1df310fbe82e2bbbc984bd85b107c97fc0781a4f15c956a45930f7af17b5e651', 'Encargado'),
('james.taylor@example.com', 'James', 'Taylor', 'Taylor7;', '2e6ef711a36089c103035e4832e5f4dd886747690e3836ed091febed7833ed39', 'Encargado'),
('elizabeth.anderson@example.com', 'Elizabeth', 'Anderson', 'Admin8!', '677b2ccebd86e71c4f8217730e9fe709e1b83b285df1024efe45f7c3782ae831', 'Administrador');
go

/*Insercion de articulos*/

INSERT INTO Articulos (Nombre, Descripcion, Codigo, Precio)
VALUES 
('Bolígrafo Azul', 'Bolígrafo de tinta azul', 'AB12345678901', 50),
('Cuaderno A5', 'Cuaderno tamaño A5 con 80 hojas', 'CD23456789012', 120),
('Goma de Borrar', 'Goma de borrar blanca', 'EF34567890123', 30),
('Lápiz HB', 'Lápiz de grafito HB', 'GH45678901234', 20),
('Regla 30cm', 'Regla de plástico de 30 cm', 'IJ56789012345', 75),
('Marcador Permanente', 'Marcador permanente negro', 'KL67890123456', 100),
('Tijeras', 'Tijeras escolares de acero inoxidable', 'MN78901234567', 150),
('Carpeta A4', 'Carpeta de plástico tamaño A4', 'OP89012345678', 180),
('Pegamento en Barra', 'Pegamento en barra de 21 gramos', 'QR90123456789', 90),
('Resaltador Amarillo', 'Resaltador de tinta amarilla', 'ST01234567890', 110);
go

/*Insercion de Tipos de Movimiento*/
INSERT INTO TipoMovimientos (Nombre, Tipo) VALUES
('Compra', 'SUMA'),
('Venta', 'RESTA'),
('Devolución de Cliente', 'SUMA'),
('Devolución a Proveedor', 'RESTA'),
('Ajuste de Inventario Positivo', 'SUMA'),
('Ajuste de Inventario Negativo', 'RESTA'),
('Donación Entrante', 'SUMA'),
('Donación Saliente', 'RESTA'),
('Transferencia Entrante', 'SUMA'),
('Transferencia Saliente', 'RESTA');
go


/*Insercion de Movimientos*/
INSERT INTO Movimientos (ArtNombre, Fecha, Cantidad, TipoId, Mail_Value)
VALUES
('Bolígrafo Azul', '2018-01-15 14:23:45', 100, 1, 'john.doe@example.com'),
('Cuaderno A5', '2018-03-22 09:15:30', 50, 2, 'jane.smith@example.com'),
('Goma de Borrar', '2018-05-18 11:30:10', 200, 3, 'michael.johnson@example.com'),
('Lápiz HB', '2018-07-29 16:45:25', 150, 4, 'emily.davis@example.com'),
('Regla 30cm', '2018-09-12 10:05:50', 75, 5, 'william.brown@example.com'),
('Marcador Permanente', '2018-11-08 08:20:15', 120, 6, 'linda.miller@example.com'),
('Tijeras', '2019-02-14 13:37:20', 90, 7, 'robert.wilson@example.com'),
('Carpeta A4', '2019-04-25 15:12:55', 60, 8, 'patricia.moore@example.com'),
('Pegamento en Barra', '2019-06-19 12:22:40', 110, 9, 'james.taylor@example.com'),
('Resaltador Amarillo', '2019-08-30 17:18:35', 85, 10, 'john.doe@example.com'),
('Bolígrafo Azul', '2019-11-07 14:56:45', 200, 1, 'jane.smith@example.com'),
('Cuaderno A5', '2020-01-21 09:43:30', 45, 2, 'michael.johnson@example.com'),
('Goma de Borrar', '2020-03-13 11:29:55', 180, 3, 'emily.davis@example.com'),
('Lápiz HB', '2020-05-26 16:02:10', 210, 4, 'william.brown@example.com'),
('Regla 30cm', '2020-07-19 10:14:50', 55, 5, 'linda.miller@example.com'),
('Marcador Permanente', '2020-09-24 08:59:25', 140, 6, 'robert.wilson@example.com'),
('Tijeras', '2020-12-02 13:23:40', 75, 7, 'patricia.moore@example.com'),
('Carpeta A4', '2021-02-15 15:18:55', 95, 8, 'james.taylor@example.com'),
('Pegamento en Barra', '2021-04-11 12:43:20', 100, 9, 'john.doe@example.com'),
('Resaltador Amarillo', '2021-06-23 17:56:10', 120, 10, 'jane.smith@example.com'),
('Bolígrafo Azul', '2021-09-05 14:39:35', 60, 1, 'michael.johnson@example.com'),
('Cuaderno A5', '2021-11-14 09:21:50', 30, 2, 'emily.davis@example.com'),
('Goma de Borrar', '2022-01-29 11:50:10', 75, 3, 'william.brown@example.com'),
('Lápiz HB', '2022-04-05 16:27:45', 95, 4, 'linda.miller@example.com'),
('Regla 30cm', '2022-06-18 10:33:20', 110, 5, 'robert.wilson@example.com'),
('Marcador Permanente', '2022-08-24 08:44:55', 125, 6, 'patricia.moore@example.com'),
('Tijeras', '2022-11-10 13:16:35', 100, 7, 'james.taylor@example.com'),
('Carpeta A4', '2023-02-12 15:51:10', 85, 8, 'john.doe@example.com'),
('Pegamento en Barra', '2023-05-29 12:24:30', 115, 9, 'jane.smith@example.com'),
('Resaltador Amarillo', '2023-08-04 17:12:50', 130, 10, 'michael.johnson@example.com');
GO
/* Insercion de Parametros */
INSERT INTO Parametros (CantArtPagina, CantMovPagina, TopeCant)
VALUES (10, 20, 250);
GO





