using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialClient.Models;
using SocialClient.Services;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace SocialClient.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApiService<Account> _MemberService;
        private readonly string MembersAPIUrl;

        public AccountsController(ApiService<Account> MemberService,
                        IOptions<ApiUrls> apiUrls)
        {
            _MemberService = MemberService;
            MembersAPIUrl = apiUrls.Value.MembersAPIUrl;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Account> members = await _MemberService.GetAllAsync(MembersAPIUrl);
            return View(members);
        }

        //[HttpGet]
        //public async Task<IActionResult> Create()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Member Member)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(Member);
        //    }

        //    bool isCreated = await _MemberService.CreateAsync(MembersAPIUrl, Member);
        //    if (isCreated)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Error creating Member. Please try again.");
        //    return View(Member);
        //}

    }
}
