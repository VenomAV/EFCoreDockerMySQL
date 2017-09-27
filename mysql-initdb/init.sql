USE efcoredockermysql;

CREATE TABLE People (
    Id INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NULL,
    Surname VARCHAR(255) NULL
);

INSERT INTO People (Name, Surname) VALUES ('Alice', 'Cooper');
INSERT INTO People (Name, Surname) VALUES ('Bob', 'Marley');
INSERT INTO People (Name, Surname) VALUES ('Charles', 'Xavier');
