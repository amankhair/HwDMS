using System.Collections.Generic;
using System.Linq;
using WpfDMS.DAL;
namespace WpfDMS.BAL.Admin
{
    public class Admin
    {
        public static DmsDB db = new DmsDB();

        #region Laboratories methods
        public List<Laboratory> GetLaboratoryTable()
        {
            return db.Laboratory.ToList();
        }

        public List<Laboratory> FindLaboratory(string labName)
        {
            return db.Laboratory.Where(w => w.lab_name == labName).ToList();
        }

        public void AddLaboratory(Laboratory lab)
        {
            db.Laboratory.Add(lab);
            db.SaveChanges();
        }

        public void DeleteLaboratory(Laboratory lab)
        {
            db.Laboratory.Remove(lab);
            db.SaveChanges();
        }
        #endregion

        #region Patient Table methods
        public List<Patient> GetPatientsTable()
        {
            return db.Patient.ToList();
        }

        public List<Patient> FindPatient(string patName)
        {
            return db.Patient.Where(w => w.p_name == patName).ToList();
        }

        public void AddNewPatient(Patient pt)
        {
            db.Patient.Add(pt);
            db.SaveChanges();
        }

        public void DeletePatient(Patient pt)
        {
            db.Patient.Remove(pt);
            db.SaveChanges();
        }
        #endregion

        #region Doctor Table methods
        public List<Doctor> GetDoctorsTable()
        {
            return db.Doctor.ToList();
        }

        public List<Doctor> FindDoctor(string docName)
        {
            return db.Doctor.Where(w => w.d_name == docName).ToList();
        }

        public void AddNewDoctor(Doctor doc)
        {
            db.Doctor.Add(doc);
            db.SaveChanges();
        }

        public void DeleteDoctor(Doctor doc)
        {
            db.Doctor.Remove(doc);
            db.SaveChanges();
        }
        #endregion

        #region Test Table meyhods
        public List<Test> GetTestsTable()
        {
            return db.Test.ToList();
        }

        public List<Test> FindTest(string name)
        {
            return db.Test.Where(w => w.t_name == name).ToList();
        }

        public void AddNewTest(Test tt)
        {
            db.Test.Add(tt);
            db.SaveChanges();
        }

        public void DeleteTest(Test tt)
        {
            db.Test.Remove(tt);
            db.SaveChanges();
        }
        #endregion

        #region Login Methods

        public List<Patient> CheckLogin(string login)
        {
            return db.Patient.Where(w => w.p_login == login).ToList();
        }

        #endregion

    }
}
