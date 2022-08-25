using System;
using System.Collections.Generic;

#nullable disable

namespace TelBookWebApplication.Models.Entities
{
    public partial class Abonent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
