use redball_basic_db
CREATE TABLE tblPlTrailerType
(
  TtId TINYINT NOT NULL PRIMARY KEY CLUSTERED,
  TtStId TINYINT NOT NULL CONSTRAINT FK_tblPlTrailerType_TtStId FOREIGN KEY REFERENCES tblPlServiceType (StId),
  TtLength TINYINT NOT NULL,
  TtName NVARCHAR(50) NULL,
  TtDescription NVARCHAR(255) NULL,
)
INSERT INTO tblPlTrailerType (TtId, TtStId, TtLength, TtName)
VALUES (1, 1, 48, NULL),
  (2, 1, 53, NULL),
  (3, 2, 48, NULL),
  (4, 2, 53, NULL),
  (5, 3, 45, NULL),
  (6, 3, 48, NULL),
  (7, 3, 53, NULL),
  (8, 3, 48, 'Extendable flatbed trailer')
CREATE TABLE tblPlServiceType
(
  StId TINYINT NOT NULL IDENTITY PRIMARY KEY CLUSTERED,
  StName NVARCHAR(50) NOT NULL,
)
INSERT INTO tblPlServiceType (StId, StName)
VALUES (1, 'Van'), (2, 'Refrigerated'), (3, 'Flatbed')

CREATE TABLE tblState
(
  StateCode NVARCHAR(2) NOT NULL PRIMARY KEY CLUSTERED,
  StateName NVARCHAR(50)
)
INSERT INTO tblState (StateName, StateCode)
VALUES ('Alabama', 'AL'),('Alaska', 'AK'),('Arizona', 'AZ'),('Arkansas', 'AR'),('California', 'CA'),('Colorado', 'CO'),('Connecticut', 'CT'),('Delaware', 'DE'),('Florida', 'FL'),('Georgia', 'GA'),('Hawaii', 'HI'),('Idaho', 'ID'),('Illinois', 'IL'),('Indiana', 'IN'),('Iowa', 'IA'),('Kansas', 'KS'),('Kentucky', 'KY'),('Louisiana', 'LA'),('Maine', 'ME'),('Maryland', 'MD'),('Massachusetts', 'MA'),('Michigan', 'MI'),('Minnesota', 'MN'),('Mississippi', 'MS'),('Missouri', 'MO'),('Montana', 'MT'),('Nebraska', 'NE'),('Nevada', 'NV'),('New Hampshire', 'NH'),('New Jersey', 'NJ'),('New Mexico', 'NM'),('New York', 'NY'),('North Carolina', 'NC'),('North Dakota', 'ND'),('Ohio', 'OH'),('Oklahoma', 'OK'),('Oregon', 'OR'),('Pennsylvania', 'PA'),('Rhode Island', 'RI'),('South Carolina', 'SC'),('South Dakota', 'SD'),('Tennessee', 'TN'),('Texas', 'TX'),('Utah', 'UT'),('Vermont', 'VT'),('Virginia', 'VA'),('Washington', 'WA'),('West Virginia', 'WV'),('Wisconsin', 'WI'),('Wyoming', 'WY'),('Guam', 'GU'),('Puerto Rico', 'PR'),('Virgin Islands', 'VI')
CREATE TABLE tblTNSBenchmarkRate
(
  TbrOriginStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblTNSBenchmarkRate_TbrOriginStateCode FOREIGN KEY REFERENCES tblState (StateCode),
  TbrTargetStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblTNSBenchmarkRate_TbrTargetStateCode FOREIGN KEY REFERENCES tblState (StateCode),
  TbrMinimumCharge DECIMAL(19,4) NOT NULL,
  TbrCostPerMile DECIMAL(19,4) NOT NULL,
  PRIMARY KEY (TbrOriginStateCode, TbrTargetStateCode)
)
INSERT INTO tblTNSBenchmarkRate (TbrOriginStateCode, TbrTargetStateCode, TbrMinimumCharge, TbrCostPerMile)
VALUES ('AL', 'PA', $700.00, $2.65),('AR', 'PA', $700.00, $2.23),('AZ', 'PA', $700.00, $2.52),('CA', 'PA', $700.00, $2.06),('CO', 'PA', $700.00, $1.61),('CT', 'PA', $700.00, $2.16),('DC', 'PA', $700.00, $9.00),('DE', 'PA', $700.00, $8.00),('FL', 'PA', $700.00, $1.80),('GA', 'PA', $700.00, $2.25),('IA', 'PA', $700.00, $2.71),('ID', 'PA', $700.00, $2.06),('IL', 'PA', $700.00, $2.93),('IN', 'PA', $700.00, $3.07),('KS', 'PA', $700.00, $2.47),('KY', 'PA', $700.00, $2.81),('LA', 'PA', $700.00, $2.01),('MA', 'PA', $700.00, $1.80),('MD', 'PA', $800.00, $10.00,),('ME', 'PA', $700.00, $2.00),('MI', 'PA', $700.00, $3.15),('MN', 'PA', $700.00, $2.65),('MO', 'PA', $700.00, $2.88),('MS', 'PA', $700.00, $2.62),('MT', 'PA', $700.00, $2.37),('NC', 'PA', $700.00, $2.66),('ND', 'PA', $700.00, $2.85),('NE', 'PA', $700.00, $2.52),('NH', 'PA', $700.00, $2.12),('NJ', 'PA', $700.00, $4.00),('NM', 'PA', $700.00, $1.98),('NV', 'PA', $700.00, $1.97),('NY', 'PA', $700.00, $2.98),('OH', 'PA', $700.00, $3.31),('OK', 'PA', $700.00, $2.08),('OR', 'PA', $700.00, $2.18),('PA', 'PA', $700.00, $5.00),('RI', 'PA', $700.00, $2.16),('SC', 'PA', $700.00, $2.50),('SD', 'PA', $700.00, $2.58),('TN', 'PA', $700.00, $2.80),('TX', 'PA', $700.00, $1.86),('UT', 'PA', $700.00, $1.91),('VA', 'PA', $700.00, $3.20),('VT', 'PA', $700.00, $2.07),('WA', 'PA', $700.00, $1.82),('WI', 'PA', $700.00, $2.81),('WV', 'PA', $700.00, $3.72),('WY', 'PA', $700.00, $1.87)

CREATE TABLE tblShipper
(
  ShipperId INT NOT NULL IDENTITY PRIMARY KEY CLUSTERED,
  ShipperName NVARCHAR(50) NOT NULL
)
INSERT INTO tblShipper (ShipperName)
VALUES ('Ollie''s Bargain Outlet')

CREATE TABLE tblShipperRateOverride
(
  SroCarrierId INT NOT NULL
    CONSTRAINT FK_tblShipperRateOverride_SroShipperId FOREIGN KEY REFERENCES tblShipper (ShipperId),
  SroOriginStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblShipperRateOverride_SroOriginStateCode FOREIGN KEY REFERENCES tblState (StateCode),
  SroTargetStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblShipperRateOverride_SroTargetStateCode FOREIGN KEY REFERENCES tblState (StateCode),
  SroCostPerMilePercentageAdjustment FLOAT NOT NULL,
  PRIMARY KEY (SroCarrierId, SroOriginStateCode, SroTargetStateCode)
)
INSERT INTO tblShipperRateOverride (SroCarrierId, SroOriginStateCode, SroTargetStateCode, SroCostPerMilePercentageAdjustment)
VALUES (1, 'MA', 'PA', -0.05)

CREATE TABLE tblOrigin
(
  OriginId INT NOT NULL PRIMARY KEY,
  OriginStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblOrigin_OriginStateCode FOREIGN KEY REFERENCES tblState (StateCode)
)

CREATE TABLE tblShipperOrigin
(
  SoShipperId INT NOT NULL,
  SoOriginId INT NOT NULL
    CONSTRAINT FK_tblShipperOrigin_SoOriginId FOREIGN KEY REFERENCES tblOrigin (OriginId)
)

CREATE TABLE tblAddress
(
  AddressId INT NOT NULL PRIMARY KEY,
  AddressStateCode NVARCHAR(2) NOT NULL
    CONSTRAINT FK_tblAddress_AddressStateCode FOREIGN KEY REFERENCES tblState (StateCode),
  AddressCity NVARCHAR(50) NULL,
  AddressStreet NVARCHAR(MAX) NULL
)

CREATE TABLE tblShipment
(
  ShipmentId INT NOT NULL PRIMARY KEY CLUSTERED,
  ShipmentAddressId INT NOT NULL
    CONSTRAINT FK_tblShipment_ShipmentAddressId FOREIGN KEY REFERENCES tblAddress (AddressId),
  ShipmentShipperId INT NOT NULL
    CONSTRAINT FK_tblShipment_ShipmentShipperId FOREIGN KEY REFERENCES tblShipper (ShipperId),
  ShipmentOriginId INT NOT NULL
    CONSTRAINT FK_tblShipment_ShipmentOriginId FOREIGN KEY REFERENCES tblOrigin (OriginId),
  ShipmentPerMileActual DECIMAL(19,4) NOT NULL,
  ShipmentDate DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET())
)
