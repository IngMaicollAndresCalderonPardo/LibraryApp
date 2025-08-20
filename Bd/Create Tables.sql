-- ============================================
-- CREATE DATABASE
-- ============================================
CREATE DATABASE LibraryDB;
GO

USE LibraryDB;
GO

-- ============================================
-- TABLE: Users
-- ============================================
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150) NOT NULL,
    Email NVARCHAR(150) NOT NULL UNIQUE
);
GO

-- ============================================
-- TABLE: Publications
-- ============================================
CREATE TABLE Publications (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    PublishDate DATETIME NOT NULL DEFAULT GETDATE(),
    UserId INT NOT NULL,
    CONSTRAINT FK_Publications_Users FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE CASCADE
);
GO

-- ============================================
-- CHECK CONSTRAINTS
-- ============================================
ALTER TABLE Publications
ADD CONSTRAINT CK_Publications_Title CHECK (LEN(LTRIM(RTRIM(Title))) > 0);

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Name CHECK (LEN(LTRIM(RTRIM(Name))) > 0);
GO
