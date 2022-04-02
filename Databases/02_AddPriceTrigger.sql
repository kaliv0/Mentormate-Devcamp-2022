CREATE OR ALTER TRIGGER tr_AddPrice 
ON OrdersProducts INSTEAD OF INSERT
AS
	DECLARE @orderId INT = (SELECT i.OrderId FROM INSERTED AS i);
	DECLARE @productId INT = (SELECT i.ProductId FROM INSERTED AS i);
	DECLARE @productQuantity INT = (SELECT i.ProductQuantity FROM INSERTED AS i);
	DECLARE @currPrice MONEY = (SELECT p.Price FROM Products  AS p WHERE p.id = @productId)
INSERT INTO OrdersProducts (OrderId, ProductId, ProductPrice, ProductQuantity)
VALUES(@orderId, @productId, @currPrice, @productQuantity)
GO