-- exercice 1
-- 1
show parameter audit_trail ;
select ISSYS_MODIFIABLE from  v$parameter where name='audit_trail';
alter system set audit_trail = 'DB' scope=spfile ;
shutdown 
startup
-- 2
create user td4 identified by td4 ;
GRANT CREATE SESSION,create table, CREATE procedure TO td4;
-- 3
AUDIT all By td7 BY access;    --LDD

AUDIT select table,delete table, insert table, update table by td4 by access ;   --LMD

AUDIT execute procedure by td4 by access ;

-- 4
alter user td4 quota unlimited on USERS QUOTA UNLIMITED ON system;
connect td4/td4
create table test (id number) ;
insert into test values(120);
update test set id=230;
delete test;
drop table test ;
-- 5
select username, timestamp ,substr(obj_name,1,15) , substr(action_name,1,15) from DBA_AUDIT_OBJECT ;



 Exercice 2:

--1
create user 41 identified by td41 quota unlimited on users QUOTA UNLIMITED ON system;
grant DBA to td41 ;

--2
truncate table aud$;
--3
AUDIT create SESSION by TD41;
Select privilege from DBA_PRIV_AUDIT_OPTS  where user_name = 'TD41';
-- 4
connect td41/td41
create table table1(a number);
create table table2(b number);
-- 5
AUDIT select ,delete , insert , update on  td41.table1 by session;-- pour faire l'audit sur la table pour un seul user on doit utiliszr FGA(audit déaillée)
AUDIT select on  td41.table2 by access ;
-- 6
select object_name,sel,ins,upd,del from dba_obj_audit_opts where owner = 'TD41';  
-- 7
connect td41/td41
select username,obj_name, action_name, ses_actions from DBA_AUDIT_TRAIL where owner = 'TD41';
/* si on trouve dans action_name 'session rec' ça veut dire
qu'on a un audit par session, si l'audit est par acces on trouve dans action_name le nom de l'action*/

/**** remarque tres importante ******
  SES_ACTIONS : Session summary (a string of 16 characters, one for each action type in the order ALTER, AUDIT, COMMENT,
                DELETE, GRANT, INDEX, INSERT, LOCK, RENAME, SELECT, UPDATE, REFERENCES, and EXECUTE. 
                Positions 14, 15, and 16 are reserved for future use. 
                The characters are: - for none, S for success, F for failure, and B for both).

**************************************/
-- 8
audit alter on default by access;
create table table3 (id number);
select  object_name,alt from dba_obj_audit_opts where owner = 'TD41';  
-- 9
noaudit select ,delete on td41.table1 ;
select object_name,sel,ins,upd,del from dba_obj_audit_opts where owner = 'TD41' and object_name='TABLE1';  



