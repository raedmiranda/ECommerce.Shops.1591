USE [ECommerce]
GO

ALTER TABLE [dbo].[Tienda] DROP CONSTRAINT [DF__Tienda__Abierto__49C3F6B7]
GO

/****** Object:  Table [dbo].[Tienda]    Script Date: 8/05/2022 13:24:49 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tienda]') AND type in (N'U'))
DROP TABLE [dbo].[Tienda]
GO

/****** Object:  Table [dbo].[Tienda]    Script Date: 8/05/2022 13:24:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Tienda](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Direccion] [varchar](250) NOT NULL,
	[Abierto] [bit] NULL,
 CONSTRAINT [PK__Tienda__3214EC07E7EAC0D2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Tienda] ADD  CONSTRAINT [DF__Tienda__Abierto__49C3F6B7]  DEFAULT ((1)) FOR [Abierto]

---------------------
GO
---------------------

USE [ECommerce]
GO

/****** Object:  StoredProcedure [dbo].[spListarTiendas]    Script Date: 8/05/2022 13:25:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spListarTiendas]
-- @Id int
as
begin
	select * 
	from Tienda
	where Abierto = 1;
end;



---------------------
GO
---------------------
USE [ECommerce]
GO

/****** Object:  StoredProcedure [dbo].[spInsertarTienda]    Script Date: 8/05/2022 13:25:47 ******/
DROP PROCEDURE [dbo].[spInsertarTienda]
GO

/****** Object:  StoredProcedure [dbo].[spInsertarTienda]    Script Date: 8/05/2022 13:25:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spInsertarTienda]
	@Nombre varchar(100),
	@Direccion varchar(250)
as
begin
	insert into Tienda(Nombre, Direccion) 
	values (@Nombre, @Direccion) 
end;
GO

