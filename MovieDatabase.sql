
CREATE DATABASE MovieDatabase;
GO


USE MovieDatabase;
GO


--creating table
--users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY, 
    Username NVARCHAR(50) NOT NULL UNIQUE,  
    Password NVARCHAR(50) NOT NULL,        
    IsAdmin BIT NOT NULL DEFAULT 0         
);

--movie
CREATE TABLE Movies (
    MovieID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Genre NVARCHAR(50),
    Year INT,
    Rating INT,
    Synopsis NVARCHAR(MAX),
    Category NVARCHAR(50),
    UserID INT,  -- links to the Users table
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

--populate
--user
INSERT INTO Users (Username, Password, IsAdmin)
VALUES ('user', 'user', 1),
       ('mark', 'password', 0);

--movies
INSERT INTO Movies (Title, Genre, Year, Rating, Synopsis, Category, UserID)
VALUES 
('Inception', 'Sci-Fi', 2010, 9, 'Mind-bending thriller', 'Top Picks', 1),
('Titanic', 'Romance', 1997, 8, 'Epic love story', 'Favorites', 2);




