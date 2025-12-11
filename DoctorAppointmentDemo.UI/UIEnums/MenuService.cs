using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using MyDoctorAppointment.Domain.Entities;
using MyDoctorAppointment.Service.Interfaces;
using MyDoctorAppointment.Service.Services;
using MyDoctorAppointment.Domain.Enums;

namespace DoctorAppointmentDemo.UI.UIEnums
{
    
    public class MenuService
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public MenuService()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }
        public void Run()
        {
            Menu();
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("=== DOCTOR APPOINTMENT DEMO ===");
                Console.WriteLine("1 - List doctors");
                Console.WriteLine("2 - Add doctor");
                Console.WriteLine("3 - Update doctor");
                Console.WriteLine("4 - Delete doctor");

                Console.WriteLine("5 - List patients");
                Console.WriteLine("6 - Add patient");
                Console.WriteLine("7 - Update patient");
                Console.WriteLine("8 - Delete patient");

                Console.WriteLine("9 - List appointments");
                Console.WriteLine("10 - Add appointment");
                Console.WriteLine("11 - Update appointment");
                Console.WriteLine("12 - Delete appointment");

                Console.WriteLine("0 - Exit");

                Console.Write("Choose: ");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                Console.WriteLine();

                switch ((MenuItem)input)
                {
                    case MenuItem.ListDoctors:
                        ListDoctors();
                        break;

                    case MenuItem.AddDoctor:
                        AddDoctor();
                        break;

                    case MenuItem.UpdateDoctor:
                        UpdateDoctor();
                        break;

                    case MenuItem.DeleteDoctor:
                        DeleteDoctor();
                        break;

                    case MenuItem.ListPatients:
                        ListPatients();
                        break;

                    case MenuItem.AddPatient:
                        AddPatient();
                        break;

                    case MenuItem.UpdatePatient:
                        UpdatePatient();
                        break;

                    case MenuItem.DeletePatient:
                        DeletePatient();
                        break;

                    case MenuItem.ListAppointments:
                        ListAppointments();
                        break;

                    case MenuItem.AddAppointment:
                        AddAppointment();
                        break;

                    case MenuItem.UpdateAppointment:
                        UpdateAppointment();
                        break;

                    case MenuItem.DeleteAppointment:
                        DeleteAppointment();
                        break;

                    case MenuItem.Exit:
                        return;

                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void ListDoctors()
        {
            var doctors = _doctorService.GetAll();
            if (!doctors.Any())
            {
                Console.WriteLine("No doctors found.");
                return;
            }

            foreach (var d in doctors)
                Console.WriteLine($"{d.Id}: {d.Name} {d.Surname}");
        }
        private void AddDoctor()
        {
            Console.Write("Enter doctor name: ");
            string name = Console.ReadLine();
            Console.Write("Enter doctor surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter doctor experience: ");
            byte experience = byte.Parse(Console.ReadLine());
            Console.WriteLine("Doctor types: 1 - Dentist, 2 - Dermatologist, 3 - FamilyDoctor, 4 - Paramedic");
            Console.Write("Chose doctor type: ");
            int type = int.Parse(Console.ReadLine());

            var newDoctor = new Doctor
            {
                Name = name,
                Surname = surname,
                Experience = experience,
                DoctorType = (DoctorTypes)type
            };

            _doctorService.Create(newDoctor);
            
            Console.WriteLine("Doctor added.");
        }
        private void UpdateDoctor()
        {
            Console.Write("Enter doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var existing = _doctorService.Get(id);
            if (existing == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.Write($"Name ({existing.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                existing.Name = name;

            Console.Write($"Surname ({existing.Surname}): ");
            var surname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(surname))
                existing.Surname = surname;

            Console.Write($"Experience ({existing.Experience}): ");
            if (byte.TryParse(Console.ReadLine(), out byte exp))
                existing.Experience = exp;

            _doctorService.Update(id, existing);
            Console.WriteLine("Doctor updated.");
        }
        private void DeleteDoctor()
        {
            Console.Write("Enter doctor ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _doctorService.Delete(id);
                Console.WriteLine("Doctor deleted.");
            }
        }

        private void ListPatients()
        {
            var patients = _patientService.GetAll();
            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in patients)
                Console.WriteLine($"{p.Id}: {p.Name} {p.Surname}");
        }
        private void AddPatient()
        {
            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();
            Console.Write("Enter patient surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter patient additional info: ");
            string additionalInfo = Console.ReadLine();
            Console.WriteLine("Illness Types: 1 - Eye Disease, 2 - Infection, 3 - Dental Disease, 4 - Skin Disease, 5 - Ambulance");
            Console.Write("Chose Illness Type: ");
            int type = int.Parse(Console.ReadLine());

            var newPatient = new Patient
            {
                Name = name,
                Surname = surname,
                AdditionalInfo = additionalInfo,
                IllnessType = (IllnessTypes)type
            };

            _patientService.Create(newPatient);

            Console.WriteLine("Patient added.");
        }
        private void UpdatePatient()
        {
            Console.Write("Enter patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var existing = _patientService.Get(id);
            if (existing == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write($"Name ({existing.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
                existing.Name = name;

            Console.Write($"Address ({existing.Address}): ");
            var address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address))
                existing.Address = address;

            _patientService.Update(id, existing);
            Console.WriteLine("Patient updated.");
        }
        private void DeletePatient()
        {
            Console.Write("Enter patient ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _patientService.Delete(id);
                Console.WriteLine("Patient deleted.");
            }
        }
        private void ListAppointments()
        {
            var appointments = _appointmentService.GetAll();
            if (!appointments.Any())
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var a in appointments)
                Console.WriteLine(
                    $"{a.Id}: DoctorId={a.Doctor.Id}, PatientId={a.Doctor.Id}, Date={a.DateTimeFrom}"
                );
        }
        private void AddAppointment()
        {
            Console.Write("Enter Doctor ID: ");
            int doctorId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine()!);

            Console.Write("Enter date (yyyy-MM-dd HH:mm): ");
            DateTime date = DateTime.Parse(Console.ReadLine()!);

            _appointmentService.Create(new Appointment
            {
                Doctor = _doctorService.Get(doctorId),
                Patient = _patientService.Get(patientId),
                DateTimeFrom = date
            });

            Console.WriteLine("Appointment added.");
        }
        private void UpdateAppointment()
        {
            Console.Write("Enter appointment ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var existing = _appointmentService.Get(id);
            if (existing == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            Console.Write($"Date ({existing.DateTimeFrom}): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                existing.DateTimeFrom = date;
            }

            _appointmentService.Update(id, existing);
            Console.WriteLine("Appointment updated.");
        }
        private void DeleteAppointment()
        {
            Console.Write("Enter appointment ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _appointmentService.Delete(id);
                Console.WriteLine("Appointment deleted.");
            }
        }
    }
}
