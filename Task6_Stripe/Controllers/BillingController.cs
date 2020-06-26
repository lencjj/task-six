using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.BillingPortal;

namespace Task6_Stripe.Controllers
{
    [Route("api/Billing")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [Route("CreateSubscription/{planNumber}")]
        public void CreateSubscription([FromRoute] int planNumber)
        {
            StripeConfiguration.ApiKey = "sk_test_51GxEfiHhYK7K9XttqUpv12yjajZLs01TY95VhvzVfPEb5Ed8GaF3GFUV2iuhFZGkBgHoNib4iHBDlpALqWPplth6008EdMnnaw";

            string plan = "";
            if (planNumber == 1)
            {
                plan = "price_1GxFdVHhYK7K9Xttie9i0RqL";
            }
            else if (planNumber == 2)
            {
                plan = "price_1GxEu5HhYK7K9XttdYlMhRBn";
            }
            var options = new SubscriptionCreateOptions
            {
                Customer = "cus_HWIVyLfT0yhlOg",
                Items = new List<SubscriptionItemOptions>
                {
                new SubscriptionItemOptions
                    {
                        Price =plan,
                    },
                },
            };
            var service = new SubscriptionService();
            Subscription subscription = service.Create(options);

        }

        [HttpPost]
        [Route("CreateSession")]
        public ActionResult CreateSession()
        {
            StripeConfiguration.ApiKey = "sk_test_51GxEfiHhYK7K9XttqUpv12yjajZLs01TY95VhvzVfPEb5Ed8GaF3GFUV2iuhFZGkBgHoNib4iHBDlpALqWPplth6008EdMnnaw";

            var options = new SessionCreateOptions
            {
                Customer = "cus_HWIVyLfT0yhlOg",
                ReturnUrl = "https://localhost:44356/Home/Billing",
            };
            var service = new SessionService();
            Session session = service.Create(options);
            return Redirect(session.Url);
        }

    }
}