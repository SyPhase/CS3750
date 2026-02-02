using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Stripe.Checkout;
                                // See test results: https://dashboard.stripe.com/acct_1SwO0rLAJ5eoJw83/test/payments
public class StripeOptions      // Follwing Tutorial Setup: https://docs.stripe.com/checkout/quickstart?lang=dotnet
{
    public string option { get; set; }
}

namespace server.Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
              .UseUrls("http://0.0.0.0:4242")
              .UseWebRoot("public")
              .UseStartup<Startup>()
              .Build()
              .Run();
        }
    }

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This test secret API key is a placeholder. Don't include personal details in requests with this key.
            // To see your test secret API key embedded in code samples, sign in to your Stripe account.
            // You can also find your test secret API key at https://dashboard.stripe.com/test/apikeys.
            StripeConfiguration.ApiKey = "sk_test_51SwO0rLAJ5eoJw83N98VDacJKxoaqmUXy6FYpslpSidnNkMRp3iYNs7b9XGOWFKpSEprsisbtOAfMlPoOJU7lp0z00YyAfssgz"; // Sandbox test key, not live
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }

    [Route("create-checkout-session")]
    [ApiController]
    public class CheckoutApiController : Controller
    {
        [HttpPost]
        public ActionResult Create()
        {
            var domain = "http://localhost:4242";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    // Provide the exact Price ID (for example, price_1234) of the product you want to sell
                    Price = "price_1SwQImLAJ5eoJw83iChGYrgi", // Define a product to sell: https://docs.stripe.com/checkout/quickstart?lang=dotnet#line-items
                    Quantity = 1,
                  },
                },
                Mode = "payment", // payment, subscription, or setup: https://docs.stripe.com/checkout/quickstart?lang=dotnet#mode
                SuccessUrl = domain + "/success.html", // customer redirect URL on successful payment
            };
            var service = new SessionService(); // Create checkout session
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url); // Redirect to checkout
            return new StatusCodeResult(303);
        }
    }
}