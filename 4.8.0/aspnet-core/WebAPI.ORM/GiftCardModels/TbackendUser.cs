using System;
using System.Collections.Generic;

namespace WebAPI.ORM.GiftCardModels
{
    public partial class TbackendUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public int? RoleId { get; set; }

        public virtual Trole Role { get; set; }
    }
}
