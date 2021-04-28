INSERT INTO dbo.Crusts (CrustType, Name, Price)
VALUES (1, 'Cheese Stuffed Crust', 1.5)

INSERT INTO dbo.Crusts (CrustType, Name, Price)
VALUES (2, 'Deep Dish Crust', 1.5)


INSERT INTO dbo.Crusts (CrustType, Name, Price)
VALUES (3, 'Traditional Crust', 1.0)

SELECT * FROM dbo.Crusts

INSERT INTO dbo.Customers (Name)
VALUES ('Nick')

SELECT * FROM dbo.Customers

INSERT INTO dbo.Sizes (SizeType, Name, Price)
VALUES (1, 'Small Size', 3.0)

INSERT INTO dbo.Sizes (SizeType, Name, Price)
VALUES (2, 'Medium Size', 4.0)

INSERT INTO dbo.Sizes (SizeType, Name, Price)
VALUES (3, 'Large Size', 4.5)

SELECT * FROM dbo.Sizes

INSERT INTO dbo.Stores (StoreType, Name)
VALUES (1, 'New York Store #1')

INSERT INTO dbo.Stores (StoreType, Name)
VALUES (2, 'Chicago Store #1')

SELECT * FROM dbo.Stores


INSERT INTO dbo.Toppings (ToppingType, Name, Price)
VALUES (1, 'Bacon', 0.5)

INSERT INTO dbo.Toppings (ToppingType, Name, Price)
VALUES (2, 'Mushroom', 0.6)

INSERT INTO dbo.Toppings (ToppingType, Name, Price)
VALUES (3, 'Onion', 0.45)

INSERT INTO dbo.Toppings (ToppingType, Name, Price)
VALUES (4, 'Pepperoni', 0.5)


SELECT * FROM dbo.Toppings