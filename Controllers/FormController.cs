using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoProjectMax.Services;
using UmbracoProjectMax.ViewModels;

namespace UmbracoProjectMax.Controllers
{
    public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionService formSubmissionService) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
    {
        private readonly FormSubmissionService _formSubmissionService = formSubmissionService;

        public IActionResult HandleCallbackForm(CallbackFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissionService.SaveCallbackReq(model);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong. Please try again.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you! Your request has been recieved and we will contact you soon.";

            return RedirectToCurrentUmbracoPage();
        }

        public IActionResult HandleSupportRequest(SupportRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissionService.SaveSupportRequest(model);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong. Please try again.";
                return RedirectToCurrentUmbracoPage();
            }

            TempData["FormSuccess"] = "Thank you! Your request has been recieved and we will contact you soon.";

            return RedirectToCurrentUmbracoPage();
        }

        public IActionResult HandleQuestionForm(QuestionRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            var result = _formSubmissionService.SaveQuestionSubmission(model);
            if (!result)
            {
                TempData["FormError"] = "Something went wrong. Please try again.";
                return RedirectToCurrentUmbracoPage();
            }
            TempData["FormSuccess"] = "Thank you! Your question has been recieved and we will get back to you soon.";

            return RedirectToCurrentUmbracoPage();
        }
    }
}
