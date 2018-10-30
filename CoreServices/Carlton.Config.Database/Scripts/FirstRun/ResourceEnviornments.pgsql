-- Table: "Resources"."ResourceEnvironments"

-- DROP TABLE "Resources"."ResourceEnvironments";

CREATE TABLE "Resources"."ResourceEnvironments"
(
    "ResourceEnvironmentId" integer NOT NULL,
    "ResourceEnvironmentName" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ResourceEnvironment_pkey" PRIMARY KEY ("ResourceEnvironmentId")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Resources"."ResourceEnvironments"
    OWNER to carlton;