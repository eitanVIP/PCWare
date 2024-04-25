CREATE TABLE CPUTBL (
    Name VARCHAR(100),
    Price DECIMAL(10, 2),
    Socket VARCHAR(20),
    Gen INT,
    Clockspeed FLOAT,
    Cores INT,
    TDP INT,
    PerformanceMark DECIMAL(10, 2),
    Value DECIMAL(10, 2)
);

INSERT INTO CPUTBL (Name, Price, Socket, Gen, Clockspeed, Cores, TDP, PerformanceMark, Value)
VALUES 
('Intel Core i9-12900K', 649.99, 'LGA 1700', 12, 3.2, 16, 125, 19000, 29.24),
('Intel Core i9-11900K', 539.99, 'LGA 1200', 11, 3.5, 8, 125, 15000, 27.78),
('Intel Core i7-12700K', 419.99, 'LGA 1700', 12, 3.6, 12, 125, 15000, 35.72),
('Intel Core i7-11700K', 399.99, 'LGA 1200', 11, 3.6, 8, 125, 14000, 35.00),
('Intel Core i5-12600K', 319.99, 'LGA 1700', 12, 3.7, 10, 125, 13000, 40.63),
('Intel Core i5-11600K', 269.99, 'LGA 1200', 11, 3.9, 6, 125, 12000, 44.45),
('Intel Core i3-12100', 149.99, 'LGA 1700', 12, 3.4, 4, 65, 9000, 60.01),
('Intel Core i3-10100', 139.99, 'LGA 1200', 10, 3.6, 4, 65, 8000, 57.15),
('Intel Core i9-11980HK', 649.99, 'BGA 1781', 11, 2.6, 8, 45, 16000, 24.62),
('Intel Core i9-10900K', 499.99, 'LGA 1200', 10, 3.7, 10, 125, 13000, 26.00),
('Intel Core i7-10700K', 399.99, 'LGA 1200', 10, 3.8, 8, 125, 12000, 30.00),
('Intel Core i5-10600K', 269.99, 'LGA 1200', 10, 4.1, 6, 125, 10000, 37.04),
('Intel Core i3-10320', 159.99, 'LGA 1200', 10, 3.8, 4, 65, 7000, 43.76),
('Intel Core i9-10980HK', 549.99, 'BGA 2598', 10, 2.4, 8, 45, 15000, 27.28),
('Intel Core i7-10875H', 429.99, 'BGA 1440', 10, 2.3, 8, 45, 14000, 32.56),
('Intel Core i5-10300H', 279.99, 'BGA 1440', 10, 2.5, 4, 45, 10000, 35.72),
('Intel Core i3-1005G1', 199.99, 'BGA 1526', 10, 1.2, 2, 15, 5000, 25.00),
('Intel Core i9-9980HK', 599.99, 'BGA 1440', 9, 2.4, 8, 45, 13000, 21.67),
('Intel Core i7-9750H', 399.99, 'BGA 1440', 9, 2.6, 6, 45, 11000, 27.50),
('Intel Core i5-9400F', 189.99, 'LGA 1151', 9, 2.9, 6, 65, 8000, 42.11);
