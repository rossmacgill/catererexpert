using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CatereringExpert.Models;

namespace CatereringExpert.Controllers
{
    public class FileController : Controller
    {
        private CatererDBContext db = new CatererDBContext();
        //
        // GET: /File/
        //public ActionResult Index(int id)
        //{
        //    var fileToRetrieve = db.Files.Find(id);
        //    return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        //}
    }
}