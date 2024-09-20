select 'Alter database' + ' ' + Name + ' '+'SET single_user with rollback immediate;' + char(13)+char(10)
+ 'Drop database' + ' ' + name  + char(13)+char(10)
from sys.databases where name Not in  ( 'master','msdb','tempdb','model','distribution')

Alter database dbPizzaDelicia SET single_user with rollback immediate;  Drop database dbPizzaDelicia  
Alter database dbCrudMVC SET single_user with rollback immediate;  Drop database dbCrudMVC  
Alter database dbExemploEFBrotas SET single_user with rollback immediate;  Drop database dbExemploEFBrotas  
Alter database dbProjetoDespesasReceitas SET single_user with rollback immediate;  Drop database dbProjetoDespesasReceitas  
Alter database dbExemploLogin SET single_user with rollback immediate;  Drop database dbExemploLogin  
Alter database dbAcaiBrotas SET single_user with rollback immediate;  Drop database dbAcaiBrotas  
Alter database dbProjetoAcaiBrotas SET single_user with rollback immediate;  Drop database dbProjetoAcaiBrotas  
Alter database dbVozesUnidas2 SET single_user with rollback immediate;  Drop database dbVozesUnidas2  
Alter database dbAppTarefas SET single_user with rollback immediate;  Drop database dbAppTarefas  
Alter database dbAppTarefas2 SET single_user with rollback immediate;  Drop database dbAppTarefas2  
Alter database dbAppTarefas3 SET single_user with rollback immediate;  Drop database dbAppTarefas3  
Alter database dbDino SET single_user with rollback immediate;  Drop database dbDino  
Alter database teste SET single_user with rollback immediate;  Drop database teste  
Alter database dbPokemon SET single_user with rollback immediate;  Drop database dbPokemon  
Alter database dbCampeonato SET single_user with rollback immediate;  Drop database dbCampeonato  
Alter database dbEmpresas SET single_user with rollback immediate;  Drop database dbEmpresas  
Alter database Concessionaria SET single_user with rollback immediate;  Drop database Concessionaria  
Alter database atv2 SET single_user with rollback immediate;  Drop database atv2  
Alter database dbAtividade02 SET single_user with rollback immediate;  Drop database dbAtividade02  
Alter database dbAtv02 SET single_user with rollback immediate;  Drop database dbAtv02  
Alter database dbAtv002 SET single_user with rollback immediate;  Drop database dbAtv002  
Alter database senaiPlay SET single_user with rollback immediate;  Drop database senaiPlay  
Alter database imobiliaria SET single_user with rollback immediate;  Drop database imobiliaria  
Alter database dbLivros SET single_user with rollback immediate;  Drop database dbLivros  
Alter database dbCinema SET single_user with rollback immediate;  Drop database dbCinema  
Alter database empresaSenai SET single_user with rollback immediate;  Drop database empresaSenai  
Alter database dbApiSenai SET single_user with rollback immediate;  Drop database dbApiSenai  
Alter database dbApiLoja SET single_user with rollback immediate;  Drop database dbApiLoja  
Alter database dbApiSenai2 SET single_user with rollback immediate;  Drop database dbApiSenai2  
Alter database DbSistemaTarefas SET single_user with rollback immediate;  Drop database DbSistemaTarefas  
Alter database dbSistemaBibliotecario SET single_user with rollback immediate;  Drop database dbSistemaBibliotecario  