using Infes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infes.Controllers
{
    public class HumanController : Controller
    {
        private IHumanRepository _humanRepository { get; }
        private IManRepository _manRepository { get; }
        public HumanController(IHumanRepository humanRepository)
        {
            _humanRepository = humanRepository;
        }
        public HumanController(IManRepository manRepository)
        {
            _manRepository = manRepository;
        }
        [Route("human/{id}")]
        public ActionResult Index(int id)
        {
            ViewData["Humans"] = id == 0 ? _manRepository.GetAllHumans() : _manRepository.GetHuman(id);
            return View();
        }   
        public ActionResult Country(string name)
        {
            ViewData["Humans"] = _humanRepository.ShowHumansByCountry(name);
            return View();
        }
        public IActionResult DeleteHuman(int humanId)
        {
            try
            {
                _manRepository.DeleteHuman(humanId);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return View();
        }
    }
}
