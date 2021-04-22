﻿using StoreDB.Models;

namespace StoreLib
{
    public interface ICartService
    {
        void AddCart(Cart cart);
        void DeleteCart(Cart cart);
        Cart GetCartByUserId(int id);
        void UpdateCart(Cart cart);
    }
}