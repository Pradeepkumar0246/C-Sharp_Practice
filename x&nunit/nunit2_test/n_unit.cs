using NUnit.Framework;
using ShoppingCartApp;

namespace n_unit
{
    [TestFixture]
    public class ShoppingCartServiceTests
    {
        private static Product P1 => new(1, "Keyboard", 1500.00m);
        private static Product P2 => new(2, "Mouse", 700.00m);

        [Test]
        public void Add_NewItem_IncreasesCount()
        {
            var cart = new ShoppingCartService();

            cart.Add(P1, 2);

            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items, Has.One.Matches<CartItem>(i => i.Quantity == 2 && i.Product.Id == P1.Id));
        }

        [Test]
        public void Add_SameItem_IncrementsQuantity()
        {
            var cart = new ShoppingCartService();

            cart.Add(P1, 1);
            cart.Add(P1, 2);

            Assert.That(cart.Items.Count, Is.EqualTo(1));
            Assert.That(cart.Items, Has.One.Matches<CartItem>(i => i.Quantity == 3));
        }

        [Test]
        public void UpdateQuantity_ToZero_RemovesItem()
        {
            var cart = new ShoppingCartService();
            cart.Add(P1, 1);

            cart.UpdateQuantity(P1.Id, 0);

            Assert.That(cart.Items, Is.Empty);
        }

        [Test]
        public void GetTotal_ReturnsSumOfLineTotals()
        {
            var cart = new ShoppingCartService();
            cart.Add(P1, 2); 
            cart.Add(P2, 1); 

            var total = cart.GetTotal();

            Assert.That(total, Is.EqualTo(3700.00m));
        }
    }
}
