CREATE OR REPLACE FUNCTION manage_area(
    action CHAR(1), -- 'A' для добавления, 'E' для редактирования, 'D' для удаления
    area_id INT,
    area_number INT,
    area_name VARCHAR(255)
) RETURNS VOID AS $$
BEGIN
    IF action = 'A' THEN
        INSERT INTO Area (area_number, area_name) VALUES (area_number, area_name);
    ELSIF action = 'E' THEN
        UPDATE Area SET area_number = area_number, area_name = area_name WHERE id = area_id;
    ELSIF action = 'D' THEN
        DELETE FROM Area WHERE id = area_id;
    END IF;
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION manage_equipment(
    action CHAR(1), 
    equipment_type VARCHAR(255), 
    equipment_name VARCHAR(255), 
    area_id INT)
RETURNS VOID AS $$
BEGIN
    IF action = 'A' THEN
        INSERT INTO Equipment (equipment_type, equipment_name, area_id) VALUES (equipment_type, equipment_name, area_id);
    ELSIF action = 'E' THEN
        UPDATE Equipment SET equipment_type = equipment_type, equipment_name = equipment_name, area_id = area_id WHERE id = equipment_id;
    ELSIF action = 'D' THEN
        DELETE FROM Equipment WHERE id = equipment_id;
    END IF;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION manage_failure_revision(
    action CHAR(1),
    revision_id INT,
    revision_date DATE,
    fail_reason VARCHAR(255),
    equipment_id INT
) RETURNS VOID AS $$
BEGIN
    IF action = 'A' THEN
        -- Добавление новой записи в Failure_revision
        INSERT INTO Failure_revision (id, revision_date, fail_reason, equipment_id)
        VALUES (revision_id, revision_date, fail_reason, equipment_id);
    ELSIF action = 'E' THEN
        -- Редактирование существующей записи в Failure_revision
        UPDATE Failure_revision
        SET revision_date = revision_date, fail_reason = fail_reason, equipment_id = equipment_id
        WHERE id = revision_id;
    ELSIF action = 'D' THEN
        -- Удаление записи из Failure_revision
        DELETE FROM Failure_revision WHERE id = revision_id;
        DELETE FROM Revisionable WHERE id = revision_id;
    END IF;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION manage_plan_revision(
    action CHAR(1),
    revision_id INT,
    revision_date DATE,
    revision_result BOOLEAN,
    fail_reason VARCHAR(255),
    equipment_id INT
) RETURNS VOID AS $$
BEGIN
    IF action = 'A' THEN
        -- Добавление новой записи в Plan_revision
        INSERT INTO Plan_revision (id, revision_date, revision_result, fail_reason, equipment_id)
        VALUES (revision_id, revision_date, revision_result, fail_reason, equipment_id);
    ELSIF action = 'E' THEN
        -- Редактирование существующей записи в Plan_revision
        UPDATE Plan_revision
        SET revision_date = revision_date, revision_result = revision_result, fail_reason = fail_reason, equipment_id = equipment_id
        WHERE id = revision_id;
    ELSIF action = 'D' THEN
        -- Удаление записи из Plan_revision
        DELETE FROM Plan_revision WHERE id = revision_id;
        -- Удаление записи из Revisionable, если существует
        DELETE FROM Revisionable WHERE id = revision_id;
    END IF;
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION manage_employee(
    action CHAR(1), 
    employee_id INT, 
    employee_table_num INT, 
    employee_fullname VARCHAR(255), 
    employee_position VARCHAR(255)
    ) RETURNS VOID AS $$
BEGIN
    IF action = 'A' THEN
        INSERT INTO Employee (employee_table_num, employee_fullname, employee_position) VALUES (employee_table_num, employee_fullname, employee_position);
    ELSIF action = 'E' THEN
        UPDATE Employee SET employee_table_num = employee_table_num, employee_fullname = employee_fullname, employee_position = employee_position WHERE id = employee_id;
    ELSIF action = 'D' THEN
        DELETE FROM Employee WHERE id = employee_id;
    END IF;
END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE VIEW view_failed_equipment AS
SELECT
    fr.revision_date AS failure_date,
    e.equipment_name,
    e.equipment_type,
    a.area_name,
    fr.fail_reason
FROM
    Failure_revision fr
INNER JOIN Equipment e ON fr.equipment_id = e.id
INNER JOIN Area a ON e.area_id = a.id
UNION ALL
SELECT
    pr.revision_date AS failure_date,
    e.equipment_name,
    e.equipment_type,
    a.area_name,
    pr.fail_reason
FROM
    Plan_revision pr
INNER JOIN Equipment e ON pr.equipment_id = e.id
INNER JOIN Area a ON e.area_id = a.id
WHERE pr.revision_result = FALSE;

CREATE OR REPLACE VIEW view_equipment_inspection_history AS
SELECT
    e.id,
    pr.revision_date AS inspection_date,
    e.equipment_name,
    e.equipment_type,
    pr.revision_result AS inspection_result,
    pr.fail_reason
FROM
    Plan_revision pr
INNER JOIN Equipment e ON pr.equipment_id = e.id;

CREATE OR REPLACE VIEW view_technical_department_employees AS
SELECT
    e.employee_fullname,
    e.employee_position,
    pr.revision_date
FROM
    Employee e
INNER JOIN Revisionable_employee re ON e.id = re.employee_id
INNER JOIN Plan_revision pr ON re.revision_id = pr.id
UNION ALL
SELECT
    e.employee_fullname,
    e.employee_position,
    fr.revision_date
FROM
    Employee e
INNER JOIN Revisionable_employee re ON e.id = re.employee_id
INNER JOIN Failure_revision fr ON re.revision_id = fr.id;

CREATE OR REPLACE FUNCTION view_failed_equipment()
RETURNS TABLE (
    failure_date DATE,
    equipment_name VARCHAR(255),
    equipment_type VARCHAR(255),
    area_name VARCHAR(255),
    fail_reason VARCHAR(255)
) AS $$
BEGIN
    RETURN QUERY
    SELECT * FROM view_failed_equipment;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION view_technical_department_employees(requested_date DATE)
RETURNS TABLE (
    employee_fullname VARCHAR(255),
    employee_position VARCHAR(255),
    revision_date DATE
) AS $$
BEGIN
    RETURN QUERY
    SELECT 
         vtde.employee_fullname,
         vtde.employee_position,
         vtde.revision_date
    FROM view_technical_department_employees vtde
	WHERE vtde.revision_date = requested_date;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION view_equipment_inspection_history(inventory_number INT)
RETURNS TABLE (
    id INT,
    inspection_date DATE,
    equipment_name VARCHAR(255),
    equipment_type VARCHAR(255),
    inspection_result BOOLEAN,
    fail_reason VARCHAR(255)
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        veih.id,
        veih.inspection_date,
        veih.equipment_name,
        veih.equipment_type,
        veih.inspection_result,
        veih.fail_reason
    FROM view_equipment_inspection_history veih
	WHERE veih.id = inventory_number;
END;
$$ LANGUAGE plpgsql;
