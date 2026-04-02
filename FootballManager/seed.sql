PRAGMA foreign_keys = ON;

INSERT INTO clubs (Name, City) VALUES
('Levski Sofia', 'Sofia'),
('CSKA Sofia', 'Sofia'),
('Ludogorets', 'Razgrad'),
('Botev Plovdiv', 'Plovdiv');

INSERT INTO leagues (Name, Season) VALUES
('First League', '2025/2026'),
('Cup Tournament', '2025/2026');

INSERT INTO players (ClubId, FullName, BirthDate, Position, ShirtNumber, Status) VALUES
(1, 'Ivan Petrov', '2001-04-12', 'MF', 8, 'Active'),
(1, 'Georgi Ivanov', '1999-09-03', 'FW', 9, 'Active'),
(1, 'Nikolay Dimitrov', '2000-01-20', 'DF', 5, 'Active'),
(2, 'Dimitar Kolev', '1998-02-14', 'GK', 1, 'Active'),
(2, 'Petar Stoyanov', '2002-06-11', 'DF', 4, 'Active'),
(2, 'Hristo Georgiev', '2001-12-30', 'MF', 10, 'Injured'),
(3, 'Martin Angelov', '1997-07-07', 'FW', 11, 'Active'),
(3, 'Kiril Velikov', '2003-03-05', 'MF', 6, 'Active'),
(4, 'Stoyan Marinov', '2000-10-10', 'DF', 3, 'Active'),
(4, 'Viktor Iliev', '1999-08-22', 'FW', 7, 'Suspended');

INSERT INTO league_teams (LeagueId, ClubId) VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 1),
(2, 3);

INSERT INTO matches (LeagueId, MatchDate, HomeClubId, AwayClubId, HomeGoals, AwayGoals) VALUES
(1, '2026-02-10', 1, 2, 2, 1),
(1, '2026-02-17', 3, 4, NULL, NULL);

INSERT INTO transfers (PlayerId, FromClubId, ToClubId, TransferDate, Fee, Note) VALUES
(1, 1, 2, '2026-01-10', 50000, 'Winter transfer'),
(3, 1, 3, '2026-01-15', 75000, 'Mid-season move'),
(5, 2, 4, '2026-02-01', 25000, 'Loan-like move');