CREATE TABLE
  fornecedor (
    id_for INT NOT NULL AUTO_INCREMENT,
    nome_for VARCHAR(255) NOT NULL,
    PRIMARY KEY (id_for)
  );

CREATE TABLE
  produto (
    id_pro INT NOT NULL AUTO_INCREMENT,
    id_for_fk INT NULL,
    nome_pro VARCHAR(255) NOT NULL,
    descricao_pro TEXT NULL,
    quantidade_pro INT NOT NULL,
    preco_pro DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id_pro),
    FOREIGN KEY (id_for_fk) REFERENCES fornecedor (id_for)
  );
  
CREATE TABLE cliente (
   
    id_cliente INT PRIMARY KEY AUTO_INCREMENT, 
    nome VARCHAR(255) NOT NULL,
    data_nascimento DATE,
    sexo VARCHAR(10), 
    telefone VARCHAR(20),
    email VARCHAR(100) UNIQUE, 

    -- Campos do Endereço (embutidos na tabela Cliente, conforme o DAO)
    rua VARCHAR(255),
    numero INT,
    bairro VARCHAR(100),
    cep VARCHAR(10),
    cidade VARCHAR(100),
    estado VARCHAR(2) 
);
 -- inserindo Cliente
INSERT INTO cliente (
    nome, 
    data_nascimento, 
    sexo, 
    telefone, 
    email, 
    rua, 
    numero, 
    bairro, 
    cep, 
    cidade, 
    estado
) 
VALUES 
(
    'Maria da Silva', 
    '1995-10-25', 
    'F', 
    '(11) 98765-4321', 
    'maria.silva@email.com', 
    'Rua das Flores', 
    123, 
    'Jardim América', 
    '01234-567', 
    'São Paulo', 
    'SP'
),
(
    'João Santos', 
    '1988-03-15', 
    'M', 
    '(21) 99887-7665', 
    'joao.santos@email.com', 
    'Avenida Principal', 
    500, 
    'Copacabana', 
    '20000-000', 
    'Rio de Janeiro', 
    'RJ'
);

-- Inserindo fornecedores
INSERT INTO
  fornecedor (nome_for)
VALUES
  ('Fornecedor Alpha'),
  ('Fornecedor Beta'),
  ('Fornecedor Gamma'),
  ('Fornecedor Delta');

-- Inserindo produtos vinculados aos fornecedores
INSERT INTO
  produto (
    id_for_fk,
    nome_pro,
    descricao_pro,
    quantidade_pro,
    preco_pro
  )
VALUES
  (
    1,
    'Notebook X',
    'Notebook de alto desempenho com 16GB RAM e SSD 512GB',
    10,
    4500.00
  ),
  (
    1,
    'Mouse Óptico',
    'Mouse com fio, 1200 DPI',
    50,
    45.90
  ),
  (
    2,
    'Smartphone Y',
    'Smartphone 6.5 polegadas, 128GB',
    20,
    2100.00
  ),
  (
    2,
    'Carregador Rápido',
    'Carregador USB-C 25W',
    100,
    89.90
  ),
  (
    3,
    'Cadeira Gamer',
    'Cadeira ergonômica ajustável',
    15,
    1250.00
  ),
  (
    3,
    'Mesa de Escritório',
    'Mesa em L com suporte para monitor',
    8,
    980.00
  ),
  (
    4,
    'Monitor 27"',
    'Monitor LED Full HD 27 polegadas',
    12,
    1150.00
  ),
  (
    4,
    'Teclado Mecânico',
    'Teclado RGB switch blue',
    30,
    350.00
  );
