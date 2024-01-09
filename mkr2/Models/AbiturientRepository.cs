using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr2.Models
{
    public class AbiturientRepository
    {
        protected VstupDBContext _db;
        public AbiturientRepository(VstupDBContext db)
        {
            _db = db;
        }

        public List<Abiturient> GetAll()
        {
            return _db.Abiturients.ToList();
        }

        public List<Abiturient> GetByName(string name)
        {
            return _db.Abiturients
                .Where(abitur => abitur.surname == name)
                .ToList();
        }

        public int GetNumOfAbiturientsByScoreAndYear(int year, int score)
        {
            return _db.Abiturients
                .Where(abitur => abitur.graduation_year == year && abitur.total_score >= score)
                .Count();
        }

    }
}
