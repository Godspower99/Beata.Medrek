using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beata.Medrek
{
   public static class DbCRUDExtensions
    {

        /// <summary>
        /// Add Patient DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="staff"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatient(this ApplicationDbContext dbContext,Patient patient)
        {
            try
            {
                dbContext.Patients.Add(patient);
                dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw (e);
            }
            return true;
        }

        /// <summary>
        /// Delete Patient DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="staff"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool DeletePatient(this ApplicationDbContext dbContext,Patient patient)
        {
            try
            {
                dbContext.Patients.Remove(patient);
                dbContext.SaveChanges();
            }

            catch (Exception e)
            {
                throw (e);
            }
            return true;
        }

        /// <summary>
        /// Edit Patient DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="staff"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool EditPatient(this ApplicationDbContext dbContext,Patient patient)
        {
            try
            {
                dbContext.Patients.Update(patient);
                dbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw (e);
            }
            return true;
        }

        /// <summary>
        /// Find single Patient DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="patient"></param>
        /// <returns><see cref="Patient"/></returns>
        public static Patient FindPatient(this ApplicationDbContext dbContext,Patient patient)
        {
            try
            {
                return dbContext.Patients.FirstOrDefault(p=>p.MedRekNO==patient.MedRekNO);
            }

            catch(Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// Get All Patient in Database DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns><see cref="List{Patient}"/></returns>
        public static List<Patient> GetAllPatients(this ApplicationDbContext dbContext)
        {
            try
            {
                return dbContext.Patients.ToList();
            }

            catch(Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// Add Patient Note DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Notes"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatientNote(this ApplicationDbContext dbContext,PatientsNotes Notes)
        {
            try
            {
                dbContext.PatientsNotes.Add(Notes);
                dbContext.SaveChanges();
                return true;
            }

            catch(Exception e) { throw (e); }
        }

        /// <summary>
        /// Add Patient Family Contact DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Notes"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatientFamilyContact(this ApplicationDbContext dbContext, FamilyContact familyContact)
        {
            try
            {
                dbContext.PatientFamilyContacts.Add(familyContact);
                dbContext.SaveChanges();
                return true;
            }

            catch (Exception e) { throw (e); }
        }

        /// <summary>
        /// Add Patient Address DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Notes"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatientAddress(this ApplicationDbContext dbContext, PatientAddress address)
        {
            try
            {
                dbContext.PatientsAddresses.Add(address);
                dbContext.SaveChanges();
                return true;
            }

            catch (Exception e) { throw (e); }
        }

        /// <summary>
        /// Add Patient Origin Of Birth DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Notes"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatientOriginOfBirth(this ApplicationDbContext dbContext, PatientOriginOfBirth originOfBirth)
        {
            try
            {
                dbContext.PatientOriginOfBirth.Add(originOfBirth);
                dbContext.SaveChanges();
                return true;
            }

            catch (Exception e) { throw (e); }
        }

        /// <summary>
        /// Add Patient Phone Contact DbContext Extension
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="Notes"></param>
        /// <returns><see cref="bool"/></returns>
        public static bool AddPatientPhone(this ApplicationDbContext dbContext, PatientPhone phone)
        {
            try
            {
                dbContext.PatientPhones.Add(phone);
                dbContext.SaveChanges();
                return true;
            }

            catch (Exception e) { throw (e); }
        }


    }
}
