CREATE TABLE Batch (
    batch_id serial PRIMARY KEY,
    batch_number varchar(50) NOT NULL,
    batch_date date NOT NULL,
    product_type varchar(50) NOT NULL
);

CREATE TABLE Item (
    item_id serial PRIMARY KEY,
    batch_id int REFERENCES Batch(batch_id) ON DELETE CASCADE,
    serial_number varchar(50) NOT NULL
);

CREATE TABLE Operator (
    operator_id serial PRIMARY KEY,
    name varchar(100) NOT NULL,
    position varchar(50)
);

CREATE TABLE Equipment (
    equipment_id serial PRIMARY KEY,
    name varchar(100) NOT NULL,
    serial_number varchar(50)
);

CREATE TABLE InspectionResult (
    inspection_id serial PRIMARY KEY,
    item_id int REFERENCES Item(item_id) ON DELETE CASCADE,
    operator_id int REFERENCES Operator(operator_id),
    equipment_id int REFERENCES Equipment(equipment_id),
    inspection_date timestamp NOT NULL,
    parameters jsonb,
    photo_path varchar(255)
);

CREATE TABLE DefectType (
    defect_type_id serial PRIMARY KEY,
    name varchar(50) NOT NULL,
    description text
);

CREATE TABLE Defect (
    defect_id serial PRIMARY KEY,
    inspection_id int REFERENCES InspectionResult(inspection_id) ON DELETE CASCADE,
    defect_type_id int REFERENCES DefectType(defect_type_id),
    description text,
    coordinates varchar(100)
);