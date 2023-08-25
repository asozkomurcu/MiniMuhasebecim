using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.RequestModels.CategoryRM
{
    public class UpdateCategoryVM
    {
        public int? Id { get; set; }
        public string CategoryName { get; set; }
    }
}
