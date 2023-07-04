using LMS.BlazorUI.Data.Interfaces;
using LMS.BlazorUI.Data.Models;
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
        private bool responseStatus;
        private string responseMessage;
        private string IsDisabled = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            category = (await Service.GetByAsync(categoryId)).ResponseData;
        }

        public async Task OnValidSubmit()
        {
            IsDisabled = "disabled";
            var result = await Service.UpdateAsync(category);
            responseStatus = result.Succeeded;
            responseMessage = result.Message;
            StateHasChanged();

            await Task.Delay(2000);
            NavigationManager.NavigateTo("categories", true);
        }
    }
}
