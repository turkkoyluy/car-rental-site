using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int imageId) 
        {
            var result=_carImageService.GetByImageId(imageId);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarid")]
        public IActionResult GetByCarId(int carId) 
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success) 
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage) 
        {
           
           var result = _carImageService.Add(file,carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(int carImageId) 
        {
            var deletedImage=_carImageService.GetByImageId(carImageId).Data;
            var result = _carImageService.Delete(deletedImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage carImage) 
        {
            var updatedImage = _carImageService.GetByImageId(carImage.CarImagesId).Data;
            var result = _carImageService.Update(file,updatedImage);
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
