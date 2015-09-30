using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDapper.Controllers
{
    public class ReviewsController : Controller
    {
        // GET: Reviews
        public ActionResult GetReviews(int? id)
        {
            return View("ReviewsView");
        }
    }
}