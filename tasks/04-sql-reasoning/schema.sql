-- schema.sql  –  DDL for tasks/04‑sql‑reasoning/donations.db
-- SQLite 3.45  (FOREIGN KEY support on by default in this project)
PRAGMA foreign_keys = ON;

------------------------------------------------------------------
-- 1.  Campaigns being funded
------------------------------------------------------------------
CREATE TABLE campaign (
    id          INTEGER PRIMARY KEY,
    name        TEXT    NOT NULL,
    target_thb  INTEGER NOT NULL CHECK (target_thb > 0),
    owner_id    INTEGER,                 -- creator / organisation
    created_at  TEXT    NOT NULL         -- ISO‑8601 date string
);

------------------------------------------------------------------
-- 2.  Donors contributing to campaigns
------------------------------------------------------------------
CREATE TABLE donor (
    id       INTEGER PRIMARY KEY,
    email    TEXT NOT NULL,
    country  TEXT NOT NULL               -- ISO‑3166 English short name
);

------------------------------------------------------------------
-- 3.  Individual pledges (donations)
------------------------------------------------------------------
CREATE TABLE pledge (
    id           INTEGER PRIMARY KEY,
    donor_id     INTEGER NOT NULL,
    campaign_id  INTEGER NOT NULL,
    amount_thb   INTEGER NOT NULL,       -- amount in Thai baht
    pledged_at   TEXT    NOT NULL,       -- ISO‑8601 date string

    -- Referential integrity
    FOREIGN KEY (donor_id)    REFERENCES donor(id),
    FOREIGN KEY (campaign_id) REFERENCES campaign(id)
);
