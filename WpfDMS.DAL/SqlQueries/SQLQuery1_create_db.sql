CREATE DATABASE DMS
ON(NAME = 'dms1',FILENAME = 'C:\Databases\DBdms\dms01.mdf', SIZE = 8MB, MAXSIZE = 100MB, FILEGROWTH = 1MB),
(NAME = 'dms2', FILENAME = 'C:\Databases\DBdms\dms02.ndf', SIZE = 8MB, MAXSIZE = 100MB, FILEGROWTH = 1MB)
LOG ON
(NAME = 'logdata', FILENAME = 'C:\Databases\DBdms\logdataDms.ldf', SIZE=8MB, MAXSIZE=100MB, FILEGROWTH=1MB)