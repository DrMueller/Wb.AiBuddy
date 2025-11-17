using JetBrains.Annotations;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Commands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.Components.CommandBars.ViewData;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.CommandManagement.ViewModelCommands;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels;
using Mmu.Mlh.WpfCoreExtensions.Areas.MvvmShell.ViewModels.Behaviors;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Mediation.Services;

namespace Mmu.Wb.TimeBuddy.WpfUI.Areas.ScreenshotAnalysis
{
    [PublicAPI]
    public class AnalyzeScreenshotViewModel : ViewModelBase, INavigatableViewModel
    {
        private readonly IMediationService _mediator;

        private string _analysisInput;

        private string _analysisResult;
        private string _defaultInput =
            "You are an AI assistant that helps users understand the content of their computer screenshots. You will receive screenshots with single- or multiple-choice questions. Answer them as brief as possibly, if possible in one word or sentence.";

        public AnalyzeScreenshotViewModel(IMediationService mediator)
        {
            _mediator = mediator;
            Commands = new CommandsViewData(AnalyzeScreenshot);
            AnalysisInput = _defaultInput;
        }

        public string AnalysisInput
        {
            get => _analysisInput;
            set => OnPropertyChanged(value, ref _analysisInput);
        }

        public string AnalysisResult
        {
            get => _analysisResult;
            set => OnPropertyChanged(value, ref _analysisResult);
        }
        public CommandsViewData Commands { get; private set; }
        public string HeadingDescription { get; } = "Analyze Screenshot";
        public string NavigationDescription { get; } = "Screenshot Analysis";
        public int NavigationSequence { get; } = 1;

        private IViewModelCommand AnalyzeScreenshot =>
            new ViewModelCommand(
                "Analyze Screenshot",
                new AsyncRelayCommand(async () =>
                {
                    AnalysisResult = await _mediator.SendAsync(new AnalyzeScreenshotQuery(AnalysisInput));
                }));
    }
}