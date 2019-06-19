using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RuffusValidator
{
    public class Ruffus
    {
        public void Valid(object entity)
        {
            CoreValidator cv = new CoreValidator();
            ValidationDomain domain = cv.GetDomainByEntityType(entity.GetType());

            if(domain == null)
                return;

            PropertyInfo property = null;
            foreach (ValidationRule rule in domain.Rules)
            {
                property = entity.GetType().GetProperty(rule.Property);
                rule.SetEntity(entity);

                ValidationEngine engine = new ValidationEngine(rule, property);
                engine.RunValidation();
            }
        }
    }
}
