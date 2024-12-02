using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using DataAccess;
using Common;

namespace Domain {
    public class CPersona {
        Persona persona = new Persona();

        public DataTable Mostrar() {
            return persona.listarPersonas();
        }

        public bool AgregarPersona(DPersona p) {
            return persona.agregarPersona(p);
        }

        public bool EliminarPersona(int id) {
            return persona.eliminarPersona(id);
        }

        public bool EditarPersona(DPersona p) {
            return persona.editarPersona(p);
        }
    }
}
