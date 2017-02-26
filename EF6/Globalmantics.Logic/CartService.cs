﻿using Globalmantics.DAL;
using Globalmantics.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Globalmantics.Logic
{
    public class CartService
    {
        private readonly GlobalmanticsContext _context;

        public CartService(GlobalmanticsContext context)
        {
            _context = context;
        }

        public Cart GetCartForUser(User user)
        {
            var cart = _context.Carts
                .Include("CartItems")
                .FirstOrDefault(x => x.UserId == user.UserId);

            if (cart == null)
            {
                cart = _context.Carts.Add(new Cart
                {
                    UserId = user.UserId,
                    CartItems = new List<CartItem>()
                });
            }

            return cart;
        }
    }
}