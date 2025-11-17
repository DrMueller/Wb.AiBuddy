using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.Settings.Provisioning.Services;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.SemKer.Implementation;

public class SemKerProxy : ISemKerProxy
{
    private readonly ISettingsProvider _settingsProvider;
    private const string DeplyomentName = "gpt-4.1";

    private const string ModelId = "gpt-4.1";


    public SemKerProxy(ISettingsProvider settingsProvider)
    {
        _settingsProvider = settingsProvider;
    }

    public async Task<string> AnalyzeScreenshotAsync(string systemMessage, byte[] image)
    {
        var kernelBuilder = Kernel.CreateBuilder();
        kernelBuilder.AddAzureOpenAIChatCompletion(
            DeplyomentName,
            _settingsProvider.AppSettings.OpenAiEndpoint,
            _settingsProvider.AppSettings.OpenAiKey,
            modelId: ModelId);

        var kernel = kernelBuilder.Build();

        var chatMsg = new ChatMessageContent(AuthorRole.User, "Analyze this screenshot.");
        chatMsg.Items.Add(new ImageContent(
            image,
            MediaTypeNames.Image.Jpeg
        ));

        var chat = kernel.GetRequiredService<IChatCompletionService>();

        var sysMsg = new ChatMessageContent(
            AuthorRole.System,
            systemMessage);

        var messages = new List<ChatMessageContent> { sysMsg, chatMsg };

        var reply = await chat.GetChatMessageContentAsync(new ChatHistory(messages));

        return reply.ToString();
    }
}