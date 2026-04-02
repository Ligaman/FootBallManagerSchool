using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace FootballManager;

public partial class LeaguesForm : Form
{
    private readonly LeaguesRepository _leaguesRepo = new();
    private readonly LeagueTeamsRepository _teamsRepo = new();

    private int? _selectedLeagueId = null;
    private int? _selectedParticipantClubId = null;

    public LeaguesForm()
    {
        InitializeComponent();

        dgvLeagues.ReadOnly = true;
        dgvLeagues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLeagues.MultiSelect = false;
        dgvLeagues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvParticipants.ReadOnly = true;
        dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvParticipants.MultiSelect = false;
        dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvLeagues.CellClick += dgvLeagues_CellClick;
        dgvParticipants.CellClick += dgvParticipants_CellClick;

        btnAddLeague.Click += btnAddLeague_Click;
        btnEditLeague.Click += btnEditLeague_Click;
        btnDeleteLeague.Click += btnDeleteLeague_Click;
        btnAddClubToLeague.Click += btnAddClubToLeague_Click;
        btnRemoveClubFromLeague.Click += btnRemoveClubFromLeague_Click;
        btnRefresh.Click += btnRefresh_Click;

        RefreshLeagues();
    }

    private void RefreshLeagues()
    {
        dgvLeagues.DataSource = _leaguesRepo.GetAllLeagues();
        dgvParticipants.DataSource = null;
        cboAvailableClubs.DataSource = null;
        _selectedLeagueId = null;
        _selectedParticipantClubId = null;
        txtLeagueName.Clear();
        txtSeason.Clear();
    }

    private void LoadLeagueDetails(int leagueId)
    {
        dgvParticipants.DataSource = _teamsRepo.GetParticipants(leagueId);

        var clubs = _teamsRepo.GetAvailableClubs(leagueId);
        cboAvailableClubs.DataSource = clubs;
        cboAvailableClubs.DisplayMember = "Name";
        cboAvailableClubs.ValueMember = "ClubId";
    }

    private bool ValidateLeagueInput()
    {
        string name = txtLeagueName.Text.Trim();
        string season = txtSeason.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Името на лигата е задължително.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(season))
        {
            MessageBox.Show("Сезонът е задължителен.");
            return false;
        }

        if (season.Length != 9 || season[4] != '/')
        {
            MessageBox.Show("Сезонът трябва да е във формат YYYY/YYYY.");
            return false;
        }

        return true;
    }

    private void dgvLeagues_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dgvLeagues.Rows[e.RowIndex];
        _selectedLeagueId = Convert.ToInt32(row.Cells["LeagueId"].Value);

        txtLeagueName.Text = row.Cells["Name"].Value?.ToString() ?? "";
        txtSeason.Text = row.Cells["Season"].Value?.ToString() ?? "";

        LoadLeagueDetails(_selectedLeagueId.Value);
    }

    private void dgvParticipants_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dgvParticipants.Rows[e.RowIndex];
        _selectedParticipantClubId = Convert.ToInt32(row.Cells["ClubId"].Value);
    }

    private void btnAddLeague_Click(object? sender, EventArgs e)
    {
        if (!ValidateLeagueInput()) return;

        try
        {
            _leaguesRepo.CreateLeague(txtLeagueName.Text.Trim(), txtSeason.Text.Trim());
            MessageBox.Show("Лигата е добавена успешно.");
            RefreshLeagues();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Add League Error");
        }
    }

    private void btnEditLeague_Click(object? sender, EventArgs e)
    {
        if (_selectedLeagueId == null)
        {
            MessageBox.Show("Избери лига.");                                                                                      
            return;
        }

        if (!ValidateLeagueInput()) return;

        try
        {
            _leaguesRepo.UpdateLeague(_selectedLeagueId.Value, txtLeagueName.Text.Trim(), txtSeason.Text.Trim());
            MessageBox.Show("Лигата е редактирана успешно.");
            RefreshLeagues();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Edit League Error");
        }
    }

    private void btnDeleteLeague_Click(object? sender, EventArgs e)
    {
        if (_selectedLeagueId == null)
        {
            MessageBox.Show("Избери лига.");
            return;
        }

        if (MessageBox.Show("Сигурни ли сте?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            _leaguesRepo.DeleteLeague(_selectedLeagueId.Value);
            MessageBox.Show("Лигата е изтрита успешно.");
            RefreshLeagues();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete League Error");
        }
    }

    private void btnAddClubToLeague_Click(object? sender, EventArgs e)
    {
        if (_selectedLeagueId == null)
        {
            MessageBox.Show("Избери лига.");
            return;
        }

        if (cboAvailableClubs.SelectedValue == null)
        {
            MessageBox.Show("Няма клуб за добавяне.");
            return;
        }

        try
        {
            int clubId = Convert.ToInt32(cboAvailableClubs.SelectedValue);
            _teamsRepo.AddClubToLeague(_selectedLeagueId.Value, clubId);
            MessageBox.Show("Клубът е добавен към лигата.");
            LoadLeagueDetails(_selectedLeagueId.Value);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Add Club Error");
        }
    }

    private void btnRemoveClubFromLeague_Click(object? sender, EventArgs e)
    {
        if (_selectedLeagueId == null)
        {
            MessageBox.Show("Избери лига.");
            return;
        }

        if (_selectedParticipantClubId == null)
        {
            MessageBox.Show("Избери участник.");
            return;
        }

        if (MessageBox.Show("Сигурни ли сте?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            _teamsRepo.RemoveClubFromLeague(_selectedLeagueId.Value, _selectedParticipantClubId.Value);
            MessageBox.Show("Клубът е премахнат от лигата.");
            LoadLeagueDetails(_selectedLeagueId.Value);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Remove Club Error");
        }
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        RefreshLeagues();
    }
}
