create database SchoolAPI;

use SchoolAPI;

create table Users (
  Id int primary key identity(100, 1) not null,
  Name nvarchar(255),
  SecondNames nvarchar(255),
  Email nvarchar(255),
  Enrollment nvarchar(255),
  Salt varbinary(50),
  Password varbinary(50),
  Role nvarchar(255),
  IsActive bit
);

create table Careers (
  Id int primary key identity(100, 1),
  Name nvarchar(255)
);

create table Students (
  Id int primary key identity(100, 1),
  UserId int,
  CareerId int,

  foreign key (UserId) references Users(Id),
  foreign key (CareerId) references Careers(Id)
);

CREATE TABLE Teacher (
  Id int primary key identity(100, 1),
  Title nvarchar(255),
  Speciality nvarchar(255),
  UserId int,

  foreign key (UserId) references Users(Id)
)


------


create table Groups (
  Id int primary key identity(100, 1),
  Name nvarchar(255)
);

create table Periods (
  Id int primary key identity(100, 1),
  Name nvarchar(255)
);



------


create table Subjects (
  Id int primary key identity(100, 1),
  Name nvarchar(255)
);

create table Grades (
  Id int primary key identity(100, 1),
  Unit1 decimal,
  Unit2 decimal,
  Unit3 decimal
);

create table Curriculums (
  Id int primary key identity(100, 1),
  Name nvarchar(255),
  CareerId int,

  foreign key (CareerId) references Careers(Id)
);

create table Semesters (
	Id int primary key identity(100, 1),
	Name nvarchar(255)
);


create table CurriculumSubjects (
  Id int primary key identity(100, 1),
  CurriculumId int,
  SubjectId int,
  SemesterId int,

  foreign key (CurriculumId) references Curriculums(Id),
  foreign key (SubjectId) references Subjects(Id),
  foreign key (SemesterId) references Semesters(Id)
);


----

CREATE TABLE TeacherSubjects (
	Id int primary key identity(100, 1),
	TeacherId int,
	SubjectId int,

	foreign key (TeacherId) references Teacher(Id),
	foreign key (SubjectId) references Subjects(Id)
)

CREATE TABLE GroupPeriods (
	Id int primary key identity(100, 1),
	PeriodId int,
	GroupId int,

	foreign key (PeriodId) references Periods(Id),
	foreign key(GroupId) references Groups(Id)
)

CREATE TABLE ActualPeriodSubjects(
	Id int primary key identity(100, 1),
	TeacherSubjectsId int,
	GroupPeriodsId int,

	foreign key (TeacherSubjectsId) references TeacherSubjects(Id),
	foreign key (GroupPeriodsId) references GroupPeriods(Id)
)




CREATE TABLE StudentsGroups (
  Id int primary key identity(100, 1),
  GradesId int,
  StudentId int,
  ActualPeriodSubjectsId int,

  foreign key (GradesId) references Grades(Id),
  foreign key (StudentId) references Students(Id),
  foreign key (ActualPeriodSubjectsId) references ActualPeriodSubjects(Id)
);




-- statics

go
insert into Careers(Name) values ('Ciencias Computacionales');
insert into Careers(Name) values ('Arquitectura');
insert into Careers(Name) values ('Ingeniería Civil');
insert into Careers(Name) values ('Ingeniería Industrial');
insert into Careers(Name) values ('Física y Tecnología Avanzada');


insert into dbo.Semesters(Name) values ('1º semestre');
insert into dbo.Semesters(Name) values ('2º semestre');
insert into dbo.Semesters(Name) values ('3º semestre');
insert into dbo.Semesters(Name) values ('4º semestre');
insert into dbo.Semesters(Name) values ('5º semestre');
insert into dbo.Semesters(Name) values ('6º semestre');
insert into dbo.Semesters(Name) values ('7º semestre');
insert into dbo.Semesters(Name) values ('8º semestre');
insert into dbo.Semesters(Name) values ('9º semestre');
insert into dbo.Semesters(Name) values ('10º semestre');
go