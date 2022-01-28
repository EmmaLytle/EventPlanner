using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib.DAL.Data.Model
{
    [ModelMetadataType(typeof(MetaData))]
    public partial class EventPlan
    {

        public class MetaData
        {
            [Required (ErrorMessage ="Please enter a title.")]
            public string Title { get; set; }




        }
    }
}
