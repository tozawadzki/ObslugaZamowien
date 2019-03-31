
using System.Collections.Generic;
using System.Collections;

namespace ObslugaZamowien.Class
{
    public interface ILoader
    {
        IEnumerable GetFile (string path);
    }
}
