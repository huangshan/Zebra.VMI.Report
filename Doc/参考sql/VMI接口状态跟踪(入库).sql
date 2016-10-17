declare @startTime datetime;
set @startTime= cast('2016-10-04 00:00:00' as datetime);
--�������״̬��ѯ
select a.partner as '�ͱ�',a.ref_value as '��ⵥ��',a.receiveTime as '���Ľ���ʱ��',
 (case when isnull(c.status,'')='Y' then '�ӵ��ɹ�'
       when isnull(c.status,'')='N' then '�ӵ�ʧ��'
	   when  isnull(c.status,'')='P' then '���ӵ�'
 end)as '�ӵ�״̬',
(CASE when SEFLAG=0 THEN 'δ���'
 WHEN seflag=2 THEN '����ѻش�'
 WHEN seflag=1 THEN '�����δ�ش�'
 else
 '�ش�ʧ��'
 end) as '���״̬',
 (
 case when isnull(PostFlux,0)=1 then '��ͬ����WMS'
 else 'δͬ����WMS'
 end
 )as 'WMSͬ��״̬'
from api_basreceivejob a 
left join osshipnotice b on(a.ref_value=b.lotno)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
where a.table_name='WMS_STOCK_IN_ORDER_NOTIFY'
and a.partner ='CSC44453' AND a.receiveTime>=@startTime
union all
--��Ȥ���״̬��ѯ
select a.partner as '�ͱ�',a.ref_value as '��ⵥ��',a.receiveTime as '���Ľ���ʱ��',
 (case when isnull(b.LotNo,'')<>'' then '�ӵ��ɹ�'
       else '�ӵ�ʧ��'
 end)acceptStatus,
(CASE when SEFLAG=0 THEN 'δ���'
 WHEN seflag=2 THEN '����ѻش�'
 WHEN seflag=1 THEN '�����δ�ش�'
 else
 '�ش�ʧ��'
 end)inboundstatus,
 (
 case when isnull(PostFlux,0)=1 then '��ͬ����WMS'
 else 'δͬ����WMS'
 end
 )ToFlux
from api_basreceivejob a 
left join osshipnotice b on(a.ref_value=b.lotno)
left join VMI_MessageParseRecord c on(a.jobid=c.jobid)
where a.table_name='LOGISTICS_SKU_STOCKIN_INFO'
and a.partner ='CSC40467' AND a.receiveTime>=@startTime
ORDER BY a.partner,a.receiveTime ;




