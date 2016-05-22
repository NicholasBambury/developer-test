using System;
using System.ComponentModel.DataAnnotations;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public int PropertyId { get; set; }
        public string BuyerUserId { get; set; }

    }
}