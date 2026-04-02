using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FootballManager;

public partial class TransfersForm : Form
{
    private readonly TransfersRepository _repo = new();
    private DataTable? _playersTable;
    private bool _isLoading = false;

    public TransfersForm()
    {
        InitializeComponent();

        dgvTransfers.ReadOnly = true;
        dgvTransfers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvTransfers.MultiSelect = false;
        dgvTransfers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        btnTransfer.Click += btnTransfer_Click;
        btnRefresh.Click += btnRefresh_Click;
        btnClear.Click += btnClear_Click;
        cboPlayer.SelectedIndexChanged += cboPlayer_SelectedIndexChanged;
        cboPlayerFilter.SelectedIndexChanged += cboPlayerFilter_SelectedIndexChanged;

        LoadLookups();
        RefreshGrid();
        ClearForm();
    }

    private void LoadLookups()
    {
        _isLoading = true;

        _playersTable = _repo.GetPlayersWithCurrentClub();

        cboPlayer.DataSource = _playersTable.Copy();
        cboPlayer.DisplayMember = "FullName";
        cboPlayer.ValueMember = "PlayerId";

        var filterPlayers = _playersTable.Copy();
        var allRow = filterPlayers.NewRow();
        allRow["PlayerId"] = 0;
        allRow["FullName"] = "All";
        allRow["ClubId"] = 0;
        allRow["ClubName"] = "";
        filterPlayers.Rows.InsertAt(allRow, 0);

        cboPlayerFilter.DataSource = filterPlayers;
        cboPlayerFilter.DisplayMember = "FullName";
        cboPlayerFilter.ValueMember = "PlayerId";

        var clubs = _repo.GetAllClubs();
        cboToClub.DataSource = clubs;
        cboToClub.DisplayMember = "Name";
        cboToClub.ValueMember = "ClubId";

        _isLoading = false;
    }

    private void RefreshGrid()
    {
        int? playerId = null;

        if (cboPlayerFilter.SelectedValue != null)
        {
            if (int.TryParse(cboPlayerFilter.SelectedValue.ToString(), out int parsed) && parsed > 0)
                playerId = parsed;
        }

        dgvTransfers.DataSource = _repo.GetTransfers(playerId);
    }

    private void cboPlayer_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_isLoading || cboPlayer.SelectedValue == null || _playersTable == null)
            return;

        if (!int.TryParse(cboPlayer.SelectedValue.ToString(), out int playerId))
            return;

        var rows = _playersTable.Select($"PlayerId = {playerId}");
        if (rows.Length > 0)
            txtFromClub.Text = rows[0]["ClubName"]?.ToString() ?? "";
    }

    private void cboPlayerFilter_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_isLoading) return;
        RefreshGrid();
    }

    private bool ValidateTransfer()
    {
        if (cboPlayer.SelectedValue == null)
        {
            MessageBox.Show("Избери играч.");
            return false;
        }

        if (cboToClub.SelectedValue == null)
        {
            MessageBox.Show("Избери нов клуб.");
            return false;
        }

        if (!int.TryParse(cboPlayer.SelectedValue.ToString(), out int playerId))
        {
            MessageBox.Show("Невалиден играч.");
            return false;
        }

        if (!int.TryParse(cboToClub.SelectedValue.ToString(), out int toClubId))
        {
            MessageBox.Show("Невалиден клуб.");
            return false;
        }

        if (_playersTable == null)
        {
            MessageBox.Show("Липсват данни за играчите.");
            return false;
        }

        var rows = _playersTable.Select($"PlayerId = {playerId}");
        if (rows.Length == 0)
        {
            MessageBox.Show("Играчът не е намерен.");
            return false;
        }

        int fromClubId = Convert.ToInt32(rows[0]["ClubId"]);
        if (fromClubId == toClubId)
        {
            MessageBox.Show("Играчът не може да бъде трансфериран в същия клуб.");
            return false;
        }

        if (numFee.Value < 0)
        {
            MessageBox.Show("Сумата не може да е отрицателна.");
            return false;
        }

        if (dtpTransferDate.Value.Date > DateTime.Today)
        {
            MessageBox.Show("Датата не може да е в бъдещето.");
            return false;
        }

        return true;
    }

    private void btnTransfer_Click(object? sender, EventArgs e)
    {
        if (!ValidateTransfer()) return;

        try
        {
            int playerId = Convert.ToInt32(cboPlayer.SelectedValue);
            int toClubId = Convert.ToInt32(cboToClub.SelectedValue);

            var rows = _playersTable!.Select($"PlayerId = {playerId}");
            int fromClubId = Convert.ToInt32(rows[0]["ClubId"]);

            decimal? fee = numFee.Value > 0 ? numFee.Value : null;
            string? note = string.IsNullOrWhiteSpace(txtNote.Text) ? null : txtNote.Text.Trim();

            _repo.AddTransfer(playerId, fromClubId, toClubId, dtpTransferDate.Value.Date, fee, note);

            MessageBox.Show("Трансферът е записан успешно.");
            LoadLookups();
            RefreshGrid();
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Transfer error");
        }
    }

    private void btnRefresh_Click(object? sender, EventArgs e)
    {
        LoadLookups();
        RefreshGrid();
    }

    private void btnClear_Click(object? sender, EventArgs e)
    {
        ClearForm();
    }

    private void ClearForm()
    {
        txtFromClub.Clear();
        txtNote.Clear();
        dtpTransferDate.Value = DateTime.Today;
        numFee.Value = 0;

        if (cboPlayer.Items.Count > 0) cboPlayer.SelectedIndex = 0;
        if (cboToClub.Items.Count > 0) cboToClub.SelectedIndex = 0;
        if (cboPlayerFilter.Items.Count > 0) cboPlayerFilter.SelectedIndex = 0;
    }
}
