-- Database Creation
CREATE DATABASE AB_SQLAdvanceDB

USE AB_SQLAdvanceDB

CREATE TABLE Authors
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50),
	Surname NVARCHAR(50)
)

CREATE TABLE Books
(
	Id INT IDENTITY PRIMARY KEY,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id),
	Name NVARCHAR(100) NOT NULL CONSTRAINT CHK_Name CHECK (LEN(Name) >= 2),
	PageCount INT NOT NULL CONSTRAINT CHK_PageCount CHECK (PageCount >= 10)
)

-- Data
INSERT INTO Authors
VALUES 
('George', 'Orwell'),
('Ashlee', 'Vance'),
('Anna', 'Crowley Redding'),
('Grigori', 'Petrov'),
('Edwin', 'Lefevre'),
('Jack', 'Schwager'),
('Morgan', 'Housel')

INSERT INTO Books (AuthorId, Name, PageCount)
VALUES 
(1, 'Animal Farm', 112),
(2, 'Elon Musk: Tesla, SpaceX, and the Quest for a Fantastic Future', 416),
(3, 'Elon Musk: A Mission to Save the World', 256),
(4, 'Finland: the country of white lilies', 180),
(5, 'Reminiscences of a Stock Operator', 288),
(5, 'Wall Street Stories', 152),
(6, 'Unknown Market Wizards: The best traders you have never heard of', 376),
(6, 'Market Wizards: Interviews with Top Traders', 481),
(7, 'The Psychology of Money', 256)

-- View
CREATE VIEW GetBooksInfo
AS
	SELECT b.*, a.Name + ' ' + a.Surname AS AuthorFullName FROM Books AS b
	JOIN Authors AS a
	ON a.Id = b.AuthorId

SELECT * FROM GetBooksInfo

-- Procedure
CREATE PROCEDURE GetBooksByBookOrAuthorName
(
	@Name NVARCHAR(100)
)
AS
BEGIN
	SELECT * FROM GetBooksInfo
	WHERE Name LIKE '%' + @Name + '%'
	OR AuthorFullName LIKE '%' + @Name + '%'
END
GO

EXEC GetBooksByBookOrAuthorName 'Musk'

-- Function
CREATE FUNCTION GetBookCountByPageCount
(
	@MinPageCount INT = 10
)
RETURNS INT
AS
BEGIN
	DECLARE @BookCount INT
	SELECT @BookCount = COUNT(*) FROM Books WHERE PageCount >= @MinPageCount
	RETURN @BookCount
END
GO

SELECT dbo.GetBookCountByPageCount(250) AS Count
SELECT dbo.GetBookCountByPageCount(DEFAULT) AS Count