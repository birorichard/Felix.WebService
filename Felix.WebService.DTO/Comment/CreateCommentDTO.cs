namespace Felix.WebService.DTO.Comment
{
    public class CreateCommentDTO
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int Frame { get; set; }
        public int ShotId { get; set; }
        public int CutId { get; set; }

    }
}
