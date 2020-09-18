using System;
using System.ComponentModel.DataAnnotations;

namespace SampleDotNet.Models
{
    public class Video
    {
        public long Id { get; set; }
        [DataType(DataType.Url)] public Uri Link { get; set; }
        [DataType(DataType.DateTime)] public DateTime Time { get; set; }
        [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; }
    }
}
