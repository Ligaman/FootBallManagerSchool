PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS league_teams;
DROP TABLE IF EXISTS transfers;
DROP TABLE IF EXISTS matches;
DROP TABLE IF EXISTS players;
DROP TABLE IF EXISTS leagues;
DROP TABLE IF EXISTS clubs;

CREATE TABLE clubs (
    ClubId     INTEGER PRIMARY KEY AUTOINCREMENT,
    Name       TEXT NOT NULL UNIQUE,
    City       TEXT,
    CreatedAt  TEXT DEFAULT (datetime('now'))
);

CREATE TABLE leagues (
    LeagueId   INTEGER PRIMARY KEY AUTOINCREMENT,
    Name       TEXT NOT NULL,
    Season     TEXT NOT NULL,
    UNIQUE (Name, Season),
    CHECK (length(Season) = 9)
);

CREATE TABLE league_teams (
    LeagueId   INTEGER NOT NULL,
    ClubId     INTEGER NOT NULL,
    PRIMARY KEY (LeagueId, ClubId),
    FOREIGN KEY (LeagueId) REFERENCES leagues(LeagueId) ON DELETE CASCADE,
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT
);

CREATE TABLE players (
    PlayerId    INTEGER PRIMARY KEY AUTOINCREMENT,
    ClubId      INTEGER NOT NULL,
    FullName    TEXT NOT NULL,
    BirthDate   TEXT NOT NULL,
    Position    TEXT NOT NULL,
    ShirtNumber INTEGER,
    Status      TEXT DEFAULT 'Active',
    FOREIGN KEY (ClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT,
    CHECK (length(FullName) >= 3),
    CHECK (Position IN ('GK','DF','MF','FW')),
    CHECK (Status IN ('Active','Injured','Suspended'))
);

CREATE TABLE matches (
    MatchId      INTEGER PRIMARY KEY AUTOINCREMENT,
    LeagueId     INTEGER NOT NULL,
    MatchDate    TEXT NOT NULL,
    HomeClubId   INTEGER NOT NULL,
    AwayClubId   INTEGER NOT NULL,
    HomeGoals    INTEGER,
    AwayGoals    INTEGER,
    FOREIGN KEY (LeagueId) REFERENCES leagues(LeagueId) ON DELETE CASCADE,
    FOREIGN KEY (HomeClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT,
    FOREIGN KEY (AwayClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT,
    CHECK (HomeClubId <> AwayClubId),
    CHECK (HomeGoals IS NULL OR HomeGoals >= 0),
    CHECK (AwayGoals IS NULL OR AwayGoals >= 0)
);

CREATE TABLE transfers (
    TransferId     INTEGER PRIMARY KEY AUTOINCREMENT,
    PlayerId       INTEGER NOT NULL,
    FromClubId     INTEGER,
    ToClubId       INTEGER NOT NULL,
    TransferDate   TEXT NOT NULL,
    Fee            REAL,
    Note           TEXT,
    FOREIGN KEY (PlayerId) REFERENCES players(PlayerId) ON DELETE RESTRICT,
    FOREIGN KEY (FromClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT,
    FOREIGN KEY (ToClubId) REFERENCES clubs(ClubId) ON DELETE RESTRICT,
    CHECK (Fee IS NULL OR Fee >= 0)
);

CREATE INDEX idx_players_club ON players(ClubId);
CREATE INDEX idx_matches_league ON matches(LeagueId);
CREATE INDEX idx_matches_date ON matches(MatchDate);
CREATE INDEX idx_transfers_player ON transfers(PlayerId);
CREATE INDEX idx_transfers_fromclub ON transfers(FromClubId);
CREATE INDEX idx_transfers_toclub ON transfers(ToClubId);
CREATE INDEX idx_transfers_date ON transfers(TransferDate);