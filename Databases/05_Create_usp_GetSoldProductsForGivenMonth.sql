/* List sold products for a given month -
result should show aggregated quantity and aggregated price for all sales during the search period. 
Every matching product should exist once into the result. */


CREATE OR ALTER PROCEDURE  usp_GetSoldProductsForGivenMonth @month int
AS
	SELECT p.[Name] AS ProductName, FORMAT(SUM(op.ProductPrice * op.ProductQuantity), 'N2') AS TotalPrice,
		op.ProductPrice AS IndividualPrice, op.ProductQuantity, MONTH(o.EndDate) AS [Month]
	FROM Orders AS o
	INNER JOIN OrdersProducts AS op
		ON o.Id = op.OrderId
	INNER JOIN Products AS p
		ON op.ProductId = p.Id
	WHERE MONTH(o.EndDate) = @month  --only lists orders made in february
							         --that are completed (e.g. order 1 is marked in progress therefore is missing here)
	GROUP BY p.[Name],op.ProductPrice, op.ProductQuantity, o.EndDate
	ORDER BY p.[Name]
GO


