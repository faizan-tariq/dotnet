﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SampleDotNet.Models
{
    public class VideoDTO
    {
        public long Id { get; set; }
        [DataType(DataType.Url)] public Uri Link { get; set; }
        [DataType(DataType.DateTime)] public DateTime Time { get; set; }
        public VideoDTO()
        {
        }
    }
}
