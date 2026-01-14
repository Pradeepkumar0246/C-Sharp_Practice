using System.Numerics;

namespace APIRepositoryPattern.Models
{
    public class Hospital
    {
        public string HospitalId { get; set; }
        public string? Name { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
