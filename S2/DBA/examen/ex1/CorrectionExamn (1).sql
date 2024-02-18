Q1:
create tablespace TBL_APP_COM  datafile
		'C:\oraclexe\oradata\xe\fd01tbl_app.dbf' size 10M Autoextend on next 2M,
        'C:\oraclexe\oradata\xe\fd02tbl_app.dbf' size 10M;
Q2:
create temporary tablespace TEMP_APP_COM  tempfile
 'C:\oraclexe\oradata\XE\ftemp_app.dbf' size 20M;

Q3:
create profile A_C_PROFILE limit
	connect_time 480
	idle_time 60
	password_life_time 30
	sessios_per_user 2
	failed_login_attempts 3
	password_lock_time 7;

Q4:
create role A_C_ROLE;
	grant create session to A_C_ROLE with admin option;
	grant select, insert on HR.EMPLOYEES to A_C_ROLE;
	grant RESOURCE to A_C_ROLE;

Q5:
A/  create user A_C_MANAGER identified by a_c_manager
    default tablespace TBL_APP_COM
    temporary tablespace TEMP_APP_COM
    profile A_C_PROFILE;
    grant A_C_ROLE to A_C_MANAGER;

 B/  create user A_C_USER identified by a_c_user 
         default tablespace TBL_APP_COM
    temporary tablespace TEMP_APP_COM
    profile A_C_PROFILE;
    grant A_C_ROLE to A_C_USER;

 Q6:
 A/ Load data infile 'C:\datafile.dat'
    badfile 'C:\badfile.bad'
    discardfile 'C:\discfile.dsc'
    fields terminated by ';'
    append
    into table client
    when (01:02) = '11' 
    (CLIENT_ID int,
     CLIENT_NAME varchar(3),
     ADRESSE_CL varchar (3),
     CREATECL_DATE date
     )
    into table commande
    when (01:02)='22'
    (NUM_COMMANDE int,
     CLIENT_ID int,
     CREATECD_DATE date
     )


 B/ sqlldr A_C_MANAGER/a_c_manager, control=c:\datafile.ctl, log= c:\logfile.log

Q7:
 create or replace directory User_Oracle as 'C:\oraclexe\app\oracle' ; 

Q8:
grant EXP_FULL_DATABASE, IMP_FULL_DATABASE on User_Oracle to A_C_MANAGER, A_C_USER;
grant read, write on User_Oracle to A_C_MANAGER, A_C_USER;

Q9:
expdp A_C_MANAGER/a_c_manager directory=User_Oracle dumpfile=expclient.dmp logfile=logclient.log tables=A_C_MANAGER.CLIENT
impdp A_C_USER/a_c_user directory=User_Oracle dumpfile=expclient.dmp logfile=logimpClient.log tables=A_C_MANAGER.CLIENT

Q10:
a) show parameter Audit_trail;
   alter system set Audit_trail='DB_EXTENDED' scope=spfile;
  startup force
b) audit connect whenever Successful;
c) audit select, insert, update, delete on A_C_MANAGER.CLIENT By session;
d) select * from DBA_AUDIT_TRAIL;
e) NOAUDIT select on A_C_MANAGER;
f) sel   A/S
   upd   -/-
