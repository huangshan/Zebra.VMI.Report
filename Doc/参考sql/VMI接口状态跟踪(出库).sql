declare @startTime datetime;
set @startTime= cast('2016-10-04 00:00:00' as datetime);
--菜鸟出库状态查询
select a.partner as '客编',a.ref_value as '出库单号',d.shiptitle as '客户订单号',a.receiveTime as '报文接收时间',
 (case when isnull(c.status,'')='Y' then '接单成功'
       when isnull(c.status,'')='N' then '接单失败'
	   when  isnull(c.status,'')='P' then '待接单'
 end)as '接单状态',
 (
 case when  d.status='5' then '未审单'
	  when  d.status='6' then '已审单'
	  when d.status='1' then '生成正式订单'
	  when  d.status='C' then '已取消'
 end
 )as '审单状态',
 (
 select top 1 isnull(y.status,'') from Api_BasReceiveJob x,VMI_MessageParseRecord y where x.JobID=y.JobId and x.table_name='WMS_ORDER_CANCEL_NOTIFY' and x.ref_value=a.ref_value
 )as '取消状态',
(select isnull(gels_sendflag,'') from api_stockOut where shiporder_id=b.slaaecode and gels_sendflag='0' and send_type='CSC44453' and [status]='Packed'
) as '打包状态',
 (
 case when isnull(NEWORDER,'')='Y' then '已同步到WMS'
 else '未同步到WMS'
 end
 )as 'WMS同步状态',
 (
 select( case when ISNULL(gels_sendflag,'')='0' then '出库回传完成'
         when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)<10 then '出库未回传' 
		 when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)>=10 then '出库回传失败' 
		end)
  from Api_StockOut where shiporder_id=d.shiptitle and  status='2' and (send_type='CSC44453') and isnull(failCount,0)<10 
 ) as '出库状态'
from api_basreceivejob a 
left join osshiplist b on(a.ref_value=b.pono)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
left join osshiplist_pre d on(a.ref_value=d.transnum)
where a.table_name='WMS_CONSIGN_ORDER_NOTIFY'
and a.partner ='CSC44453' AND a.receiveTime>=@startTime
union all
--丰趣出库状态查询
select 
a.partner as '客编',a.ref_value as '出库单号',b.shiptitle as '客户订单号',a.receiveTime as '报文接收时间',
 '接单成功' as '接单状态',
 (
 case when  b.status='5' then '未审单'
	  when  b.status='6' then '已审单'
	  when b.status='1' then '生成正式订单'
	  when  b.status='C' then '已取消'
 end
 )as '审单状态',
 (
case when b.status='C' then '已取消'
else '未取消'
end
 )as '取消状态',
'' as '打包状态',
 (
 case when isnull(c.NEWORDER,'')='N' then '已同步到WMS'
 else '未同步到WMS'
 end
 )as 'WMS同步状态',
 (
 select( case when ISNULL(gels_sendflag,'')='0' then '出库回传完成'
         when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)<10 then '出库未回传' 
		 when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)>=10 then '出库回传失败' 
		end)
  from Api_StockOut where shiporder_id=b.shiptitle and  status='2' and (send_type='CSC40467') and isnull(failCount,0)<10 
 ) as '出库状态'  
from Api_BasReceiveJob a
left join osShipList_Pre b on (a.ref_value=b.shiptitle)
left join osshiplist c on(a.ref_value=c.shiptitle)
where partner='CSC40467' AND table_name='LOGISTICS_SKU_PAID' and b.slarea='HKH' and receiveTime>=@startTime
order by '客编','报文接收时间'
