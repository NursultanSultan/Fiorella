using Fiorello.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiorello.Services
{
    public class LayoutServices
    {
        private AppDBContext _context { get; }
        public LayoutServices(AppDBContext context)
        {
            _context = context;
        }

        public Dictionary<string,string> GetSetting()
        {
            return _context.Setting.AsEnumerable().ToDictionary(s => s.Key, s => s.Value);
        }
    }
}
