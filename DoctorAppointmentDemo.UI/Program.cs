using DoctorAppointmentDemo.UI.UIEnums;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;

namespace MyDoctorAppointment
{
    public static class Program
    {
        public static void Main()
        {
            var menu = new MenuService();
            menu.Run();
        }
    }
}