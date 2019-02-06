insert into Statuses(StatusCode, StatusName) values 
( 1, 'Success'),
( 2, 'Failed'),
( 3, 'Canceled' );

insert into Currencies(CurrencyCode, CurrencyName) values
(1, 'USD'),
(2, 'JPY'),
(3, 'THB'),
(4, 'SGD');

insert into Customers(CustomerName, CustomerContactEmail, CustomerMobileNumer) values 
('John', 'john.doe@test.com', '123456789');

insert into Transactions(TransactionDate, TransactionAmount, StatusID, CurrencyID, CustomerID) values 
(GETDATE(), 200, IDENT_CURRENT('Statuses'), IDENT_CURRENT('Currencies'), IDENT_CURRENT('Customers'));

