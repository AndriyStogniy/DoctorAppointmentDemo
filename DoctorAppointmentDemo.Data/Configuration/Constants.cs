namespace MyDoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        // заменить на путь валидный для вашей директории на пк (в будущем будем использовать относительный путь)
        //public const string AppSettingsPath = "C:\\Users\\VEC-PC-155\\Git\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.json";
        public static string AppSettingsPath =>
            Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\DoctorAppointmentDemo.Data\Configuration\appsettings.json");
    }
}
