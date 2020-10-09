CREATE TYPE PRODUCT_TYPE AS ENUM ('computer', 'mobile', 'tv', 'camera'); --add goods types here
CREATE TYPE ORDER_STATUS AS ENUM ('not_sent', 'sent', 'delivered'); --something else?

CREATE TYPE SHOPPING_CART AS ( --TODO create indexes
    product_id INTEGER,
    quantity INTEGER
);

CREATE TABLE products(
    id SERIAL PRIMARY KEY,
    name VARCHAR(30) NOT NULL UNIQUE,
    price INTEGER NOT NULL,
	rating SMALLINT CHECK (1 <= rating && rating <= 10), --there is a postgres extension with 1-byte number type, switch to it later?
    reviews_number INTEGER DEFAULT 0,-- CHECK reviews_number >= -1,
	manufacturer VARCHAR(30), --make it a foreign key to a separate table if we will do filter by manufacturer
	type PRODUCT_TYPE
    --link to table with specs
);

CREATE TABLE customers(
    id SERIAL PRIMARY KEY,
    login VARCHAR(20) NOT NULL UNIQUE,--store hash instead of actual value?
    password VARCHAR(40) NOT NULL, --store hash instead of actual value?
    email TEXT NOT NULL UNIQUE,
    shopping_cart SHOPPING_CART[]
);

CREATE TABLE orders(
    id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL,
    status ORDER_STATUS NOT NULL,
    products INTEGER[] NOT NULL,
    cost INTEGER NOT NULL --will be auto evaluated on server on adding order
);

CREATE TABLE reviews( --or maybe store reviews in array in products table?
    product_id INTEGER,
    customer_id INTEGER,
    rating SMALLINT CHECK (1 <= rating && rating <= 10), --there is a postgres extension with 1-byte number type, switch to it later?
    text TEXT,
    FOREIGN KEY (product_id) REFERENCES products(id) ON DELETE CASCADE, --we don't need reviews for deleted products
    FOREIGN KEY (customer_id) REFERENCES customers(id) ON DELETE RESTRICT --we don't care if user who wrote review is deleted
);