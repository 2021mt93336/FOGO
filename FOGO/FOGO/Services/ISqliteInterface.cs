using System;
using SQLite;
using System.Collections.Generic;
using System.Text;

namespace FOGO.Services
{
    public interface ISqliteInterface
    {
        SQLiteConnection GetConnection();
    }
}
