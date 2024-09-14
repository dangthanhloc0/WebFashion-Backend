
using BACKENDEMO.Data;
using BACKENDEMO.Dtos.Comment;
using BACKENDEMO.Dtos.Product;
using BACKENDEMO.Entity;
using BACKENDEMO.Helps;
using BACKENDEMO.interfaces;
using BACKENDEMO.Mappers;
using BACKENDEMO.Repositoory;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BACKENDEMO.Controllers
{
    [Route("v6/api/Image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly AppplicationDBContext _context;
        private readonly IImageRepository _image;
        private readonly IListImageRepository _Listimage;
        public ImageController(AppplicationDBContext context, IImageRepository image, IListImageRepository listImage)
        {
            _context = context;
            _image = image;
            _Listimage = listImage;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAllImageByProductId([FromRoute] int id) {
            var result =await _Listimage.GetAllListImageAsyncByProductId(id);  
            if(result.Count == 0)
            {
                return BadRequest("Image not found");
            }
            return Ok(result);  
        }
/*
        [HttpPost]
        [Route("{id:int}")]*/
        public async Task<IActionResult> CreateListImage([FromRoute] int id, [FromBody]ImageDto ListStringImage)
        {
            if(ListStringImage == null && ListStringImage.imageUrl.Count == 0) {
                return BadRequest("No image");
            }
            int count = 0;

            foreach (var image in ListStringImage.imageUrl) {
                var imageProduct = new ImageProduct
                {
                    ImageUrl = image
                };
                var IdImage = await _image.SaveImageAsync(imageProduct);
                var ListImage = new listImage
                {
                    productId = id,
                    imageId = IdImage   
                };
                var createListImage = _Listimage.SaveListImageAsync(ListImage);
                count++;
            }

            if(count == ListStringImage.imageUrl.Count)
            {
                return Ok("Create Successed");
            }
            else { 
                return BadRequest("Create failed");
            }
    
        }
    } 
}