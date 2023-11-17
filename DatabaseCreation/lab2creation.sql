DROP TABLE IF EXISTS Revisionable_employee CASCADE;
DROP TABLE IF EXISTS Plan_revision CASCADE;
DROP TABLE IF EXISTS Failure_revision CASCADE;
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Revisionable;
DROP TABLE IF EXISTS Equipment;
DROP TABLE IF EXISTS Area;
-- Таблица для учёта зон/участков предприятия
CREATE TABLE IF NOT EXISTS Area (
    id SERIAL PRIMARY KEY,
    area_number INT NOT NULL,
    area_name VARCHAR(255) NOT NULL
);


-- Таблица для управления общими айдишниками осмотров
CREATE TABLE IF NOT EXISTS Revisionable (
    id SERIAL PRIMARY KEY
);

-- Таблица для учёта оборудования
CREATE TABLE IF NOT EXISTS Equipment (
    id SERIAL PRIMARY KEY,
	equipment_type VARCHAR(255) NOT NULL,
    equipment_name VARCHAR(255) NOT NULL,
	area_id INT NOT NULL,
	FOREIGN KEY(area_id) REFERENCES Area(id) ON DELETE RESTRICT
);

-- Таблица для учёта сотрудников
CREATE TABLE IF NOT EXISTS Employee (
    id SERIAL PRIMARY KEY,
    employee_table_num INT UNIQUE,
    employee_fullname VARCHAR(255),
    employee_position VARCHAR(255)
);

-- Таблица для плановых осмотров
CREATE TABLE IF NOT EXISTS Plan_revision (
    id SERIAL PRIMARY KEY,
    revision_date DATE,
	revision_result BOOLEAN NOT NULL,
	fail_reason VARCHAR(255),
    equipment_id INT,
    FOREIGN KEY (equipment_id) REFERENCES Equipment(id) ON DELETE CASCADE,
	FOREIGN KEY (id) REFERENCES Revisionable(id)
);

-- Таблица для осмотров при отказе
CREATE TABLE IF NOT EXISTS Failure_revision (
    id SERIAL PRIMARY KEY,
    revision_date DATE,
	fail_reason VARCHAR(255),
    equipment_id INT,
    FOREIGN KEY (equipment_id) REFERENCES Equipment(id) ON DELETE CASCADE,
	FOREIGN KEY (id) REFERENCES Revisionable(id)
);
-- Таблица для коллективных осмотров (ассоциативная таблица)
CREATE TABLE IF NOT EXISTS Revisionable_employee (
    revision_id INT,
    employee_id INT,
    FOREIGN KEY (revision_id) REFERENCES Revisionable(id),
    FOREIGN KEY (employee_id) REFERENCES Employee(id)
);

CREATE OR REPLACE FUNCTION create_revisionable_on_plan_revision_insert()
RETURNS TRIGGER AS $$
BEGIN
  -- Проверка, существует ли запись в Revisionable с заданным id
  IF NOT EXISTS (SELECT 1 FROM Revisionable WHERE id = NEW.id) THEN
    INSERT INTO Revisionable (id) VALUES (NEW.id);
  END IF;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER create_revisionable_on_plan_revision_insert_trigger
BEFORE INSERT ON Plan_revision
FOR EACH ROW
EXECUTE FUNCTION create_revisionable_on_plan_revision_insert();

CREATE OR REPLACE FUNCTION create_revisionable_on_failure_revision_insert()
RETURNS TRIGGER AS $$
BEGIN
  -- Проверка, существует ли запись в Revisionable с заданным id
  IF NOT EXISTS (SELECT 1 FROM Revisionable WHERE id = NEW.id) THEN
    INSERT INTO Revisionable (id) VALUES (NEW.id);
  END IF;
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER create_revisionable_on_failure_revision_insert_trigger
BEFORE INSERT ON Failure_revision
FOR EACH ROW
EXECUTE FUNCTION create_revisionable_on_failure_revision_insert();

INSERT INTO Area (area_number, area_name) VALUES
    (1, 'Galvanic Section'),
    (2, 'Raw Material Processing Section'),
    (3, 'Another Section');

INSERT INTO Equipment (equipment_type, equipment_name, area_id) VALUES
    ('Gas', 'Gas Welding Machine', 1),
    ('Electric', 'Electric Press', 2),
    ('Gas', 'Gas Cutter', 1);
	
INSERT INTO Employee (employee_table_num, employee_fullname, employee_position) VALUES
    (1001, 'John Doe', 'Engineer'),
    (1002, 'Jane Smith', 'Technician'),
    (1003, 'Bob Johnson', 'Supervisor');

INSERT INTO Plan_revision (revision_date, revision_result, fail_reason, equipment_id, id)
VALUES
    ('2023-10-25', true, NULL, 1, 1),
    ('2023-10-26', true, NULL, 2, 2),
    ('2023-10-27', false, 'Mechanical failure', 3, 3);

INSERT INTO Failure_revision (revision_date, fail_reason, equipment_id, id)
VALUES
    ('2023-10-28', 'Electrical issue', 1, 4),
    ('2023-10-29', 'Mechanical failure', 2, 5),
    ('2023-10-30', 'Electrical issue', 3, 6);

INSERT INTO Revisionable_employee (revision_id, employee_id)
VALUES
    (1, 1), -- John Doe performed the first revision
    (1, 2), -- Jane Smith also performed the first revision
    (2, 2), -- Jane Smith performed the second revision
    (2, 3), -- Bob Johnson also performed the second revision
    (3, 1), -- John Doe performed the third revision
    (3, 3); -- Bob Johnson also performed the third revision