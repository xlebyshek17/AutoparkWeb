create Database AutoPark;

use AutoPark;

create table VehicleTypes (
	Id int not null identity(1,1) CONSTRAINT typesID_pk primary key(Id),
	TypeName varchar(50) not null, 
	TaxCoefficient decimal(10,2)  not null
);

create table Vehicles (
	Id int not null identity(1,1) CONSTRAINT vehiclesID_pk primary key(Id),
	TypeId int not null, 
	ModelName nvarchar(50) not null,
	RegistrationNumber nvarchar(50) not null,
	Weight decimal(10,2) not null,
	ManufactureYear int not null,
	Mileage decimal(10,2) not null,
	TankVolume decimal(10,2) not null,
	Color nvarchar(50) not null,
	Engine nvarchar(50) not null,
	FOREIGN KEY(TypeId) REFERENCES VehicleTypes(Id) ON DELETE CASCADE
);

create table Orders (
	Id int not null identity(1,1) CONSTRAINT ordersID_pk primary key(Id),
	VehicleId int not null,
	FOREIGN KEY(VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
);

create table SpareParts (
	Id int not null identity(1,1) CONSTRAINT SparePartsID_pk primary key(Id),
	Name nvarchar(50) not  null
);

create table OrderItems (
	Id int not null identity(1,1) CONSTRAINT orderItemsID_pk primary key(Id),
	OrderId int not null,
	DetailId int not null,
	DetailCount int not null,
	FOREIGN KEY(OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
	FOREIGN KEY(DetailId) REFERENCES SpareParts(Id) ON DELETE CASCADE
);