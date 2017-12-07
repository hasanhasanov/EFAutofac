﻿using FluentValidation.Attributes;

namespace WebDoctor.Models
{
    [Validator(typeof(UpdateArticleValidator))]
    public class UpdateArticleModel
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}