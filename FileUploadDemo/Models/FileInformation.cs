using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadDemo.Models
{
    public class FileInformation
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 扩展名
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// 进制
        /// </summary>
        public byte[] BinaryData { get; set; }
    }
}