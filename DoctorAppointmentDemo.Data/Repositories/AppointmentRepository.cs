using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }
        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = System.IO.Path.GetFullPath((string)result.Database.Appointments.Path, AppContext.BaseDirectory);
            LastId = result.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            Console.WriteLine();
            Console.WriteLine($"Id: {appointment.Id}");
            Console.WriteLine($"DoctorId: {appointment.Doctor?.Id}");
            Console.WriteLine($"PatientId: {appointment.Patient?.Id}");
            Console.WriteLine($"From: {appointment.DateTimeFrom}");
            Console.WriteLine($"To: {appointment.DateTimeTo}");
            Console.WriteLine($"Description: {appointment.Description}");
        }

        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
