﻿CREATE DATABASE webapiblog;

USE webapiblog;

CREATE TABLE Users
(
    Id uuid NOT NULL,
    Name VARCHAR(150) NOT NULL,    
    Email VARCHAR(100) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id)
);

INSERT INTO Users VALUES('4327dc6f-efda-4513-a6ce-a2caccc91b96', 'MOZART O ELEGANTE', 'mo@gmail.com', '123');
INSERT INTO Users VALUES('6020ca57-db8c-49fe-8783-26d1cbdf65bf', 'LUAR FOCA', 'luar@gmail.com', '123');
INSERT INTO Users VALUES('ee0fc58f-490d-4086-bc3e-ad78d2569dde', 'LUA LEGAL', 'lua@gmail.com', '123');

CREATE TABLE Topics
(
    Id uuid NOT NULL,
    Name VARCHAR(50) NOT NULL,
    PRIMARY KEY (Id)
);

INSERT INTO Topics VALUES('f2462ffe-5c0e-447c-9c22-8a697fafa276', 'Cultura');
INSERT INTO Topics VALUES('f6480e1f-80de-4a90-9ebf-d65e74aed60d', 'Economia');
INSERT INTO Topics VALUES('86a473ae-b87f-478c-b710-ffa5b07060a0', 'Educacao');
INSERT INTO Topics VALUES('60b173df-ce3f-4275-9349-df4068921321', 'Entretenimento');
INSERT INTO Topics VALUES('e5aa4451-38d2-4a24-9b80-84f360b795ec', 'Esporte');
INSERT INTO Topics VALUES('67dcaf8d-7863-4580-babe-c6d8b0b5dee5', 'Politica');
INSERT INTO Topics VALUES('1422cf7b-53fc-4b45-aa0a-9bf70b6fab2b', 'Saude');
INSERT INTO Topics VALUES('9b80ee97-7800-42e1-9566-5a9255e1d1dd', 'Tecnologia');
INSERT INTO Topics VALUES('d07e87e9-64d1-4c3a-b1de-627bfd5f3670', 'Tempo');

CREATE TABLE Publications
(
    Id uuid NOT NULL,
    AutorId uuid,
    Title VARCHAR(100) NOT NULL,
    Content VARCHAR(1200) NOT NULL,
    DateCreated timestamp NOT NULL,
    TopicId uuid
);

CREATE TABLE Comments
(
    Id uuid NOT NULL,
    AutorId uuid,
    Content VARCHAR(1200) NOT NULL    
);

ALTER TABLE Publications ADD FOREIGN KEY (TopicId) REFERENCES Topics (Id);
ALTER TABLE Publications ADD FOREIGN KEY (AutorId) REFERENCES Users (Id);

ALTER TABLE Comments ADD FOREIGN KEY (AutorId) REFERENCES Users (Id);

INSERT INTO Comments VALUES('bcaa7084-c5b2-4509-baa0-98b15c9d7201', '4327dc6f-efda-4513-a6ce-a2caccc91b96', 'Teste legal');

INSERT INTO Publications VALUES('6b8b218d-7fb3-49fa-a2ed-c63ab38c3aa5', '4327dc6f-efda-4513-a6ce-a2caccc91b96', 'Teste', 'Teste do teste', '2019-10-16 00:00:00', 'f6480e1f-80de-4a90-9ebf-d65e74aed60d');