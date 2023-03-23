using System;
using System.Collections.Generic;

namespace DbFirstApproach.DbModels
{
    public partial class FileDetail
    {
        public int Id { get; set; }
        public string FileName { get; set; } = null!;
        public byte[] FileData { get; set; } = null!;
        public int FileType { get; set; }
    }
}
