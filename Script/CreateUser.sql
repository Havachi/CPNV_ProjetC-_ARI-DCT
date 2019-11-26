CREATE USER 'DBConnector'@'localhost' IDENTIFIED BY '1234';
GRANT SELECT, INSERT, DELETE  ON `arx\_db`.* TO 'DBConnector'@'localhost';