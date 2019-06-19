using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuffusValidator
{
    public class CoreValidator
    {
        private static List<ValidationDomain> Domains { get; set; }
        private static object locker = new object();

        internal ValidationDomain GetDomainByEntityType(Type type)
        {
            lock(locker)
            {
                return Domains.FirstOrDefault(d => d.EntityType.FullName.Equals(type.FullName) ||
                        type.Name.Contains(d.EntityType.Name));
            }
        }

        public void AddDomain(ValidationDomain domain)
        {
            lock (locker)
            {
                if (Domains == null)
                    Domains = new List<ValidationDomain>();

                Domains.Add(domain);
            }
        }
    }
}
