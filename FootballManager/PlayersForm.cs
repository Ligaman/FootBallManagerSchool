using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootballManager;

public partial class PlayersForm : Form
{
    private readonly PlayersRepository _repo = new();
    private int? _selectedPlayerId = null;
    private bool _isLoading = false;

    public PlayersForm()
    {
        InitializeComponent();

        dgvPlayers.ReadOnly = true;
        dgvPlayers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPlayers.MultiSelect = false;
        dgvPlayers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvPlayers.CellClick += dgvPlayers_CellClick;

        btnRefresh.Click += btnRefresh_Click;
        btnAdd.Click += btnAdd_Click;
        btnUpdate.Click += btnUpdate_Click;
        btnDelete.Click += btnDelete_Click;
        btnClear.Click += btnClear_Click;

        cboClubFilter.SelectedIndexChanged += FiltersChanged;
        cboPositionFilter.SelectedIndexChanged += FiltersChanged;
        txtSearchName.TextChanged += FiltersChanged;

        LoadLookups();
        RefreshGrid();
        ClearForm();
    }

    private void LoadLookups()
    {
        _isLoading = true;

        var clubs = _repo.GetAllClubs();

        cboClub.DataSource = clubs.Copy();
        cboClub.DisplayMember = "Name";
        cboClub.ValueMember = "ClubId";

        var clubsFilter = clubs.Copy();
        var allRow = clubsFilter.NewRow();
        allRow["ClubId"] = DBNull.Value;
        allRow["Name"] = "All";
        clubsFilter.Rows.InsertAt(allRow, 0);

        cboClubFilter.DataSource = clubsFilter;
        cboClubFilter.DisplayMember = "Name";
        cboClubFilter.ValueMember = "ClubId";

        cboPosition.Items.Clear();
        cboPosition.Items.AddRange(new[] { "GK", "DF", "MF", "FW" });

        cboPositionFilter.Items.Clear();
        cboPositionFilter.Items.AddRange(new[] { "All", "GK", "DF", "MF", "FW" });

        cboStatus.Items.Clear();
        cboStatus.Items.AddRange(new[] { "Active", "Injured", "Suspended" });

        if (cboPosition.Items.Count > 0) cboPosition.SelectedIndex = 0;
        if (cboPositionFilter.Items.Count > 0) cboPositionFilter.SelectedIndex = 0;
        if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        if (cboClub.Items.Count > 0) cboClub.SelectedIndex = 0;
        if (cboClubFilter.Items.Count > 0) cboClubFilter.SelectedIndex = 0;

        _isLoading = false;
    }

    private void RefreshGrid()
    {
        int? clubId = null;

        if (cboClubFilter.SelectedValue != null && cboClubFilter.SelectedValue != DBNull.Value)
        {
            if (int.TryParse(cboClubFilter.SelectedValue.ToString(), out int parsedClubId))
                clubId = parsedClubId;
        }

        string? position = cboPositionFilter.SelectedItem?.ToString();
        string? nameLike = txtSearchName.Text.Trim();

        dgvPlayers.DataSource = _repo.GetPlayers(clubId, position, nameLike);
    }

    private void FiltersChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        RefreshGrid();
    }

    private bool ValidateInput()
    {
        string fullName = txtFullName.Text.Trim();
        if (string.IsNullOrWhiteSpace(fullName))
        {
            MessageBox.Show("Името е задължително.");
            return false;
        }

        if (fullName.Length < 3)
        {
            MessageBox.Show("Името трябва да е поне 3 символа.");
            return false;
        }

        DateTime birthDate = dtpBirthDate.Value.Date;
        DateTime today = DateTime.Today;

        if (birthDate > today)
        {
            MessageBox.Show("Датата на раждане не може да е в бъдещето.");
            return false;
        }

        int age = today.Year - birthDate.Year;
        if (birthDate > today.AddYears(-age))
            age--;

        if (age < 10 || age > 60)
        {
            MessageBox.Show("Възрастта трябва да е между 10 и 60 години.");
            return false;
        }

        string? position = cboPosition.SelectedItem?.ToString();
        if (position != "GK" && position != "DF" && position != "MF" && position != "FW")
        {
            MessageBox.Show("Избери валидна позиция.");
            return false;
        }

        if (cboClub.SelectedValue == null)
        {
            MessageBox.Show("Избери клуб.");
            return false;
        }

        return true;
    }

    private void btnAdd_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        try
        {
            int clubId = Convert.ToInt32(cboClub.SelectedValue);
            string fullName = txtFullName.Text.Trim();
            DateTime birthDate = dtpBirthDate.Value.Date;
            string position = cboPosition.SelectedItem!.ToString()!;
            int? shirtNumber = numShirtNumber.Value > 0 ? (int)numShirtNumber.Value : null;
            string status = cboStatus.SelectedItem?.ToString() ?? "Active";

            _repo.Add(clubId, fullName, birthDate, position, shirtNumber, status);
            MessageBox.Show("Играчът е добавен успешно.");
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Add error");
        }
    }

    private void btnUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedPlayerId == null)
        {
            MessageBox.Show("Избери играч за редакция.");
            return;
        }

        if (!ValidateInput()) return;

        try
        {
            int clubId = Convert.ToInt32(cboClub.SelectedValue);
            string fullName = txtFullName.Text.Trim();
            DateTime birthDate = dtpBirthDate.Value.Date;
            string position = cboPosition.SelectedItem!.ToString()!;
            int? shirtNumber = numShirtNumber.Value > 0 ? (int)numShirtNumber.Value : null;
            string status = cboStatus.SelectedItem?.ToString() ?? "Active";

            _repo.Update(_selectedPlayerId.Value, clubId, fullName, birthDate, position, shirtNumber, status);
            MessageBox.Show("Играчът е обновен успешно.");
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Update error");
        }
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedPlayerId == null)
        {
            MessageBox.Show("Избери играч за изтриване.");
            return;
        }

        if (MessageBox.Show("Сигурни ли сте?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            _repo.Delete(_selectedPlayerId.Value);
            MessageBox.Show("Играчът е изтрит успешно.");
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete error");
        }
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearForm();
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        RefreshGrid();
    }

    private void ClearForm()
    {
        _selectedPlayerId = null;
        txtFullName.Clear();
        dtpBirthDate.Value = DateTime.Today;

        if (cboClub.Items.Count > 0) cboClub.SelectedIndex = 0;
        if (cboPosition.Items.Count > 0) cboPosition.SelectedIndex = 0;
        if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;

        numShirtNumber.Value = 0;
        dgvPlayers.ClearSelection();
    }

    private void dgvPlayers_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dgvPlayers.Rows[e.RowIndex];

        _selectedPlayerId = Convert.ToInt32(row.Cells["PlayerId"].Value);
        txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";

        if (DateTime.TryParse(row.Cells["BirthDate"].Value?.ToString(), out DateTime birthDate))
            dtpBirthDate.Value = birthDate;

        cboClub.SelectedValue = row.Cells["ClubId"].Value;

        string? position = row.Cells["Position"].Value?.ToString();
        if (!string.IsNullOrWhiteSpace(position))
            cboPosition.SelectedItem = position;

        string? status = row.Cells["Status"].Value?.ToString();
        if (!string.IsNullOrWhiteSpace(status))
            cboStatus.SelectedItem = status;

        var shirtNumberValue = row.Cells["ShirtNumber"].Value;
        if (shirtNumberValue == DBNull.Value || shirtNumberValue == null)
            numShirtNumber.Value = 0;
        else
            numShirtNumber.Value = Convert.ToDecimal(shirtNumberValue);
    }
}