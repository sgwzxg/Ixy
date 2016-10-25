using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ixy.Models.Identity
{
    public class IxyUser : IdentityUser, IAggregateRoot
    {

    }
}
