using AutoMapper;
using IOB.Application.DTO.Response;
using IOB.Application.Interfaces.Services;
using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Services;
using IOB.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IOB.WebApp.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private IContatoService _contatoService;
        private ICorreiosService _correiosService;

        public ContatoController(ILogger<HomeController> logger, IContatoService contatoService, ICorreiosService correiosService, IMapper mapper)
        {
            _logger = logger;
            _contatoService = contatoService;
            _correiosService = correiosService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contatos = await _contatoService.ObterPorFiltroAsync(includeProperties: "Endereco");
            var contatosResponse = _mapper.Map<IEnumerable<ContatoResponse>>(contatos);

            return View(contatosResponse);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Estados = await ObterEstados();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContatoModel contatoRequest)
        {
            if (ModelState.IsValid)
            {
                var contato = _mapper.Map<Contato>(contatoRequest);
                await _contatoService.AdicionarAsync(contato);

                TempData["ResultOk"] = "Contato cadastro!";
                return RedirectToAction("Index");
            }

            return View(contatoRequest);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var contato = await ObterContatoAsync(id);
            if (contato is null)
                return NotFound();

            ViewBag.Estados = await ObterEstados();
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarContato(ContatoModel contatoRequest)
        {
            if (ModelState.IsValid)
            {
                var contato = _mapper.Map<Contato>(contatoRequest);
                await _contatoService.AtualizarAsync(contato);

                TempData["ResultOk"] = "Contato Atualizado!";
                return RedirectToAction("Index");
            }

            return View(contatoRequest);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var contato = await ObterContatoAsync(id);

            if (contato is null)
                return NotFound();

            ViewBag.Estados = await ObterEstados();
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarContato(int? id)
        {
            var contato = await ObterContatoAsync(id);
            if (contato is null)
                return NotFound();

            await _contatoService.RemoverPorIdAsync(id.Value);

            TempData["ResultOk"] = "Contato Removido!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> ObterEnderecoPorCep(string cep)
        {
            var endereco = await _correiosService.ObterEnderecoPorCepAsync(cep);
            return Json(endereco);
        }

        private async Task<ContatoModel> ObterContatoAsync(int? id)
        {
            var contato = !id.HasValue ? null : await _contatoService.ObterPorFiltroAsync(p => p.Id.Equals(id.Value), includeProperties: "Endereco");

            return _mapper.Map<ContatoModel>(contato?.FirstOrDefault());
        }

        private async Task<ICollection<SelectListItem>?> ObterEstados()
        {
            var estados = await _correiosService.ObterUfAsync();

            return estados?.OrderBy(p => p.Nome).Select(c => new SelectListItem()
            {
                Text = c.Nome,
                Value = c.Sigla
            }).ToList();
        }
    }
}