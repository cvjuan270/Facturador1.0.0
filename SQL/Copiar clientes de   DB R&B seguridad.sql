select * from [FACTURADOR01].[dbo].[SOCNEG]
insert into [FACTURADOR01].[dbo].[SOCNEG]
 select CardCode,1,CardName,LicTradNum,null,null,null,Address,Address,1,null,null from OCRD where CardType = 'C' and Address is not null and CardCode not in ('20454587929','20601317185')
