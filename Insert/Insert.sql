USE [ApiREST]
GO

/* Añios */
INSERT INTO [dbo].[Anios] ([Descrip]) VALUES ('Primero')
INSERT INTO [dbo].[Anios] ([Descrip]) VALUES ('Segundo')
INSERT INTO [dbo].[Anios] ([Descrip]) VALUES ('Tercero')

/* Aulas */
INSERT INTO [dbo].[Aulas] ([Descrip],[Activa]) VALUES ('Aula N° 1',0)
INSERT INTO [dbo].[Aulas] ([Descrip],[Activa]) VALUES ('Aula N° 2',1)
INSERT INTO [dbo].[Aulas] ([Descrip],[Activa]) VALUES ('Aula N° 3',1)
INSERT INTO [dbo].[Aulas] ([Descrip],[Activa]) VALUES ('Aula N° 4',0)
INSERT INTO [dbo].[Aulas] ([Descrip],[Activa]) VALUES ('Aula N° 5',1)

/*Carreras*/
INSERT INTO [dbo].[Carreras] ([Descripcion]) VALUES ('ANALISTA EN MEDIO AMBIENTE')
INSERT INTO [dbo].[Carreras] ([Descripcion]) VALUES ('TÉCNICO SUPERIOR EN GESTIÓN INDUSTRIAL')
INSERT INTO [dbo].[Carreras] ([Descripcion]) VALUES ('TÉCNICO SUPERIOR EN INFRAESTRUCTURA DE TECNOLOGÍA DE LA INFORMACIÓN')
INSERT INTO [dbo].[Carreras] ([Descripcion]) VALUES ('TÉCNICO SUPERIOR EN DESARROLLO DE SOFTWARE')

/* Curso */
INSERT INTO [dbo].[Condiciones] ([Descrip]) VALUES ('LIBRE')
INSERT INTO [dbo].[Condiciones] ([Descrip]) VALUES ('REGULAR')
INSERT INTO [dbo].[Condiciones] ([Descrip]) VALUES ('APROBADA')

/* Dias */
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Lunes')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Martes')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Miercoles')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Jueves')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Viernes')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Sabado')
INSERT INTO [dbo].[Dias] ([Descrip]) VALUES ('Domingo')

/* Estado Civiles */
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Soltero/a')
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Casado/a')
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Divorciado/a')
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Viudo/a')
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Concubinato')
INSERT INTO [dbo].[EstadosCiviles] ([Descrip]) VALUES ('Separación en proceso judicial')

/* Generos */
INSERT INTO [dbo].[Generos] ([Descrip]) VALUES ('Masculino')
INSERT INTO [dbo].[Generos] ([Descrip]) VALUES ('Femenino')

/*Horarios*/
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('18:00 - 18:40')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('18:40 - 19:20')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('19:30 - 20:10')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('20:10 - 20:50')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('20:50 - 21:40')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('21:40 - 22:20')
INSERT INTO [dbo].[Horarios] ([Descrip]) VALUES ('22:20 - 23:00')

/*Localidades*/
INSERT INTO [dbo].[Localidades] ([Descrip]) VALUES('Reconquista')
INSERT INTO [dbo].[Localidades] ([Descrip]) VALUES('Avellaneda')

/* Nacionalidades */
INSERT INTO [dbo].[Nacionalidades] ([Descrip]) VALUES ('Argentina')
INSERT INTO [dbo].[Nacionalidades] ([Descrip]) VALUES ('Uruguaya')
INSERT INTO [dbo].[Nacionalidades] ([Descrip]) VALUES ('Chilena')
INSERT INTO [dbo].[Nacionalidades] ([Descrip]) VALUES ('Boliviana')

/* Tipos de Documentos */
INSERT INTO [dbo].[TiposDocs] ([Descrip]) VALUES ('DNI')
INSERT INTO [dbo].[TiposDocs] ([Descrip]) VALUES ('LC - Libreta Cívica')
INSERT INTO [dbo].[TiposDocs] ([Descrip]) VALUES ('CI - Cédula de Identidad')

GO


