CREATE TYPE OS_DESKTOP AS ENUM ('Windows', 'Mac', 'Linux', 'Other', 'None');
CREATE TYPE OS_MOBILE AS ENUM ('Android', 'IOS', 'Other');

CREATE TABLE desktop(
    product_id INTEGER,
    ram SMALLINT, --in GB
    memory INTEGER,
    screen_diagonal INTEGER,
    os OS_DESKTOP,
    screen_x INTEGER,
    screen_y INTEGER,
    size_x INTEGER,
    size_y INTEGER,
    size_z INTEGER,
    battery_capacity INTEGER, -- null if no battery?
    processor VARCHAR(20),
    processor_cores SMALLINT,
    processor_clock_rate INTEGER,
    ethernet INTEGER --null if no ethernet?
);

CREATE TABLE mobile(
    product_id INTEGER,
    ram SMALLINT, --in GB
    memory INTEGER,
    screen_diagonal INTEGER,
    os OS_MOBILE,
    os_version SMALLINT, --version of android/ios
    screen_x INTEGER,
    screen_y INTEGER,
    size_x INTEGER,
    size_y INTEGER,
    size_z INTEGER,
    battery_capacity INTEGER,
    processor VARCHAR(20),
    processor_cores SMALLINT,
    processor_clock_rate INTEGER,
    camera SMALLINT,
    front_camera SMALLINT,
    optical_stabilization BOOLEAN
);
