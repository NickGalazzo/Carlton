-- Table: "Resources"."Resources"

-- DROP TABLE "Resources"."Resources";

CREATE TABLE "Resources"."Resources"
(
    "ResourceId" SERIAL NOT NULL,
    "Url" text COLLATE pg_catalog."default" NOT NULL,
    "IpAddress" text COLLATE pg_catalog."default" NOT NULL,
    "ResourceStatusId" integer NOT NULL,
    "ResourceEnvironmentId" integer NOT NULL,
    "ResourceTypeId" integer NOT NULL,
    CONSTRAINT "Resources_pkey" PRIMARY KEY ("ResourceId"),
    CONSTRAINT "Resources_ResourceEnvironmentId_fkey" FOREIGN KEY ("ResourceEnvironmentId")
        REFERENCES "Resources"."ResourceEnvironments" ("ResourceEnvironmentId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Resources_ResourceStatusId_fkey" FOREIGN KEY ("ResourceStatusId")
        REFERENCES "Resources"."ResourceStatueses" ("ResourceStatusId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "Resources_ResourceTypeId_fkey" FOREIGN KEY ("ResourceTypeId")
        REFERENCES "Resources"."ResourceTypes" ("ResourceTypeId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Resources"."Resources"
    OWNER to carlton;