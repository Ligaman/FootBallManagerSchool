# 📊 Етап 5: Лиги + участници (LeaguesForm)

## 🎯 1. Цели на етапа

До края на седмица 10 проектът трябва да включва модул, който:

* създава и редактира лиги/сезони (напр. „Първа лига 2025/2026“)
* показва участниците (клубовете) в избрана лига
* позволява добавяне и премахване на клубове
* гарантира валидност:

  * няма дублиране на участник
  * (препоръчително) не позволява премахване на клуб, ако има мачове

---

## 🗄️ 2. База данни

### 2.1 Таблица `leagues`

**Полета:**

* `LeagueId` (PK, AUTO)
* `Name` (NOT NULL)
* `Season` (NOT NULL)

**Ограничение:**

```sql
UNIQUE(Name, Season)
```

---

### 2.2 Таблица `league_teams`

**Many-to-Many връзка (лига ↔ клуб)**

* `LeagueId` (FK → leagues)
* `ClubId` (FK → clubs)

```sql
PRIMARY KEY (LeagueId, ClubId)
```

---

## 🖥️ 3. LeaguesForm – UI

### 3.1 Контроли

**Ляв панел:**

* `dgvLeagues` / `ListBox`

**Десен панел:**

* `dgvParticipants` / `ListBox`
* `cboAvailableClubs`

**Бутони:**

* `btnAddLeague`
* `btnEditLeague`
* `btnDeleteLeague`
* `btnAddClubToLeague`
* `btnRemoveClubFromLeague`
* `btnRefresh`

---

### 3.2 Поведение

* При избор на лига:

  * показва участниците
  * зарежда наличните клубове

* При добавяне:

  * клубът се добавя веднага
  * изчезва от available списъка

* При премахване:

  * изисква потвърждение
  * връща клуба в available списъка

---

## ⚙️ 4. Функционалности

### 4.1 CRUD за лиги

* Create → добавяне на лига
* Read → списък с лиги
* Update → редакция
* Delete → изтриване (по избор с ограничения)

**Валидации:**

* Name ≠ празно
* Season = формат `YYYY/YYYY`
* UNIQUE(Name + Season)

---

### 4.2 Управление на участници

#### ➕ Add Club

* избор на лига
* избор от `cboAvailableClubs`
* `INSERT` в `league_teams`

#### ➖ Remove Club

* избор на участник
* `DELETE` от `league_teams`

**Правила:**

* няма дублиране (PK/UNIQUE)
* (препоръчително) не се трие ако има мачове

---

## 🧱 5. Repository слой

### `LeaguesRepository.cs`

* `CreateLeague(name, season)`
* `GetAllLeagues()`
* `UpdateLeague(...)`
* `DeleteLeague(leagueId)`

### `LeagueTeamsRepository.cs`

* `AddClubToLeague(leagueId, clubId)`
* `RemoveClubFromLeague(leagueId, clubId)`
* `GetParticipants(leagueId)`
* `GetAvailableClubs(leagueId)`

✔️ Използвайте:

* параметризирани заявки
* `using` блокове

---

## 🧮 6. SQL логика

### Участници в лига

```sql
SELECT c.*
FROM league_teams lt
JOIN clubs c ON c.ClubId = lt.ClubId
WHERE lt.LeagueId = @leagueId;
```

### Налични клубове

```sql
SELECT c.*
FROM clubs c
LEFT JOIN league_teams lt 
  ON c.ClubId = lt.ClubId AND lt.LeagueId = @leagueId
WHERE lt.ClubId IS NULL;
```

---

## 📦 7. Deliverables

* ✔️ Проект (Solution / GitHub)
* ✔️ `schema.sql`
* ✔️ `seed.sql`

**Минимум данни:**

* 4 клуба
* 2 лиги
* участници

**Screenshots:**

* списък с лиги
* участници
* добавяне
* премахване
* грешка (duplicate / invalid season)

---

## 🚀 8. Очаквани резултати

### Основни

* таблици + repository
* CRUD за лиги
* показване на участници

### Разширени

* добавяне/премахване
* UI синхронизация
* валидации

---

## ✅ 9. Критерии за оценка

* ✔️ CRUD работи
* ✔️ UNIQUE(Name, Season)
* ✔️ участници се управляват коректно
* ✔️ няма дублиране
* ✔️ UI се обновява
* ✔️ параметризирани заявки
* ✔️ (за отличен) бизнес правило за мачове

---

## ⚙️ Настройка

1. Настрой `connection string` в `appsettings.json`
2. Стартирай проекта
3. Използвай LeaguesForm

---

