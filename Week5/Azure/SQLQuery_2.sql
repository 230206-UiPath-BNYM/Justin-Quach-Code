-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[cohort]', 'U') IS NOT NULL
DROP TABLE [dbo].[cohort]
GO

-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[associates]', 'U') IS NOT NULL
DROP TABLE [dbo].[associates]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[associates]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [Location] NVARCHAR(50) NOT NULL,
    [Reva_points] INT
    -- Specify more columns here
);
GO

-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[trainers]', 'U') IS NOT NULL
DROP TABLE [dbo].[trainers]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[trainers]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [Location] NVARCHAR(50) NOT NULL
    -- Specify more columns here
);
GO

-- Create the table in the specified schema
CREATE TABLE [dbo].[cohort]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [trainer_id] INT NOT NULL foreign key references trainers(Id),
    [associate_id] INT NOT NULL foreign key references associates(Id)
    -- Specify more columns here
);
GO

insert into trainers(Name, Location) VALUES
('Marielle', 'USF'),
('Richard', 'UTA');

select * from trainers 

insert into associates(name, Location, Reva_points) VALUES
('Chase', 'FL', 10),
('Gavin', 'FL', 10),
('Michael', 'FL', 10),
('Michael', 'MI', 10);

insert into cohort(trainer_id, associate_id) VALUES
(1,1),
(1,2),
(1,3),
(1,4);

select count(*) from associates group by location

insert into associates(name, location, Reva_points) VALUES
('Joanna', 'CT', 100),
('Jamal', 'AZ', 100);

select Name from associates inner join cohort on associate_id = cohort.associate_id

select * from associates
left join cohort on associates.Id = cohort.associate_id

select trainers.Name, associates.Name as 'associate'
from associates inner join cohort
on associates.Id = cohort.associate_id
right join trainers
on cohort.trainer_id = trainers.Id

-- Create a new table called '[TableName]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[graduated]', 'U') IS NOT NULL
DROP TABLE [dbo].[graduated]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[graduated]
(
    [Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- Primary Key column
    [Name] NVARCHAR(50) NOT NULL,
    [Location] NVARCHAR(50) NOT NULL,
    [Reva_points] int
    -- Specify more columns here
);
GO

insert into graduated (name, [Location], Reva_points) VALUES
('Joanna', 'CT', 100),
('Jamal', 'AZ', 100);

select location from associates
INTERSECT
select location from graduated

insert into graduated (name, [Location], Reva_points) VALUES
('Bao', 'FL', 90);