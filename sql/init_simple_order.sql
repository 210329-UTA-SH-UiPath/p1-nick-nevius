INSERT INTO dbo.Orders (StoreID, CustomerID, TotalPrice, TimePlaced)
VALUES (1, 1, 100.0, SYSDATETIME())

SELECT * FROM ORDERS
SELECT * FROM dbo.Crusts
SELECT * FROM dbo.Sizes
SELECT * FROM dbo.Customers

INSERT INTO dbo.Pizzas (PizzaType, CrustID, SizeID, Price, Name, OrderID)
VALUES (1, 2, 1, 90.0, 'Custom Pizza', 1)

SELECT * FROM dbo.Toppings
SELECT * FROM dbo.Pizzas

INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (1, 1, 2)

INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (1, 4, 2)


INSERT INTO dbo.Pizzas (PizzaType, CrustID, SizeID, Price, Name, OrderID)
VALUES (2, 3, 2, 90.0, 'Meat Pizza', 1)

INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (2, 1, 1)

INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (2, 4, 1)


INSERT INTO dbo.Pizzas (PizzaType, CrustID, SizeID, Price, Name, OrderID)
VALUES (3, 1, 3, 80.0, 'Vegan Pizza', 1)


INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (3, 2, 1)

INSERT INTO dbo.PizzaToppings (PizzaID, ToppingID, Amount)
VALUES (3, 3, 1)

SELECT * FROM dbo.Pizzas
SELECT * FROM dbo.PizzaToppings
SELECT * FROM dbo.Toppings