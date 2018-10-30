-- Table: "Health"."HealthStatusResult"

-- DROP TABLE "Health"."HealthStatusResult";

CREATE TABLE "Health"."HealthStatusResult"
(
    "HealthStatusResultId" SERIAL NOT NULL,
    "ResourceId" integer NOT NULL,
    "HealthStatusId" integer NOT NULL,
    "TimeStamp" timestamp with time zone NOT NULL,
    CONSTRAINT "HealthStatusResults_pkey" PRIMARY KEY ("HealthStatusResultId"),
    CONSTRAINT "HealthStatusResult_HealthStatusId_fkey" FOREIGN KEY ("HealthStatusId")
        REFERENCES "Health"."HealthStatuses" ("HealthStatusId") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Health"."HealthStatusResult"
    OWNER to carlton;