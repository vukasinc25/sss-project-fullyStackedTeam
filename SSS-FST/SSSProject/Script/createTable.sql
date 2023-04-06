﻿drop table HasIllneses
drop table HasGoals
drop table HasProps
drop table HasLanguages
drop table Appointments
drop table Clients
drop table Coaches
drop table Comments
drop table Users
drop table Languages

create table Languages(
	id int identity(1,1) primary key,
	Name varchar(30)
)

create table Users(
	id int identity(1,1) primary key,
	FirstName varchar(50),
	LastName varchar(50),
	Email varchar(50) unique,
	Password varchar(50),
	Tel varchar(30),
	CreditCard varchar(30),
	Street varchar(50),
	City varchar(30),
	Country varchar(30),
	PrimaryLanguageId int,
	constraint FK_Languages_Users
	foreign key (PrimaryLanguageId) references Languages (id)
)

create table Comments(
	id int identity(1,1) primary key,
	Contents varchar(200),
	Rating float,
	UserId int,
	constraint FK_Users_Comments
	foreign key (UserId) references Users (id)
)

create table Clients(
	id int identity(1,1) primary key,
	Height float,
	Weight float,
	UserId int,
	constraint FK_Users_Clients
	foreign key (UserId) references Users (id)
)

create table Coaches(
	id int identity(1,1) primary key,
	DiplomaName varchar(40),
	SertificateName varchar(40),
	Title varchar(40),
	NumberSuccessfulAppointments int,
	UserId int,
	constraint FK_Users_Coaches
	foreign key (UserId) references Users (id)
)

create table Appointments(
	id int identity(1,1) primary key,
	TrainerId int,
	constraint FK_Coaches_Appointments
	foreign key (TrainerId) references Coaches (id)

)

create table HasIllneses(
	UserId int,
	IllnesId int,
	primary key(UserId, IllnesId),
	constraint FK_Users_HasIllneses
	foreign key (UserId) references Users (id),
)

create table HasGoals(
	UserId int,
	GoalId int,
	primary key(UserId, GoalId),
	constraint FK_Users_HasGoals
	foreign key (UserId) references Users (id),
)

create table HasProps(
	UserId int,
	PropId int,
	primary key(UserId, PropId),
	constraint FK_Clients_HasProps
	foreign key (UserId) references Users (id),
)

create table HasLanguages(
	UserId int,
	LangId int,
	primary key(UserId, LangId),
	constraint FK_Users_HasLanguages
	foreign key (UserId) references Users (id),
	constraint FK_Languages_HasLanguages
	foreign key (LangId) references Languages (id)
)