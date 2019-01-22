create database lab2;

create table if not exists todo
(
  id          serial not null
    constraint todo_pk
      primary key,
  title       text,
  description text,
  isdone      boolean
);

create unique index if not exists todo_id_uindex
  on todo (id);

