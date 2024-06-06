﻿using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> _patients;
        public PatientRepository()
        {
            _patients = new Dictionary<int, Patient>();
        }
        int GenerateId()
        {
            if (_patients.Count == 0) return 1;
            int id = _patients.Keys.Max() + 1;
            return id;
        }
        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item)) return null;
            int id = GenerateId();
            _patients[id] = item;
            return _patients[id];
        }

        public bool Delete(int key)
        {
            if (_patients.ContainsKey(key) == false) return false;
            Patient RemovedDoc = _patients[key];
            _patients.Remove(key);
            return true;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0) return null;
            return _patients.Values.ToList();
        }

        public Patient GetById(int key)
        {
            return _patients[key] ?? null;
        }

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.Id) == false) return null;
            _patients[item.Id] = item;
            return _patients[item.Id];
        }
    }
}
