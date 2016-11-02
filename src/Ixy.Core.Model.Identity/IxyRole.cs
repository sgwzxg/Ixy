using Ixy.Core.Model.Interface;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ixy.Core.Model.Identity
{
    public class IxyRole : IdentityRole, IAggregateRoot
    {

    }
}
