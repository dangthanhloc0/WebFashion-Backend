using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

[ApiController]
[Route("v2/api/images")]
public class ImagesController : ControllerBase
{
    private readonly string _mainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "imgProductMain");
    private readonly string _productImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "imgProducts");
    private readonly string _userAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), "images", "avtUsers"); 
    private readonly string _rateProductImagePath = Path.Combine(Directory.GetCurrentDirectory(), "images", "rateProduct"); 

    // Hàm upload ảnh
    [HttpPost]
    public async Task<IActionResult> UploadImages([FromForm] IFormFileCollection files, [FromQuery] bool isMainImage = false, [FromQuery] bool isUserAvatar = false)
    {
        try
        {
            string uploadPath;

            if (isUserAvatar)
            {
                uploadPath = _userAvatarPath;
            }
            else
            {
                uploadPath = isMainImage ? _mainImagePath : _productImagePath;
            }

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var uploadedUrls = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Lấy tên file gốc
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(uploadPath, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // URL để trả về
                    var folder = isUserAvatar ? "avtUsers" : (isMainImage ? "imgProductMain" : "imgProducts");
                    var url = $"/images/{folder}/{fileName}";

                    uploadedUrls.Add(url);
                }
            }

            return Ok(new { urls = uploadedUrls });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi khi upload file", error = ex.Message });
        }
    }
     [HttpPost("rateProduct")]
    public async Task<IActionResult> UploadReviewImage([FromForm] IFormFileCollection files)
    {
        try
        {
            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(_rateProductImagePath))
            {
                Directory.CreateDirectory(_rateProductImagePath);
            }

            var uploadedUrls = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    // Lấy tên file gốc
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(_rateProductImagePath, fileName);

                    // Lưu file vào thư mục rateProduct
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // Trả về URL của hình ảnh đã tải lên
                    var url = $"/images/rateProduct/{fileName}";
                    uploadedUrls.Add(url);
                }
            }

            return Ok(new { urls = uploadedUrls });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Lỗi khi upload hình ảnh đánh giá", error = ex.Message });
        }
    }


    [HttpDelete]
    public IActionResult DeleteImage([FromQuery] string imageName, [FromQuery] bool isMainImage = false, [FromQuery] bool isUserAvatar = false)
    {
        try
        {
            // Giải mã đường dẫn nếu có
            string decodedImageName = Uri.UnescapeDataString(imageName);

            // Xác định thư mục lưu trữ hình ảnh
            string imagePath = isUserAvatar
                ? _userAvatarPath
                : isMainImage
                    ? _mainImagePath
                    : _productImagePath;

            // Xác định đường dẫn đầy đủ đến tệp
            string filePath = Path.Combine(imagePath, decodedImageName);

            // Kiểm tra nếu thư mục tồn tại
            if (!Directory.Exists(imagePath))
            {
                return NotFound(new { message = "Thư mục không tồn tại" });
            }

            // Kiểm tra nếu file tồn tại
            if (System.IO.File.Exists(filePath))
            {
                // Xóa file
                System.IO.File.Delete(filePath);
                return Ok(new { message = "Xóa hình ảnh thành công" });
            }

            // Trả về lỗi nếu không tìm thấy file
            return NotFound(new { message = "Không tìm thấy hình ảnh" });
        }
        catch (Exception ex)
        {
            // Xử lý lỗi nếu có
            return StatusCode(500, new { message = "Lỗi khi xóa hình ảnh", error = ex.Message });
        }
    }
}
