using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Ixy.EntityFrameworkCore.Models.Identity
{
    public class IxyUser : IdentityUser, IAggregateRoot
    {

    }
}
