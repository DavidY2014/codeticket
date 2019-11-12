using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class Trole
    {
        public Trole()
        {
            TbackendUser = new HashSet<TbackendUser>();
        }

        public int RoleId { get; set; }
        public string Permission { get; set; }

        public virtual ICollection<TbackendUser> TbackendUser { get; set; }
    }
}
