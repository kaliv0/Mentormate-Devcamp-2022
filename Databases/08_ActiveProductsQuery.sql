/* Products list - select all active products (paginated) */
USE Restaurant

UPDATE Products
SET IsDeleted = 1
WHERE [Name] = 'Whisky' OR [Name] = 'Spinach';

SELECT * FROM Products
WHERE IsDeleted = 0
ORDER BY [Name]
	OFFSET 0 ROWS
	FETCH NEXT 10 ROWS ONLY

SELECT * FROM Products
WHERE IsDeleted = 0
ORDER BY [Name]
	OFFSET 10 ROWS
	FETCH NEXT 10 ROWS ONLY