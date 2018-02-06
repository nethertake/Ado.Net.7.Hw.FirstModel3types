namespace HWmodule5
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesModel")]
    public partial class TablesModel
    {
        [Key]
        public int intModelID { get; set; }

        [StringLength(10)]
        public string strName { get; set; }

        public int? intManufacturerID { get; set; }

        public int? intSMCSFamilyID { get; set; }

        [StringLength(250)]
        public string strImage { get; set; }
    }
}
