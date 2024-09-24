using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.CoreLayer;
using OrderSystem.CoreLayer.Entites;
using OrderSystem.Dtos;
using OrderSystem.Errors;

namespace OrderSystem.Controllers
{
  //2 get , 2 post
    public class ProductController :BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(
            IUnitOfWork unitOfWork,
            IMapper mapper) 
        {
           _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProsuct() 
        {
            var Products = await _unitOfWork.Repositry<Product>().GetAllAsync();
            if(Products is  null ) 
            return NotFound(new ApiResponse(404));

            return Ok(Products);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetById(int Id) 
        {
           var product = await _unitOfWork.Repositry<Product>().GetByIdAsync(Id);

            if (product is null)
                return BadRequest(new ApiResponse(400));
            return Ok(product);
        }
        //Auht And AdminOnly
        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct(ProductDto product)
        {
            var Entity = _mapper.Map<ProductDto, Product>(product);

            _unitOfWork.Repositry<Product>().Create(Entity);

          var Result =await _unitOfWork.CompleteAsync();
            if (Result == 0)
                return BadRequest(new ApiResponse(400));

            return Ok();


        }

        [HttpPost("UpdateProduct")]
        public async Task<ActionResult> UpdateProduct(ProductDto product)
        {
         var Entity =   _mapper.Map<ProductDto, Product>(product);

            _unitOfWork.Repositry<Product>().Update(Entity);

            var Result = await _unitOfWork.CompleteAsync();

            if (Result == 0)
                return BadRequest(new ApiResponse(400));

            return Ok();
        }

    }
}
