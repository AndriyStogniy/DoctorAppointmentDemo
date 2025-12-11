using MyDoctorAppointment.Data.Configuration;
using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;

namespace MyDoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }
        public PatientRepository()
        {
            dynamic result = ReadFromAppSettings();

            Path = System.IO.Path.GetFullPath((string)result.Database.Patients.Path, AppContext.BaseDirectory);
            LastId = result.Database.Doctors.LastId;
        }
        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine();
            Console.WriteLine($"Id: {patient.Id}");
            Console.WriteLine($"Name: {patient.Name} {patient.Surname}");
            Console.WriteLine($"Illness: {patient.IllnessType}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Additional: {patient.AdditionalInfo}");
        }
        protected override void SaveLastId()
        {
            dynamic result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        }
    }
}
