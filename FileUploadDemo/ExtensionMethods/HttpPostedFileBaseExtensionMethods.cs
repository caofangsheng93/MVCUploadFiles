using FileUploadDemo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileUploadDemo.ExtensionMethods
{
    /*
     2016-5-4 create by cfs
     GetFileName – It will return the name of the uploaded file.

     GetContentType – It will return the content type (MIME type) for the uploaded file.
     * For example for jpeg image file, content type will be image/jpeg.

     GetBinaryData – It will convert the binary information of a file into a byte array 
     * which we can use to save the file information in a table. 

     GetFileExtension – It will return the extension for the uploaded file. 
     * For example for png image file, it will return .png.

     GetFileInformation – This method returns an object of type FileInformation 
     * which contain the information like filename, content type, file extension and byte array data for a single uploaded file.
     */


    public static class HttpPostedFileBaseExtensionMethods
    {
        /*
         1.扩展方法必须是静态的；
         2.扩展方法，必须在非泛型的静态类中定义
         3.扩展方法必须包含关键字this作为他的第一个参数类型，并在后面跟着他所扩展的类的名称
         
         */

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileName(this HttpPostedFileBase file)
        {
            return file.FileName;
        }

        /// <summary>
        /// 获取上传文件的类型
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetContentType(this HttpPostedFileBase file)
        {
            return file.ContentType;
        }

        /// <summary>
        /// 获取二进制数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static byte[] GetBinaryData(this HttpPostedFileBase file)
        {
            var fileBinary = new byte[file.InputStream.Length];
            file.InputStream.Read(fileBinary, 0, fileBinary.Length);
            return fileBinary;
        }

        /// <summary>
        /// 获取文件扩展名
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileExtension(this HttpPostedFileBase file)
        {
            return Path.GetExtension(GetFileName(file));
        }

        /// <summary>
        /// 获取文件信息
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static FileInformation GetFileInformation(this HttpPostedFileBase file)
        {
            return new FileInformation()
            {

                FileName = GetFileName(file),
                ContentType = GetContentType(file),
                FileExtension = GetFileExtension(file),
                BinaryData = GetBinaryData(file)

            };
        }
    }
}