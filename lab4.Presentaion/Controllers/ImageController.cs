﻿using lab4.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace lab4.Presentaion.Controllers
{
    public class ImageController : Controller
    {

        //private readonly IOptionsMonitor<ImageOptions> _imageOptionsMonitor;

        //public ImageController(IOptionsMonitor<ImageOptions> imageOptionsMonitor)
        //{
        //    _imageOptionsMonitor = imageOptionsMonitor;
        //}

        //public IActionResult Index()
        //{
        //    ImageOptions imageOptions = _imageOptionsMonitor.CurrentValue;
        //    return View(imageOptions);
        //}

        //[HttpGet]
        //public IActionResult AddImage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddImage(AddImageVM vm)
        //{
        //    if (vm.Image is null)
        //    {
        //        ModelState.AddModelError("", "Image is not found");
        //        return View();
        //    }
        //    if (vm.Image.Length > _imageOptionsMonitor.CurrentValue.Size)
        //    {
        //        ModelState.AddModelError("", "Image size exceeded the limit");
        //        return View();
        //    }
        //    var allowedExtensions = new string[] { _imageOptionsMonitor.CurrentValue.Allowed.ToString() };
        //    var sentExtension = Path.GetExtension(vm.Image.FileName).ToLower();
        //    if (!allowedExtensions.Contains(sentExtension))
        //    {
        //        ModelState.AddModelError("", "Image extension is not valid");
        //        return View();
        //    }
        //    string newName = $"{Guid.NewGuid()}{sentExtension}";
        //    string fullPath = @$"{_imageOptionsMonitor.CurrentValue.FolderPath}{newName}";

        //    using (var stream = System.IO.File.Create(fullPath))
        //    {
        //        vm.Image.CopyTo(stream);
        //    }

        //    return RedirectToAction(nameof(Index));
    }
}
