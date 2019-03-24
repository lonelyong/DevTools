using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortUrl.Api.Entities
{
    [Table("tb_short_url")]
    public class Url : EntityBase
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public long Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Link { get; set; }
    }
}
