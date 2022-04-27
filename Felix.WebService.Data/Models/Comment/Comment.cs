using Felix.WebService.Common.Constants;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.Data.Models.Movie;
using Felix.WebService.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Felix.WebService.Data.Models.Comment
{
    [Table(nameof(Comment), Schema = DataConstants.CommentSchemaName)]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public bool IsDeleted { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }

        public int CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById)), Required]
        public User CreatedBy { get; set; }

        public CommentPriorityEnum Priority { get; set; }

        public int ShotCutRelId { get; set; }
        
        [ForeignKey(nameof(ShotCutRelId))]
        public ShotCutRel ShotCutRel { get; set; }
    }
}
