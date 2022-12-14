
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


        [Test]
        public void GivenDistTimeAndRideStyle_Should_Return_TotalFare_For_Multiple_Rides()
        {
            try
            {
               
                Invoice = new CabInvoiceGenerator();
                Ride[] ride = { new Ride(5, 10, RideStyle.Normal), new Ride(10, 5, RideStyle.Premium) };
                
                double ActualFare = Invoice.CalculateFare(ride);
               
                Assert.AreEqual(ActualFare, 220);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        [Test]
        public void Given_Dist_Time_RideStyle_Return_RideSummary_For_Multiple_Ride()
        {
            try
            {
                //Assembly
                Invoice = new CabInvoiceGenerator();
                Ride[] ride = { new Ride(5, 10, RideStyle.Normal), new Ride(10, 5, RideStyle.Premium) };
                CabMonthlyReport expected = new CabMonthlyReport(220, 2);
                //Act
                object actual = Invoice.CalculateAverage(ride);
                //Assert
                Assert.AreEqual(actual, expected);
            }
            catch (CabInvoiceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}