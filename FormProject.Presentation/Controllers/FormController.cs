using FormProject.Application.Models.DTOs;
using FormProject.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormProject.Presentation.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        public readonly IFormService _formService;
        public readonly IFieldService _fieldService;
        public readonly IAppUserService _appUserService;

        public FormController(IFormService formService, IFieldService fieldService, IAppUserService appUserService)
        {
            _formService = formService;
            _fieldService = fieldService;
            _appUserService = appUserService;
        }

        public async Task<IActionResult> Index()
        {
            var field = await _fieldService.CreateField();
            ViewBag.DataTypes = new SelectList(field.DataTypes);

            if (TempData["searchString"] != null)
            {

                string searchString = ((string[])(TempData["searchString"]))[0]; //Search barın kullanılabilmesi için eklendi.
                ViewBag.Forms = await _formService.GetForms(searchString); // yapılan aramada kullanılan kelime formun name propertysi içerisinde bulunuyorsa sonuçları gösteriyor
                return View();
            }
            ViewBag.Forms = await _formService.GetForms();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFormDTO model, IFormCollection collection)
        {

            var field = await _fieldService.CreateField();

            var isRequired = collection["isRequired"].ToList();
            var forWhat = collection["forWhat"].ToList();
            var dataType = collection["dataType"].ToList(); // Fieldlardan gelen bilgiler burada tutulmakta

            for (int i = 0; i < isRequired.Count; i++) // collection içerisinde dönülerek, fieldlar teker teker modele eklenmektedir
            {
                CreteFieldDTO creteFieldDTO = new CreteFieldDTO();
                creteFieldDTO.Required = isRequired[i] == "true" ? true : false;
                creteFieldDTO.Name = forWhat[i];
                foreach (var item in field.DataTypes)
                {
                    if (item.ToString() == dataType[i])
                    {
                        creteFieldDTO.DataType = item;
                        break;
                    }
                }
                await _formService.AssignFieldToForm(model, creteFieldDTO);

            }

            int userId = await _appUserService.UserId(User.Identity.Name);
            model.CreatedBy = userId;
            await _formService.Create(model);
            return RedirectToAction("index");

        }
        [Route("forms/{id}")]
        public async Task<IActionResult> FormDetail(int id)
        {

            return View(await _formService.GetFormDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> GetFormByName()
        {
            var searchString = Request.Form["searchString"];
            TempData["searchString"] = searchString;
            return RedirectToAction("Index"); // Search barda arama yapıldığı zaman öncelikle bu action method çalışmaktadır.
        }

    }
}
