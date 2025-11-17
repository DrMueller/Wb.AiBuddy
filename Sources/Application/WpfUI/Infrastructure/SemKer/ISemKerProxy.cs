using System.Threading.Tasks;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.SemKer
{
    public interface ISemKerProxy
    {
        Task<string> AnalyzeScreenshotAsync(string systemMessage, byte[] image);
    }
}
