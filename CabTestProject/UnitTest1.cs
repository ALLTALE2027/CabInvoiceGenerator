
using CabInvoice;
namespace CabTestProject
{
    public class Tests
    {
        CabInvoiceGenerator Invoice;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(4, 3, RideStyle.Normal, 43)]
        [TestCase(10, 3, RideStyle.Premium, 156)]
        [TestCase(1, 2, RideStyle.Premium, 20)]
        [TestCase(0, 2, RideStyle.Premium, 20)]
        [TestCase(1, 0, RideStyle.Premium, 20)]
        public void GivenDistTimeAndRideStyle_Should_Return_TotalFare_For_Single_Ride(int distance, int time, RideStyle rideStyle, double expected)
        {

            try
            {
                Invoice = new CabInvoiceGenerator();
                Ride ride = new Ride(distance, time, rideStyle);
               
                double actual = Invoice.CalculateFare(ride);

                Assert.AreEqual(actual, expected);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}