using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace AcessaCity.Business.Models
{
   public class ReportSatus: Entity
   {
     public string description { get; set; }

     public Boolean denied { get; set; }

     public Boolean approved { get; set; }

     public Boolean review { get; set; }

     public Boolean inProgress { get; set; }
   }
}