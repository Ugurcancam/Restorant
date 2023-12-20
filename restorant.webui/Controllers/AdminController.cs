using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using restorant.webui.Dtos.AboutDto;
using restorant.webui.Dtos.BookingDto;
using restorant.webui.Dtos.CategoryDto;
using restorant.webui.Dtos.ContactDto;
using restorant.webui.Dtos.DiscountDto;
using restorant.webui.Dtos.FeatureDto;
using restorant.webui.Dtos.ProductDto;
using restorant.webui.Dtos.TestimonialDto;

namespace restorant.webui.Controllers
{

    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;


        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Categories()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            createCategoryDto.Status = true;
            var response = await client.PostAsync("http://localhost:5033/api/Category", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Categories");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Categories");
            }
            return View();
        }
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Category/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Categories");
            }
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Product/GetProductsWithCategory");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> AddProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categories = (from x in values select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.v = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            createProductDto.Status = true;
            var response = await client.PostAsync("http://localhost:5033/api/Product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Products");
            }
            return View();
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Products");
            }
            return View();
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("http://localhost:5033/api/Category");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData2);
            List<SelectListItem> categories = (from x in values2 select new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            ViewBag.v = categories;


            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Product/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Products");
            }
            return View();
        }
        public async Task<IActionResult> Bookings()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Booking");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddBooking()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/probmlem+json");
            var response = await client.PostAsync("http://localhost:5033/api/Booking", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Bookings");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Bookings");
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }

            return View();
        }
        public async Task<IActionResult> UpdateBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Booking/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Booking/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Bookings");
            }
            return View();
        }
        public async Task<IActionResult> About()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/About");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAbout(CreateAboutDto createAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5033/api/About", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("About");
            }
            return View();
        }
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/About/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("About");
            }
            return View();
        }
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/About/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/About/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("About");
            }
            return View();
        }
        public async Task<IActionResult> Contact()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Contact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5033/api/Contact", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact");
            }
            return View();
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact");
            }
            return View();
        }
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Contact/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Contact");
            }
            return View();
        }
        public async Task<IActionResult> Discount()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Discount");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDiscount(CreateDiscountDto createDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createDiscountDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5033/api/Discount", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Discount");
            }
            return View();
        }
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Discount/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Discount");
            }
            return View();
        }
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Discount/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Discount/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Discount");
            }
            return View();
        }
        public async Task<IActionResult> Feature()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Feature");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFeature(CreateFeatureDto createFeatureDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5033/api/Feature", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Feature");
            }
            return View();
        }
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Feature/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Feature");
            }
            return View();
        }
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Feature/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Feature/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Feature");
            }
            return View();
        }
        public async Task<IActionResult> Testimonial()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5033/api/Testimonial");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5033/api/Testimonial", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Testimonial");
            }
            return View();
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5033/api/Testimonial/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Testimonial");
            }
            return View();
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5033/api/Testimonial/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5033/api/Testimonial/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Testimonial");
            }
            return View();
        }
    }
}