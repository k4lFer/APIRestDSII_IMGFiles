CREATE DATABASE dbCrudGallery;
use dbCrudGallery;

create table tgallery
(
idGallery char(36) not null,
imageValue varchar(max) not null,
name varchar(700) not null,
description varchar(max) not null,
extension varchar(7) not null,
primary key(idGallery)
);
--IFormFile
select * from tgallery
delete from tgallery