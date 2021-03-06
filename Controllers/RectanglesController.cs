using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RectangleChecker.Models;

namespace RectangleChecker.Controllers
{
  public class RectanglesController : Controller
  {
    [HttpGet("/rectangles")]
    public ActionResult Index()
    {
      return View("CreateForm");
    }

    // [HttpGet("/rectangle/result")]
    // public ActionResult Result()
    // {
    //   Rectangle myRectangle = new Rectangle(Int32.Parse(Request.Query["side-length"]), Int32.Parse(Request.Query["side-width"]));
    //   return View("RectangleResult", myRectangle);
    // }

    [HttpGet("/rectangles/result")]
    public ActionResult Result()
    {
        Dictionary<string, object> Shapes = new Dictionary<string, object>();
        Rectangle myRectangle = new Rectangle(Int32.Parse(Request.Query["side-length"]), Int32.Parse(Request.Query["side-width"]));
        Shapes.Add("ResultingRectangle", myRectangle);
        if (myRectangle.IsSquare())
        {
            Cube myCube = new Cube(myRectangle);
            Shapes.Add("ResultingCube", myCube);
        }
        return View("RectangleResult", Shapes);
    }
  }
}
