using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Localization
{
    public interface ITranslationsKeyGenerator
    {
        string GenerateKey(IEnumerable<string> keyWords);
    }
}
