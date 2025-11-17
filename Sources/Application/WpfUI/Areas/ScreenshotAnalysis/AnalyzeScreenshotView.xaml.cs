using System.Windows.Controls;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.Views.Interfaces;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.ScreenshotAnalysis
{
    /// <summary>
    ///     Interaction logic for AnalyzeScreenshotView.xaml
    /// </summary>
    public partial class AnalyzeScreenshotView : UserControl, IViewMap<AnalyzeScreenshotViewModel>
    {
        public AnalyzeScreenshotView()
        {
            InitializeComponent();
        }
    }
}