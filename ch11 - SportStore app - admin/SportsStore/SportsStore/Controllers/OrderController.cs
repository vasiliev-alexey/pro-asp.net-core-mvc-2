namespace SportsStore.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    public class OrderController : Controller
    {
        public Cart Cart { get; }

        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            this.Cart = cart;
            this.orderRepository = orderRepository;
        }

        public ViewResult List() => View(orderRepository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            var order = orderRepository.Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                this.orderRepository.SaveOrder(order);
            }

            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!Cart.Lines.Any())
            {
                ModelState.AddModelError(string.Empty, " Корзина пуста!! ");
            }

            if (ModelState.IsValid)
            {
                order.Lines = Cart.Lines.ToArray();
                orderRepository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            Cart.Clear();
            return View();
        }
    }
}