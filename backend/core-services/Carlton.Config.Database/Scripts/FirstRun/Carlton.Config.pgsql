--
-- PostgreSQL database dump
--

-- Dumped from database version 10.5
-- Dumped by pg_dump version 10.4

-- Started on 2018-10-31 18:49:54

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Carlton.Config";
--
-- TOC entry 2840 (class 1262 OID 24670)
-- Name: Carlton.Config; Type: DATABASE; Schema: -; Owner: -
--

CREATE DATABASE "Carlton.Config" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';


\connect "Carlton.Config"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 9 (class 2615 OID 24671)
-- Name: Health; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA "Health";


--
-- TOC entry 4 (class 2615 OID 24672)
-- Name: Resources; Type: SCHEMA; Schema: -; Owner: -
--

CREATE SCHEMA "Resources";


--
-- TOC entry 1 (class 3079 OID 12924)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2842 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: -
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_with_oids = false;

--
-- TOC entry 204 (class 1259 OID 24756)
-- Name: HealthStatusResult; Type: TABLE; Schema: Health; Owner: -
--

CREATE TABLE "Health"."HealthStatusResult" (
    "HealthStatusResultId" integer NOT NULL,
    "ResourceId" integer NOT NULL,
    "HealthStatusId" integer NOT NULL,
    "TimeStamp" timestamp with time zone NOT NULL
);


--
-- TOC entry 203 (class 1259 OID 24754)
-- Name: HealthStatusResult_HealthStatusResultId_seq; Type: SEQUENCE; Schema: Health; Owner: -
--

CREATE SEQUENCE "Health"."HealthStatusResult_HealthStatusResultId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- TOC entry 2843 (class 0 OID 0)
-- Dependencies: 203
-- Name: HealthStatusResult_HealthStatusResultId_seq; Type: SEQUENCE OWNED BY; Schema: Health; Owner: -
--

ALTER SEQUENCE "Health"."HealthStatusResult_HealthStatusResultId_seq" OWNED BY "Health"."HealthStatusResult"."HealthStatusResultId";


--
-- TOC entry 198 (class 1259 OID 24673)
-- Name: HealthStatuses; Type: TABLE; Schema: Health; Owner: -
--

CREATE TABLE "Health"."HealthStatuses" (
    "HealthStatusId" integer NOT NULL,
    "HealthStatusName" text NOT NULL
);


--
-- TOC entry 200 (class 1259 OID 24694)
-- Name: ResourceEnvironments; Type: TABLE; Schema: Resources; Owner: -
--

CREATE TABLE "Resources"."ResourceEnvironments" (
    "ResourceEnvironmentId" integer NOT NULL,
    "ResourceEnvironmentName" text NOT NULL
);


--
-- TOC entry 201 (class 1259 OID 24702)
-- Name: ResourceStatueses; Type: TABLE; Schema: Resources; Owner: -
--

CREATE TABLE "Resources"."ResourceStatueses" (
    "ResourceStatusId" integer NOT NULL,
    "ResourceStatusName" text NOT NULL
);


--
-- TOC entry 202 (class 1259 OID 24710)
-- Name: ResourceTypes; Type: TABLE; Schema: Resources; Owner: -
--

CREATE TABLE "Resources"."ResourceTypes" (
    "ResourceTypeId" integer NOT NULL,
    "ResourceTypeName" text NOT NULL
);


--
-- TOC entry 199 (class 1259 OID 24686)
-- Name: Resources; Type: TABLE; Schema: Resources; Owner: -
--

CREATE TABLE "Resources"."Resources" (
    "ResourceId" integer NOT NULL,
    "Url" text NOT NULL,
    "IpAddress" text NOT NULL,
    "ResourceStatusId" integer NOT NULL,
    "ResourceEnvironmentId" integer NOT NULL,
    "ResourceTypeId" integer NOT NULL
);


--
-- TOC entry 2697 (class 2604 OID 24759)
-- Name: HealthStatusResult HealthStatusResultId; Type: DEFAULT; Schema: Health; Owner: -
--

ALTER TABLE ONLY "Health"."HealthStatusResult" ALTER COLUMN "HealthStatusResultId" SET DEFAULT nextval('"Health"."HealthStatusResult_HealthStatusResultId_seq"'::regclass);


--
-- TOC entry 2709 (class 2606 OID 24761)
-- Name: HealthStatusResult HealthStatusResults_pkey; Type: CONSTRAINT; Schema: Health; Owner: -
--

ALTER TABLE ONLY "Health"."HealthStatusResult"
    ADD CONSTRAINT "HealthStatusResults_pkey" PRIMARY KEY ("HealthStatusResultId");


--
-- TOC entry 2699 (class 2606 OID 24677)
-- Name: HealthStatuses HealthStatuses_pkey; Type: CONSTRAINT; Schema: Health; Owner: -
--

ALTER TABLE ONLY "Health"."HealthStatuses"
    ADD CONSTRAINT "HealthStatuses_pkey" PRIMARY KEY ("HealthStatusId");


--
-- TOC entry 2703 (class 2606 OID 24701)
-- Name: ResourceEnvironments ResourceEnvironment_pkey; Type: CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."ResourceEnvironments"
    ADD CONSTRAINT "ResourceEnvironment_pkey" PRIMARY KEY ("ResourceEnvironmentId");


--
-- TOC entry 2705 (class 2606 OID 24709)
-- Name: ResourceStatueses ResourceStatueses_pkey; Type: CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."ResourceStatueses"
    ADD CONSTRAINT "ResourceStatueses_pkey" PRIMARY KEY ("ResourceStatusId");


--
-- TOC entry 2707 (class 2606 OID 24717)
-- Name: ResourceTypes ResourceTypes_pkey; Type: CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."ResourceTypes"
    ADD CONSTRAINT "ResourceTypes_pkey" PRIMARY KEY ("ResourceTypeId");


--
-- TOC entry 2701 (class 2606 OID 24693)
-- Name: Resources Resources_pkey; Type: CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."Resources"
    ADD CONSTRAINT "Resources_pkey" PRIMARY KEY ("ResourceId");


--
-- TOC entry 2713 (class 2606 OID 24762)
-- Name: HealthStatusResult HealthStatusResult_HealthStatusId_fkey; Type: FK CONSTRAINT; Schema: Health; Owner: -
--

ALTER TABLE ONLY "Health"."HealthStatusResult"
    ADD CONSTRAINT "HealthStatusResult_HealthStatusId_fkey" FOREIGN KEY ("HealthStatusId") REFERENCES "Health"."HealthStatuses"("HealthStatusId");


--
-- TOC entry 2710 (class 2606 OID 24718)
-- Name: Resources Resources_ResourceEnvironmentId_fkey; Type: FK CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."Resources"
    ADD CONSTRAINT "Resources_ResourceEnvironmentId_fkey" FOREIGN KEY ("ResourceEnvironmentId") REFERENCES "Resources"."ResourceEnvironments"("ResourceEnvironmentId");


--
-- TOC entry 2711 (class 2606 OID 24723)
-- Name: Resources Resources_ResourceStatusId_fkey; Type: FK CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."Resources"
    ADD CONSTRAINT "Resources_ResourceStatusId_fkey" FOREIGN KEY ("ResourceStatusId") REFERENCES "Resources"."ResourceStatueses"("ResourceStatusId");


--
-- TOC entry 2712 (class 2606 OID 24728)
-- Name: Resources Resources_ResourceTypeId_fkey; Type: FK CONSTRAINT; Schema: Resources; Owner: -
--

ALTER TABLE ONLY "Resources"."Resources"
    ADD CONSTRAINT "Resources_ResourceTypeId_fkey" FOREIGN KEY ("ResourceTypeId") REFERENCES "Resources"."ResourceTypes"("ResourceTypeId");


-- Completed on 2018-10-31 18:49:54

--
-- PostgreSQL database dump complete
--

