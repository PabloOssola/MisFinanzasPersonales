using MisFinanzas.Context;
using MisFinanzas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MisFinanzas.Helpers
{
    public class PersonaHelper
    {
        public PersonaHelper() { }

        public Persona addPersona(string username, string email, string password, int idGrupo)
        { 
            Persona newPerson = new Persona();
            newPerson.UserName = username;
            newPerson.Email = email;
            newPerson.Password = password;
            newPerson.IdGrupo = idGrupo;

            Persona p = this.getByEmail(email);
            if (p == null)
            {
                using (var db = new FinanzasContext())
                {
                    db.Personas.Add(newPerson);
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("El Nombre del usuario ya existe");
            }
            return newPerson; 
        }

        public Persona validarPersona(string userName, string password)
        {
            Persona persona = new Persona();
            using (var db = new FinanzasContext())
            {
                persona = (from p in db.Personas where p.UserName.Equals(userName) && p.Password.Equals(password) select p).FirstOrDefault();
            }
            if(persona!= null)
                return persona;
            throw new Exception("Por favor ingrese un usuario o contraseña valida");
        }

        public Persona getById(int id)
        {
            Persona persona = new Persona();
            using (var db = new FinanzasContext())
            {
                persona = db.Personas.Find(id);
            }
            return persona;
        }

        public Persona getByEmail(string email)
        {
            Persona persona = new Persona();
            using (var db = new FinanzasContext())
            {
                persona = (from p in db.Personas where p.Email.Equals(email) select p).FirstOrDefault();
            }
            return persona;
        }

        public void removePersona(int id)
        {
            using (var db = new FinanzasContext())
            {
                var persona = db.Personas.Find(id);
                if (persona != null)
                {
                    db.Personas.Remove(persona);
                    db.SaveChanges();
                }
            }
        }

        public void updatePersona(int id, String description)
        {
            using (var db = new FinanzasContext())
            {
                var persona = db.Personas.Find(id);
                if (persona != null)
                {
                    persona.Password = description;
                    db.SaveChanges();
                }
            }
        }
    }
}