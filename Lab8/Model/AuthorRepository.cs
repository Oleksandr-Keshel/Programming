using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab8.Models
{
    public class AuthorRepository
    {
        protected AuthorDBContext _db;
        public AuthorRepository(AuthorDBContext db)
        {
            _db = db;
        }

        //TaskA простий запит на вибірку;
        public async Task<List<Author>> GetAllAsync()
        {
            return await _db.Authors.ToListAsync();
        }

        //TaskB  запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
        public async Task<List<Author>> GetByFirstCharsOfNameAsync(string frstCharsOfName)
        {
            var authors = await _db.Authors
                .Where(auth => auth.name.StartsWith(frstCharsOfName))
                .ToListAsync();

            return authors;
        }

        //TaskC  запит зі складним критерієм;
        public async Task<List<Author>> GetByTopicAndFirstCharsOfNameAsync(string topic, string frstCharsOfName)
        {
            var authors = await _db.Authors
                .Where(auth => auth.topic == topic && auth.name.StartsWith(frstCharsOfName))
                .ToListAsync();

            return authors;

        }

        //TaskD  запит з унікальними значеннями;
        public async Task<List<string>> GetDifferentValuesAsync()//string userSelector)
        {
            var distinctValues = await _db.Authors
                .Select(auth => auth.topic)
                .Distinct()
                .ToListAsync();

            return distinctValues;
        }

        //TaskE запит з використанням обчислювального поля;
        public async Task<string> GetAuthorByFirstNameInAlphabetAsync()
        {
            string authorName = await _db.Authors
                .Select(auth => auth.name)
                .MinAsync();

            return authorName;
        }

        //TaskF  запит з групуванням по заданому полю, використовуючи умову групування;
        public async Task<Dictionary<string, int>> GetNumOfAuthorsGropedByTopicAsync()
        {
            var keyValuePairs = await _db.Authors
                .GroupBy(auth => auth.topic)
                .Select(obj => new
                {
                    obj.Key,
                    numOfAuths = obj.Count()
                })
                .ToDictionaryAsync(x => x.Key, x => x.numOfAuths);
            
            return keyValuePairs;

        }

        //TaskG запит із сортування по заданому полю в порядку зростання та спадання значень;
        public async Task<List<Author>> GetAuthorsSortedByNameInAscOrDescOrderAsync(string order)
        {
            List<Author> authors;
            if (order == "ASC")
            {
                authors = await _db.Authors
                .OrderBy(auth => auth.name)
                .ToListAsync();
            }
            else
            {
                authors = await _db.Authors
                    .OrderByDescending(auth => auth.name)
                    .ToListAsync();
            }

            return authors;
        }

        //TaskH запит з використанням дій по модифікації записів.
        public async Task<bool> UpdateAuthorAsync(Author authorToChange)
        {
            Author author = await _db.Authors.FindAsync(authorToChange.Id);

            if(author != null)
            {
                author.name = authorToChange.name;
                author.topic= authorToChange.topic;
                author.title= authorToChange.title;

                _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

    }
}
