using Microsoft.EntityFrameworkCore;

namespace dotnet;

public class DatabaseCV :DbContext
{
    // constructor of the class
    public DatabaseCV(DbContextOptions<DatabaseCV> options) : base(options) { }
    // db set heye shu 3am fawet 3ala ldatabase ana fawatet class cv info 
    // bas a3mel migration ha ye5la2le database feyo linfos yalle be cv info
    public DbSet<CV_Info> CVS { get; set; }

   

}
