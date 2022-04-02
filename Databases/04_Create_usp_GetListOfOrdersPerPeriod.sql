/* List orders per period (start date and time, end date time) - result should contain order total and date */
CREATE OR ALTER PROCEDURE  usp_GetListOfOrdersPerPeriod @startDate DATETIME, @endDate DATETIME
AS
	SELECT o.Id AS OrderId, FORMAT(SUM(op.ProductPrice * op.ProductQuantity), 'N2') AS TotalAmount, CONVERT(DATE, o.EndDate) AS [Date] 
	FROM Orders AS o
	INNER JOIN OrdersProducts AS op
		ON o.Id = op.OrderId
	INNER JOIN Products AS p
		ON op.ProductId = p.Id
	WHERE o.CreateDate >= @startDate  --only lists orders made in february and march
		AND o.EndDate <= @endDate     --that are completed (e.g. order 1 is marked in progress therefore is missing here)
	GROUP BY o.Id, o.EndDate
GO

