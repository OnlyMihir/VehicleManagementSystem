# Vehicle-Management-System

### Problem Statement:
XYZ(**Company name intentionally hidden**) LLP – .NET Backend coding challenge

Task #1:
Create C# classes for a basic vehicle management system.  
The system you're about to create is designed to handle a wide range of vehicles, from cars and trucks to motorcycles. Each vehicle will be uniquely identified and will include details such as its make, model, and year of manufacture.  
Additionally, for cars, include fields for the number of doors and whether it's a convertible. Trucks should have fields for the payload capacity and whether they have four-wheel drive. Motorcycles should include fields for the engine displacement and whether they have anti-lock brakes.  
 
Task #2:
The next task in extending the vehicle management system is to implement the 'CheckOutVehicles' method. When called with a list of unique identifiers, this method queries the database and returns the associated vehicles. 
However, there are constraints on the checkout process: 
1.	The user can only check out a total of 10 vehicles. 
2.	The user can check out a maximum of 4 vehicles of each type (car, truck, motorcycle). 
Ensure that the 'CheckOutVehicles' method enforces these constraints and returns an appropriate result to the caller. 
 
Task #3:
Write unit tests to verify the functionality of the vehicle management system implemented earlier. Your unit tests should cover various scenarios, including: 
1.	Creating instances of different types of vehicles (cars, trucks, motorcycles). 
2.	Setting and retrieving properties of vehicles. 
3.	Checking out vehicles: 
a.	Ensure that the 'CheckOutVehicles' method correctly retrieves vehicles from the database based on the provided unique identifiers. 
b.	Test that the method enforces the limitation of checking out a total of 10 vehicles. 
c.	Test that the method enforces the limitation of checking out a maximum of 4 vehicles of each type (car, truck, motorcycle). 
