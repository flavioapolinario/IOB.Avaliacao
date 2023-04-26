using AutoMapper;
using IOB.Application.DTO.Response;
using IOB.Domain.Entidades;
using IOB.Domain.Interfaces.Services;
using IOB.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IOB.WebApp.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private IContatoService _contatoService;

        public ContatoController(ILogger<HomeController> logger, IContatoService contatoService, IMapper mapper)
        {
            _logger = logger;
            _contatoService = contatoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var contatos = await _contatoService.ObterTodosAsync();
            var contatosResponse = _mapper.Map<IEnumerable<ContatoResponse>>(contatos);
            return View(contatosResponse);
        }

        public IActionResult Create()
        {
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
                return  NotFound();                       

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

        private async Task<ContatoModel> ObterContatoAsync(int? id)
        {
            var contato = !id.HasValue ? null : await _contatoService.ObterPorIdAsync(id.Value);

            return _mapper.Map<ContatoModel>(contato);
        }
    }
}