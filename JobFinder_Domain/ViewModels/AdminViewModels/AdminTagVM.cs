using JobFinder_Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobFinder_Domain.ViewModels.AdminViewModels
{
    public class AdminTagVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }

    }
}
