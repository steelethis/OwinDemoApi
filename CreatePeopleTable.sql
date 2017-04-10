-- This is a SQL script for creating the people table used in the demo APIs.
-- This table was created using SQLite, but it can be easily converted to work with any other database.
CREATE TABLE `people` 
( 
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
	`Name` TEXT NOT NULL, 
	`Address` TEXT NOT NULL, 
	`Email` TEXT NOT NULL 
)