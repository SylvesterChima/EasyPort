﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EasyPort.Helpers
{
    public class ImageHelper
    {
        private readonly IFileProvider _fileProvider;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageHelper(IFileProvider fileProvider, IHostingEnvironment hostingEnvironment)
        {
            _fileProvider = fileProvider;
            _hostingEnvironment = hostingEnvironment;
        }
        #region Local
        public async Task<string> UploadImage(IFormFile file, string userName)//, string Ip
        {
            var imgUrl = "";
            if (file != null)
            {
                FileInfo fi = new FileInfo(file.FileName);
                //string picName = string.Format("{0}_image_{1}_{2}", property.Replace(" ", ""), userName, Path.GetFileName(file.FileName.Trim().Replace(" ", ""))) + fi.Extension;
                string picName = userName + "_" + string.Format("{0:d}", (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;

                var webPath = _hostingEnvironment.WebRootPath;
                var path = Path.Combine("", webPath + @"\ImageFiles\" + picName);

                imgUrl = @"/ImageFiles/" + picName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                   await file.CopyToAsync(stream);
                }
            }

            return imgUrl;
        }
        #endregion
    }
}