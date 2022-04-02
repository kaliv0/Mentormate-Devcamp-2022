/* List of order products by order number - result should contain name, code, price 
	e.g. All products for Order with id = 1 */
USE Restaurant

SELECT o.Id AS OrderNumber, os.[Name] AS OrderStatus, p.[Name] AS ProductName, op.ProductPrice
FROM Orders AS o
INNER JOIN OrderStatuses AS os
	ON o.[Status] = os.Id
INNER JOIN OrdersProducts as op
	ON o.Id = op.OrderId
INNER JOIN Products AS p
	ON op.ProductId = p.Id
WHERE o.Id = 1
