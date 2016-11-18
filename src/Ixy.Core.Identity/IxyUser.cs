using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Ixy.Core.Interface;

namespace Ixy.Core.Identity
{
    public class IxyUser : IdentityUser, IAggregateRoot
    {

    }
  
}
