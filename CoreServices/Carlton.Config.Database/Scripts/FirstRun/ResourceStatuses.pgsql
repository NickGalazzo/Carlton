-- Table: "Resources"."ResourceStatueses"

-- DROP TABLE "Resources"."ResourceStatueses";

CREATE TABLE "Resources"."ResourceStatueses"
(
    "ResourceStatusId" integer NOT NULL,
    "ResourceStatusName" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ResourceStatueses_pkey" PRIMARY KEY ("ResourceStatusId")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Resources"."ResourceStatueses"
    OWNER to carlton;