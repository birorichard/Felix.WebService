using System;
using System.Collections.Generic;

namespace Felix.WebService.DTO.Movie
{
    public class CutDTO
    {
        public int Id { get; set; }
        public MovieDTO Movie { get; set; }
        public int ShotCount { get; set; }
        public int LengthInFrames { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public List<ShotDTO> Shots { get; set; }
    }
}
