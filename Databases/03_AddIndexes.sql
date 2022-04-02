USE Restaurant

CREATE INDEX idx_productName
ON Products ([Name])

CREATE INDEX idx_productPrice
ON OrdersProducts (ProductPrice)

CREATE INDEX idx_orderCreateDate
ON Orders (CreateDate)

CREATE INDEX idx_orderEndDate
ON Orders (EndDate)