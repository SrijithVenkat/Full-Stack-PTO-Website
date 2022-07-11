using FirstWebsite.Data.Models;
using FirstWebsite.Data.Services;
using java.awt.image;
using java.io;
using javax.imageio;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstWebsite.Web.Controllers
{
    public class UserDataFormController : Controller
    {
        private readonly UserData dataBase;

        public UserDataFormController(UserData db)
        {
            dataBase = db;
        }
        [HttpGet]
        // GET: UserDataForm
        public ActionResult Index(string searchString)
        {
            if (Session["idUser"] != null)
            {
                var model = dataBase.GetAll();
                if (!String.IsNullOrEmpty(searchString))
                {

                    model = dataBase.Search(searchString);
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = dataBase.Get(id);
                if (model == null)
                {
                    return View("Not Found");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            if (Session["idUser"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user, HttpPostedFileBase image1)
        {
            if(image1== null)
            {
                string fileName = HttpContext.Server.MapPath(@"~/Content/defaultUser.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                user.profilePicture = imageData;
            }
            else
            {
                user.profilePicture = new byte[image1.ContentLength];
                image1.InputStream.Read(user.profilePicture, 0, image1.ContentLength);
            }
            user.passWord = HomeController.GetMD5(user.passWord);
            dataBase.Add(user);
            return RedirectToAction("Details", new { id = user.userId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = dataBase.Get(id);
                if (model == null)
                {
                    HttpNotFound();
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user, HttpPostedFileBase image1)
        {

            if (image1 != null)
            {
                user.profilePicture = new byte[image1.ContentLength];
                image1.InputStream.Read(user.profilePicture, 0, image1.ContentLength);
            }
            dataBase.Update(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["idUser"] != null)
            {
                var model = dataBase.Get(id);
                return View(model);
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            dataBase.Delete(id);
            return RedirectToAction("Index");
        }

    }
}