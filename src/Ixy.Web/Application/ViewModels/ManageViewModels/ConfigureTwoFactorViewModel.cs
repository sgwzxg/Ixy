using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Ixy.Application.ViewModels.ManageViewModels
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}
