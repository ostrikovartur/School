SELECT Name FROM School
JOIN Teacher 
ON SchoolId = School.Id
Join Employee
ON FirstName = 'abccc'

SELECT Name FROM School
JOIN Director
ON SchoolId = School.Id
Join Employee
ON FirstName = 'abccc'