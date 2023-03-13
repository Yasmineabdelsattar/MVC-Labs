using System.Diagnostics.Metrics;

namespace lab2.Models.Domain;

public class Ticket
{
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severitys Severity { get; set; }
    public string Description { get; set; } = string.Empty;


    public Ticket()
    {
        CreatedDate = DateTime.Now;
    }

    public Ticket(
        bool isClosed,
        Severitys severity,
        string description)
       
    {
        IsClosed = isClosed;
        Severity = severity;
        Description = description;  
    }


    private static readonly List<Ticket> _tickets = new()
                    {
                        new Ticket(true ,Severitys.high, "amazing"),
                        new Ticket(false ,Severitys.low,  "good"),
                        new Ticket(false ,Severitys.high, "amazing"),
                        new Ticket(true ,Severitys.medium, "amazing"),               
                    };
    public static List<Ticket> GetTicketsList() => _tickets;
}
