using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class AuthorRepository
    {
        protected AuthorDBContext _db;
        public AuthorRepository(AuthorDBContext db)
        {
            _db = db;
        }

        //TaskA простий запит на вибірку;
        public List<Author> GetAll()
        {
            return _db.Authors.ToList();
        }

        //TaskB  запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
        public List<Author> GetByFirstCharsOfName(string frstCharsOfName)
        {
            var authors = _db.Authors
                .Where(auth => auth.name.StartsWith(frstCharsOfName))
                .ToList();

            return authors;
        }

        //TaskC  запит зі складним критерієм;
        public List<Author> GetByTopicAndFirstCharsOfName(string topic, string frstCharsOfName)
        {
            var authors = _db.Authors
                .Where(auth => auth.topic == topic && auth.name.StartsWith(frstCharsOfName))
                .ToList();

            return authors;

        }

        //TaskD  запит з унікальними значеннями;
        public List<string> GetDifferentValues()//string userSelector)
        {
            var distinctValues = _db.Authors
                .Select(auth => auth.topic)
                .Distinct()
                .ToList();

            return distinctValues;
        }

        //TaskE запит з використанням обчислювального поля;
        public string GetAuthorByFirstNameInAlphabet()
        {
            string authorName = _db.Authors
                .Select(auth => auth.name)
                .Min();

            return authorName;
        }

        //TaskF  запит з групуванням по заданому полю, використовуючи умову групування;
        public Dictionary<string, int> GetNumOfAuthorsGropedByTopic()
        {
            var keyValuePairs = _db.Authors
                .GroupBy(auth => auth.topic)
                .Select(obj => new
                {
                    obj.Key,
                    numOfAuths = obj.Count()
                })
                .ToDictionary(x => x.Key, x => x.numOfAuths);
            
            return keyValuePairs;

        }

        //TaskG запит із сортування по заданому полю в порядку зростання та спадання значень;
        public List<Author> GetAuthorsSortedByNameInAscOrDescOrder(string order)
        {
            List<Author> authors;
            if (order == "ASC")
            {
                authors = _db.Authors
                .OrderBy(auth => auth.name)
                .ToList();
            }
            else
            {
                authors = _db.Authors
                    .OrderByDescending(auth => auth.name)
                    .ToList();
            }

            return authors;
        }

        //TaskH запит з використанням дій по модифікації записів.
        public bool UpdateAuthor(Author authorToChange)
        {
            Author author = _db.Authors.Find(authorToChange.Id);

            if(author != null)
            {
                author.name = authorToChange.name;
                author.topic= authorToChange.topic;
                author.title= authorToChange.title;

                _db.SaveChanges();

                return true;
            }
            return false;
        }

    }
}
