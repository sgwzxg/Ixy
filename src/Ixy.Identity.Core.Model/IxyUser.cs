using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ixy.Core.Model.Interface;

namespace Ixy.Identity.Core.Model
{
    public class IxyUser : IdentityUser, IAggregateRoot
    {

    }
}
