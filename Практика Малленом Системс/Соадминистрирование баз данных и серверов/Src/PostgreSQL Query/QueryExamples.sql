-- Добавить новую партию
INSERT INTO Batch (batch_number, batch_date, product_type) VALUES ('B-2025-07-08', '2025-07-08', 'Плитка');

-- Найти все дефекты по типу
SELECT d.*, dt.name FROM Defect d
JOIN DefectType dt ON d.defect_type_id = dt.defect_type_id
WHERE dt.name = 'Трещина';

-- Получить все результаты контроля за период
SELECT * FROM InspectionResult WHERE inspection_date BETWEEN '2025-07-01' AND '2025-07-08';