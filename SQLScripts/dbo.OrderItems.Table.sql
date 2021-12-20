CREATE TABLE [OrderItems]
(
[OrderItemId] INT IDENTITY(1, 1) NOT NULL,
[OrderId] INT NOT NULL,
[ComponentId] INT NOT NULL,
[Quantity] INT NOT NULL,

CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED([OrderItemId] ASC),
CONSTRAINT [FK_OrderItems_Orders] FOREIGN KEY([OrderId]) REFERENCES [Orders]([OrderId]) ON DELETE CASCADE,
CONSTRAINT [FK_OrderItems_Components] FOREIGN KEY([ComponentId]) REFERENCES [Components]([ComponentId]) ON DELETE CASCADE,
);