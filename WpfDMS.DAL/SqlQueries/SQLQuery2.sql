USE DMS;

CREATE TABLE Laboratory
(
lab_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
lab_name VARCHAR(35) NOT NULL,
lab_adress VARCHAR(50) NOT NULL,
lab_phone VARCHAR(50) NOT NULL,
lab_timings VARCHAR(50) NOT NULL,
lab_tests VARCHAR(50) NOT NULL
)

CREATE TABLE Patient
(
p_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
p_name VARCHAR(30) NOT NULL,
p_age INT NOT NULL,
p_gender VARCHAR(10) NOT NULL,
p_adress VARCHAR(40) NOT NULL,
p_phone VARCHAR(20) NOT NULL,
p_login VARCHAR(10) NOT NULL,
p_password VARCHAR(10) NOT NULL
)

CREATE TABLE Doctor
(
d_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
d_name VARCHAR(30) NOT NULL,
d_age INT NOT NULL,
d_gender VARCHAR(10) NOT NULL,
d_adress VARCHAR(40) NOT NULL,
d_phone VARCHAR(20) NOT NULL,
d_login VARCHAR(10) NOT NULL,
d_password VARCHAR(10) NOT NULL
)

CREATE TABLE Bill
(
b_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
b_test_charge VARCHAR(30),
b_delivery_charges VARCHAR(50)
)

CREATE TABLE Test
(
t_id INT PRIMARY KEY NOT NULL IDENTITY(1,1),
t_name VARCHAR(20),
t_price INT NOT NULL,
t_lab_id INT NOT NULL
)