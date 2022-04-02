USE Restaurant;

INSERT INTO Roles (RoleType)
VALUES 
	('Administrator'),
	('Bartender'), 
	('Waiter')

INSERT INTO Users (FirstName, LastName, Email, [Role])
VALUES
	('Gancho', 'Ganchev', 'g.ganchev@dbmail.com', 1), 
	('Georgi', 'Georgiev', 'geo.georgiev@dbmail.com', 2), 
	('Doncho', 'Donchev', 'd.donchev@dbmail.com', 3), 
	('Tzenko', 'Tzenkov', 'tz.tzenkov@dbmail.com', 3)

INSERT INTO [Tables] (Capacity)
VALUES
	(8),
	(6), 
	(4), 
	(2),
	(2),
	(2)

INSERT INTO ProductCategories ([Name])
VALUES
	('Food'),
	('Beverage') 

INSERT INTO CategoryTypes ([MainCategory], [Name])
VALUES
	(1,'Meat'),
	(1,'Salad'),
	(1,'Dessert'),
	(2,'Alcohol'),
	(2,'Soft drink')

INSERT INTO Products ([Name], Category, [Type], ImagePath, Price)
VALUES
--meat
	('Veal', 1, 1, NULL, 20),
	('Pork', 1, 1, NULL, 18), 
	('Chicken', 1, 1, 'https://www.simplyrecipes.com/recipes/buttermilk_fried_chicken/', 15), 
--salads	
	('Spinach', 1, 2, NULL, 2), 
	('Cucumber', 1, 2, NULL, 2), 
	('Tomato', 1, 2, 'https://www.walmart.ca/en/ip/carrot-jumbo/6000197107011', 2), 
--desserts	
	('Cake', 1, 3, NULL, 8),
	('Pancake', 1, 3, NULL, 5),
--alcohol
	('Whisky', 2, 4, NULL, 12),
	('Beer', 2, 4, NULL, 3),
	('Wine', 2, 4, null, 8),
--soft drinks
	('Coke', 2, 5, NULL, 2),
	('Orange juice', 2, 5, 'https://unsplash.com/s/photos/orange-juice', 3)

INSERT INTO OrderStatuses ([Name])
   VALUES
	  ('In Progress'),
	  ('Completed'),
	  ('Cancelled')

INSERT INTO Orders (Waiter, [Table], [Status], CreateDate, CreatedBy, EndDate, UpdatedBy)
VALUES
	(3, 1, 1, '2022-02-07 13:23:00', 3, NULL, NULL), --chicken & beer
----------------------------
	(3, 2, 2, '2022-02-07 13:30:00', 3,'2022-02-07 13:35:00', 3), --coke, orange juice
	(3, 2, 2, '2022-02-07 14:00:00', 3,'2022-02-07 14:10:00', 3), --cake, pancake
----------------------------
	(4, 3, 2, '2022-02-07 17:30:00', 4,'2022-02-07 17:35:00', 4), --cucumber salad
	(4, 4, 2, '2022-02-07 17:30:00', 4,'2022-02-07 17:35:00', 4)  --pork & wine
	

INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (1, 3, 8)   --chicken * 8
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (1, 10, 8)  --beer * 8
----------------------------
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (2, 12, 1)  --coke * 1
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (2, 13, 3)  --orange juice * 3
-----------------------------
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (3, 7, 2)   --cake * 2
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (3, 8, 2)   --pancake * 2
------------------------------
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (4, 5, 3)   --cucumber salad * 3
-------------------------------
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (5, 2, 2)   --pork * 2
INSERT INTO OrdersProducts (OrderId, ProductId, ProductQuantity) VALUES (5, 11, 2)   --wine * 2
