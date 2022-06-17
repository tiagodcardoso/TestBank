--• Listar os primeiros quatro clientes que possuem alguma parcela com mais de cinco dias em atraso (Data Vencimento maior que data atual E data pagamento nula).

select * from dbo.Parcelas where DataVencimento < GETDATE() and DataPagamento is null


--Listar todos os clientes do estado de SP que possuem mais de 60% das parcelas pagas;

select IdFinanciamento
,count(DataPagamento)*100/count(NumeroParcela) as percentual_pago
from parcelas
where idfinanciamento in
      (select distinct IdFinanciamento from dbo.Parcelas where DataPagamento is not null)
group by IdFinanciamento
having  count(DataPagamento)*100/count(NumeroParcela) >= 60