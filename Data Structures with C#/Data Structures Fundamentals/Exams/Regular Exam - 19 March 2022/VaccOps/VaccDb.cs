namespace VaccOps
{
    using Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class VaccDb : IVaccOps
    {
        private Dictionary<string, Doctor> doctorsByName;
        private Dictionary<string, Patient> patientsByName;
        private Dictionary<string, List<Patient>> doctorWithPatients;
        private Dictionary<string, Doctor> patientWithDoctor;

        public VaccDb()
        {
            this.doctorsByName = new Dictionary<string, Doctor>();
            this.patientsByName = new Dictionary<string, Patient>();
            this.doctorWithPatients = new Dictionary<string, List<Patient>>();
            this.patientWithDoctor = new Dictionary<string, Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.doctorsByName.Add(doctor.Name, doctor);
            this.doctorWithPatients.Add(doctor.Name, new List<Patient>());
        }

        public void AddPatient(Doctor doctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(doctor.Name))
            {
                throw new ArgumentException();
            }

            this.patientsByName.Add(patient.Name, patient);
            this.doctorWithPatients[doctor.Name].Add(patient);
            this.patientWithDoctor.Add(patient.Name, doctor);
        }

        public void ChangeDoctor(Doctor oldDoctor, Doctor newDoctor, Patient patient)
        {
            if (!this.doctorsByName.ContainsKey(oldDoctor.Name))
            {
                throw new ArgumentException();
            }

            if (!this.doctorsByName.ContainsKey(newDoctor.Name))
            {
                throw new ArgumentException();
            }

            if (!this.patientsByName.ContainsKey(patient.Name))
            {
                throw new ArgumentException();
            }

            this.doctorWithPatients[oldDoctor.Name].Remove(patient);
            this.doctorWithPatients[newDoctor.Name].Add(patient);
            this.patientWithDoctor[patient.Name] = newDoctor;
        }

        public bool Exist(Doctor doctor)
        {
            return this.doctorsByName.ContainsKey(doctor.Name);
        }

        public bool Exist(Patient patient)
        {
            return this.patientsByName.ContainsKey(patient.Name);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return this.doctorsByName.Values;
        }

        public IEnumerable<Doctor> GetDoctorsByPopularity(int populariry)
        {
            return this.doctorsByName.Values
                .Where(d => d.Popularity == populariry);
        }

        public IEnumerable<Doctor> GetDoctorsSortedByPatientsCountDescAndNameAsc()
        {
            return this.doctorsByName.Values
                .OrderByDescending(d => doctorWithPatients[d.Name].Count)
                .ThenBy(d => d.Name);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return this.patientsByName.Values;
        }

        public IEnumerable<Patient> GetPatientsByTown(string town)
        {
            return this.patientsByName.Values
                .Where(p => p.Town == town);
        }

        public IEnumerable<Patient> GetPatientsInAgeRange(int lo, int hi)
        {
            return this.patientsByName.Values
              .Where(p => p.Age >= lo && p.Age <= hi);
        }

        public IEnumerable<Patient> GetPatientsSortedByDoctorsPopularityAscThenByHeightDescThenByAge()
        {
            return this.patientsByName.Values
                .OrderBy(p => patientWithDoctor[p.Name].Popularity)
                .ThenByDescending(p => p.Height)
                .ThenBy(p => p.Age);
        }

        public Doctor RemoveDoctor(string name)
        {
            if (!this.doctorsByName.ContainsKey(name))
            {
                throw new ArgumentException();
            }

            Doctor doctorTobeRemoved = this.doctorsByName[name];

            foreach(Patient patient in this.doctorWithPatients[name])
            {
                this.patientsByName.Remove(patient.Name);
                this.patientWithDoctor.Remove(patient.Name);
            }

            this.doctorsByName.Remove(name);
            this.doctorWithPatients.Remove(name);

            return doctorTobeRemoved;
        }
    }
}
