using System;
using System.Collections.Generic;
using System.Text;

namespace Beata.Medrek.Core
{
    public class StaffCache : IApplicationCache<Staff>
    {
        private Staff _object;

        public Staff Object {
            set => _object = value;
            get => _object;
        }

        public void ClearCache()
        {
            Object = null;
        }

        public Staff GetObject() => Object;

        public void SetObject(Staff obj)
        {
            _object = obj;
        }
    }
}
