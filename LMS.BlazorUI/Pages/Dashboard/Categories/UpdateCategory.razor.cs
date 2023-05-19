using LMS.BlazorUI.Data.Models;
using Microsoft.AspNetCore.Components;

namespace LMS.BlazorUI.Pages.Dashboard.Categories
{
    public partial class UpdateCategory : ComponentBase
    {
        private Category category = new Category();

        [Parameter]
        public int categoryId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var response = await Service.GetByAsync(categoryId);
            category = response.ResponseData;
        }

        public void OnValidSubmit()
        {
            var result = Service.UpdateAsync(category);

            NavigationManager.NavigateTo("categories", true);
        }
    }
}
