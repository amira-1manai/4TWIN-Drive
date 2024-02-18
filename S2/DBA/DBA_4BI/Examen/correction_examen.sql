PArtie1
1.
create user usr_ex1 identified by usr_ex1;

create user usr_ex2 identified by usr_ex2;

2.
create tablespace usr_tbl datafile 'f1.dbf' size 5m, 'f2.dbf' size 10m autoextend on next 1m maxsize 20m;
alter user usr_ex1 default tablespace usr_tbl quota unlimited on usr_tbl temporary tablespace temp;
alter user usr_ex2 default tablespace usr_tbl quota unlimited on usr_tbl temporary tablespace temp;

3.
create profile p1 limit
failed_login_attempts 1
password_lock_time 5*24*60
sessions_per_user 3
idle_time 60


alter user usr_ex1 profile p1;
alter user usr_ex1 profile p1;

grant create session, create table, grant any privilege to usr_ex1, usr_ex2;
grant dba to usr_ex1, usr_ex2;

create or replace function PWD_VERIF(login varchar2, passe varchar2) return boolean is
val boolean;

begin
val:=false;
if substr(passe,1,1)=upper(substr(passe,1,1)) then 
val:=true;
end if;
return val;
end;

alter profile p1 limit
password_verify_function PWD_VERIF;


4

create or replace procedure PS_TBL_LOCAL is 

cursor cur is select tablespace_name from dba_tablespaces where extent_management='LOCAL';

begin

for rec in cur loop
dbms_output.put_line(rec.tablespace_name);
end loop;
end;


PARTIE2
1.
Audit connect by usr_ex1 whenever not successful;
audit create table by usr_ex1 by access;
audit create table by usr_ex1 by access;

2.
Audit connect by usr_ex2 whenever successful;
audit insert table, delete table by usr_ex2 by session;
3.
conn usr_ex1/usr_ex1

CREATE TABLE books (    title VARCHAR2(30),   price NUMBER,  nb_pages  NUMBER  );

4.
fich.ctl

5.
expdp usr_ex1/usr_ex1 directory=dpdir dumpfile=usr_ex1.dmp

6.
impdp usr_ex1/usr_ex1 directory=dpdir dumpfile=usr_ex1.dmp tables=books content=metadata_only remap_schema=usr_ex1:usr_ex2

7.
create or replace procedure PS_STR_USR2 is

cursor cur is select ins, upd, sel, del from dba_obj_audit_opts where owner='USR_EX2';

begin

for rec in cur loop
dbms_output.put_line(rec.ins||rec.upd||rec.del);
end loop;
end;

8.
create or replace procedure PS_OBJ_USR2 is

cursor cur is select action_name from dba_audit_trail where username='USR_EX2';

begin

for rec in cur loop
dbms_output.put_line(rec.action_name);
end loop;
end;
/









