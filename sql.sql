CREATE TABLE incoming
(
	pk       serial PRIMARY KEY,
	pk_gs    int,
	pk_prvds int,
	price    int,
	count    int
);

ALTER TABLE incoming
	ADD CONSTRAINT ref_incoming_goods_pk_pk_gs FOREIGN KEY (goods_pk) REFERENCES goods (pk);

ALTER TABLE incoming
	ADD CONSTRAINT ref_incoming_provider_pk_provider_pk FOREIGN KEY (provider_pk) REFERENCES provider (pk);

CREATE TABLE leaving
(
	pk          serial PRIMARY KEY,
	goods_pk    int,
	consumer_pk int,
	price       int,
	count       int
);

ALTER TABLE leaving
	ADD CONSTRAINT ref_leaving_goods_pk_goods_pk FOREIGN KEY (goods_pk) REFERENCES goods (pk);

ALTER TABLE leaving
	ADD CONSTRAINT ref_leaving_consumer_pk_consumer_pk FOREIGN KEY (consumer_pk) REFERENCES consumer (pk);

INSERT INTO provider (nm)
VALUES ('Агроном');

INSERT INTO incoming (goods_pk, provider_pk, price, count)
VALUES ((SELECT pk FROM goods WHERE nm = 'Яблоки'),
		(SELECT pk FROM provider WHERE nm = 'Агроном'),
		100,
		100);

SELECT *
FROM incoming;


UPDATE provider SET pk = pk-4 WHERE pk > 3;
UPDATE incoming set provider_pk=4 WHERE provider_pk=2;


SELECT * from provider;

SELECT * from incoming;

SELECT p.nm, g.nm, count, price
FROM incoming inc
		 JOIN provider p ON inc.provider_pk = p.pk
		 JOIN goods g ON inc.goods_pk = g.pk