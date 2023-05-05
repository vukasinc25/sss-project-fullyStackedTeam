insert into Goals (Name) values ('Gain')
insert into Goals (Name) values ('Loss')
insert into Goals (Name) values ('Misc')

insert into Languages (Name) values ('Serbian')
insert into Languages (Name) values ('English')
insert into Languages (Name) values ('Spanish')
insert into Languages (Name) values ('German')

insert into Illnesses (Name) values ('Cardiovascular Disease')
insert into Illnesses (Name) values ('Hypertension')
insert into Illnesses (Name) values ('Dysrhythmia')
insert into Illnesses (Name) values ('Heart Murmur')

insert into Props (Name) values ('5kg weights')
insert into Props (Name) values ('Treadmill')
insert into Props (Name) values ('Exercise bike')


delete from Props
select * from Goals
select * from HasGoals
select * from HasLanguages
select * from Props
select * from Languages
select * from Clients
select * from Users
select * from Coaches
select * from Illnesses
select * from HasIllneses
select * from HasProps