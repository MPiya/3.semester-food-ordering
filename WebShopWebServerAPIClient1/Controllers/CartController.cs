﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using WebShop.Models.Session;
using WebShopModel.Model;
using WebShopWebServerAPIClient.ServiceLayer;
using WebShopWebServerAPIClient1.Data;
using WebShopWebServerAPIClient1.Models.ViewModels;

public class CartController : Controller
{
    private readonly AppDbContext _context;

    string baseURL = "https://localhost:7177/";

    private ServiceConnection connectToAPI;
    public CartController(AppDbContext context)
    {
        _context = context;
        connectToAPI = new ServiceConnection();
        
    }





    public IActionResult Index()
    {

        // if.getJson is null then create new List CartItem object
        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        CartViewModel cartVM = new()
        {
            CartItems = cart,
            GrandTotal = cart.Sum(x => x.Quantity * x.Price)
        };

        return View(cartVM);
    }

    public async Task<IActionResult> Add(int id)
    {

        //Consume API
        Product product = new Product();
       
        connectToAPI.UseUrl += "api/products/" + id;
        //Check response
        HttpResponseMessage getData = await connectToAPI.CallServiceGet();

        if (getData.IsSuccessStatusCode)
        {

            string results = getData.Content.ReadAsStringAsync().Result;
            product = JsonConvert.DeserializeObject<Product>(results);
        }

        else
        {
            Console.WriteLine("Error");
        }

        // Product product = await _context.Product.FindAsync(id);


        //WANT THIS LIST CARTiTEM iN   IN ORDERLINE
        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

        if (cartItem == null)
        {
            cart.Add(new CartItem(product));
        }
        else
        {
            cartItem.Quantity += 1;
        }

        HttpContext.Session.SetJson("Cart", cart);

        TempData["Success"] = "The product has been added!";

        return Redirect(Request.Headers["Referer"].ToString());
    }

    public async Task<IActionResult> Decrease(long id)
    {
        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

        CartItem cartItem = cart.Where(c => c.ProductId == id).FirstOrDefault();

        if (cartItem.Quantity > 1)
        {
            --cartItem.Quantity;
        }
        else
        {
            cart.RemoveAll(p => p.ProductId == id);
        }



        if (cart.Count == 0)
        {
            HttpContext.Session.Remove("Cart");
        }
        else
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        TempData["Success"] = "The product has been removed!";

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Remove(long id)
    {
        List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

        cart.RemoveAll(p => p.ProductId == id);

        if (cart.Count == 0)
        {
            HttpContext.Session.Remove("Cart");
        }
        else
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        TempData["Success"] = "The product has been removed!";

        return RedirectToAction("Index");
    }

    public IActionResult Clear()
    {
        HttpContext.Session.Remove("Cart");

        return RedirectToAction("Index");
    }
}
