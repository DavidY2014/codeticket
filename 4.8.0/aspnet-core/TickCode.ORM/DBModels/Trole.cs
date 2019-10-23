using System;
using System.Collections.Generic;

namespace TickCode.ORM.DBModels
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
