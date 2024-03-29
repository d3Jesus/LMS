﻿using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Category;

public class AddCategoryDto
{
    [Required(ErrorMessage = "The category name is required.")]
    [StringLength(50, ErrorMessage = "This field only allows {1} characters.")]
    public string CategoryName { get; set; }
}
