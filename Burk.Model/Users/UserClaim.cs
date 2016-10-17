using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("Claim", Schema = "user")]
    public class UserClaim : IdentityUserClaim
    {
    }
}
