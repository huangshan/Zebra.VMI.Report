IF  EXISTS (SELECT * FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[GetNewOutboundOrders]') AND TYPE IN (N'P', N'PC'))
DROP PROCEDURE [GetNewOutboundOrders]
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

CREATE PROCEDURE GetNewOutboundOrders
AS					   
BEGIN
	SET NOCOUNT ON;
	DECLARE
	@STARTTIME DATETIME = DATEADD(DAY, -1, GETDATE());
	select top 1 @STARTTIME=intoDate from VMI_OutboundReport where intoDate>@STARTTIME order by intoDate desc;

	insert into VMI_OutboundReport (id, slcode, shiptitle, slarea, supin, sucode, status, intodate) 
	select REPLACE (newid(), '-' , ''), sl.slcode, sl.shiptitle, sl.slarea, sl.supin, u.sucode, sl.status, sl.intodate
	from osshiplist_pre sl
	inner join osShipUser u on sl.supin=u.supin
	where intodate>@STARTTIME and slarea in ('HKH')
	and u.suCode in (select sucode from vmi_customerwhitelist where enable='Y' and starttime<@STARTTIME)
END;
GO