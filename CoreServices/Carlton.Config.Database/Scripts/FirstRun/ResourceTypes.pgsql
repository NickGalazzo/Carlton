-- Table: "Resources"."ResourceTypes"

-- DROP TABLE "Resources"."ResourceTypes";

CREATE TABLE "Resources"."ResourceTypes"
(
    "ResourceTypeId" integer NOT NULL,
    "ResourceTypeName" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ResourceTypes_pkey" PRIMARY KEY ("ResourceTypeId")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Resources"."ResourceTypes"
    OWNER to carlton;