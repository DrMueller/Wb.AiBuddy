using MediatR;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Container;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Models;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.SemKer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.ScreenshotAnalysis
{
    public record AnalyzeScreenshotQuery(string AnalysisInput) : ICommand<string>;

    public class AnalyzeScreenshotQueryHandler(ISemKerProxy semKerProxy) : IRequestHandler<AnalyzeScreenshotQuery, string>
    {
        public async Task<string> Handle(AnalyzeScreenshotQuery request, CancellationToken cancellationToken)
        {
            var screenshot = await TakeScreenshotAsync();
            var analysis = await semKerProxy.AnalyzeScreenshotAsync(request.AnalysisInput, screenshot);

            return analysis;
        }

        private static async Task<byte[]> TakeScreenshotAsync()
        {
            App.HideableView.Hide();
            await Task.Delay(50);

            var screenWidth = (int)SystemParameters.PrimaryScreenWidth;
            var screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            using var bmp = new Bitmap(screenWidth, screenHeight);
            using var g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            using var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);  
            var bytes = ms.ToArray();

            App.HideableView.Show();

            return bytes;
        }
    }
}