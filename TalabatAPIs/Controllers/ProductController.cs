using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;
using Talabat.Core.Spesification;
using Talabat.Repository;
using TalabatAPIs.Dtos;
using TalabatAPIs.Errors;

namespace TalabatAPIs.Controllers
{

    public class ProductController : ApiBaseController
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductwithBrandandTypeSpesfication();
            var products = await _genericRepository.GetAllWithSpescAsync(spec);

            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductwithBrandandTypeSpesfication(id);
            var product = await _genericRepository.GetByIdWithSpescAsync(spec);

            if (product is null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<Product,ProductToReturnDto>(product));
        }
    }
}
