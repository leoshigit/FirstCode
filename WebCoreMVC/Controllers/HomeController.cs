using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebCoreMVC.Models;

namespace WebCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestService _testService;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            // 資料清單
            var data = _testService.GetData();
            // 單筆資料
            var item = _testService.GetTestVM();

            var editViewModel = new Service.Models.TestEditViewModel() { Name = "TEST" };
            // 新增
            editViewModel.Id = _testService.Create(editViewModel);
            // 更新
            editViewModel.Name = "TEST2";
            _testService.Update(editViewModel);
            // 刪除
            _testService.Delete(editViewModel.Id.Value);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
