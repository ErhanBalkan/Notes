# Örnek kullanım
```c#
    [HttpGet("getall")]
    //[Authorize()] // Bu şekilde sadece giriş yapması yeterli olur.
    [Authorize(Roles = "Product.List")] 
    // Böyle ise kullanıcının Product.List rolüne sahip olması gereklidir.
    public IActionResult GetAll(){
        var result = _productService.GetAll();
        if(result.Success)
            return Ok(result);
        return BadRequest(result);
    }
```

