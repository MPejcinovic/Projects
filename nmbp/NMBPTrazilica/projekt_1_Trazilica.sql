CREATE TABLE movies.filmovi
(
  id serial NOT NULL,
  naziv character varying(40) NOT NULL,
  redatelj character varying(40) NOT NULL,
  radnja character varying(200),
  zanr character(20),
  vrijeme_trajanja smallint,
  datum_unosa date NOT NULL,
  vrijeme_unosa time without time zone NOT NULL,
  u_boji boolean,
  glavni_glumac character varying(50),
  naziv_ts tsvector,
  CONSTRAINT filmovi_pkey PRIMARY KEY (id)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE movies.filmovi
  OWNER TO postgres;

-- Index: movies.naziv_idx

-- DROP INDEX movies.naziv_idx;

CREATE INDEX naziv_idx
  ON movies.filmovi
  USING gin
  (naziv_ts);

-- Index: movies.naziv_trigram_idx

-- DROP INDEX movies.naziv_trigram_idx;

CREATE INDEX naziv_trigram_idx
  ON movies.filmovi
  USING gist
  (naziv COLLATE pg_catalog."default" gist_trgm_ops);
  
  
  
  
  
  CREATE TABLE movies.upiti
(
  id_upit serial NOT NULL,
  upit character(100) NOT NULL,
  datum_unosa date,
  vrijeme_unosa timestamp without time zone,
  CONSTRAINT upiti_pkey PRIMARY KEY (id_upit)
)
WITH (
  OIDS=FALSE
);
ALTER TABLE movies.upiti
  OWNER TO postgres;
GRANT ALL ON TABLE movies.upiti TO postgres;
GRANT SELECT, INSERT ON TABLE movies.upiti TO public;
