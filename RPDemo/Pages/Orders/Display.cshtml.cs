using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPDemo.Pages.Orders
{
    public class DisplayModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public OrderModel Order { get; set; }

        public string ItemPurchased { get; set; }

        public DisplayModel(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        public async Task<IActionResult> OnGet()
        {
            Order = await _orderData.GetOrderById(Id);

            if(Order != null)
            {
                var food = await _foodData.GetFood();

                ItemPurchased = food.Where(x => x.Id == Order.FoodId).FirstOrDefault()?.Title;

            }

            return Page();
        }
    }
}
