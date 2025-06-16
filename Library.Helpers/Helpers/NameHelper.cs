using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Helpers
{
    public static class NameHelper
    {
        public static string GetFullName(string name, string surname, string? patronymic) 
        {
            return string.Join(" ", new[] { name, surname, patronymic }
                .Where(s => !string.IsNullOrWhiteSpace(s)));
        }
    }
}
