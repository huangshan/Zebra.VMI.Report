declare @startTime datetime;
set @startTime= cast('2016-10-04 00:00:00' as datetime);
--�������״̬��ѯ
select a.partner as '�ͱ�',a.ref_value as '���ⵥ��',d.shiptitle as '�ͻ�������',a.receiveTime as '���Ľ���ʱ��',
 (case when isnull(c.status,'')='Y' then '�ӵ��ɹ�'
       when isnull(c.status,'')='N' then '�ӵ�ʧ��'
	   when  isnull(c.status,'')='P' then '���ӵ�'
 end)as '�ӵ�״̬',
 (
 case when  d.status='5' then 'δ��'
	  when  d.status='6' then '����'
	  when d.status='1' then '������ʽ����'
	  when  d.status='C' then '��ȡ��'
 end
 )as '��״̬',
 (
 select top 1 isnull(y.status,'') from Api_BasReceiveJob x,VMI_MessageParseRecord y where x.JobID=y.JobId and x.table_name='WMS_ORDER_CANCEL_NOTIFY' and x.ref_value=a.ref_value
 )as 'ȡ��״̬',
(select isnull(gels_sendflag,'') from api_stockOut where shiporder_id=b.slaaecode and gels_sendflag='0' and send_type='CSC44453' and [status]='Packed'
) as '���״̬',
 (
 case when isnull(NEWORDER,'')='Y' then '��ͬ����WMS'
 else 'δͬ����WMS'
 end
 )as 'WMSͬ��״̬',
 (
 select( case when ISNULL(gels_sendflag,'')='0' then '����ش����'
         when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)<10 then '����δ�ش�' 
		 when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)>=10 then '����ش�ʧ��' 
		end)
  from Api_StockOut where shiporder_id=d.shiptitle and  status='2' and (send_type='CSC44453') and isnull(failCount,0)<10 
 ) as '����״̬'
from api_basreceivejob a 
left join osshiplist b on(a.ref_value=b.pono)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
left join osshiplist_pre d on(a.ref_value=d.transnum)
where a.table_name='WMS_CONSIGN_ORDER_NOTIFY'
and a.partner ='CSC44453' AND a.receiveTime>=@startTime
union all
--��Ȥ����״̬��ѯ
select 
a.partner as '�ͱ�',a.ref_value as '���ⵥ��',b.shiptitle as '�ͻ�������',a.receiveTime as '���Ľ���ʱ��',
 '�ӵ��ɹ�' as '�ӵ�״̬',
 (
 case when  b.status='5' then 'δ��'
	  when  b.status='6' then '����'
	  when b.status='1' then '������ʽ����'
	  when  b.status='C' then '��ȡ��'
 end
 )as '��״̬',
 (
case when b.status='C' then '��ȡ��'
else 'δȡ��'
end
 )as 'ȡ��״̬',
'' as '���״̬',
 (
 case when isnull(c.NEWORDER,'')='N' then '��ͬ����WMS'
 else 'δͬ����WMS'
 end
 )as 'WMSͬ��״̬',
 (
 select( case when ISNULL(gels_sendflag,'')='0' then '����ش����'
         when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)<10 then '����δ�ش�' 
		 when  ISNULL(gels_sendflag,'')='1' and  isnull(failCount,0)>=10 then '����ش�ʧ��' 
		end)
  from Api_StockOut where shiporder_id=b.shiptitle and  status='2' and (send_type='CSC40467') and isnull(failCount,0)<10 
 ) as '����״̬'  
from Api_BasReceiveJob a
left join osShipList_Pre b on (a.ref_value=b.shiptitle)
left join osshiplist c on(a.ref_value=c.shiptitle)
where partner='CSC40467' AND table_name='LOGISTICS_SKU_PAID' and b.slarea='HKH' and receiveTime>=@startTime
order by '�ͱ�','���Ľ���ʱ��'
