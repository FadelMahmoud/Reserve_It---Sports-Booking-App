﻿using SportsBookingApp.Models;
using SportsBookingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SportsBookingApp.ViewModels
{
    public class AdminBookingHistoryViewModel : BaseViewModel
    {
        double totalPerDay_ForBookingsTotalMoney;
        public AdminBookingHistoryViewModel(string selectedsportname, string Centername)
        {
            CenterName = Centername;
            SelectedSportName = selectedsportname;

            Courts = new ObservableCollection<Court>();
            Bookings = new ObservableCollection<Booking>();

            //b = new ObservableCollection<Booking>();
            //TotalRevenueForTheCourtPerDay = new ObservableCollection<double>();
            /*
            CourtCopyyy = new ObservableCollection<CourtCopy>();
            BookingsCopyyy = new ObservableCollection<BookingsCopy>();
            */

            //GetCourtsAndBookings(Centername, selectedsportname, bookingsdate);
            /*
            GetCourts(Centername, selectedsportname);
            GetBookings(Centername, selectedsportname, bookingsdate);
            */

        }
        public AdminBookingHistoryViewModel(string selectedsportname, string Centername, DateTime bookingsdate)
        {
            CenterName = Centername;
            SelectedSportName = selectedsportname;

            Courts = new ObservableCollection<Court>();
            Bookings = new ObservableCollection<Booking>();

            //b = new ObservableCollection<Booking>();
            //TotalRevenueForTheCourtPerDay = new ObservableCollection<double>();

            /*
            CourtCopyyy = new ObservableCollection<CourtCopy>();
            BookingsCopyyy = new ObservableCollection<BookingsCopy>();
            */

            GetCourtsAndBookings(Centername, selectedsportname, bookingsdate);
            /*
            GetCourts(Centername, selectedsportname);
            GetBookings(Centername, selectedsportname, bookingsdate);
            */
        }

        public ObservableCollection<Court> Courts { get; set; }
        /*
        private ObservableCollection<Court> _Courts;
        public ObservableCollection<Court> Courts
        {
            get { return _Courts; }
            set
            {
                _Courts = value;
                OnpropertyChanged();

            }
        }
        */
        public ObservableCollection<Booking> Bookings { get; set; }

        //public ObservableCollection<Booking> b { get; set; }

        private string _CenterName;
        public string CenterName
        {
            get { return _CenterName; }
            set
            {
                _CenterName = value;
                OnpropertyChanged();

            }
        }

        private string _SelectedSportName;
        public string SelectedSportName
        {
            get { return _SelectedSportName; }
            set
            {
                _SelectedSportName = value;
                OnpropertyChanged();

            }
        }


        //public ObservableCollection<double> TotalRevenueForTheCourtPerDay { get; set; }
        /*
        private double _TotalRevenueForTheCourtPerDay;
        public double TotalRevenueForTheCourtPerDay
        {
            get { return _TotalRevenueForTheCourtPerDay; }
            set
            {
                _TotalRevenueForTheCourtPerDay = value;
                OnpropertyChanged();

            }
        }
        */
        /*
        private async void GetCourts(string selectedCenterName, string selectedSportName)
        {
            var data = await new CourtDataService().GetCourtsNamesBySportAndCenterAsync(selectedCenterName, selectedSportName);

            CourtsNames.Clear();
            foreach (var item in data)
            {
                CourtsNames.Add(item);
            }

        }
        */
        /*
        public ObservableCollection<CourtCopy> CourtCopyyy { get; set; }
        public ObservableCollection<BookingsCopy> BookingsCopyyy { get; set; }
        */
        /*
        private async void GetCourtsAndBookings(string selectedCenterName, string selectedSportName, DayOfWeek bookingsDate)
        {
            var Courtsdata = await new CourtDataService().GetCourtsDetailsBySportAndCenterAsync(selectedCenterName, selectedSportName);

            Courts.Clear();
            Bookings.Clear();



            foreach (var Courtitem in Courtsdata)
            {
                
                Courts.Add(Courtitem);


                totalPerDay_ForBookingsTotalMoney = 0;

                var Bookingsdata = await new BookingDataService().GetBookedSlotsItemsByCenterAndCourtAndDateAsync(selectedCenterName, Courtitem.CourtName, bookingsDate);
                foreach (var Bookingitem in Bookingsdata)
                {
                    Bookings.Add(Bookingitem);

                    totalPerDay_ForBookingsTotalMoney += Bookingitem.TotalPaymentAmount;

                }

                TotalRevenueForTheCourtPerDay.Add(totalPerDay_ForBookingsTotalMoney);
            }

        }
        */
        private async void GetCourtsAndBookings(string selectedCenterName, string selectedSportName, DateTime bookingsDate)
        {
            var Courtsdata = await new CourtDataService().GetCourtsDetailsBySportAndCenterAsync(selectedCenterName, selectedSportName);

            Courts.Clear();
            //b.Clear();
            //Bookings.Clear();



            foreach (var Courtitem in Courtsdata)
            {
                /*
                return new ObservableCollection<CourtCopy>
            {

                new CourtCopy { CenterName = Courtitem.CenterName, SportName = Courtitem.SportName, SportID = Courtitem.SportID, CourtName = Courtitem.CourtName, MaxReservationATime = Courtitem.MaxReservationATime, CourtPaymentTimeScale = Courtitem.CourtPaymentTimeScale, CourtPaymentCostScale = Courtitem.CourtPaymentCostScale,
                    BookingsCopyyy = new ObservableCollection<BookingsCopy>{ new BookingsCopy { Name = "Mahdy", Time = "04:00 PM", Amount = "RM 100" }, new BookingsCopy { Name = "Tahan", Time = "06:00 PM", Amount = "RM 150" }, new BookingsCopy { Name = "Gerald", Time = "07:00 PM", Amount = "RM 50" } } },

            };
                */


                totalPerDay_ForBookingsTotalMoney = 0;



                Bookings.Clear();
                var Bookingsdata = await new BookingDataService().GetBookedSlotsItemsByCenterAndCourtAndDateAsync(selectedCenterName, Courtitem.CourtName, bookingsDate);
                foreach (var Bookingitem in Bookingsdata)
                {
                    Bookings.Add(Bookingitem);

                    //b.Add(Bookingitem);

                    totalPerDay_ForBookingsTotalMoney += Bookingitem.TotalPaymentAmount;

                }

                //TotalRevenueForTheCourtPerDay.Add(totalPerDay_ForBookingsTotalMoney);


                Courtitem.TotalRevenueForTheCourtPerDay = totalPerDay_ForBookingsTotalMoney;
                //Courtitem.BookingMember.Clear();
                Courtitem.BookingMember = Bookings;
                Courts.Add(Courtitem);


            }

        }
        /*
        public class CourtCopy
        {
            public string CenterName { get; set; }
            public string SportName { get; set; }
            public int SportID { get; set; }
            public int CourtID { get; set; }
            public string CourtName { get; set; }
            public int MaxReservationATime { get; set; }
            public string CourtPaymentTimeScale { get; set; }
            public double CourtPaymentCostScale { get; set; }
            public ObservableCollection<BookingsCopy> BookingsCopyyy{ get; set; }
        }
        public class BookingsCopy
        {
            public string SportName { get; set; }
            public string CourtName { get; set; }
            public string Username { get; set; }
            public string CenterName { get; set; }
            public DateTime StartingBookingTime { get; set; }
            public DateTime EndingBookingTime { get; set; }
            public DayOfWeek BookingDate { get; set; }
            public double TotalPaymentAmount { get; set; }
        }
        
        */
        /*
        private async void GetBookings(string selectedCenterName, string selectedSportName, DayOfWeek bookingsDate)
        {
            var data = await new BookingDataService().GetBookedSlotsItemsByCenterAndCourtAndDateAsync(centerName, courtName, bookingdate);
            BookedSlots.Clear();
            foreach (var item in data)
            {
                BookedSlots.Add(item);
            }

            var d = BookedSlots;
        }
        */
        /*
        public ObservableCollection<Agenda> MyAgenda { get => GetAgenda(); }

        private ObservableCollection<Agenda> GetAgenda()
        {
            return new ObservableCollection<Agenda>
            {

                new Agenda { Topic = "Futsal Court 1", Duration = "07:30 AM - 11:30 AM", Money="RM 150", Color = "#B96CBD", Date = new DateTime(2020, 3, 23),
                    Bookings = new ObservableCollection<Bookings>{ new Bookings { Name = "Aziz", Time = "07:30 AM", Amount="RM 50" }, new Bookings { Name = "MD. Sabbir", Time = "08:30 AM", Amount = "RM 50" }, new Bookings { Name = "Faruk", Time = "10:30 AM", Amount = "RM 50" } } },

                new Agenda { Topic = "Futsal Court 2", Duration = "04:00 PM - 08:00 PM", Money="RM 300", Color = "#00C6AE", Date = new DateTime(2020, 3, 23),
                    Bookings = new ObservableCollection<Bookings>{ new Bookings { Name = "Mahdy", Time = "04:00 PM", Amount = "RM 100" }, new Bookings { Name = "Tahan", Time = "06:00 PM", Amount = "RM 150" }, new Bookings { Name = "Gerald", Time = "07:00 PM", Amount = "RM 50" } } },

            };
        }


        public class Agenda
        {
            public string Topic { get; set; }
            public string Money { get; set; }
            public string Duration { get; set; }
            public DateTime Date { get; set; }
            public ObservableCollection<Bookings> Bookings { get; set; }
            public string Color { get; set; }
        }

        public class Bookings
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public string Amount { get; set; }
        }
        */


    }

}

