CREATE DATABASE Logare;
USE Logare;

CREATE TABLE Logare(
  user_id int AUTO_INCREMENT,
  username varchar(200) NOT NULL,
  password varchar(200) not NULL,
  PRIMARY KEY (user_id)
);



INSERT INTO Logare VALUES(1,'caramaneliza','liza123');
