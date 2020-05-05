﻿using DataAccess.Entities;
using Shared;
using Shared.DTO;
using Shared.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class BookingRepo : IBooking
    {
        private AutogeneratedAlphanumericCode alphanumericCode;
        private CampDBEntities dBEntities;

        public BookingRepo()
        {
            dBEntities = new CampDBEntities();
            alphanumericCode = new AutogeneratedAlphanumericCode();
        }
        
        /// <summary>
        /// Delete booking by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteBooking(int id)
        {
            var entity = dBEntities.BookingDetails.FirstOrDefault(o => o.OrderId == id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                dBEntities.BookingDetails.Remove(entity);
                dBEntities.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Get all the bookings
        /// </summary>
        /// <returns></returns>
        public IList<BookingDTO> GetAllBookings()
        {
            IList<BookingDTO> bookingDTOs = null;
            bookingDTOs = AutoMapper.Mapper.Map<IList<BookingDTO>>(dBEntities.BookingDetails.ToList());
            return bookingDTOs;
        }

        /// <summary>
        /// Get booking by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookingDTO GetBooking(int id)
        {
            BookingDTO bookingDTO = AutoMapper.Mapper.Map<BookingDTO>(dBEntities.BookingDetails.FirstOrDefault(myid => myid.OrderId == id));
            return bookingDTO;
        }

        /// <summary>
        /// Get booking from Booking Number.
        /// </summary>
        /// <param name="bookingNo"></param>
        /// <returns></returns>
        public BookingDTO GetBookingFromBookingNo(string bookingNo)
        {
            BookingDTO bookingDTO = AutoMapper.Mapper.Map<BookingDTO>(dBEntities.BookingDetails.FirstOrDefault(myid => myid.BookingNo == bookingNo));
            return bookingDTO;
        }

        /// <summary>
        /// Update Booking detail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
        public bool UpdateBooking(int id, BookingDTO bookingDTO)
        {
            var entity = dBEntities.BookingDetails.FirstOrDefault(o => o.OrderId == id);
            if (entity == null)
            {
                return false;
            }
            else
            {
                entity.CampId = bookingDTO.CampId;
                entity.TotalDays = bookingDTO.TotalDays;
                entity.ContactNo = bookingDTO.ContactNo;
                entity.BillAddress = bookingDTO.BillAddress;
                entity.CheckIn = bookingDTO.CheckIn;
                entity.CheckOut = bookingDTO.CheckOut;
                entity.Amount = bookingDTO.Amount;
               // entity.BookingNo = bookingDTO.BookingNo;
                entity.State = bookingDTO.State;
                entity.Country = bookingDTO.Country;
                entity.ZIP = bookingDTO.ZIP;
                dBEntities.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Add booking into records
        /// </summary>
        /// <param name="bookingDTO"></param>
        public void AddBooking(BookingDTO bookingDTO)
        {
            int price = dBEntities.Camps.Single(x => x.CampId == bookingDTO.CampId).Price;
            int amount = price * bookingDTO.TotalDays;
           
            dBEntities.spAddBooking(bookingDTO.CampId,bookingDTO.TotalDays,bookingDTO.ContactNo,bookingDTO.BillAddress,bookingDTO.State,
            bookingDTO.Country,bookingDTO.ZIP,bookingDTO.CheckIn,bookingDTO.CheckOut,amount,alphanumericCode.GenerateAlphaNumeric());
            dBEntities.SaveChanges();  
        }




    }
}
