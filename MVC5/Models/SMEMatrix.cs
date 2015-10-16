using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MMSWebApp.Models
{
    public class SMEMatrix
    {
        public int ID { get; set; }
        public string FunctionArea { get; set; }
        public string System { get; set; }
        public string Type { get; set; }
        public string APJSME1 { get; set; }
        public string APJSME2 { get; set; }
        public string APJSME3 { get; set; }
        public string APJSME4 { get; set; }
        public string MTRTeam { get; set; }
        public string MTRSME1 { get; set; }
        public string MTRSME2 { get; set; }
        public string MTRSME3 { get; set; }
        public string MTRSME4 { get; set; }
        public string Remark { get; set; }

    }

    public class SMEMatrixDBContext : DbContext
    {
        public DbSet<SMEMatrix> SMEMatrixs { get; set; }
    }
}