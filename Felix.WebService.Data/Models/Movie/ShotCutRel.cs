using Felix.WebService.Common.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Movie
{
    /// <summary>
    /// Relation between a cut and a shot
    /// </summary>
    [Table(nameof(ShotCutRel), Schema=DataConstants.MovieSchemaName)]
    public class ShotCutRel
    {
        [Key]
        public int Id { get; set; }

        public int CutId { get; set; }
        
        [ForeignKey(nameof(CutId))]
        public Cut Cut { get; set; }
        
        public int ShotId { get; set; }

        [ForeignKey(nameof(ShotId))]
        public Shot Shot { get; set; }

        [InverseProperty(nameof(Comment.Comment.ShotCutRel))]
        public virtual ICollection<Comment.Comment> Comments { get; set; }
    }
}
