using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager;

public class Player
{
    public int PlayerId { get; set; }
    public int ClubId { get; set; }
    public string FullName { get; set; } = "";
    public DateTime BirthDate { get; set; }
    public string Position { get; set; } = "";
    public int? ShirtNumber { get; set; }
    public string Status { get; set; } = "Active";
}