using System;

namespace Felix.WebService.DTO.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int StartFrame { get; set; }
        public int EndFrame { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; }
        public string CreatedByName { get; set; }
        public int CreatedById{ get; set; }
        public string Priority { get; set; }
        public int ShotId { get; set; }
    }
}
