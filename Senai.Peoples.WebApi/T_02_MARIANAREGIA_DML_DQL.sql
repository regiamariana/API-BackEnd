USE T_Peoples;

INSERT FUNCIONARIOS (NOME) VALUES ('CATARINA STRADA');
INSERT FUNCIONARIOS (NOME) VALUES ('TADEU VITELLI');

SELECT * FROM FUNCIONARIOS ORDER BY IDFUNCIONARIOS ASC;

SELECT IDFUNCIONARIOS, Nome FROM FUNCIONARIOS WHERE IDFUNCIONARIOS = 1;

INSERT FUNCIONARIOS (NOME) VALUES ('MARIANA GUIRADO');

UPDATE FUNCIONARIOS SET datanascimento = '12/09/1994' WHERE IDFUNCIONARIOS = 1;