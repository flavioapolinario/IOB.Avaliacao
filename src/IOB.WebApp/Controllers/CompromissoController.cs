using AutoMapper;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Services;
using IOB.Domain.Services;
using IOB.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IOB.WebApp.Controllers
{
    public class CompromissoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private ICompromissoService _compromissoService;

        public CompromissoController(ILogger<HomeController> logger, IMapper mapper, ICompromissoService compromissoService)
        {
            _logger = logger;
            _mapper = mapper;
            _compromissoService = compromissoService;
        }

        public async Task<IActionResult> Index()
        {
            var compromissos = await _compromissoService.ObterTodosAsync();
            var compromissosResponse = _mapper.Map<IEnumerable<CompromissoResponse>>(compromissos);

            return View(compromissosResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string filtro, DateTime? dataCompromisso)
        {
            var compromissos = string.IsNullOrEmpty(filtro) && !dataCompromisso.HasValue
               ? await _compromissoService.ObterTodosAsync()
               : await _compromissoService.ObterPorFiltroAsync(
                    filter: p => p.Titulo.Contains(filtro)
                    || p.Descricao.Contains(filtro)
                    || (dataCompromisso.HasValue && p.DataCompromisso.Date == dataCompromisso.Value.Date));

            var compromissosResponse = _mapper.Map<IEnumerable<CompromissoResponse>>(compromissos);

            return View(compromissosResponse);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompromissoModel compromissoRequest)
        {
            if (ModelState.IsValid)
            {
                var compromisso = _mapper.Map<Compromisso>(compromissoRequest);
                await _compromissoService.AdicionarAsync(compromisso);

                TempData["ResultOk"] = "Compromisso cadastro!";
                return RedirectToAction("Index");
            }

            return View(compromissoRequest);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var compromisso = await ObterCompromissoAsync(id);
            if (compromisso is null)
                return NotFound();

            return View(compromisso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarCompromisso(CompromissoModel compromissoRequest)
        {
            if (ModelState.IsValid)
            {
                var compromisso = _mapper.Map<Compromisso>(compromissoRequest);
                await _compromissoService.AtualizarAsync(compromisso);

                TempData["ResultOk"] = "Compromisso Atualizado!";
                return RedirectToAction("Index");
            }

            return View(compromissoRequest);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var compromisso = await ObterCompromissoAsync(id);

            if (compromisso is null)
                return NotFound();

            ViewBag.Desabilitar = true;

            return View(compromisso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarCompromisso(int? id)
        {
            var compromisso = await ObterCompromissoAsync(id);
            if (compromisso is null)
                return NotFound();

            await _compromissoService.RemoverPorIdAsync(id.Value);

            TempData["ResultOk"] = "Compromisso Removido!";
            return RedirectToAction("Index");
        }

        private async Task<CompromissoModel> ObterCompromissoAsync(int? id)
        {
            var compromisso = !id.HasValue ? null : await _compromissoService.ObterPorIdAsync(id.Value);
            return _mapper.Map<CompromissoModel>(compromisso);
        }

    }
}
