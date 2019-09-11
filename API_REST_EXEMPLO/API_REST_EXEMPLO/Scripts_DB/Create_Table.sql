USE rest_with_asp_net_udemy;

CREATE TABLE Persons (
	Id 		  INT identity primary key,
	FirstName VARCHAR(50) NULL,
	LastName  VARCHAR(50) NULL,
	Address  VARCHAR(50) NULL,
	Gender	  VARCHAR(50) NULL
)	
;