using System;
using System.Collections.Generic;

namespace WebAPI.ORM.Models
{
    public partial class Trole
    {
        public Trole()
        {
            Tlogin = new HashSet<Tlogin>();
        }

        public int RoleId { get; set; }
        public string Permission { get; set; }

        public virtual ICollection<Tlogin> Tlogin { get; set; }
    }
}
