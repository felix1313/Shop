using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Filters;
using Shop.Models;  
using Shop.Observers;

namespace Shop.Controllers
{
	[AuthorizationFilter]
    public class ManageItemsController : BaseController
    {
        //
        // GET: /ManageItems/

		public ManageItemsController()
		{
			AddObserver(new AdminsObserver());
			AddObserver(new LoggerObserver());
		}


		public ActionResult Index()
        {
           return View(DisplayModelsProvider.GetItemModels());
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult SubmitAdd(ItemModel item, HttpPostedFileBase imgFile)
        {
	        if (imgFile != null)
	        {
		        var file = UploadFile(imgFile.InputStream, imgFile.FileName);
		        item.ImageSrc = file.FullName.Substring(AppDomain.CurrentDomain.BaseDirectory.Length-1).Replace('\\','/');
	        }
	        
			DisplayModelsProvider.AddItem(item);

			Notify(ActionFactory.CreateSimpleAction("New Item!"));

            return RedirectToAction("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

		private static string GetPath()
		{
			return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content\\Img");
		}

		private static FileInfo UploadFile(Stream inputStream, string fileName)
		{
			string path = GetPath();
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			if (string.IsNullOrEmpty(fileName))
			{
				fileName = "img";
			}

			string uniqFileName = string.Format(
				"{0}-{1:yyyy-MM-dd_hh-mm-ss-tt}{2}",
				Path.GetFileNameWithoutExtension(fileName),
				DateTime.Now,
				Path.GetExtension(fileName));

			FileInfo file = new FileInfo(Path.Combine(path, uniqFileName));
			using (FileStream fileStream = file.Create())
			{
				inputStream.Seek(0, SeekOrigin.Begin);
				inputStream.CopyTo(fileStream);
			}

			return file;
		}
    }
}
