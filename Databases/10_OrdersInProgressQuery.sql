/* List orders in progress */
USE Restaurant

SELECT p.[Name], os.[Name] AS [Status]
FROM Orders AS o
INNER JOIN OrdersProducts AS op
	ON op.OrderId = o.Id
INNER JOIN Products AS p
	ON op.ProductId = p.Id
INNER JOIN OrderStatuses AS os
	ON o.[Status] = os.Id
WHERE [Status] = 1;