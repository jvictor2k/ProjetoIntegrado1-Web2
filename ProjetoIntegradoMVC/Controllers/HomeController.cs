using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoIntegradoMVC.Models.ViewModels;
using ProjetoIntegradoMVC.Models;

namespace ProjetoIntegradoMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ProjetoIntegradoMVC.Models.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public FileResult GerarRelatorio()
        {
            using (var doc = new PdfSharpCore.Pdf.PdfDocument())
            {
                var page = doc.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                page.Orientation = PdfSharpCore.PageOrientation.Portrait;

                var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                var corFonte = PdfSharpCore.Drawing.XBrushes.Black;
                var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                var fonteSeller = new PdfSharpCore.Drawing.XFont("Arial", 12);
                var fonteDepartment = new PdfSharpCore.Drawing.XFont("Arial", 12, PdfSharpCore.Drawing.XFontStyle.Bold);

                var qtdPaginas = doc.PageCount;
                textFormatter.DrawString(qtdPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(578,825,page.Width,page.Height));

                var alturaTituloDetalhesY = 40;
                var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                detalhes.DrawString("Id", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Date", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(100, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Seller", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(170, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Department", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(250, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Amount", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(320, alturaTituloDetalhesY, page.Width, page.Height));
                detalhes.DrawString("Status", fonteDepartment, corFonte, new PdfSharpCore.Drawing.XRect(390, alturaTituloDetalhesY, page.Width, page.Height));

                var alturaDetalhesItens = 60;

                List<SalesRecord> lista = new List<SalesRecord>();

                foreach (var item in lista)
                {
                    textFormatter.DrawString(item.Id.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(item.Date.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(item.Seller.Name.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(item.Seller.Department.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(item.Amount.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                    textFormatter.DrawString(item.Status.ToString(), fonteSeller, corFonte, new PdfSharpCore.Drawing.XRect(30, alturaDetalhesItens, page.Width, page.Height));
                }

                using (MemoryStream stream = new MemoryStream())
                {
                    var contantType = "application/pdf";
                    doc.Save(stream, false);

                    var nomeArquivo = "RelatorioSales.pdf";

                    return File(stream.ToArray(), contantType, nomeArquivo);
                }
            }
        }
    }
}
