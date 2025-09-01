using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartApp
{
    public record Product(int Id, string Name, decimal Price);

    public record CartItem(Product Product, int Quantity)
    {
        public decimal LineTotal => Product.Price * Quantity;
    }

    public sealed class ShoppingCartService
    {
        private readonly Dictionary<int, CartItem> _items = new();

        public IReadOnlyCollection<CartItem> Items => _items.Values.ToList().AsReadOnly();

        public void Add(Product product, int quantity = 1)
        {
            if (product is null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            if (_items.TryGetValue(product.Id, out var existing))
            {
                _items[product.Id] = existing with { Quantity = existing.Quantity + quantity };
            }
            else
            {
                _items[product.Id] = new CartItem(product, quantity);
            }
        }

        public void UpdateQuantity(int productId, int newQuantity)
        {
            if (newQuantity < 0) throw new ArgumentOutOfRangeException(nameof(newQuantity));

            if (!_items.ContainsKey(productId)) return;

            if (newQuantity == 0)
                _items.Remove(productId);
            else
                _items[productId] = _items[productId] with { Quantity = newQuantity };
        }

        public void Remove(int productId) => _items.Remove(productId);

        public decimal GetTotal() => _items.Values.Sum(i => i.LineTotal);
    }
}
