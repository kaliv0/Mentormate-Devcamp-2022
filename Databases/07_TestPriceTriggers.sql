USE Restaurant

SELECT p.[Name], p.Id, p.Price, op.ProductPrice
FROM Products AS p
INNER JOIN OrdersProducts AS op
	ON p.Id =  op.ProductId
WHERE p.[Name] = 'Wine'

UPDATE Products
SET Price += 1
WHERE Id = 11

SELECT p.[Name], p.Id, p.Price, op.ProductPrice
FROM Products AS p
INNER JOIN OrdersProducts AS op
	ON p.Id =  op.ProductId
WHERE p.[Name] = 'Wine'