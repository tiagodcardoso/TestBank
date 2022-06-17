Create Table [dbo].[Cliente](
		[Id]			[int] IDENTITY NOT NULL,
		[Nome]			[varchar](180) NOT NULL,
		[UF]			[int]		   NOT NULL,
		[Celular]		[varchar](15)  NOT NULL,
				CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		))
GO

Create Table [dbo].[Financiamento](
		[Id]					[int] IDENTITY  NOT NULL,
		[Cpf]					[varchar](11)   NOT NULL,
		[TipoFinanciamento]		[int]		    NOT NULL,
		[ValorTotal]			[decimal](15,4) NOT NULL,
		[DataUltimoVencimento]	[Datetime]	    NOT NULL,
			CONSTRAINT [PK_Financiamento] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		))
GO

Create Table [dbo].[Parcelas](
		[Id]				[int] IDENTITY  NOT NULL,
		[IdFinanciamento]	[int]   NOT NULL,
		[NumeroParcela]		[int]		    NOT NULL,
		[ValorParcela]		[decimal](15,4) NOT NULL,
		[DataVencimento]	[Datetime]	    NOT NULL,
		[DataPagamento]		[Datetime]	    NOT NULL,
		CONSTRAINT [PK_Parcelas] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		))
GO

ALTER TABLE [dbo].[Parcelas] WITH CHECK ADD CONSTRAINT [FK_Parcelas_Financiamento] FOREIGN KEY (Id)
REFERENCES [dbo].[Financiamento]([Id])
GO



