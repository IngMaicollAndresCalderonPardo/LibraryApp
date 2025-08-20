-- Insert Users
INSERT INTO Users (Name, Email)
VALUES 
('Alice Johnson', 'alice.johnson@email.com'),
('Bob Smith', 'bob.smith@email.com'),
('Charlie Brown', 'charlie.brown@email.com'),
('Diana Miller', 'diana.miller@email.com'),
('Ethan Davis', 'ethan.davis@email.com');

-- Insert Publications
INSERT INTO Publications (Title, Content, PublishDate, UserId)
VALUES
('Getting started with SQL', 'This is an introductory guide to SQL basics.', GETDATE(), 1),
('ASP.NET MVC Tips', 'Best practices for working with controllers and views.', GETDATE(), 2),
('Entity Framework Explained', 'Understanding EF for database interactions.', GETDATE(), 3),
('Bootstrap in Web Apps', 'How to use Bootstrap for responsive design.', GETDATE(), 4),
('C# for Beginners', 'Introduction to programming with C#.', GETDATE(), 5);

