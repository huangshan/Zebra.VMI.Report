IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[GetNewInboundOrders]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [GetNewInboundOrders]
GO

SET ANSI_NULLS ON
GO

SET ANSI_PADDING ON
GO

SET ANSI_WARNINGS ON
GO

SET ARITHABORT ON
GO

SET CONCAT_NULL_YIELDS_NULL ON
GO

SET NUMERIC_ROUNDABORT OFF
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetNewInboundOrders
AS					   
BEGIN
	SET NOCOUNT ON;
	DECLARE
	@STARTTIME DATETIME = DATEADD(DAY, -1, GETDATE());
	select top 1 @STARTTIME=receiveTime from VMI_InboundReport where receiveTime>@STARTTIME order by receiveTime desc;

	insert into VMI_InboundReport (id, ref_value, partner, slArea, pin, receiveTime
	, ParseStatus, PostFlux, SEFLAG, LotNo, addtime) 

	select REPLACE (newid(), '-' , ''), a.ref_value, a.partner, b.sgarea, a.pin, a.receiveTime
	, c.status, b.PostFlux, b.seflag, b.LotNo, getdate()
	from api_basreceivejob a
	left join osshipnotice b on(a.ref_value=b.lotno)
	left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
	where a.receiveTime>@STARTTIME
END;
GO