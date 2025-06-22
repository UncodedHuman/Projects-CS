-- SQLite
-- triggers

CREATE TRIGGER if not exists teacherInsOnAspIns
after insert on AspNetUsers
for EACH ROW
when new.IsAdmin = 0
BEGIN
    insert into teachers(id, name)
    values (new.Id, new.FullName);

END;


CREATE TRIGGER if not exists teacherDelOnAspDel
after delete on AspNetUsers
for each ROW
BEGIN
    delete from teachers
    where id = old.Id;
END;


create trigger if not exists teacherUpdOnAspUpd
after update on AspNetUsers
for each ROW
BEGIN
    update teachers
    set name = new.FullName
    where id = new.Id;
END;
