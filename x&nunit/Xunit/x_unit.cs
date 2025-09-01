using ShoppingCartApp;
using Xunit;

namespace x_unit
{
    public class ShoppingCartServiceTests
    {
        private static Product P1 => new(1, "Keyboard", 1500.00m);
        private static Product P2 => new(2, "Mouse", 700.00m);

        [Fact]
        public void Add_NewItem_IncreasesCount()
        {
            var cart = new ShoppingCartService();

            cart.Add(P1, 2);

            Assert.Single(cart.Items);
            Assert.Equal(2, Assert.Single(cart.Items).Quantity);
        }

        [Fact]
        public void Add_SameItem_IncrementsQuantity()
        {
            var cart = new ShoppingCartService();

            cart.Add(P1, 1);
            cart.Add(P1, 2);

            Assert.Single(cart.Items);
            Assert.Equal(3, Assert.Single(cart.Items).Quantity);
        }

        [Fact]
        public void UpdateQuantity_ToZero_RemovesItem()
        {
            var cart = new ShoppingCartService();
            cart.Add(P1, 1);

            cart.UpdateQuantity(P1.Id, 0);

            Assert.Empty(cart.Items);
        }

        [Fact]
        public void GetTotal_ReturnsSumOfLineTotals()
        {
            var cart = new ShoppingCartService();
            cart.Add(P1, 2); 
            cart.Add(P2, 1); 
            var total = cart.GetTotal();

            Assert.Equal(3700.00m, total);
        }
    }
}
