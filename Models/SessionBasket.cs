﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission9_twilso48.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mission9_twilso48.Models
{
    public class SessionBasket : Basket
    {

        public static Basket GetBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();

            basket.Session = session;

            return basket;
        }


        [JsonIgnore]
        public ISession Session { get; set; }

        //methods 

        public override void AddItem(Books book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }
        // Remove Item
        public override void RemoveItem(Books book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);

        }
        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");

        }
    }
}