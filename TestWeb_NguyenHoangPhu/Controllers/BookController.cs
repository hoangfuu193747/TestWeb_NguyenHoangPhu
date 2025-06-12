using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb_NguyenHoangPhu.Models;

namespace TestWeb_NguyenHoangPhu.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var musicCD = _db.Books.ToList();
            return View(musicCD);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book d)
        {
            if (ModelState.IsValid)
            {
                d = new Book
                {
                    Title = d.Title,
                    Author = d.Author,
                    Price = d.Price,
                    Quantity = d.Quantity
                    
                };
                _db.Books.Add(d);
                _db.SaveChanges();
                TempData["success"] = "Thêm thành công 1 quyển sách!";
                var musicCD = _db.Books.ToList();
                return RedirectToAction("Index", musicCD);
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            var CDEdit = _db.Books.FirstOrDefault(d => d.Id == Id);
            if (CDEdit == null)
            {
                return NotFound();
            }
            return View(CDEdit);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Book cd)
        {
            if (!_db.Books.Any(d => d.Id == Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(cd);
                _db.SaveChanges();
                var CDList = _db.Books.ToList();
                TempData["success"] = "Cập nhật sách thành công!";
                return RedirectToAction("Index", CDList);
            }
            return View(cd);
        }
        public IActionResult DeleteConfirm(int Id)
        {
            var CDDelete = _db.Books.FirstOrDefault(d => d.Id == Id);
            if (CDDelete == null) return NotFound();
            return View("DeleteConfirm", CDDelete);
        }

        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var cd = _db.Books.FirstOrDefault(d => d.Id == Id);
            if (cd == null) return NotFound();
            _db.Books.Remove(cd);
            _db.SaveChanges();
            var CDList = _db.Books.ToList();
            TempData["success"] = "Xóa sách thành công!";
            return RedirectToAction("Index");

        }
    }
}
