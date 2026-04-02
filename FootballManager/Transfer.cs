using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager;

public class Transfer
{
    public int TransferId { get; set; }
    public int PlayerId { get; set; }
    public int? FromClubId { get; set; }
    public int ToClubId { get; set; }
    public DateTime TransferDate { get; set; }
    public decimal? Fee { get; set; }
    public string? Note { get; set; }
}
