using Felix.WebService.Common.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Movie
{
    [Table(nameof(Shot), Schema = DataConstants.MovieSchemaName)]
    public class Shot
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public string FileName { get; set; }

        [InverseProperty(nameof(ShotCutRel.Shot))]
        public virtual ICollection<ShotCutRel> ShotCutRels { get; set; }



    }
}
