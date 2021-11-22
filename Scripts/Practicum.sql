use Practicum

-- 1.1	Написать скрипт, который генерирует схему БД согласно рисунку.

create table [dbo].[Genres]
(
	[Id] int identity (1, 1) not null,
	[GenreName]  nvarchar(20) not null,
	constraint [PK_Genres] primary key clustered([Id] asc)
)

create table [dbo].[Authors]
(
	[Id] int identity (1, 1) not null,
	[FirstName] nvarchar(20) not null,
	[LastName] nvarchar(20) not null,
	[MiddleName] nvarchar(20),
	constraint [PK_Authors] primary key clustered([Id] asc)
)

create table [dbo].[Books]
(
	[Id] int identity (1, 1) not null,
	[Title]  nvarchar(50) not null,
	[AuthorId] int not null,
	constraint [PK_Books] primary key clustered([Id] asc),
	constraint [FK_Authors_AuthorId] foreign key ([AuthorId]) references Authors ([Id]) on delete cascade
)

create table [dbo].[Persons]
(
	[Id] int identity (1, 1) not null,
	[BirthDate] date not null,
	[FirstName] nvarchar(20) not null,
	[LastName] nvarchar(20) not null,
	[MiddleName] nvarchar(20),
	constraint [PK_Persons] primary key clustered([Id] asc)
)

create table [dbo].[BookGenre]
(
	[BooksId] int not null,
	[GenresId] int not null,
	constraint [PK_BookGenre] primary key clustered([BooksId] ASC, [GenresId] ASC),
	constraint [FK_BookGenre_BooksId] foreign key([BooksId]) references [dbo].[Books] ([Id]) on delete cascade,
	constraint [FK_BookGenre_GenresId] foreign key([GenresId]) references [dbo].[Genres] ([Id]) on delete cascade,
)

create table [dbo].[LibraryCards]
(
	[Id] int identity (1, 1) not null,
	[BooksId] int not null,
	[PersonsId] int not null,
	constraint [FK_LibraryCards_BooksId] foreign key([BooksId]) references Books(Id) on delete cascade,
	constraint [FK_LibraryCards_PersonsId] foreign key([PersonsId]) references Persons(Id) on delete cascade,
	constraint [PK_LibraryCards] primary key clustered([Id] asc)
)

-- 1.2	Написать скрипт, который добавляет в БД тестовые данные

INSERT INTO [dbo].[Genres] (GenreName) 
VALUES
('Роман'),
('Поэзия'),
('Рассказ'),
('Повесть')

INSERT INTO [dbo].[Authors] (LastName, FirstName, MiddleName) 
VALUES
('Тургенев','Иван','Сергеевич'),
('Лермонтов','Михаил','Юрьевич'),
('Саббатини','Рафаэль', null),
('Лондон', 'Джек', null),
('Калугин','Алексей','Александрович')

INSERT INTO [dbo].[Books] (Title, AuthorId) 
VALUES
('Постоялый двор',1),
('Затишье', 1),
('Одисея капитана Блада', 3),
('Собрание сочинений', 2),
('Великий кудесник',4),
('Пустые земли',5)

insert into [dbo].[Persons] (LastName,FirstName,MiddleName,BirthDate)
values
('Шпак','Виктория','Юрьевна','1992-02-15'),
('Иванов','Кирилл','Борисович','1989-11-10'),
('Лопатин','Дмитрий','Валерьевич','1993-06-24')

insert into [dbo].[BookGenre]
values
(1,4),
(4,1),
(4,3),
(1,1),
(1,3),
(2,1),
(3,2),
(5,3),
(5,4),
(6,1)

insert into [dbo].[LibraryCards]
values
(1,1),
(1,3),
(2,3),
(2,1),
(2,2),
(5,3),
(6,3)

-- 3.	Добавить sql скрипты с запросами
-- 3.1	Получить список всех взятых пользователем книг в качестве параметра поиска - ID пользователя. Полное дерево: Книги - автор - жанр (через запятую)

select b.Title,aut.LastName,aut.FirstName,aut.MiddleName,STRING_AGG(g.GenreName, ',') as Genres from Books as b 
join LibraryCards as lc on b.Id = lc.BooksId
join Authors as aut on aut.Id=b.AuthorId
join BookGenre as bg on bg.BooksId=b.Id
join Genres as g on g.Id=bg.GenresId
where lc.PersonsId=3
group by b.Title,aut.LastName,aut.FirstName,aut.MiddleName


-- 3.2	Получить список книг автора (книг может и не быть). автор + книги + жанры  (через запятую)

select b.Title,aut.LastName,aut.FirstName,aut.MiddleName,STRING_AGG(g.GenreName, ',') as Genres from Books as b 
join Authors as aut on aut.Id=b.AuthorId
join BookGenre as bg on bg.BooksId=b.Id
join Genres as g on g.Id=bg.GenresId
where aut.Id=1
group by b.title,aut.LastName,aut.FirstName,aut.MiddleName



-- 3.3	Вывод статистики Жанр - количество книг

select distinct g.GenreName, count(BookGenre.BooksId) as Books_count from BookGenre
left join Genres as g on g.Id=GenresId
group by g.GenreName



-- 3.4	Вывод статистики Авторов - количество книг по жанрам 

select concat(a.LastName,' ',a.FirstName) as Authors_name, g.GenreName,count(b.Id) as Books_count from BookGenre
left join Genres as g on g.Id=GenresId
left join Books as b on b.Id=BooksId
left join Authors as a on a.Id=b.AuthorId
group by g.GenreName,concat(a.LastName,' ',a.FirstName)

-- 4.1	Добавить  в схему дату получения книги для выявления должников

alter table [dbo].[LibraryCards]
add ReceiptDate DATETIME2 

update LibraryCards
set ReceiptDate = '2021-11-10 12:45'
where Id=1

update LibraryCards
set ReceiptDate = '2021-10-10 12:45'
where Id=2

update LibraryCards
set ReceiptDate = '2021-10-28 12:45'
where Id=3

update LibraryCards
set ReceiptDate = '2021-11-14 12:45'
where Id=4

update LibraryCards
set ReceiptDate = '2021-09-12 12:45'
where Id=5

update LibraryCards
set ReceiptDate = '2021-09-17 12:45'
where Id=6

update LibraryCards
set ReceiptDate = '2021-08-25 12:45'
where Id=7

ALTER TABLE [dbo].[LibraryCards]
ALTER COLUMN ReceiptDate DATETIME not null 

ALTER TABLE [dbo].[LibraryCards] ADD CONSTRAINT DF_ReceiptDate DEFAULT GETDATE() FOR ReceiptDate

-- 4.2	Получить всех должников (Пользователь, книга, время просрочки сдачи в днях) 

declare @current_date DATETIME
set @current_date = getdate()

select concat(p.LastName,' ',p.FirstName,' ',p.MiddleName) as Persons,
	b.Title,DATEDIFF(day, ReceiptDate, @current_date) from LibraryCards
join Books as b on b.Id = BooksId
join Persons as p on p.Id = PersonsId
where DATEDIFF(day, ReceiptDate, @current_date) > 14


-- 4.3	Получить всех должников, у которых более 3 просроченных книг (пользователь, кол-во книг)

select concat(p.LastName,' ',p.FirstName,' ',p.MiddleName) as Persons,
	count(BooksId) as Books_count from LibraryCards
join Persons as p on p.Id = PersonsId
where DATEDIFF(day, ReceiptDate, getdate()) > 14
group by concat(p.LastName,' ',p.FirstName,' ',p.MiddleName)
having count(BooksId) > 3


-- 4.4	Получить статистику по должникам (пользователь, количество просроченных книг, их суммарная по дням просрочка)

select concat(p.LastName,' ',p.FirstName,' ',p.MiddleName) as Persons,
	count(BooksId) as Books_count, 
	sum(DATEDIFF(day, ReceiptDate, getdate()) - 14) as total_arrears_days from LibraryCards
join Persons as p on p.Id = PersonsId
where DATEDIFF(day, ReceiptDate, getdate()) > 14
group by concat(p.LastName,' ',p.FirstName,' ',p.MiddleName)
having count(BooksId)>0



-- reset

--drop table LibraryCards
--drop table BookGenre
--drop table Books
--drop table Genres
--drop table Persons
--drop table Authors


