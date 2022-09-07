using AutoMapper;

using System.Text.Json;

using VisitorManagement.Data;
using VisitorManagement.Mock;
using VisitorManagement.Models;

namespace VisitorManagement.Services
{
    public class DataSeeder : IDataSeeder
    {
        //Used DI to inject in the database context
        private readonly ApplicationDbContext _context;
        // add mapper to map jsonVisitor
        private readonly IMapper _mapper;
        public DataSeeder(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        //https://medium.com/executeautomation/seeding-data-using-ef-core-in-asp-net-core-6-0-minimal-api-d5f6ecdb350c

        //a method that seeds data 
        public async Task SeedStaffAsync()
        {
            //if there are no fields in the StaffNames db
            if (!_context.StaffNames.Any())
            {
                var staff = new List<StaffNames>
                {
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dwain Henson",
                        Department ="Counselling",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Ciara Head",
                        Department ="Counselling",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dwain Henson",
                        Department ="Web Design",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Quentin Thwaite",
                        Department ="NZ Bat",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Madhav Benn",
                        Department ="Web Design",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Suniti Lockwood",
                        Department ="Early Childhood",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Susie Tyrrell",
                        Department ="Early Childhood",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jie Roy",
                        Department ="Web Design",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Shobha Carpenter",
                        Department ="Software",
                        VisitorCount = 2
                    },
                    new StaffNames()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Merletta Winton",
                        Department ="Ultimate",
                        VisitorCount = 2
                    }

                };

                _context.StaffNames.AddRange(staff);
                await _context.SaveChangesAsync();


            }




        }
        //IAsyncEnumerable<Visitor> 
        public async Task SeedVisitorsAsync()
        {
            //https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?pivots=dotnet-6-0

            if (!_context.Visitor.Any())
            { //get path to my visitorsMock json file 
                string fileName = "Mock/visitorsMock.json";
                //read the data from the json file
                using FileStream openStream = File.OpenRead(fileName);
                //make a list of JsonVisitor to hold the data
                var visitorList = new List<JsonVisitor>();

                // Instantiate random number generator 
                var rand = new Random();
                //count how many entries there are in the Staffnames 
                var StaffGuids = _context.StaffNames.Select(s => s.Id).ToList();

                await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<JsonVisitor>(openStream))
                {
                    //get a random number between 0 and the cout of staffnames
                    int randRow = rand.Next(0, StaffGuids.Count);
                    //get a random staffName.Id 
                    Guid id = StaffGuids[randRow];
                    //convert it to a string and pass it to the StaffnameId
                    item.StaffNameId = id.ToString();


                    //add the whole lot to the list.
                    visitorList.Add(item);
                }


                var visitorContext = _mapper.Map<IEnumerable<Visitor>>(visitorList);

                _context.Visitor.AddRange(visitorContext);
                await _context.SaveChangesAsync();
            }
        }


    }




}
//Next up, we need to call this DataSeeder class while the we need it, this can be done while the application starts or by specifying in the commandline via dotnet run command. Here is how we are going to do the same

//In the program.cs file, we are going to first add the following two lines

//var connectionString = builder.Configuration.GetConnectionString("AppDb");
//builder.Services.AddTransient<DataSeeder>();
//Making sure we call the DataSeeder as Transient in the service container.