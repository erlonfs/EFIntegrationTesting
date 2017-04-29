﻿using Globalmantics.Domain;
using Globalmantics.Logic;
using Highway.Data;
using Highway.Data.Contexts;
using System;

namespace Globalmantics.UnitTests
{
    public class CartServiceContext : UserServiceContext
    {
        public CartService CartService { get; }

        protected CartServiceContext()
        {
            CartService = new CartService(Repository, new MockLog());
        }

        public void GivenLoyaltyCard()
        {
            throw new NotImplementedException();
        }

        public Cart WhenLoadCart()
        {
            var user = WhenCreateUser();
            return CartService.GetCartForUser(user);
        }

        public void WhenAddItemToCart(Cart cart,
            int quantity = 1)
        {
            CartService.AddItemToCart(cart, "CAFE-314", quantity);
            Context.Commit();
        }

        public static CartServiceContext GivenServices()
        {
            return new CartServiceContext();
        }
    }
}
