using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.MVC.ViewModel
{
    public class RequestsListViewModel
    {
        public IList<StudentRequestViewModel> RequestsList { get; set; }
        public int GroupId { get; set; }
    }
}
