
PARTIE1
-- 1
create user user1 identified by pwd1;
create user user2 identified by pwd2;

-- 2
grant connect, resource, dba to user1, user2;
grant exp_full_database, imp_full_database to user1,user2;

-- 3
CONNECT user1/pwd1
create table Test1 (a1 number, b1 number); 
create table Test2 (a2 number, b2 number); 
-- 4
insert into test1 values (3,5);
insert into test1 values (4,3);
insert into test1 values (9,8);
insert into test2 values (2,10);
insert into test2 values (7,12);
insert into test2 values (15,22);
-- 5
create or replace directory oracle as 'C:\oraclexe\app\oracle';
-- 6
grant read, write on directory ORACLE to user1; 
grant read, write on directory ORACLE to user2;
-- 7
expdp user1/pwd1 directory=ORACLE dumpfile=user1.dmp logfile=imp_log.log tables=user1.test1,user1.test2
-- 8
impdp system/oracle directory=ORACLE dumpfile=user1.dmp logfile=exp_log.log tables=user1.test1 content=METADATA_ONLY remap_schema=user1:user2
-- 9
Select * from tab ; 
/* la requete affiche 
TNAME                          TABTYPE  CLUSTERID
------------------------------ ------- ----------
TEST1                          TABLE               
*/
Select * from Test1 ; 
-- aucune ligne sélectionnée, car on a juste importé la structure (metadata only)
-- 10
impdp system/oracle directory=ORACLE dumpfile=user1.dmp logfile=exp_log2.log tables=user1.test2 remap_schema=user1:user2
-- 11
Select * from tab ; 
/* la requete affiche 
TNAME                          TABTYPE  
------------------------------ ------- 
TEST2                          TABLE             
TEST1                          TABLE            
*/
Select * from Test2 ; 


PARTIE 2:
1-

LOAD DATA INFILE 'artiste.txt' 
badfile 'artiste.bad'
discardfile 'artiste.dsc'
APPEND
INTO TABLE artiste 
WHEN (1:1)="0" 
FIELDS TERMINATED BY ','
(identifiant ,
 nom ,
 prenom  ,
 pays
 )


2-


LOAD DATA 
	INFILE ‘emp.dat' 
	APPEND 
	INTO TABLE emp
   	 WHEN (05) = ‘B‘ and (16:22) = '990112' 
	( empID       POSITION (02:05), 
  	nom           POSITION(06:15), 
  	date_emb  POSITION(16:22)
	)



