CREATE TABLE City (
 Id INT,
 Name VARCHAR(150),
 CountryCode VARCHAR(10)
);
CREATE TABLE Population (
 Id INT IDENTITY(1, 1),
 CityId INT,
 Population INT
);
CREATE TABLE CarAmount (
 Id INT IDENTITY(1, 1),
 CityId INT,
 Amount INT
);
--City
INSERT INTO City(Id, Name, CountryCode) VALUES (1, 'New York', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (2, 'Los Angeles', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (3, 'Chicago', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (4, 'Coral Springs', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (5, 'Arvada', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (6, 'Ann Arbor', 'USA');
INSERT INTO City(Id, Name, CountryCode) VALUES (7, 'Toronto', 'CN');
INSERT INTO City(Id, Name, CountryCode) VALUES (8, 'Kingston', 'CN');
INSERT INTO City(Id, Name, CountryCode) VALUES (9, 'Midland', 'CN');
--Population
INSERT INTO Population(CityId, Population) VALUES (1, 8468999);
INSERT INTO Population(CityId, Population) VALUES (2, 3822238);
INSERT INTO Population(CityId, Population) VALUES (3, 2665039);
INSERT INTO Population(CityId, Population) VALUES (4, 133369);
INSERT INTO Population(CityId, Population) VALUES (5, 121581);
INSERT INTO Population(CityId, Population) VALUES (6, 119900);
INSERT INTO Population(CityId, Population) VALUES (7, 5647656);
INSERT INTO Population(CityId, Population) VALUES (8, 128000);
INSERT INTO Population(CityId, Population) VALUES (9, 26246);
INSERT INTO CarAmount(CityId, Amount) VALUES (1, 2162191);
INSERT INTO CarAmount(CityId, Amount) VALUES (2, 1223211);
INSERT INTO CarAmount(CityId, Amount) VALUES (3, 1000039);
INSERT INTO CarAmount(CityId, Amount) VALUES (4, 55369);
INSERT INTO CarAmount(CityId, Amount) VALUES (5, 35581);
INSERT INTO CarAmount(CityId, Amount) VALUES (6, 44900);
INSERT INTO CarAmount(CityId, Amount) VALUES (7, 2643616);
INSERT INTO CarAmount(CityId, Amount) VALUES (8, 99010);
INSERT INTO CarAmount(CityId, Amount) VALUES (9, 5010);

--1 Query the NAME for all American cities in the CITY table with populations larger than 130,000. The CountryCode for America is USA
select c.name as "NAME"
from city as c 
inner join population as p on c.id=p.cityId
where c.CountryCode='USA' and p.Population>130000;

--2 Query the NAME for the smallest city in Canada. The CountryCode for Canada is CN.
select top 1 c.name as "NAME"
from city as c 
inner join population as p on c.id=p.cityId
where c.CountryCode='CN'
order by p.Population asc;

--3 Find the total population of each country, including the number of cities and the total population for each country.
select c.CountryCode, count(*) as NumberOfCities, sum(p.Population) as TotalPopulation
from city as c 
inner join population as p on c.id=p.cityId
group by c.CountryCode;

--4 Retrieve the top 3 cities with the highest population in the table, along with their respective populations.
select top 3 c.name as "cityName", sum(p.Population) as TotalPopulation
from city as c 
inner join population as p on c.id=p.cityId
group by c.name
order by sum(p.Population) desc;

--5 Find the city with the highest number of cars (CarAmount) and display its name.
select top 1 c.name , ca.Amount
from city as c 
inner join CarAmount as ca on c.id=ca.cityId
order by ca.Amount desc;

--6 List the countries with more than 2 cities in the database.
select c.CountryCode, count(*) as NumberOfCities
from city as c
group by c.CountryCode
having count(*)>2;
