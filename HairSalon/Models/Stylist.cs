using System.Collections.Generic;

namespace HairSalon.Models
{
  public class Stylist
  {
    public Stylist()
    {
      this.Clients = new HashSet<Client>();
    }
    public virtual ICollection<Client> Clients { get; set; }
    public int StylistId { get; set; }
    public string Name { get; set; }
    public string Specialty { get; set; }
  }
}