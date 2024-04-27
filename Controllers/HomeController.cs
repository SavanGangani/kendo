using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using mvc.Repo;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HomeRepository _homeRepository;
    private readonly BuyRepository _buyRepository;
    private readonly CityRepository _cityRepository;
    private readonly IWebHostEnvironment _hostingEnvironment;


    public HomeController(ILogger<HomeController> logger, HomeRepository homeRepository, BuyRepository buyRepository, CityRepository cityRepository, IWebHostEnvironment hostingEnvironment)
    {
        _logger = logger;
        _homeRepository = homeRepository;
        _buyRepository = buyRepository;
        _cityRepository = cityRepository;
                    _hostingEnvironment = hostingEnvironment;

    }
    static string file = "";


    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetAllStudent()
    {
        return Json(_homeRepository.GetAllStudent());
    }

    [HttpPost]
    public IActionResult EditStudent(tblSRS student)
    {
        Console.WriteLine(student.c_admission_date);
        _homeRepository.EditStudent(student);
        return Json("Student Details Edit Success");
    }

    [HttpPost]
    public IActionResult AddStudent(tblSRS student)
    {
        student.c_photo = file;
        _homeRepository.AddStudent(student);
        return Json("Student Details Added Success");
    }

    [HttpDelete]
    public IActionResult DeleteStudent(int id)
    {
        _homeRepository.DeleteStudent(id);
        return Json("Student Details Deleted Success");
    }

    [HttpGet]
    public IActionResult GetAllCity()
    {
        return Json(_cityRepository.GetAllCitys());
    }

    [HttpPost]
    public IActionResult BuyProduct(tblBuy buy)
    {
        Console.WriteLine(buy.c_quantity);
        _buyRepository.buy(buy);
        return Json("Index", "Home");
    }

    [HttpPost]
    public IActionResult UploadImage(IFormFile photo)
    {
        if (photo != null)
        {
            string filename = photo.FileName;
            string filepath = Path.Combine(_hostingEnvironment.WebRootPath,"images", filename);
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }
            file = filename;

        }
        else
        {
            Console.WriteLine("Could not create ");
        }
        return Json("OKAY");
    }

}
