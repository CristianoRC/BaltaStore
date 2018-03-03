--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.6
-- Dumped by pg_dump version 9.6.6

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: Order; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Order" (
    id text NOT NULL,
    customerid text NOT NULL,
    createdate date NOT NULL,
    status smallint NOT NULL
);


ALTER TABLE "Order" OWNER TO postgres;

--
-- Name: address; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE address (
    id text NOT NULL,
    idcustomer text NOT NULL,
    street character varying(160) NOT NULL,
    number character varying(10) NOT NULL,
    complement character varying(40),
    city character varying(60) NOT NULL,
    state character(2) NOT NULL,
    country character(2) NOT NULL,
    zipcode character(8) NOT NULL,
    type smallint NOT NULL
);


ALTER TABLE address OWNER TO postgres;

--
-- Name: customer; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE customer (
    id text NOT NULL,
    firstname character varying(40) NOT NULL,
    lastname character varying(40) NOT NULL,
    document character(11) NOT NULL,
    email character varying(160) NOT NULL,
    phone character varying(13) NOT NULL
);


ALTER TABLE customer OWNER TO postgres;

--
-- Name: delivery; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE delivery (
    id text NOT NULL,
    orderid text NOT NULL,
    createdate date NOT NULL,
    estimatedelivery date NOT NULL,
    status smallint NOT NULL
);


ALTER TABLE delivery OWNER TO postgres;

--
-- Name: orderitem; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE orderitem (
    id text NOT NULL,
    orderid text NOT NULL,
    productid text NOT NULL,
    quantity numeric(10,2) NOT NULL,
    price money NOT NULL
);


ALTER TABLE orderitem OWNER TO postgres;

--
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE product (
    id text NOT NULL,
    title character varying(255) NOT NULL,
    description text NOT NULL,
    image character varying(1024) NOT NULL,
    price money NOT NULL,
    quantityonhand numeric(10,2) NOT NULL
);


ALTER TABLE product OWNER TO postgres;

--
-- Data for Name: Order; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Order" (id, customerid, createdate, status) FROM stdin;
\.


--
-- Data for Name: address; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY address (id, idcustomer, street, number, complement, city, state, country, zipcode, type) FROM stdin;
\.


--
-- Data for Name: customer; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY customer (id, firstname, lastname, document, email, phone) FROM stdin;
\.


--
-- Data for Name: delivery; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY delivery (id, orderid, createdate, estimatedelivery, status) FROM stdin;
\.


--
-- Data for Name: orderitem; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY orderitem (id, orderid, productid, quantity, price) FROM stdin;
\.


--
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY product (id, title, description, image, price, quantityonhand) FROM stdin;
\.


--
-- Name: customer pk_customerid; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY customer
    ADD CONSTRAINT pk_customerid PRIMARY KEY (id);


--
-- Name: delivery pk_deliveryid; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY delivery
    ADD CONSTRAINT pk_deliveryid PRIMARY KEY (id);


--
-- Name: address pk_idaddress; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY address
    ADD CONSTRAINT pk_idaddress PRIMARY KEY (id);


--
-- Name: Order pk_idorder; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Order"
    ADD CONSTRAINT pk_idorder PRIMARY KEY (id);


--
-- Name: orderitem pk_idorderitem; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY orderitem
    ADD CONSTRAINT pk_idorderitem PRIMARY KEY (id);


--
-- Name: product pk_idproduct; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product
    ADD CONSTRAINT pk_idproduct PRIMARY KEY (id);


--
-- Name: Order fk_customerid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Order"
    ADD CONSTRAINT fk_customerid FOREIGN KEY (customerid) REFERENCES customer(id);


--
-- Name: address fk_idcustomer; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY address
    ADD CONSTRAINT fk_idcustomer FOREIGN KEY (idcustomer) REFERENCES customer(id);


--
-- Name: delivery fk_order; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY delivery
    ADD CONSTRAINT fk_order FOREIGN KEY (orderid) REFERENCES "Order"(id);


--
-- Name: orderitem fk_orderid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY orderitem
    ADD CONSTRAINT fk_orderid FOREIGN KEY (orderid) REFERENCES "Order"(id);


--
-- Name: orderitem fk_productid; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY orderitem
    ADD CONSTRAINT fk_productid FOREIGN KEY (productid) REFERENCES product(id);


--
-- PostgreSQL database dump complete
--
