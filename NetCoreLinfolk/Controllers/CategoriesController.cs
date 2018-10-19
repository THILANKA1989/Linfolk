using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetCoreLinfolk.Data.Entities;
using NetCoreLinfolk.Data.LinfolkContext;
using NetCoreLinfolk.ViewModels;

namespace NetCoreLinfolk.Controllers
{
    [Route("api/[Controller]")]
    public class CategoriesController : Controller
    {
        private readonly LinfolkContext _context;
        private readonly ILinfolkRepository _repository;
        private readonly ILogger<CategoriesController> _logger;
        private readonly IMapper _mapper;

        public CategoriesController(LinfolkContext context, ILinfolkRepository repository, ILogger<CategoriesController> logger, IMapper mapper)
        {
            _context = context;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Category>,IEnumerable<CategoryViewModel>>(_repository.GetCategories()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get category: {ex}");
                return BadRequest("Failed to get category");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _repository.GetCategoryById(id);
                if (category != null) return Ok(_mapper.Map<Category,CategoryViewModel>(category));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get category: {ex}");
                return BadRequest("Failed to get category");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]CategoryViewModel model)
        {
            // add it to db
            try
            {
                if (ModelState.IsValid)
                {
                    var newCategory = _mapper.Map<CategoryViewModel, Category>(model); 
                    _repository.AddEntity(newCategory);
                   if(_repository.SaveAll())
                    {
                        return Created($"/api/categories/{newCategory.Id}", _mapper.Map< Category, CategoryViewModel>(newCategory));
                    }
                    
                }
                else
                {
                    return BadRequest(ModelState);
                }
                
            }
            catch(Exception ex)
            {
                _logger.LogError($"Failed to save category: {ex}");
            }
            return BadRequest("Failed to save category");
        }
       
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
