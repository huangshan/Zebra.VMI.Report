declare @startTime datetime;
set @startTime= cast('2016-10-04 00:00:00' as datetime);
--菜鸟入库状态查询
select a.partner as '客编',a.ref_value as '入库单号',a.receiveTime as '报文接收时间',
 (case when isnull(c.status,'')='Y' then '接单成功'
       when isnull(c.status,'')='N' then '接单失败'
	   when  isnull(c.status,'')='P' then '待接单'
 end)as '接单状态',
(CASE when SEFLAG=0 THEN '未入库'
 WHEN seflag=2 THEN '入库已回传'
 WHEN seflag=1 THEN '已入库未回传'
 else
 '回传失败'
 end) as '入库状态',
 (
 case when isnull(PostFlux,0)=1 then '已同步到WMS'
 else '未同步到WMS'
 end
 )as 'WMS同步状态'
from api_basreceivejob a 
left join osshipnotice b on(a.ref_value=b.lotno)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
where a.table_name='WMS_STOCK_IN_ORDER_NOTIFY'
and a.partner ='CSC44453' AND a.receiveTime>=@startTime
union all
--丰趣入库状态查询
select a.partner as '客编',a.ref_value as '入库单号',a.receiveTime as '报文接收时间',
 (case when isnull(b.LotNo,'')<>'' then '接单成功'
       else '接单失败'
 end)acceptStatus,
(CASE when SEFLAG=0 THEN '未入库'
 WHEN seflag=2 THEN '入库已回传'
 WHEN seflag=1 THEN '已入库未回传'
 else
 '回传失败'
 end)inboundstatus,
 (
 case when isnull(PostFlux,0)=1 then '已同步到WMS'
 else '未同步到WMS'
 end
 )ToFlux
from api_basreceivejob a 
left join osshipnotice b on(a.ref_value=b.lotno)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
where a.table_name='LOGISTICS_SKU_STOCKIN_INFO'
and a.partner ='CSC40467' AND a.receiveTime>=@startTime
ORDER BY a.partner,a.receiveTime ;




