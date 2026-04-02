using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;


namespace FootballManager;
public partial class ClubsForm : Form
{
    private readonly ClubsRepository _repo = new();
    private int? _selectedId = null;

    public ClubsForm()
    {
        InitializeComponent();
        dgvClubs.ReadOnly = true;
        dgvClubs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClubs.MultiSelect = false;

        dgvClubs.CellClick += dgvClubs_CellClick;
    }

    private void RefreshGrid()
    {
        dgvClubs.DataSource = _repo.GetAll();
        _selectedId = null;
        txtName.Clear();
        txtCity.Clear();
    }

    private void btnInitDb_Click_1(object sender, EventArgs e)
    {
        try
        {
            DatabaseInit.Init();
            MessageBox.Show("Database created successfully!\n" + Db.DbPath);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Init DB Error");
        }
    }

    private void btnLoad_Click(object sender, EventArgs e)
    {
        try
        {
            RefreshGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Load error");
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var name = txtName.Text.Trim();
        var city = txtCity.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Name cannot be empty.");
            return;
        }

        try
        {
            _repo.Add(name, string.IsNullOrWhiteSpace(city) ? null : city);
            MessageBox.Show("Added successfully.");
            RefreshGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Add error");
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Select a club first.");
            return;
        }

        var name = txtName.Text.Trim();
        var city = txtCity.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Name cannot be empty.");
            return;
        }

        try
        {
            _repo.Update(_selectedId.Value, name, string.IsNullOrWhiteSpace(city) ? null : city);
            MessageBox.Show("Updated successfully.");
            RefreshGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Edit error");
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Select a club first.");
            return;
        }

        if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;

        try
        {
            _repo.Delete(_selectedId.Value);
            MessageBox.Show("Deleted successfully.");
            RefreshGrid();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Delete error");
        }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        _selectedId = null;
        txtName.Clear();
        txtCity.Clear();
        dgvClubs.ClearSelection();
    }

    private void dgvClubs_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var row = dgvClubs.Rows[e.RowIndex];
        _selectedId = Convert.ToInt32(row.Cells["ClubId"].Value);
        txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
        txtCity.Text = row.Cells["City"].Value?.ToString() ?? "";
    }


}