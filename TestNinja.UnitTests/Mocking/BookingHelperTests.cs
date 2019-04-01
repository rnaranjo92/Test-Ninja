using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelperTests_OverlappingBookingsExist
    {
        private Booking _existingbooking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _existingbooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2019, 1, 20),
                Reference = "a"
            };

            _repository = new Mock<IBookingRepository>();
            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
            {
                _existingbooking
            }.AsQueryable());
        }
        [Test]
        public void BookingDoesNotOverlapAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingbooking.ArrivalDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingOverlapsInTheMiddleOfAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate),
                DepartureDate = After(_existingbooking.ArrivalDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingbooking.Reference));
        }
        [Test]
        public void BookingOverlapsAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingbooking.ArrivalDate),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingbooking.Reference));
        }
        [Test]
        public void BookingOverlapsInTheMiddleOfAnExistingBookingAndEndsIntheMiddleOfIt_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.ArrivalDate),
                DepartureDate = Before(_existingbooking.DepartureDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingbooking.Reference));
        }
        [Test]
        public void BookingOverlapsInTheStartOfAnExistingBookingButEndsAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.ArrivalDate),
                DepartureDate = After(_existingbooking.DepartureDate),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.EqualTo(_existingbooking.Reference));
        }
        [Test]
        public void BookingStartAndFinishesAfterAnExistingBooking_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.DepartureDate),
                DepartureDate = After(_existingbooking.DepartureDate, days: 2),
                Reference = "a"
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
        [Test]
        public void BookingsOverlapButNewBookingIsCancelled_ReturnEmptyString()
        {
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = After(_existingbooking.DepartureDate),
                DepartureDate = After(_existingbooking.DepartureDate, days: 2),
                Reference = "Cancelled"
            }, _repository.Object);

            Assert.That(result, Is.Empty);
        }
        private DateTime Before(DateTime dateTime,int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        private DateTime After(DateTime dateTime, int days =1)
        {
            return dateTime.AddDays(days);
        }
        private DateTime ArriveOn(int year,int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
