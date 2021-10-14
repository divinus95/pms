
CREATE OR REPLACE FUNCTION public."GetActiveArrivedVisitingInfos"(
	)
    RETURNS TABLE("VisitorId" integer, "FirstName" text, "LastName" text) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT av."VisitorId", vs."FirstName", vs."LastName"
    FROM "Visiting" av
	LEFT JOIN "Visitor" vs ON av."VisitorId" = vs."VisitorId"
	WHERE av."Active" = true;
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetAllCells"(
	)
    RETURNS TABLE("CellId" integer, "CellName" text, "RenovationIssue" text, "isOccupied" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT cc."CellId", cc."CellName", cc."RenovationIssue", cc."isOccupied"
    FROM "Cell" cc
		WHERE cc."isOccupied" = false;
	
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetAllCrimeClass"(
	)
    RETURNS TABLE("PrisonerClassificationId" integer, "Classification" text) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT cc."PrisonerClassificationId", cc."Classification"
    FROM "PrisonerClassification" cc;
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetAllPrisoners"(
	)
    RETURNS TABLE("PrisonerId" integer, "FirstName" text, "OtherName" text, "LastName" text, "Active" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT pp."PrisonerId", pp."FirstName", pp."OtherName", pp."LastName", pp."Active"
    FROM "Prisoner" pp
	WHERE pp."Active" = true;
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetAllPrisonersByCrimeType"(
	"PrisonerClassId" integer)
    RETURNS TABLE("PrisonerId" integer, "FirstName" text, "LastName" text, "Gender" text, "Active" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT pp."PrisonerId", pp."FirstName",  pp."LastName", pp."Gender", pp."Active"
    FROM "Prisoner" pp
	WHERE pp."Active" = true AND  pp."PrisonerClassificationId" = "PrisonerClassId";
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetAllPrisonersByGender"(
	sex text)
    RETURNS TABLE("PrisonerId" integer, "FirstName" text, "LastName" text, "Gender" text, "Active" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT pp."PrisonerId", pp."FirstName",  pp."LastName", pp."Gender", pp."Active"
    FROM "Prisoner" pp
	WHERE pp."Active" = true AND  pp."Gender" = "sex";
END
$BODY$;




CREATE OR REPLACE FUNCTION public."GetAllPrisonersInfo"(
	)
    RETURNS TABLE("PrisonerId" integer, "FirstName" text, "OtherName" text, "LastName" text, "Offence" text, "Sentence" text, "Gender" text, "Description" text, "EmergencyContact" text, "HealthConditions" text, "DateConvicted" timestamp without time zone, "DateOfBirth" timestamp without time zone, "ExpectedJailTerm" timestamp without time zone, "DateRegistered" timestamp without time zone, "PassportURL" text, "CellId" integer, "PrisonerClassificationId" integer, "ColorOfEye" text, "Height" double precision, "Weight" double precision, "CellName" text, "Classification" text, "Active" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT pp."PrisonerId", pp."FirstName", pp."OtherName", pp."LastName", 
	pp."Offence", pp."Sentence", pp."Gender", pp."Description", pp."EmergencyContact", 
	pp."HealthConditions", pp."DateConvicted", 
	pp."DateOfBirth", pp."ExpectedJailTerm", pp."DateRegistered", pp."PassportURL", pp."CellId", 
	pp."PrisonerClassificationId", pp."ColorOfEye", pp."Height", pp."Weight", cc."CellName", pc."Classification", pp."Active"
    FROM "Prisoner" pp
	LEFT JOIN public."Cell" cc ON cc."CellId" = pp."CellId"
	LEFT JOIN public."PrisonerClassification" pc ON pc."PrisonerClassificationId" = pp."PrisonerClassificationId"
	WHERE pp."Active" = true;
END
$BODY$;


CREATE OR REPLACE FUNCTION public."GetAllVisitorsInfo"(
	)
    RETURNS TABLE("VisitorId" integer, "FirstName" text, "LastName" text, "ResidentAddress" text, "Phone" text, "Gender" text, "PrisonerId" integer, "PrisonerFirstName" text, "PrisonerLastName" text, "Active" boolean) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT vv."VisitorId", vv."FirstName",  vv."LastName", vv."ResidentAddress", vv."Phone",
	vv."Gender", vv."PrisonerId", pp."FirstName", pp."LastName", vv."Active"
    FROM "Visitor" vv
	LEFT JOIN "Prisoner" pp ON pp."PrisonerId" = vv."PrisonerId"
	WHERE vv."Active" = true;
END
$BODY$;



CREATE OR REPLACE FUNCTION public."GetArrivedVisitingInfo"(
	"visitorId" integer)
    RETURNS TABLE("VisitingId" integer, "ArrivalTime" timestamp without time zone, "VisitorId" integer) 
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    ROWS 1000
    
AS $BODY$
BEGIN
    RETURN QUERY
    SELECT av."VisitingId", av."ArrivalTime", av."VisitorId"
    FROM "Visiting" av
	WHERE av."VisitorId" = "visitorId" AND av."Active" = true;
END
$BODY$;


CREATE OR REPLACE FUNCTION public."RegisterPrisoner"(
	"pFirstName" text,
	"pOtherName" text,
	"pLastName" text,
	"pOffence" text,
	"pSentence" text,
	"pGender" text,
	"pDescription" text,
	"pEmergencyContact" text,
	"pHealthConditions" text,
	"pDateConvicted" timestamp without time zone,
	"pDateOfBirth" timestamp without time zone,
	"pExpectedJailTerm" timestamp without time zone,
	"pCellId" integer,
	"pPrisonerClassificationId" integer,
	"pPassportURL" text,
	"pHeight" double precision,
	"pWeight" double precision,
	"pColorOfEye" text,
	"pDateRegistered" timestamp without time zone,
	"pActive" boolean DEFAULT true)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    
AS $BODY$
DECLARE newId INT;
BEGIN
    INSERT INTO
        "Prisoner"("FirstName","OtherName","LastName","Offence","Sentence","Gender","Description","EmergencyContact",
				 "HealthConditions","DateConvicted","DateOfBirth","ExpectedJailTerm","CellId",
				 "PrisonerClassificationId","PassportURL", "Height", "Weight", "ColorOfEye", "DateRegistered","Active")
    VALUES ("pFirstName","pOtherName","pLastName","pOffence","pSentence","pGender","pDescription","pEmergencyContact",
				 "pHealthConditions","pDateConvicted","pDateOfBirth","pExpectedJailTerm","pCellId",
				 "pPrisonerClassificationId","pPassportURL", "pHeight","pWeight", "pColorOfEye", "pDateRegistered", "pActive")
    RETURNING "PrisonerId" INTO newId;
    IF newId IS NOT NULL THEN
        RETURN newId;
    END IF;
    RETURN -1;
END
$BODY$;



-- FUNCTION: public.RegisterVisitor(text, text, text, text, text, integer, boolean)

-- DROP FUNCTION public."RegisterVisitor"(text, text, text, text, text, integer, boolean);

CREATE OR REPLACE FUNCTION public."RegisterVisitor"(
	"vFirstName" text,
	"vLastName" text,
	"vResidentAddress" text,
	"vPhone" text,
	"vGender" text,
	"vPrisonerId" integer,
	"vActive" boolean DEFAULT true)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    
AS $BODY$
DECLARE newId INT;
BEGIN
    INSERT INTO
        "Visitor"("FirstName","LastName", "ResidentAddress", "Phone","Gender","PrisonerId", "Active")
    VALUES ("vFirstName","vLastName", "vResidentAddress", "vPhone","vGender","vPrisonerId", "vActive")
    RETURNING "VisitorId" INTO newId;
    IF newId IS NOT NULL THEN
        RETURN newId;
    END IF;
    RETURN -1;
END
$BODY$;




CREATE OR REPLACE FUNCTION public."UpdateCellStatus"(
	"pCellId" integer)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    
AS $BODY$
DECLARE existedId INT;
BEGIN
    SELECT cc."CellId" FROM public."Cell" cc WHERE cc."CellId"="pCellId" INTO existedId;
    IF existedId IS NOT NULL THEN
        UPDATE "Cell" cc
        SET
            "isOccupied"= true
          
        WHERE cc."CellId" = existedId;
        RETURN existedId;
    END IF;
    RETURN -1;
END
$BODY$;


CREATE OR REPLACE FUNCTION public."UpdateDepartureStatus"(
	"pVisitorId" integer,
	"pDepartedTime" timestamp without time zone)
    RETURNS integer
    LANGUAGE 'plpgsql'

    COST 100
    VOLATILE 
    
AS $BODY$
DECLARE existedId INT;
BEGIN
    SELECT vs."VisitorId" FROM public."Visiting" vs WHERE vs."VisitorId"="pVisitorId" INTO existedId;
    IF existedId IS NOT NULL THEN
        UPDATE "Visiting" vs
        SET
            "DepartedTime"= "pDepartedTime",
			"Active" = false
          
        WHERE vs."VisitorId" = existedId;
        RETURN existedId;
    END IF;
    RETURN -1;
END
$BODY$;

