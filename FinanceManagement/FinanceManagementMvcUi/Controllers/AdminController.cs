namespace FinanceManagementMvcUi.Controllers
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using FinanceManagement.ETL.Models;
    using FinanceManagement.ETL.Repositories;
    using Services;

    public class AdminController : Controller
    {
        private readonly EtlService _etlService;
        private ImportFileType _currentImportFileType;
        public AdminController()
        {
            _etlService = new EtlService(new EtlRepository());
        }

        // GET: Admin
        public ActionResult Index()
        {
            var importFileTypes = _etlService.GetImportFileTypes();
            return View(importFileTypes);
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            var importFileType = _etlService.GetImportFileTypeById(id);
            return View(importFileType);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var importFileType = Helpers.ConvertIFormCollectionToImportFileType(collection);
                _etlService.CreateImportFileType(importFileType);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            if (_currentImportFileType == null || _currentImportFileType.ImportFileTypeId != id)
            {
                _currentImportFileType = _etlService.GetImportFileTypeById(id);
            }

            return View(_currentImportFileType);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var importFileType = Helpers.ConvertIFormCollectionToImportFileType(collection);
                _etlService.UpdateImportFileType(importFileType);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}