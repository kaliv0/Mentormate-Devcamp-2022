/* Select order details by order number - result should contain total price, waiter, date and time */
USE Restaurant

SELECT  o.Id AS OrderNumber,
		FORMAT(SUM(op.ProductPrice * op.ProductQuantity), 'N2') AS TotalPrice,
		u.FirstName + ' ' + u.LastName AS Waiter
FROM Orders AS o
INNER JOIN OrdersProducts AS op
	ON o.Id = op.OrderId
INNER JOIN Products AS p
	ON p.Id = op.ProductId
INNER JOIN Users AS u
	ON o.Waiter = u.Id
GROUP BY o.iD, u.FirstName, u.LastName
HAVING o.Id = 1



