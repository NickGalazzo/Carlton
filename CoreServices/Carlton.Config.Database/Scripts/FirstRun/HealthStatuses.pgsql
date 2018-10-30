-- Table: "Health"."HealthStatuses"

-- DROP TABLE "Health"."HealthStatuses";

CREATE TABLE "Health"."HealthStatuses"
(
    "HealthStatusId" integer NOT NULL,
    "HealthStatusName" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "HealthStatuses_pkey" PRIMARY KEY ("HealthStatusId")
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

ALTER TABLE "Health"."HealthStatuses"
    OWNER to carlton;