using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cours1test.Models;
using OfficeOpenXml;
using Microsoft.AspNetCore.Http;
using System.Data;
using OfficeOpenXml.Style;
using System.IO;
using System.Net; 
using Comment = cours1test.Models.Comment; 
using ClosedXML.Excel;
using DataTable = System.Data.DataTable;
using Microsoft.AspNetCore.Identity;

namespace cours1test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FanficContextDB _db; 
        private readonly UserManager<User> _userManager; 


        public HomeController(FanficContextDB context, ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _db = context;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index(string? sortOrder)
        {
            //ICollection<Fanfic> fanfics = _db.Fanfics.ToList();

            var fanfics = _db.Fanfics.ToList();
            foreach( var f in fanfics)
            {
                f.Likes = GetLikes(f);
                f.Comments = GetComments(f);
            }
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ActiveSortParm = sortOrder == "likes" ? "comments" : "likes";

            switch (sortOrder)
            {
                case "name_desc":
                    fanfics = fanfics.OrderByDescending(s => s.Title).ToList();
                    break;
                case "likes":
                    fanfics = fanfics.OrderByDescending(s => s.Likes.Count()).ToList();
                    break;
                case "comments":
                    fanfics = fanfics.OrderByDescending(s => s.Comments.Count()).ToList();
                    break;
                default:
                    fanfics = fanfics.OrderBy(s => s.Title).ToList();
                    break;
            }

            //return Content(User.Identity.Name); 
            return View(fanfics);
        }

        public IActionResult ExportExcel()
        {
            var fanfics = _db.Fanfics.ToList();

            DataTable dt = new DataTable("Fanfics");
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ID"),
                                        new DataColumn("Title"),
                                        new DataColumn("Description")
                                        });

            foreach (Fanfic f in fanfics)
            {
                

                dt.Rows.Add(f.ID, f.Title, f.Description);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Fanfics.xlsx");
                }
            }

            //try
            //{
            //    Application application = new Excel.Application();
            //    Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value);
            //    Sheets sheets = application.Sheets;
            //    Worksheet worksheet = (Worksheet)sheets[1];
            //    worksheet.Cells[1, 1] = "ID";
            //    worksheet.Cells[1, 1] = "title";
            //    worksheet.Cells[1, 1] = "Description";
            //    List <Fanfic> fanfics = _db.Fanfics.ToList();
            //    int row = 2;
            //    foreach (Fanfic f in fanfics)
            //    {
            //        worksheet.Cells[row, 1] = f.ID;
            //        worksheet.Cells[row, 1] = f.Title;
            //        worksheet.Cells[row, 1] = f.Description;
            //        row++;
            //    }
            //    workbook.SaveAs("/Users/natavoylokova/Desktop/test/test.xls");
            //    workbook.Close();
            //    Marshal.ReleaseComObject(workbook);

            //    application.Quit();
            //    Marshal.FinalReleaseComObject(application);



            //    ViewBag.Result = "Done";
            //    return RedirectToAction("Index", "Home");
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Result = ex.Message;

            //    return RedirectToAction("MyProfile", "Fanfiction");

            //}

        }

            //    using (ExcelPackage pck = new ExcelPackage(newFile))
            //    {
            //        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Accounts");
            //        ws.Cells["A1"].LoadFromDataTable(dataTable, true);
            //        pck.Save();
            //    }
            //string sWebRootFolder = _hostingEnvironment.WebRootPath;
            //string sFileName = @"demo.xlsx";
            //string URL = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, sFileName);
            //FileInfo file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            //if (file.Exists)
            //{
            //    file.Delete();
            //    file = new FileInfo(Path.Combine(sWebRootFolder, sFileName));
            //}
            //using (ExcelPackage package = new ExcelPackage(file))
            //{
            //    // add a new worksheet to the empty workbook
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employee");
            //    //First add the headers
            //    worksheet.Cells[1, 1].Value = "ID";
            //    worksheet.Cells[1, 2].Value = "Name";
            //    worksheet.Cells[1, 3].Value = "Gender";
            //    worksheet.Cells[1, 4].Value = "Salary (in $)";

            //    //Add values
            //    worksheet.Cells["A2"].Value = 1000;
            //    worksheet.Cells["B2"].Value = "Jon";
            //    worksheet.Cells["C2"].Value = "M";
            //    worksheet.Cells["D2"].Value = 5000;

            //    worksheet.Cells["A3"].Value = 1001;
            //    worksheet.Cells["B3"].Value = "Graham";
            //    worksheet.Cells["C3"].Value = "M";
            //    worksheet.Cells["D3"].Value = 10000;

            //    worksheet.Cells["A4"].Value = 1002;
            //    worksheet.Cells["B4"].Value = "Jenny";
            //    worksheet.Cells["C4"].Value = "F";
            //    worksheet.Cells["D4"].Value = 5000;

            //    package.Save(); //Save the workbook.
            //}
            //return URL;






            //List<Fanfic> fanfics = _db.Fanfics.ToList();
            //ExcelPackage excel = new ExcelPackage();
            //ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Report");
            //ws.DefaultRowHeight = 12; 
            //ws.Row(1).Height = 20;
            //ws.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //ws.Row(1).Style.Font.Bold = true;
            //ws.Cells["A1"].Value = "Название документа";
            //ws.Cells["B1"].Value = "Описание";
            //ws.Cells["C1"].Value = "Размер";
            //ws.Cells["В1"].Value = "Фандом";

            //int recordIndex = 2;
            //foreach (var fanfic in fanfics)
            //{
            //    ws.Cells[recordIndex, 1].Value = fanfic.Title;
            //    ws.Cells[recordIndex, 2].Value = fanfic.Description;
            //    ws.Cells[recordIndex, 3].Value = fanfic.Chapters.Count();
            //    ws.Cells[recordIndex, 4].Value = fanfic.Fandom;
            //    recordIndex++;
            //}
            //ws.Column(1).AutoFit();
            //ws.Column(2).AutoFit();
            //ws.Column(3).AutoFit();
            //ws.Column(4).AutoFit();
            //string excelName = "Fanfics";

            //using (var memoryStream = new MemoryStream())
            //{
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.Headers.Add("content-disposition", "attachment; filename=" + excelName + ".xlsx");
            //    excel.SaveAs(memoryStream);
            //    memoryStream.WriteTo(Response.OutputStream());
            //    Response.Flush();
            //    Response.End();

            //    Response.Clear();
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.SendFileAsync("");
            //    Response.SendFileAsync();
            //    var streamagain = new MemoryStream(excel.GetAsByteArray());
            //}
            //}


            public IActionResult SearchPage(string searching)
        {
            //ICollection<Fanfic> fanfics = _db.Fanfics.ToList();
            Console.WriteLine("Часть поиска: "+ searching);
            var fanfics = _db.Fanfics.Where(
                f => f.Title.Contains(searching) ||
                f.Description.Contains(searching)).ToList();

            foreach (var f in fanfics)
            {
                f.Likes = GetLikes(f);
                f.Comments = GetComments(f);
            }

            //return Content(User.Identity.Name); 
            return View(fanfics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ICollection<PostLike> GetLikes(Fanfic f)
        {
            var likes = _db.Likes.Where(l => l.FanficId == f.ID).ToList(); ;

            return likes;
        }

        public ICollection<Comment> GetComments(Fanfic f)
        {
            var comments = _db.Comments.Where(l => l.FanficId == f.ID).ToList(); ;

            return comments;
        }

        public async Task<User> getAuthor(Fanfic f)
        {
            try
            {
                var auth = _db.authorship.FirstOrDefault(a => a.FanficID == f.ID);
                var author = await _userManager.FindByIdAsync(auth.UsreId);
                return author;
            }
            catch
            {
                return null ;
            }

            
        }
    }


}
