using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MMSWebApp.Models
{
    public class MaintenanceLogDetail
    {
        private string desc;

        public int id { get; set; }
        public int OriginID { get; set; }
        public int SMEID { get; set; }
        [Display(Name = "FA")]
        public string FunctionArea { get; set; }
        public string System { get; set; }
        [Display(Name = "SER/Temp")]
        public string SERNoTempNo { get; set; }
        [Display(Name = "Req Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Requested_Date { get; set; }
        [Display(Name = "Req By")]
        public string Requested_By { get; set; }

        [Display(Name = "Desc")]
        [DataType(DataType.MultilineText)]
        public string IssueDescription
        {
            get
            {
                if (desc.Length > 150)
                    return desc.Substring(0, 150) + "...";
                else
                    return desc;
            }

            set { desc = value; }
            }
        public string Priority { get; set; }
        public string Severity { get; set; }
        public decimal Estimated { get; set; }
        [Display(Name = "Category")]
        public string IssueCategory { get; set; }
        public string Status { get; set; }

        [Display(Name = "actBy")]
        public string ActionedBy { get; set; }

        [Display(Name = "BaselineStart Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BaselineStart { get; set; }
        [Display(Name = "BaselineFinish Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BaselineFinish { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RevisedStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RevisedFinish { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActualStart { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActualFinish { get; set; }
        [Display(Name = "actMDs")]
        public decimal ActualMandays { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LastUpdatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public string Remarks { get; set; }
        public string Type { get; set; }
        public string ImportDesc { get; set; }

    }

    public class MaintenanceLogDetailDBContext : DbContext
    {
        public DbSet<MaintenanceLogDetail> MaintenanceLogDetails { get; set; }
    }
}