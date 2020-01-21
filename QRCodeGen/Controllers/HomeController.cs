using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCodeGen.Models;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;


namespace QRCodeGen.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var builder = new StringBuilder();
            builder.Append("00020101021229370016A0000006770101110113006691493165953037645802TH6304");
            var payload = builder.ToString().Select(x => Convert.ToByte(x)).ToArray();
            var crc = new CRC16().ComputeCheckSum(payload);
            builder.Append(crc.ToString("X").PadLeft(4, '0'));
            var str = builder.ToString();
                    MessagingToolkit.QRCode.Codec.QRCodeEncoder encoder = new MessagingToolkit.QRCode.Codec.QRCodeEncoder();
                    encoder.QRCodeScale = 8;              
                    Bitmap bmp = encoder.Encode(str);
                
                   
           
            return View();
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
    }
}
