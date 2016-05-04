using FileUploadDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUploadDemo.ExtensionMethods;

namespace FileUploadDemo.Filters
{

    /*
     
     * create by cfs
     As we are creating an action filter, 
     * we need to inherit from IActionFilter interface which has two methods OnActionExecuted and OnActionExecuting.

     We need to focus on OnActionExecuting method. 
     * Because we need to process the uploaded files before the execution of an action method in controller.

     Instead of directly implementing IActionFilter interface, we are using the ActionFilterAttribute class,
     * which provides the default implementation for IActionFilter interface.

     ActionFilterAttribute class is an abstract class, so to provide the implementation details for OnActionExecuting method, 
     * we overridden that method in our UploadFileAttribute class.

     OnActionExecuting method has a parameter called filterContext which is of type ActionExecutingContext. 
     * Using this parameter, we can get the information about the current request object and thus the uploaded files.

     Using request.Files property, we are getting the collection of all the files that are uploaded by client.
     * Each file in this collection is of type HttpPostedFileBase. Then in for each loop, we are using our GetFileInformation extension method to extract the information like filename, content type, byte array and file extension for the file and adding it to list variable named as fileInformation. This list is of type List of FileInformation which we have created at the beginning of the method.

     Now our fileInformation list variable contains the information about all the uploaded files.
     * Then we are using the ActionParameters property of filterContext object to set our list variable (fileInformation)
     * as a parameter to the called action method. 
     * Name of the parameter that we need to add to action method will be uploadedFiles which will be of type List<FileInformation>.
     
     
     
     */


    public class UploadFileAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var fileInformation = new List<FileInformation>();

            if (filterContext != null)
            {
                var request = filterContext.HttpContext.Request;
                if (request != null && request.Files.Count > 0)//request.Files客户端上载文件的集合
                {
                    foreach (string uploadedFile in request.Files)
                    {
                        if (request.Files[uploadedFile].ContentLength > 0)
                        {
                            var fileInfo = request.Files[uploadedFile].GetFileInformation();
                            fileInformation.Add(fileInfo);
                        }
                    }
                }

                filterContext.ActionParameters["wahaha"] = fileInformation;
            }


            base.OnActionExecuting(filterContext);
        }
    }
}