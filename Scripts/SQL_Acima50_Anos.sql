SELECT
o.Nome, 
o.Email, 
o.Escolaridade,
o.Idade,
case 
	when o.idade <= 20 then 'Menor de 20'
	when o.idade > 20 and o.idade <= 50 then 'Entre 20 e 50'
	else 'Acima de 50'
end FaixaEtaria
From
( SELECT 
u.Nome, 
u.Email, 
u.DataNascimento,
u.IdEscolaridade,
e.Escolaridade,
FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) Idade
From Usuario u
left join Escolaridade e on e.IdEscolaridade = u.IdEscolaridade
where u.IdEscolaridade in (SELECT idEscolaridade From Escolaridade where Escolaridade = 'Superior')
) o
where o.idade > 50
