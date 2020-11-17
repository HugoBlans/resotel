using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Entities
{
    class RepasJour
    {
        public RepasJour(DateTime date)
        {
            List<Repas> lst = new List<Repas>();
            using (Entities.AppContext context = new Entities.AppContext())
            {
                lst = context.Repas.ToList();
            }
            dateHebdo = date;
            int tempnbRepasMatin = 0, tempsnbRepasmidi = 0;
            foreach (Repas repas in lst)
            {
                if (repas.DateRepas.Date == date.Date)
                {
                    if (repas.EstPetitDejeuner)
                    {
                        tempnbRepasMatin++;
                    }
                    else
                    {
                        tempsnbRepasmidi++;
                    }
                }
            }
            _nbRepasMatin = tempnbRepasMatin;
            _nbRepasMidi = tempsnbRepasmidi;
        }
        private DateTime _dateHebdo;
        public DateTime dateHebdo
        {
            get
            {
                return _dateHebdo;
            }
            set
            {
                _dateHebdo = value;
            }
        }
        private int _nbRepasMatin;
        public int nbRepasMatin
        {
            get
            {
                return _nbRepasMatin;
            }
            set
            {
                _nbRepasMatin = value;
            }
        }
        private int _nbRepasMidi;
        public int nbRepasMidi
        {
            get
            {
                return _nbRepasMidi;
            }
            set
            {
                _nbRepasMidi = value;
            }
        }
    }
}
