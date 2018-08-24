namespace TaskManager.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Task")]
    public partial class Task
    {
        [Key]
        public int Task_ID { get; set; }

        public int? Parent_ID { get; set; }

        [Column("Task")]
        [StringLength(20)]
        public string Task1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Start_Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? End_Date { get; set; }

        public int? Priority { get; set; }

        public virtual ParentTask ParentTask { get; set; }
    }
}
