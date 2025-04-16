create database School_API;

use School_API;

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

create table StudentsGroups (
  Id int primary key identity(100, 1),
  StudentId int,
  GroupId int,
  PeriodId int,

  foreign key (StudentId) references Students(Id),
  foreign key (GroupId) references Groups(Id),
  foreign key (PeriodId) references Periods(Id)
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

CREATE TABLE GroupSubjects (
  Id int primary key identity(100, 1),
  SubjectId int,
  GradesId int,
  StudentGroupId int,
  TeacherId int,

  foreign key (SubjectId) references Subjects(Id),
  foreign key (GradesId) references Grades(Id),
  foreign key (StudentGroupId) references StudentsGroups(Id),
  foreign key (TeacherId) references Teacher(Id)
);





















-- statics

go
insert into Careers(Name) values ('Ciencias Computacionales');
insert into Careers(Name) values ('Arquitectura');
insert into Careers(Name) values ('Ingenier�a Civil');
insert into Careers(Name) values ('Ingenier�a Industrial');
insert into Careers(Name) values ('F�sica y Tecnolog�a Avanzada');


insert into dbo.Semesters(Name) values ('1� semestre');
insert into dbo.Semesters(Name) values ('2� semestre');
insert into dbo.Semesters(Name) values ('3� semestre');
insert into dbo.Semesters(Name) values ('4� semestre');
insert into dbo.Semesters(Name) values ('5� semestre');
insert into dbo.Semesters(Name) values ('6� semestre');
insert into dbo.Semesters(Name) values ('7� semestre');
insert into dbo.Semesters(Name) values ('8� semestre');
insert into dbo.Semesters(Name) values ('9� semestre');
insert into dbo.Semesters(Name) values ('10� semestre');
go