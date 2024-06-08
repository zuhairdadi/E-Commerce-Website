﻿using Ecommerce_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace E_Commerce_Website.Controllers
{
	public class CustomerController : Controller

	{
		private myContext _Context;
        private IWebHostEnvironment _env;
        public CustomerController(myContext Context, IWebHostEnvironment env)
		{
			_Context = Context;
            _env = env;
        }
		public IActionResult Index()
		{
			List<Ecommerce_Website.Models.Category> category = _Context.tbl_category.ToList();
			ViewData["category"] = category;
            List<Ecommerce_Website.Models.Product> products = _Context.tbl_product.ToList();
            ViewData["product"] = products;
            ViewBag.checkSession = HttpContext.Session.GetString("customerSession");
			return View();
		}
		public IActionResult customerLogin()
		{
			return View();
		}
		[HttpPost]
        public IActionResult customerLogin(string customerEmail, string customerPassword)
        {
			var customer = _Context.tbl_customer.FirstOrDefault(c => c.customer_email == customerEmail);
            if(customer!=null && customer.customer_password == customerPassword)
			{
				HttpContext.Session.SetString("customerSession", customer.customer_id.ToString());
				return RedirectToAction("Index");
			}
			else
			{
				ViewBag.message = "incorrect username or password";
				return View();
			}
        }
        public IActionResult CustomerRegisteration()
        {
            return View();
        }
		[HttpPost]
		public IActionResult CustomerRegisteration(Customer customer)
		{
			_Context.tbl_customer.Add(customer);
			_Context.SaveChanges();
			return RedirectToAction("customerLogin");

		}
		public IActionResult customerLogout()
		{
			HttpContext.Session.Remove("customerSession");
			return RedirectToAction("Index");
		}
		public IActionResult customerProfile()
		{
			if(string.IsNullOrEmpty(HttpContext.Session.GetString("customerSession")))
			{
				return RedirectToAction("customerLogin");
			}
			else
			{
                List<Ecommerce_Website.Models.Category> category = _Context.tbl_category.ToList();
                ViewData["category"] = category;
                var customerId = HttpContext.Session.GetString("customerSession");
                var row = _Context.tbl_customer.Where(c => c.customer_id == int.Parse(customerId)).ToList();
                return View(row);
               
            }
            
		}
		public IActionResult updateCustomerProfile(Customer customer)
		{
			_Context.tbl_customer.Update(customer);
			_Context.SaveChanges();
			return RedirectToAction("customerProfile");
		}
		public IActionResult changeProfileImage(Customer customer, IFormFile customer_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "customer_images", customer_image.FileName);
            FileStream fs = new FileStream(ImagePath, FileMode.Create);
            customer_image.CopyTo(fs);
            customer.customer_image = customer_image.FileName;
            _Context.tbl_customer.Update(customer);
            _Context.SaveChanges();
           
            return RedirectToAction("customerProfile");
		}
		public IActionResult feedback()
		{
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;
            return View(); 
		}
		[HttpPost]
		public IActionResult feedback(Feedback feedback)
		{
			TempData["message"] = "Feedback Successfully submitted";
			_Context.tbl_feedback.Add(feedback);
			_Context.SaveChanges();
			return RedirectToAction("feedback");
		}
		public IActionResult fetchAllProducts()
		{
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;
            List<Ecommerce_Website.Models.Product> products = _Context.tbl_product.ToList();
            ViewData["product"] = products;
            return View();
		}
		public IActionResult productDetails(int id)
		{
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;

			var products = _Context.tbl_product.Where(p=>p.product_id == id).ToList();
			return View(products);
        }

		public IActionResult AddToCart(int prod_id , Cart cart)
		{
           string isLogin =  HttpContext.Session.GetString("customerSession");
			if(isLogin != null)
			{
                cart.prod_id = prod_id;
                cart.cust_id = int.Parse(isLogin);
                cart.product_quantity = 1;
                cart.cart_status = 0;
                _Context.tbl_cart.Add(cart);
                _Context.SaveChanges();
                TempData["message"] = "Product Added In Cart.";
                return RedirectToAction("fetchAllProducts");
            }
			else
			{
				
                return RedirectToAction("customerLogin");
            }
            

		}
		public IActionResult fetchCart()
		{
            List<Category> category = _Context.tbl_category.ToList();
            ViewData["category"] = category;
			string customerId = HttpContext.Session.GetString("customerSession");
			if (customerId != null)
			{
				var cart = _Context.tbl_cart.Where(c => c.cust_id == int.Parse(customerId)).Include(c => c.products).ToList();
				return View(cart);
			}
			else
			{
				return RedirectToAction("customerLogin");
			}
		}
		public IActionResult removeProduct(int id)
		{
			var product = _Context.tbl_cart.Find(id);
			_Context.tbl_cart.Remove(product);
			_Context.SaveChanges();
			return RedirectToAction("fetchCart");
		}
	}
}