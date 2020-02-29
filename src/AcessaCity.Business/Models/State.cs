using System.Collections.Generic;

namespace AcessaCity.Business.Models
{
    public class State : Entity
    {
        public string UFCode { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<City> Cities { get; set; }
    }
}