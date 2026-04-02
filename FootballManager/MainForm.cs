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

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        btnClubs.Click += (s, e) => new ClubsForm().Show();
        btnPlayers.Click += (s, e) => new PlayersForm().Show();
        btnTransfers.Click += (s, e) => new TransfersForm().Show();
        btnLeagues.Click += (s, e) => new LeaguesForm().Show();
    }
}
