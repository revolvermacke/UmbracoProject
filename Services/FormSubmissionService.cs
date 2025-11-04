using Umbraco.Cms.Core.Services;
using UmbracoProjectMax.ViewModels;

namespace UmbracoProjectMax.Services;

public class FormSubmissionService(IContentService contentService)
{
    private readonly IContentService _contentService = contentService;

    public bool SaveCallbackReq(CallbackFormViewModel model)
    {
        try
        {
            var container = _contentService.GetRootContent().FirstOrDefault(x => x.ContentType.Alias == "formSubmissions");
            if (container == null)
                return false;

            var requestName = $"{DateTime.Now:yyyy-MM-dd HH:mm} - {model.Name}";
            var request = _contentService.Create(requestName, container, "callbackRequest");

            request.SetValue("callbackRequestName", model.Name);
            request.SetValue("callbackRequestEmail", model.Email);
            request.SetValue("callbackRequestPhone", model.Phone);
            request.SetValue("callbackRequestOption", model.SelectedOption);

            var savedResult = _contentService.Save(request);
            return savedResult.Success;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
