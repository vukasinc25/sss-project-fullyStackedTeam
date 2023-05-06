drop table HasIllneses
drop table HasGoals
drop table HasProps
drop table HasLanguages
drop table Appointments
drop table Coments
drop table Clients
drop table Coaches
drop table Users
drop table Languages
drop table Goals
drop table Illnesses
drop table Props

create table Languages(
	id int identity(1,1) primary key,
	Name varchar(30)
)

create table Goals(
	id int identity(1,1) primary key,
	Name varchar(30)
)

create table Illnesses(
	id int identity(1,1) primary key,
	Name varchar(30)
)

create table Props(
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
	isAdmin bit,
	constraint FK_Languages_Users
	foreign key (PrimaryLanguageId) references Languages (id)
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
	Profit float,
	IsSent bit,
	Rank float,
	UserId int,
	constraint FK_Users_Coaches
	foreign key (UserId) references Users (id)
)

create table Appointments(
    id int identity(1,1) primary key,
    CoachId int,
    ClientId int,
    TimeOfStart varchar(30),
    Duration varchar(30),
    Price float,
    Status bit not null,
    constraint FK_Coaches_Appointments
    foreign key (CoachId) references Coaches (id),
)

create table HasIllneses(
	ClientId int,
	IllnessId int,
	primary key(ClientId, IllnessId),
	constraint FK_Users_HasIllnesses
	foreign key (ClientId) references Clients (id),
	constraint FK_Illnesses_HasIllnesses
	foreign key (IllnessId) references Illnesses (id),
)

create table HasGoals(
	ClientId int,
	GoalId int,
	primary key(ClientId, GoalId),
	constraint FK_Users_HasGoals
	foreign key (ClientId) references Clients (id),
	constraint FK_Goals_HasGoals
	foreign key (GoalId) references Goals (id),
)

create table HasProps(
	ClientId int,
	PropId int,
	primary key(ClientId, PropId),
	constraint FK_Clients_HasProps
	foreign key (ClientId) references Clients (id),
	constraint FK_Props_HasProps
	foreign key (PropId) references Props (id),
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

create table Coments(
	Id int identity(1,1) primary key,
	Coment varchar (255),
	Rating float,
	CoachId int,
    ClientId int,
	constraint FK_Coaches_Coments
    foreign key (CoachId) references Coaches (id),
    constraint FK_Clients_Coments
    foreign key (ClientId) references Clients (id)
)
select * from Coaches
delete from Coments
