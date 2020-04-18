﻿using Microsoft.AspNetCore.Http;


namespace CallingMvc.Dto
{
    public class PhotosDetails
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public IFormFile Photo { get; set; }
    }
}