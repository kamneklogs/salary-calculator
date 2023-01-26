CREATE TABLE developers (
	dev_id serial PRIMARY KEY,
	dev_name VARCHAR ( 100 ) NOT NULL,
	dev_type VARCHAR ( 50 ) NOT NULL,
	worked_hours INTEGER NOT NULL,
	salary_by_hour DECIMAL (12,2) NOT NULL
);