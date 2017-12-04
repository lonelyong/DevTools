using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortUrl.Entities
{
    [Table("TShortUrl")]
    public class Url
    {
        [Key]
        [Column(TypeName = "bigint")]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Link { get; set; }
    }
}
