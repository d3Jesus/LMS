using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Helpers;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorUI.Pages.Dashboard.Categories
{
    public partial class UpdateCategory : ComponentBase
    {
        [Inject]
        public ICategoryService Service { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private Category category = new Category();

        [Parameter]
        public int categoryId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var response = await Service.GetByAsync(categoryId);
            category = response.ResponseData;
        }

        public async Task OnValidSubmit()
        {
            var message = string.Empty;
        
            var result = await Service.UpdateAsync(category);
            if(result.Succeeded)
                message = ResponseStatus.SUCCESS;
            else
                message = ResponseStatus.ERROR;

            NavigationManager.NavigateTo($"categories/{message}", true);
        }
    }
}
