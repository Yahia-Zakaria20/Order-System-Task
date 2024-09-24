using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderSystem.CoreLayer.RepositoryLayer.Contract;
using OrderSystem.Dtos;
using OrderSystem.Errors;
using Talabat.Rev.CoreLayer.Entites;

namespace OrderSystem.Controllers
{
   
    public class BasketController:BaseApiController
    {
        private readonly IBasketRepositry _repositry;
        private readonly IMapper _mapper;

        ///post , get ,delet

        public BasketController(IBasketRepositry repositry,
            IMapper mapper)
        {
            _repositry = repositry;
           _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id) 
        {

            var result = await  _repositry.GetCustomerBasketAsync(id);

                return Ok(result ?? new CustomerBasket(id));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBasket(string id)
        {
           var result  =  await _repositry.DeleteCustomerBasketAsync(id);

            if(result)
                return Ok();

            return BadRequest(new ApiResponse(400));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdateBasket(CustomerBasketDto customerBasket) 
        {

          var customerbasket = _mapper.Map<CustomerBasketDto,CustomerBasket>(customerBasket);

          var result = await  _repositry.UpdateCustomerBasketAsync(customerbasket);

            if(result is not null) 
                return Ok(result);

            return BadRequest(new ApiResponse(400));
        }

    }
}
