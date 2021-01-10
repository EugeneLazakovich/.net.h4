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
        private ICountryRepository _countryRepository { get; }
        public HumanController(IHumanRepository humanRepository, IManRepository manRepository, ICountryRepository countryRepository)
        {
            _humanRepository = humanRepository;
            _manRepository = manRepository;
            _countryRepository = countryRepository;
        }
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
        [Route("human/{humanId}")]
        public IActionResult District(int humanId)
        {
            var districtId = _manRepository.GetHuman(humanId).Where(c => c.Id == humanId).Select(c => c.DistrictId).FirstOrDefault();
            ViewData["District"] = _countryRepository.GetDistrict(districtId).FirstOrDefault();
            return View();
        }
    }
}
