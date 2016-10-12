--³ö¿â±¨±í
IF NOT EXISTS ( select 'x'
			from sys.tables st
				inner join sys.schemas ss on st.schema_id = ss.schema_id
			WHERE ss.name = 'dbo'
			and st.name = 'VMI_OutboundReport')	
BEGIN
PRINT 'CREATE TABLE VMI_OutboundReport'
CREATE TABLE [VMI_OutboundReport](
	[Id] [varchar](50) NOT NULL,
	[slCode] varchar(16),
	[shipTitle] nvarchar(500),
	[slArea] varchar(10),
	[suPin] varchar(50),
	[suCode] varchar(50),
	[status] char(1),
	[intoDate] datetime,
	[slAAECode] varchar(40),
	[slDate] datetime,
	[slFlag] int,
	[NewOrder] char(1),
	IsPacked char(1) default 'N',
	PackedTime datetime,
	PackedWeight numeric(18, 2),
	IsCz char(1) default 'N',
	CzTime datetime,
	CzWeight  numeric(18, 2),
	ShipWeight decimal(10, 3),
	RealWeight numeric(10, 3),
	ChargeWeight numeric(10, 3),
	[IsPayment] char(1) default 'N',
	IsOutBound char(1) default 'N',
	OutBoundTime datetime,
	OutBoundWeight  numeric(18, 2),
	AddTime datetime,
 CONSTRAINT [PK_VMI_OutboundReport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END



GO