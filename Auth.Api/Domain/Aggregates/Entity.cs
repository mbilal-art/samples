using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates
{
    public class Entity
    {
        public Guid Id { get; set; }

        #region Enitity Tracking
        //if want tracking of entities enable following properties
        //public DateTime CreatedTimestamp { get; set; }
        //public DateTime UpdateTimestamp { get; set; }
        #endregion
        #region User Tracking
        //following properties may use in future entities for user tracking
        //public string ModifiedByUserId { get; set; }
        //public string CreatedByUserId { get; set; }
        #endregion
    }
}
